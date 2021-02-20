using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageAt : MonoBehaviour
{

    public Button startGame;
    public Button resumeGame;

    void Start()
    {

        int stageAt = PlayerPrefs.GetInt("stageAt");

        if (stageAt == 0)
        {
            startGame.gameObject.SetActive(true);
            resumeGame.gameObject.SetActive(false);
            startGame.onClick.AddListener(StageAtScene);
        } 
        else
        {
            startGame.gameObject.SetActive(false);
            resumeGame.gameObject.SetActive(true);
            resumeGame.onClick.AddListener(StageAtScene);
        }
    }

    void StageAtScene()
    {
        int stageAt = PlayerPrefs.GetInt("stageAt");
        if (stageAt == 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(stageAt);
        }
    }
        
}
