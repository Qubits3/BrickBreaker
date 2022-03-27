using UnityEngine;

namespace Core
{
    public class BrickManager : MonoBehaviour
    {
        private GameObject _bundle;
        private LevelManager _levelManager;
        private int _brickCount;

        private void Start()
        {
            _bundle = GameObject.FindWithTag("BrickBundle");
            _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

            GetBrickCount();
        }

        private void CheckBrickCount()
        {
            if (_brickCount != 0) return;

            _levelManager.LoadNextLevel();
        }

        public void DecreaseBrickCount()
        {
            _brickCount--;

            CheckBrickCount();
        }

        private void GetBrickCount()
        {
            foreach (Transform child in _bundle.transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    _brickCount++;
                }
            }
        }
    }
}