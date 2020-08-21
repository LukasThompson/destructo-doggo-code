using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("[SPAWN MANAGER] - The SpawnManager is NULL.");
                Debug.LogError("[SPAWN MANAGER] - Instantiating NEW SpawnManager.");
                GameObject go = new GameObject("SpawnManager");
                go.AddComponent<SpawnManager>();
                Debug.LogError("[SPAWN MANAGER] - Instantiation completed.");

            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void StartSpawning()
    {
        Debug.Log("Spawn Started.");
        Debug.Log("Notifying Game Manager.");
        GameManager.Instance.DisplayName();
    }
}
