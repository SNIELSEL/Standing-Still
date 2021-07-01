using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    void Update()
    {
        Debug.Log("The Score Is " + score);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider is working");
        if (other.gameObject.tag == "scoreup")
        {
            score++;
        }
    }
}
