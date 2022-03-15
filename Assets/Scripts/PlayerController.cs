using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    private Touch _touch;
    [SerializeField] private float touchMovementSensitivity = 0.01f;

    private void Update()
    {
#if UNITY_EDITOR
        KeyboardControl();
        TouchControl();
#elif UNITY_ANDROID
        TouchControl();
#endif
    }

    private void KeyboardControl()
    {
        var transformPosition = transform.position;
        KeepInBounds(transformPosition);

        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * (horizontalInput * speed * Time.deltaTime));
    }

    private void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                var position = transform.position;
                position = new Vector3(position.x + _touch.deltaPosition.x * touchMovementSensitivity,
                    position.y, position.z);

                position.x = Mathf.Clamp(position.x, -4.2f, 4.2f);

                transform.position = position;
            }
        }
    }

    private void KeepInBounds(Vector3 transformPosition)
    {
        transformPosition.x = Mathf.Clamp(transformPosition.x, -7.5f, 7.5f);
        transform.position = transformPosition;
    }
}