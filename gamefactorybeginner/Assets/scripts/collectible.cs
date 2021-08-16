using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectible : MonoBehaviour
{
    public void Collect()
    {
        FindObjectOfType<ScoreManager>().AddScore(5);
        Destroy(gameObject);
    }
}