using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic SharedInstance { get; private set; }

    private void Awake()
    {
        if (SharedInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        SharedInstance = this;
        DontDestroyOnLoad(gameObject);
    }
}
