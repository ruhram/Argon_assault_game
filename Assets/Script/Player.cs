using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 7f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 8f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        print("Player Collided Something");
    }
    void OnTriggerEnter(Collider other)
    {
        print("Player Trigerred Something");
    }
    // Update is called once per frame
    void Update()
    {
        ProcessingTranslation();
        ProcessingRotation();

    }

    void ProcessingRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessingTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYpos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
