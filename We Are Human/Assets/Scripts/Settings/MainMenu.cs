using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void MainMenuGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ChangeLevelGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Quit Game!");
    }

}
