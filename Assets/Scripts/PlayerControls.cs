using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // [SerializeField] InputAction movement; this var is require for new way of implementing input (same goes for OnEnable() & OnDisable() + NewMovementSystem method below)

    void Start()
    {
        
    }

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
        float verticalMove = Input.GetAxis("Vertical");
        Debug.Log(verticalMove);
        float horizontalMove = Input.GetAxis("Horizontal");
        Debug.Log(horizontalMove);
    }
}
