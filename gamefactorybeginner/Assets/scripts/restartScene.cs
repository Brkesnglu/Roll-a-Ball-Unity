using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartScene : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        bool hasCollidedWithEnemy = collision.collider.GetComponent<enemy>();
        if (!hasCollidedWithEnemy)
        {

            Application.LoadLevel(0);
        }
    }
}
