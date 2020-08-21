using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("[GAME MANAGER] - The GameManager is NULL.");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void DisplayName()
    {
        Debug.Log("Display Player Name");
    }

    public void AnotherTest()
    {
        Debug.Log("[AnotherTest] firing!");
    }

    public void AddCurrency(int currencyToAdd, string currencyType)       
    {
        Debug.Log("[GameManager] Add Currency Firing....");
        Player.Instance.AddCurrency(currencyToAdd, currencyType);
        UIManager.Instance.AddCurrency(currencyToAdd, currencyType);
    }


}
