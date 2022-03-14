using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1.0f;
    
    private Rigidbody2D _rigidbody;
    private GameManager _gameManager;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        _rigidbody.AddRelativeForce((Vector3.up + Vector3.right) * speed);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            collision.gameObject.SetActive(false);
            _gameManager.AddScore();
            
            _audioSource.Play();
        } else if (collision.gameObject.CompareTag("BottomBound"))
        {
            Destroy(gameObject);
        }
    }
}