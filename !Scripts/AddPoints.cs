using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public int pointValue = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddScore(pointValue);
        }
    }

    private void AddScore(int pointValue)
    {
        Debug.Log("Point value: " + pointValue);
        Player.Instance.AddPoints(pointValue);
    }
}
