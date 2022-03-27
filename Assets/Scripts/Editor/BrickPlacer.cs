using UnityEngine;

namespace Editor
{
    [ExecuteInEditMode]
    public class BrickPlacer : MonoBehaviour
    {
        [Range(-10, 10)]
        public int column;
        private const float BrickHeight = 0.605f; 

        private void OnValidate()
        {
            UpdateBrickLocation();
        }

        private void UpdateBrickLocation()
        {
            var transformPosition = transform.position;
            transformPosition.y = BrickHeight * (column - 1);
            transform.position = transformPosition;
        }
    }
}