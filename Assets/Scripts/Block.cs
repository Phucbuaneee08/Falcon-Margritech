using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    
    
    
    [SerializeField] public int health;
    private BoxCollider2D bc;
    private TextMeshPro text;
    private bool isMove;
    // Update is called once per frame
    private void Start()
    {
        isMove = false;
        text = gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        text.text = health + "";
    }
    private void OnCollisionEnter2D(Collision2D collison)
    {
        if (!collison.gameObject.CompareTag("Ball")) return;
        if (health > 0)
        {
            health--;
            text.text = health + "";
            GameManager.Instance.UpdateScores(1);
           
        }
        if (health == 0)
        {
            GameManager.Instance.UpdateBlockCount();
            Destroy(gameObject);
            
        }
    }
    public void Update()
    {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            // Nếu bóng ra khỏi màn hình, xóa bóng khỏi danh sách và hủy đối tượng bóng
            if (screenPosition.y < 0)
            {
                GameManager.Instance.GameOver();
                Time.timeScale = 0f;
                
            }
        }
    
   
    
}
