using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{

    public void OpenDoor(){
        Debug.Log("kapıaçılanzi");
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("OpenDoor");

    }

    
}
