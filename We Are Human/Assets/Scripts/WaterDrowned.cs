using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrowned : MonoBehaviour
{
    public PlayerMovement player;
    public PlayerDied die;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
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
