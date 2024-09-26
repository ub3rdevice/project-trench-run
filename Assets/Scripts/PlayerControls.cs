using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 43f;
    [SerializeField] float xRange = 8.5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -25f;

    float xMove, yMove;

    // [SerializeField] InputAction movement; this var is require for new way of implementing input (same goes for OnEnable() & OnDisable() + NewMovementSystem method below)

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
        ProcessAxesMovement();
        ProcessRotation();
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

    // void NewMovementSystem()
    // {
    //     float horizontalMove = movement.ReadValue<Vector2>().x;
    //     Debug.Log(horizontalMove);
    //     float verticalMove = movement.ReadValue<Vector2>().y;
    //     Debug.Log(verticalMove);
    // }

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
}
