using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        Debug.Log(this.name +"-collided with-" + other.gameObject.name); //there is no point from c# perspective to put "this.name" instead of just "name", since engine will address to the object with this script attached as THIS and every other object as OTHER. 
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log($"{name} *triggered by* {other.gameObject.name}"); //another way of string interpolation in C#
    }
}
