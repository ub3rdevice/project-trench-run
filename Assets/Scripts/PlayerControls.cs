using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("General movement settings")]
    [Tooltip("playerShip speed")][SerializeField] float controlSpeed = 43f;
    [Tooltip("how far playerShip could move on x axis")][SerializeField] float xRange = 15f;
    [Tooltip("how far playerShip could move on y axis")][SerializeField] float yRange = 10f;
    [Header("Weapons settings")]
    [Tooltip("Selection of weaponry")][SerializeField] GameObject[] lasers;
     [Header("Additional movement settings")]
    [Tooltip("Offsets playerShips pitch")][SerializeField] float positionPitchFactor = -2f;
    [Tooltip("Offsets playerShips yaw")][SerializeField] float positionYawFactor = 2f;
    [Tooltip("Adds aditional pitch due to player input")][SerializeField] float controlPitchFactor = -15f;
    [Tooltip("Adds aditional roll due to player input")][SerializeField] float controlRollFactor = -25f;

    float xMove, yMove;

    // [SerializeField] InputAction movement; this var is required for new way of implementing input (same goes for OnEnable() & OnDisable() + NewMovementSystem method below)
    // [SerializeField] InputAction fire;

    // void OnEnable() 
    // {
    //     movement.Enable();    
    // }

    // void OnDisable() 
    // {
    //     movement.Disable();
    // }

    void Update()
    {
        // NewMovementSystem();
        // ProcessShootingInNewInputSystem()
        ProcessAxesMovement();
        ProcessRotation();
        ProcessShooting();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToPlayerInput = yMove * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToPlayerInput;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xMove * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessAxesMovement() // old way of implementing input
    {
        yMove = Input.GetAxis("Vertical");
        xMove = Input.GetAxis("Horizontal");

        float xOffset = xMove * Time.deltaTime * controlSpeed;
        float unlimitedXpos = transform.localPosition.x + xOffset;

        float yOffset = yMove * Time.deltaTime * controlSpeed;
        float unlimitedYpos = transform.localPosition.y + yOffset;

        float limitedXpos = Mathf.Clamp(unlimitedXpos, -xRange, xRange);
        float limitedYpos = Mathf.Clamp(unlimitedYpos, -yRange, yRange);

        transform.localPosition = new Vector3 (limitedXpos, limitedYpos, transform.localPosition.z);

    }

    void ProcessShooting()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLasersEnable(true);
        }
        else
        {
            SetLasersEnable(false);
        }
    }

    void SetLasersEnable(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }
    }

    // void NewMovementSystem()
    // {
    //     float horizontalMove = movement.ReadValue<Vector2>().x;
    //     Debug.Log(horizontalMove);
    //     float verticalMove = movement.ReadValue<Vector2>().y;
    //     Debug.Log(verticalMove);
    // }

    // void ProcessShootingInNewInputSystem()
    // {
    //     if(fire.ReadValue<float>() > 0.5)
    //     {
    //         Debug.Log("I'm shooting");
    //     }
    // }

}
