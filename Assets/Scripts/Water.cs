using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Water : MonoBehaviour
{
    FirstPersonMovement movement;
    public GameObject waterEffect;
    public AudioSource waterAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<FirstPersonMovement>() != null)
        {
            movement = other.GetComponent<FirstPersonMovement>();
            movement.isSwimming = true;
            other.GetComponent<Jump>().enabled = false;
            other.GetComponent<Crouch>().enabled = false;
            waterEffect.SetActive(true);
            waterAudio.Play();
            Debug.Log("Trigger Enter");
        }
        if (other.CompareTag("EyeLevel"))
        {
            other.GetComponentInParent<Rigidbody>().useGravity = false;
            if (movement != null)
            {
                movement.ResetVelocity();
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        movement = other.GetComponent<FirstPersonMovement>();
        movement.isSwimming = false;
        other.GetComponent<Jump>().enabled = true;
        other.GetComponent<Crouch>().enabled = true;
        movement.ResetVelocity();
        waterEffect.SetActive(false);
        waterAudio.Play();
        Debug.Log("Trigger Exit");
    }
}
