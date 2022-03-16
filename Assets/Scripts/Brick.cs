using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Brick : MonoBehaviour, ISoundEffect, ICollisionManager
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
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.2f);

        GameManager.SharedInstance.AddScore();
        gameObject.SetActive(false);
    }
}