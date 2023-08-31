using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private RaycastHit2D ray;
    public bool isStart;
    [SerializeField] private LayerMask layermask;
    private float angle;
    public static ArrayList activeBalls = new ArrayList();
    private LineRenderer lineRenderer;
    private Vector2 reflectionDirection;
    public int balls;
    [SerializeField] Vector2 minMaxAngle;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float force;
    [SerializeField] int ballCount;
    [SerializeField] float delay;
    
    public void Start(){
     
        lineRenderer = GetComponent<LineRenderer>();

        // Set LineRenderer properties
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        Color c1 = Color.white;
        Color c2 = new Color(85, 241, 224, 0);
       
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(c1, c2);
        reflectionDirection = Vector2.zero;
    }
    public void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Physics2D.Raycast(transform.position, transform.up, 100f, layermask);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, ray.point);

            Debug.DrawLine(transform.position, ray.point, Color.red, 2f);
            //Xác định tia phản xạ dựa trên tia tới và điểm va chạm
            Vector2 reflactPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;

            //tính toán góc tới và góc phản xạ
          
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            // Vẽ tia phản xạ   
            if (angle >= minMaxAngle.x && angle <= minMaxAngle.y)
            {
            
                Debug.DrawRay(ray.point, reflactPos.normalized * 6f, Color.green);
                lineRenderer.positionCount = 4;
                lineRenderer.SetPosition(2, ray.point);
                lineRenderer.SetPosition(3, ray.point + reflactPos.normalized * 6f);

            }
            transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
        }
    }

    public void Update()
    {
        
    
        if (Input.GetMouseButtonUp(0))
        {
            if (activeBalls.Count == 0){
                StartCoroutine(ShootBalls());
            }
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
    public IEnumerator ShootBalls()
    {
        isStart = true;
        for (int i = 0; i < ballCount; i++)
        {
            yield return new WaitForSeconds(delay);
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
            activeBalls.Add(ball);
        }
        // GameManager.Instance.UpdatePlays(-1);
        
    }

}
