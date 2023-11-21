using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFolder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.name);
        other.GetComponent<FolderHover>().isPassibleOpenFolder(true);
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<FolderHover>().isPassibleOpenFolder(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name);
    }
}
