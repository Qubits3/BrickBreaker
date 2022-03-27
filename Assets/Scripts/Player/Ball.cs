using Core;
using UnityEngine;

namespace Player
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;
        
        public void ApplyInitialForce()
        {
            if (GetComponent<Rigidbody2D>().velocity != Vector2.zero) return;

            gameObject.transform.parent = null;
            GetComponent<Rigidbody2D>().AddRelativeForce((Vector3.up + Vector3.right) * speed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<ISoundEffect>().PlaySound();
        
            StartCoroutine(collision.gameObject.GetComponent<ICollisionManager>().OnBallCollided(gameObject));
        }
    }
}