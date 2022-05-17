using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    FirstPersonMovement movement;
    public GameObject WaterEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.GetComponent<FirstPersonMovement>() != null)
        {
            movement = other.GetComponent<FirstPersonMovement>();
            movement.isSwimming = true;
            other.GetComponent<Jump>().enabled = false;
            other.GetComponent<Crouch>().enabled = false;
            WaterEffect.SetActive(true);
            Debug.Log("Trigger Enter");
        }
        if(other.CompareTag("EyeLevel"))
        {
            other.GetComponentInParent<Rigidbody>().useGravity = false;
            if(movement != null)
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
        WaterEffect.SetActive(false);
        Debug.Log("Trigger Exit");
    }
}
