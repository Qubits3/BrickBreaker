using System;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private GameObject _bundle;

    void Start()
    {
        _bundle = GameObject.FindWithTag("BrickBundle");
    }

    private void Update()
    {
        CheckBricks();
    }

    private void CheckBricks()
    {
        var brickCount = 0;
        foreach (Transform child in _bundle.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                brickCount++;
            }
        }
        
        print(brickCount);
    }

    
}
