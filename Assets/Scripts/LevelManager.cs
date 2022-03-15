using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        var level = Instantiate(Resources.Load<GameObject>("Prefabs/Level1"));
        
    }
}