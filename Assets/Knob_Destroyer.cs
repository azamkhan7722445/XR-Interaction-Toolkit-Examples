using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob_Destroyer : MonoBehaviour
{
    // Reference to the Knob GameObject
    public Transform Knob;

    // Public reference to the Water GameObject
    public GameObject Water;

    public void Update123()
    {

        // Check if the Knob's Z rotation is -90 degrees
        if (Knob.transform.localEulerAngles.y >= 60 )
        {
           
                
                Water.gameObject.SetActive(false);
                Debug.Log("Knob GameObject destroyed!");
           
        }
        
      
    }

    // Helper method to normalize angles to the range [-180, 180]
    
}
