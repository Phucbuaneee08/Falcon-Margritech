using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    [SerializeField] public int health;
    private BoxCollider2D bc;
    private TextMeshPro text;
    // Update is called once per frame
    private void Start(){
        bc = gameObject.GetComponent<BoxCollider2D>();
        text = gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        text.text = health + "";
    }
    private void OnCollisionEnter2D(Collision2D collison){
        if(!collison.gameObject.CompareTag("Ball")) return;
        if(health > 0) {
            health--;
            text.text = health + "";
            Debug.Log(text.text);
            }
        
        if(health==0){
            Destroy(bc);
            Destroy(gameObject);
        }
    }
    private void SetHelth(){
    }
}
