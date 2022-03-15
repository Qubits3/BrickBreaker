using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bound : MonoBehaviour, ISoundEffect, ICollisionManager
{
    private AudioSource _audioSource;
    private LevelManager _levelManager;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    public void OnBallCollided(GameObject collidedObject)
    {
        if (gameObject.name.Equals("bottom"))
        {
            Destroy(collidedObject);

            _levelManager.RestartLevel();
        }
    }
}