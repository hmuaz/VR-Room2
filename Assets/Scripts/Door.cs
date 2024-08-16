using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{

    public void OpenDoor(){
        GetComponent<Animator>().enabled = true;
    }

    
}
