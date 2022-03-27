using System.Collections;
using Core;
using Editor;
using UnityEngine;

namespace Brick
{
    [RequireComponent(typeof(AudioSource), typeof(BrickPlacer))]
    public abstract class BrickBase : MonoBehaviour, ISoundEffect, ICollisionManager
    {
        [SerializeField] private Sprite[] sprites;
        
        private int _brickLevel;
        private AudioSource _audioSource;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            
            _brickLevel = SetBrickLevel();
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }

        public IEnumerator OnBallCollided(GameObject collidedObject)
        {
            _brickLevel--;

            if (_brickLevel <= 0)
            {
                _spriteRenderer.enabled = false;
                _boxCollider2D.enabled = false;

                yield return new WaitForSeconds(0.2f);

                GameManager.SharedInstance.AddScore();
                gameObject.SetActive(false);
            } else if (_brickLevel == 1)
            {
                SetBrickSprite();
                GameManager.SharedInstance.AddScore();
            } else if (_brickLevel == 2)
            {
                SetBrickSprite();
                GameManager.SharedInstance.AddScore();
            }
        }

        private void SetBrickSprite()
        {
            GetComponent<SpriteRenderer>().sprite = sprites[_brickLevel - 1];
        }

        protected abstract int SetBrickLevel();
    }
}