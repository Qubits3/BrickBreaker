using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ApplyInitialForce()
    {
        if (_rigidbody.velocity != Vector2.zero) return;
        
        gameObject.transform.parent = null;
        _rigidbody.AddRelativeForce((Vector3.up + Vector3.right) * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<ISoundEffect>().PlaySound();

        collision.gameObject.GetComponent<ICollisionManager>().OnBallCollided(gameObject);
    }
}