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

        private BrickManager _brickManager;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            
            _brickManager = GameObject.Find("BrickManager").GetComponent<BrickManager>();

            _brickLevel = SetBrickLevel();
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }

        public IEnumerator OnBallCollided(GameObject collidedObject)
        {
            _brickLevel--;

            if (_brickLevel == 0)
            {
                _spriteRenderer.enabled = false;
                _boxCollider2D.enabled = false;

                yield return new WaitForSeconds(0.2f);

                GameManager.SharedInstance.AddScore();

                gameObject.SetActive(false);

                _brickManager.DecreaseBrickCount();
            }
            else
            {
                SetBrickSprite();
            }
        }

        private void SetBrickSprite()
        {
            GetComponent<SpriteRenderer>().sprite = sprites[_brickLevel - 1];

            GameManager.SharedInstance.AddScore();
        }

        protected abstract int SetBrickLevel();
    }
}