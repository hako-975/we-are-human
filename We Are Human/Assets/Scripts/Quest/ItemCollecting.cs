using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecting : MonoBehaviour
{
    private bool onTriggerEnter = false;
    QuestManager questManager;
    public GameObject interactText;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTriggerEnter == true)
        {
            interactText.SetActive(false);
            this.gameObject.SetActive(false);
            questManager.questGiver.questGoal.ItemCollected();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (questManager.questGiver.questActive == true)
        {
            if (other.CompareTag("Player"))
            {
                interactText.SetActive(true);
                onTriggerEnter = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            onTriggerEnter = false;
        }
    }
}
