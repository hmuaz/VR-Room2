using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sartel : MonoBehaviour
{
    public SartelRenk renk;
    public GameObject sartelObject;
    public bool IsSartelDown = false;
    public bool IsSartelUp = false;
    public bool IsSartelMiddle = false;


    void OnTriggerEnter(Collider other)
{
    // Diğer objenin tag'ine bakarak işlem yapabilirsiniz
    if (other.CompareTag("SartelAlt"))
    {
        IsSartelDown = true;
        IsSartelUp = false;
        IsSartelMiddle = false;
        
    }
    if (other.CompareTag("SartelUst"))
    {
        IsSartelDown = false;
        IsSartelUp = true;
        IsSartelMiddle = false;
        
    }
}

}
