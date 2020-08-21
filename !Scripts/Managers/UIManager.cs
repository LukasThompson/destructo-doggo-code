using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    private int playerScore = 0;
    private int livesCount = 3;
    private int bonesCount = 0;
    private int baconCount = 0;

    public Text scoreText;
    public Text livesText;
    public Text bonesText;
    public Text baconText;

    // private variable to declae the instance of this class. -- has to be static
    private static UIManager _instance;
    public static UIManager Instance
    {
        // Never a set, never allow someone to change the INSTANCE of the class.
        get
        {
            if (_instance == null)
            {
                Debug.Log("[UIManager] UIManager is NULL.");
            }

            return _instance;
        }
    }

        private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        livesText.text = livesCount.ToString();
        scoreText.text = playerScore.ToString();
        bonesText.text = bonesCount.ToString();
        baconText.text = baconCount.ToString();
    }

    public void UpdateScore(int points)
    {
        Debug.Log("points: " + points);
        playerScore += points;
        Debug.Log("playerScore: " + playerScore);
        scoreText.text = playerScore.ToString();
    }

    public void AddCurrency(int currencyAmount, string currencyType)
    {
        Debug.Log("Adding " + currencyAmount + " to " + currencyType);
        if (currencyType == "Bones")
        {
            bonesCount += currencyAmount;
            Debug.Log("bonesCount: " + bonesCount);
            bonesText.text = bonesCount.ToString();
        }
        else if (currencyType == "Bacon")
        {
            baconCount += currencyAmount;
            Debug.Log("baconCount: " + baconCount);
            baconText.text = baconCount.ToString();
        }
    }

    public void SubtractCurrency(int currencyAmount, string currencyType)
    {
        Debug.Log("Adding " + currencyAmount + " to " + currencyType);
        if (currencyType == "Bones")
        {
            bonesCount -= currencyAmount;
            Debug.Log("bonesCount: " + bonesCount);
            bonesText.text = bonesCount.ToString();
        }
        else if (currencyType == "Bacon")
        {
            baconCount -= currencyAmount;
            Debug.Log("baconCount: " + baconCount);
            baconText.text = baconCount.ToString();
        }
    }
}

