using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    public GameObject interactText;

    public bool haveQuest;

    public QuestGiver questGiver;

    public QuestManager questManager;
    
    private bool onTriggerEnter = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTriggerEnter == true)
        {         
            if (haveQuest)
            {
                questManager.questGiver = questGiver;
                dialogueTrigger.TriggerDialogue(haveQuest, questGiver.questGoal.goalType);
            }
            else
            {
                dialogueTrigger.TriggerDialogue(false, questGiver.questGoal.goalType);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(true);
            onTriggerEnter = true;
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
