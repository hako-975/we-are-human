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
    PlayerMovement playerMovement;


    [HideInInspector]
    public QuestGiver questGiver;


    private void Start()
    {
        cam = FindObjectOfType<CinemachineFreeLook>();
        playerMovement = FindObjectOfType<PlayerMovement>();
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
                objectName.text = questGiver.objectName.ToString();
                currentQuest.SetActive(true);
                questGiver.questActive = true;
            }

            if (GameObject.FindGameObjectWithTag("thirdNPC").GetComponent<QuestGiver>().questActive)
            {
                GameObject thirdNpc = GameObject.FindGameObjectWithTag("thirdNPC");
                thirdNpc.GetComponent<Animator>().SetBool("isIdle", true);

                GameObject fourthNpc = GameObject.FindGameObjectWithTag("fourthNPC");
                fourthNpc.GetComponent<CapsuleCollider>().isTrigger = true;
                fourthNpc.GetComponent<QuestGiver>().questActive = true;
                fourthNpc.GetComponent<CapsuleCollider>().radius = 2f;
                fourthNpc.GetComponent<QuestGiver>().questActive = true;
            }
        }
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        title.text = questGiver.title;
        objectNameQuestWindow.text = questGiver.objectName;
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
        playerMovement.GetComponent<CharacterController>().enabled = true;
    }

    public void Complete(GoalType goalType)
    {
        currentQuest.SetActive(false);

        questGiver.questActive = false;
        questGiver = null;

        if (goalType == GoalType.Gathering)
        {
            if (GameObject.FindGameObjectWithTag("firstNPC") == true)
            {
                GameObject firstNpc = GameObject.FindGameObjectWithTag("firstNPC");
                firstNpc.gameObject.SetActive(false);

                GameObject secondNpc = GameObject.FindGameObjectWithTag("secondNPC");
                secondNpc.GetComponent<CapsuleCollider>().isTrigger = true;
                secondNpc.GetComponent<QuestGiver>().questActive = true;
                secondNpc.GetComponent<CapsuleCollider>().radius = 2f;
                secondNpc.GetComponent<QuestGiver>().questActive = true;
            }

        }

        if (goalType == GoalType.Delivery)
        {
            StartCoroutine(WaitDisappear());
        }
    }

    private IEnumerator WaitDisappear()
    {
        yield return new WaitForSeconds(3);
        
        if (GameObject.FindGameObjectWithTag("secondNPC") == true)
        {
            GameObject secondNpc = GameObject.FindGameObjectWithTag("secondNPC");
            GameObject WoodBlockObject = GameObject.FindGameObjectWithTag("WoodBlockObject");
            secondNpc.gameObject.SetActive(false);
            WoodBlockObject.gameObject.SetActive(false);
            GameObject bridge = GameObject.FindGameObjectWithTag("Bridge");
            bridge.transform.position = new Vector3(bridge.transform.position.x, -0.8f, bridge.transform.position.z);
        }
        else if (GameObject.FindGameObjectWithTag("fourthNPC") == true)
        {
            GameObject pickaxe = GameObject.FindGameObjectWithTag("pickaxe");
            pickaxe.gameObject.SetActive(false);
            
            GameObject fourthNpc = GameObject.FindGameObjectWithTag("fourthNPC");
            fourthNpc.gameObject.SetActive(false);

            GameObject fourthNpc_2 = GameObject.FindGameObjectWithTag("fourthNPC_2");
            fourthNpc_2.GetComponent<CapsuleCollider>().isTrigger = false;

            GameObject thirdNpc = GameObject.FindGameObjectWithTag("thirdNPC");
            thirdNpc.gameObject.SetActive(false);

            GameObject thirdNpc_2 = GameObject.FindGameObjectWithTag("thirdNPC_2");
            thirdNpc_2.GetComponent<CapsuleCollider>().isTrigger = true;
            thirdNpc_2.GetComponent<QuestGiver>().questActive = true;
            thirdNpc_2.GetComponent<CapsuleCollider>().radius = 2f;
            thirdNpc_2.GetComponent<QuestGiver>().questActive = true;
        }
        else if (GameObject.FindGameObjectWithTag("thirdNPC_2") == true)
        {
            GameObject stone = GameObject.FindGameObjectWithTag("stone");
            stone.transform.position = new Vector3(stone.transform.position.x, -100f, stone.transform.position.z);
            GameObject.FindGameObjectWithTag("thirdNPC_2").gameObject.SetActive(false);
        }


    }
}
