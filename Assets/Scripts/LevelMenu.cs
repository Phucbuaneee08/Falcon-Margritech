using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void OpenLevel(int levelId){
        string levelname = "Level"+levelId;
        SceneManager.LoadScene(levelname);
       
    }
}
