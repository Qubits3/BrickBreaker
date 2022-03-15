using UnityEngine;

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
        SpawnBall();
    }

    private void SpawnBall()
    {
        _ball = Instantiate(Resources.Load<GameObject>("Prefabs/Ball"));

        _ball!.transform.position = new Vector3(0, -4.06f);
        _ball!.transform.parent = transform;
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