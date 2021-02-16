using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public GameObject dialogueBox;

    private Queue<string> sentences;

    CinemachineFreeLook cam;

    QuestManager questManager;

    PlayerMovement playerMovement;

    protected bool haveQuestDialogue;
    protected GoalType goalTypeQuestGiver;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        questManager = FindObjectOfType<QuestManager>();
        cam = FindObjectOfType<CinemachineFreeLook>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void StartDialogue(Dialogue dialogue, bool haveQuest, GoalType goalType)
    {
        if (haveQuest)
        {
            goalTypeQuestGiver = goalType;
            haveQuestDialogue = haveQuest;
        }

        dialogueBox.SetActive(true);

        cam.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();
    
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);

        StartCoroutine(DelayDeactive());

        if (haveQuestDialogue)
        {
            if (goalTypeQuestGiver != GoalType.Delivery)
            {
                questManager.OpenQuestWindow();
            }
            else
            {
                cam.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else
        {
            cam.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    IEnumerator DelayDeactive()
    {
        yield return new WaitForSeconds(1);
        dialogueBox.SetActive(false);
    }
}
