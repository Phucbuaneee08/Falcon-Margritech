using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int scores;
    public bool gameOver;
    public int blockCount;
    
    public static GameManager Instance;
    public GameObject loseScreen;
    public GameObject winScreen;
    public TextMeshPro scoresText;

    private void Awake(){
      
       if(Instance == null){
        Instance =this;
       }
      
      
    }
    // public void UpdatePlays(int changeInPlays){
    //     plays += changeInPlays;
    //     Debug.Log(plays);
    //     if(plays == 0){
    //         GameOver();
    //     }
    // }
    public void UpdateScores(int changeInScores){
        scores += changeInScores;
        scoresText.text = scores + "";
    }
    public void UpdateBlockCount(){
        blockCount--;
        Debug.Log(blockCount);
        if(blockCount == 0){
            GameWin();
        }
    }
    void Start()
    {
        
    }
    public void GameOver(){
       
        loseScreen.SetActive(true);
    }
    public void GameWin(){
        winScreen.SetActive(true);
    }
    // Update is called once per frame
    
}
