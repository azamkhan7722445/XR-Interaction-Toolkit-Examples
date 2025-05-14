using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// crete a script where i can add game objects and intract with this game object its destoyred the game object parmently



public class TowelInteraction : MonoBehaviour
{
    public float destroyDelay = 3f; // Time delay before destroying towel


    

    void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.name =="water") // Check if towel touches water
        {
            Debug.Log("Towel dropped onto water. It will be destroyed soon...");
            Destroy(other.gameObject, destroyDelay); // Destroy the towel after a delay
        }
    }
}