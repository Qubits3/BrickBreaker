using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Brick : MonoBehaviour, ISoundEffect, ICollisionManager
{
    private AudioSource _audioSource;
    private GameManager _gameManager;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

    public void OnBallCollided(GameObject collidedObject)
    {
        _gameManager.AddScore();
        gameObject.SetActive(false);
    }
}
