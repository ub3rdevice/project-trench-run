using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 43f;
    [SerializeField] float xRange = 8.5f;
    [SerializeField] float yRange = 5f;
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
        Movement();
    }

    // void NewMovementSystem()
    // {
    //     float horizontalMove = movement.ReadValue<Vector2>().x;
    //     Debug.Log(horizontalMove);
    //     float verticalMove = movement.ReadValue<Vector2>().y;
    //     Debug.Log(verticalMove);
    // }

    void Movement() // old way of implementing input
    {
        float yMove = Input.GetAxis("Vertical");
        float xMove = Input.GetAxis("Horizontal");

        float xOffset = xMove * Time.deltaTime * controlSpeed;
        float unlimitedXpos = transform.localPosition.x + xOffset;

        float yOffset = yMove * Time.deltaTime * controlSpeed;
        float unlimitedYpos = transform.localPosition.y + yOffset;

        float limitedXpos = Mathf.Clamp(unlimitedXpos, -xRange, xRange);
        float limitedYpos = Mathf.Clamp(unlimitedYpos, -yRange, yRange);

        transform.localPosition = new Vector3 (limitedXpos, limitedYpos, transform.localPosition.z);

    }
}
