using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public Button[] stageButtons;

    // Start is called before the first frame update
    void Start()
    {
        int stageAt = PlayerPrefs.GetInt("stageAt", 2);

        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (i + 2 > stageAt)
            {
                stageButtons[i].interactable = false;
            }
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }
}
