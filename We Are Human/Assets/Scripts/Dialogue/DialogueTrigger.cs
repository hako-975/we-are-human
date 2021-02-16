using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(bool haveQuest, GoalType goalType)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, haveQuest, goalType);
    }
}
