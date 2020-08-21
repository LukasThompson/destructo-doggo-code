using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Purchasing;

public class Player : MonoSingleton<Player>
{
    public int points = 0;
    public int lives = 3;
    public int bones = 0;
    public int bacon = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
           GameManager.Instance.AddCurrency(5, "Bones");
        }

        if (Input.GetKeyDown("f"))
        {
            GameManager.Instance.AddCurrency(3, "Bacon");
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        UIManager.Instance.UpdateScore(pointsToAdd);
    }


    public void AddCurrency(int currencyToAdd, string currencyType)
    {
        if (currencyType == "Bones")
        {
            bones += currencyToAdd;
            Debug.Log("[Player] bones: " + bones);
        }
        else if (currencyType == "Bacon")
        {
            bacon += currencyToAdd;
            Debug.Log("[Player] bacon: " + bacon);
        }
    }

    public void UseCurrency(int currencyToUse, string currencyType)
    {
        if(currencyType == "Bones")
        {
            bones -= currencyToUse;
        }
        else if (currencyType == "Bacon")
        {
            bacon -= currencyToUse;
        }
    }

    public bool HasEnoughBones (int amount)
    {
        return (bones >= amount);
    }

    public bool HasEnoughBacon (int amount)
    {
        return (bacon >= amount);
    }
}
