using UnityEditor;
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
        _ball = PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>("Prefabs/Ball")) as GameObject;

        _ball!.transform.position = new Vector3(0, -4.06f);

        // ConstraintSource constraintSource = default;
        // if (ball != null)
        // {
        //     var parentConstraint = ball.AddComponent<ParentConstraint>();
        //     constraintSource.sourceTransform = transform;
        //     parentConstraint.AddSource(constraintSource);
        //     parentConstraint.constraintActive = true;
        //
        //     ball.transform.position = new Vector3(0, -4.39f, 0);
        // }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ball.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}