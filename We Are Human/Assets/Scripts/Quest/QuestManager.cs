using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI objectNameQuestWindow;
    public TextMeshProUGUI description;

    public Image iconQuest;
    public GameObject currentQuest;
    public TextMeshProUGUI objectName;
    public Image currentIconQuest;
    public TextMeshProUGUI currentAmount;

    public GameObject questWindow;

    CinemachineFreeLook cam;

    [HideInInspector]
    public QuestGiver questGiver;


    private void Start()
    {
        cam = FindObjectOfType<CinemachineFreeLook>();
    }

    private void Update()
    {
        if (questGiver != null)
        {
            if (questGiver.questActive)
            {
                currentAmount.text = questGiver.questGoal.currentAmount.ToString();
                currentAmount.text += "x";
                currentIconQuest.sprite = questGiver.iconQuest.sprite;
                objectNameQuestWindow.text = questGiver.objectName;
            }
        }
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        title.text = questGiver.title;
        objectName.text = questGiver.objectName;
        description.text = questGiver.description;
        iconQuest.sprite = questGiver.iconQuest.sprite;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        questGiver.questActive = true;
        cam.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        currentQuest.SetActive(true);
    }

    public void Complete(GoalType goalType)
    {
        currentQuest.SetActive(false);

        questGiver.questActive = false;
        questGiver = null;

        if (goalType == GoalType.Gathering)
        {
            GameObject firstNpc = GameObject.FindGameObjectWithTag("firstNPC");
            firstNpc.gameObject.SetActive(false);

            GameObject secondNpc = GameObject.FindGameObjectWithTag("secondNPC");
            secondNpc.GetComponent<CapsuleCollider>().isTrigger = true;
            secondNpc.GetComponent<QuestGiver>().questActive = true;
            secondNpc.GetComponent<CapsuleCollider>().radius = 2f;
        }

        Debug.Log(goalType);

        if (goalType == GoalType.Delivery)
        {
            StartCoroutine(waitDisappear());
        }

        Debug.Log("Quest Complete");
    }

    IEnumerator waitDisappear()
    {
        yield return new WaitForSeconds(5);
        GameObject secondNpc = GameObject.FindGameObjectWithTag("secondNPC");
        GameObject WoodBlockObject = GameObject.FindGameObjectWithTag("WoodBlockObject");
        secondNpc.gameObject.SetActive(false);
        WoodBlockObject.gameObject.SetActive(false);
        GameObject bridge = GameObject.FindGameObjectWithTag("Bridge");
        bridge.transform.position = new Vector3(bridge.transform.position.x, -0.8f, bridge.transform.position.z);
    }
}
