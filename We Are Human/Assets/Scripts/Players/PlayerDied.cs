using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    public GameObject diePanel;
    public void Died()
    {
        diePanel.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
