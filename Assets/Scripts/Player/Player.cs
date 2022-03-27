using Core;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class Player : MonoBehaviour, ISoundEffect
    {
        private GameObject _ball;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            GetBallReference();
        }

        private void GetBallReference()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name.Equals("Ball"))
                {
                    _ball = child.gameObject;
                }
            }
        }

        private void Update()
        {
            StartGame();
        }

        private void StartGame()
        {
            if (_ball.GetComponent<Rigidbody2D>().velocity != Vector2.zero) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _ball.GetComponent<Ball>().ApplyInitialForce();
            }
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }
    }
}