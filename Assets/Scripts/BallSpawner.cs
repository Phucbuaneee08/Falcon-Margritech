using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private RaycastHit2D ray; 
    [SerializeField] private LayerMask layermask;
    private float angle;
    [SerializeField] Vector2 minMaxAngle;
    public void FixedUpdate(){
        if(Input.GetMouseButton(0)){
        ray = Physics2D.Raycast(transform.position,transform.up,10f,layermask);
        Debug.DrawLine(transform.position,ray.point,Color.red,1f);

        Vector2 reflactPos = Vector2.Reflect(new Vector3(ray.point.x,ray.point.y) - transform.position,ray.normal);
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg - 90f;
        if(angle >= minMaxAngle.x && angle <=minMaxAngle.y){
            Debug.DrawLine(transform.position,transform.up*ray.distance*2f,Color.red);
            Debug.DrawLine(ray.point,reflactPos.normalized*2f,Color.green);
        }
        transform.rotation = Quaternion.AngleAxis(angle,transform.forward);
        }
    }
}
