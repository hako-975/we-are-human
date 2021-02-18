using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    new AudioSource audio;
    Rigidbody rb;
    PlayerMovement Character;
    // Start is called before the first frame update
    void Start()
    {
        Character = GetComponent<PlayerMovement>();
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.isGrounded == true && rb.velocity.magnitude > 2f && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.3f, 0.5f);
            audio.pitch = Random.Range(1f, 1.2f);
            audio.Play();
        }
    }
}
