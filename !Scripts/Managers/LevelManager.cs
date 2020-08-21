using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public override void Init()
    {
        base.Init();

        Debug.Log("Level Manager Initialized!");
    }
}
