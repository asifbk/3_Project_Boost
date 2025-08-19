using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    float rcsThrust = 100f;
    Rigidbody rigidBody;
    AudioSource audioSource;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }
    private void  Thrust()
    {
        if (Input.GetKey(KeyCode.Space))  // can thrust
        {
            rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * 100f);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true;
        float rotationthisFrame = rcsThrust * Time.deltaTime;   //take manual control of rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationthisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationthisFrame);
        }
        rigidBody.freezeRotation = false; // unfreeze rotation so physics can take over
    }
}
