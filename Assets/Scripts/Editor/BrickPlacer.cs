using UnityEngine;

namespace Editor
{
    [ExecuteInEditMode]
    public class BrickPlacer : MonoBehaviour
    {
        [SerializeField, Range(-10, 10)] private int column;
        private const float BrickHeight = 0.605f;

        private void OnValidate()
        {
            UpdateBrickLocation();
        }

        private void UpdateBrickLocation()
        {
            var transformPosition = transform.position;
            transformPosition.y = BrickHeight * column;
            transform.position = transformPosition;
        }
    }
}