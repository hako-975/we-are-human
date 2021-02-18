using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;

    public GameObject interactText;

    public bool haveQuest;

    [HideInInspector]
    public QuestGiver questGiver;

    QuestManager questManager;
    
    private bool onTriggerEnter = false;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        questGiver = GetComponent<QuestGiver>();
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTriggerEnter == true)
        {         
            if (haveQuest)
            {
                questManager.questGiver = questGiver;

                if (questManager.questGiver.questGoal.goalType == GoalType.Delivery)
                {
                    questManager.questGiver.questGoal.ask = true;
                }

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
