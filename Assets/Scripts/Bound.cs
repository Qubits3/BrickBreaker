using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bound : MonoBehaviour, ISoundEffect, ICollisionManager
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    public IEnumerator OnBallCollided(GameObject collidedObject)
    {
        if (gameObject.name.Equals("bottom"))
        {
            Destroy(collidedObject);

            GameManager.SharedInstance.DecreaseLife();
        }

        yield return null;
    }
}