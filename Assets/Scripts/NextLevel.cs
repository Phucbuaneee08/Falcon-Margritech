using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpScreen;
    public void OpenLevel(int levelId){
        string levelname = "Level"+levelId;
        SceneManager.LoadScene(levelname);
         popUpScreen.SetActive(false);
    }
    public void ReturnHome(){
        SceneManager.LoadScene("Menu");
         popUpScreen.SetActive(false);
    }
    public void PlayAgian(int levelId){
        popUpScreen.SetActive(false);
        SceneManager.LoadScene("Level"+levelId);
        
    }
}
