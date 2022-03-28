using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class BrickManager : MonoBehaviour
    {
        private GameObject _bundle;
        private LevelManager _levelManager;
        [SerializeField] private int _brickCount;

        private void Awake()
        {
            _bundle = GameObject.FindWithTag("BrickBundle");
            _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                GetBrickCount();   
            }
        }

        private void CheckBrickCount()
        {
            if (_brickCount != 0) return;

            GameManager.SharedInstance.SaveData();

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