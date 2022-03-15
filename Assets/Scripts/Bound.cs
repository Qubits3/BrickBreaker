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

    public void OnBallCollided(GameObject collidedObject)
    {
        if (gameObject.name.Equals("bottom"))
        {
            Destroy(collidedObject);
        }
    }
}