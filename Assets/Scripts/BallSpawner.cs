using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private RaycastHit2D ray;
    private RaycastHit2D previousRay; // Biến tạm lưu trữ ray cũ
    [SerializeField] private LayerMask layermask;
    private float angle;
    private ArrayList activeBalls = new ArrayList();
    [SerializeField] Vector2 minMaxAngle;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float force;
    [SerializeField] int ballCount;
    [SerializeField] float delay;
    public void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
           
            if (previousRay.collider != null)
            {
                Debug.DrawLine(transform.position, previousRay.point, Color.clear); 
            }

            ray = Physics2D.Raycast(transform.position, transform.up, 100f, layermask);
            previousRay = ray; 
            Debug.DrawLine(transform.position, ray.point, Color.red, 2f);
            //Xác định tia phản xạ dựa trên tia tới và điểm va chạm
            Vector2 reflactPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            
            //tính toán góc tới và góc phản xạ
            Debug.Log(ray.point);
            Debug.Log(reflactPos.normalized);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            // Vẽ tia phản xạ 
            if (angle >= minMaxAngle.x && angle <= minMaxAngle.y)
            {
                Debug.DrawRay(ray.point, reflactPos.normalized * 10f, Color.green);
            }
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
        }
    }
    
    public void Update(){
        if(Input.GetMouseButtonUp(0)){
            if(activeBalls.Count==0)
            StartCoroutine(ShootBalls());
        }
        for (int i = activeBalls.Count - 1; i >= 0; i--)
        {
            GameObject ball = (GameObject)activeBalls[i];
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(ball.transform.position);
            // Nếu bóng ra khỏi màn hình, xóa bóng khỏi danh sách và hủy đối tượng bóng
            if (screenPosition.y < 0)
            {
                activeBalls.RemoveAt(i);
                Destroy(ball);
            }
        }
    }
    public IEnumerator ShootBalls(){
        for(int i = 0 ; i<ballCount ; i++){
            yield return new WaitForSeconds(delay);
            GameObject ball = Instantiate(ballPrefab,transform.position,Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up*force);
            activeBalls.Add(ball); 
        }
    }
    
}
