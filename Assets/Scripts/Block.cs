using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int health;
    private BoxCollider2D bc;
    // Update is called once per frame
    private void Start(){
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collison){
        if(!collison.gameObject.CompareTag("Ball")) return;
        if(health > 0) health--;
        
        if(health==0){
            Destroy(bc);
            Destroy(gameObject);
        }
    }
    private void SetHelth(){
    }
}
