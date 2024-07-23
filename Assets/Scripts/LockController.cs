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
            Debug.Log("okey?");

        if (other.gameObject.CompareTag("key"))
        {
            // Sandığı aktif hale getir
            chestAttach.SetActive(true);
            chestAttachRb.isKinematic = false;

            // Anahtarı yok et
            Destroy(other.gameObject);
            // Kilit objesini görünmez yap
            gameObject.SetActive(false);
        }
    }
}
