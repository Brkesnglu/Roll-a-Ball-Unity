using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ballcontroller>() != null)
        {
            FindObjectOfType<LevelManager>().NextLevel();
        }
    }
}
