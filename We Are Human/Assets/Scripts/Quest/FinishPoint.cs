using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [HideInInspector]
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextSceneLoad > PlayerPrefs.GetInt("stageAt"))
            {
                PlayerPrefs.SetInt("stageAt", nextSceneLoad);
            }

            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}
