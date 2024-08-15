using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public GameObject chestAttach;
    public Rigidbody chestAttachRb;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("key"))
        {
            chestAttach.SetActive(true);
            chestAttachRb.isKinematic = false;

            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
