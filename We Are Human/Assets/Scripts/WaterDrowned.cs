using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrowned : MonoBehaviour
{
    public PlayerMovement player;
    public PlayerDied die;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.GetComponent<CharacterController>().enabled = false;
            playerMovement.transform.position = new Vector3(transform.position.x, -3.25f, transform.position.z);
            player.animator.SetBool("isDrowned", true);
            die.Died();
        }
        else
        {
            // Animation Drowned
            player.animator.SetBool("isDrowned", false);
        }
    }

}
