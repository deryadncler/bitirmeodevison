using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public AudioSource AudioSource;

    public CharacterController controller;

    public float footsteptreshold;
    public float footstepRate;
    private float lastFootStepTime;

    private void FixedUpdate()
    {
        if (controller.velocity.magnitude > footsteptreshold)
        {
            if (Time.time - lastFootStepTime > footstepRate)
            {
                lastFootStepTime = Time.time;

                AudioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
            }
        }
    }
}
