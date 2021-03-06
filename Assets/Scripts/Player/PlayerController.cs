using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 20.0f;
        private Touch _touch;
        private const float Bound = 7.5f;

        private const float TouchMovementSensitivity = 0.025f;

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
            KeepThePlayerInBounds(transformPosition);

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
                    position = new Vector3(position.x + _touch.deltaPosition.x * TouchMovementSensitivity,
                        position.y, position.z);

                    position.x = Mathf.Clamp(position.x, -Bound, Bound);

                    transform.position = position;
                }
            }
        }

        private void KeepThePlayerInBounds(Vector3 transformPosition)
        {
            transformPosition.x = Mathf.Clamp(transformPosition.x, -Bound, Bound);
            transform.position = transformPosition;
        }
    }
}