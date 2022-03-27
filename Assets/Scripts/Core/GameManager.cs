using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager SharedInstance { get; private set; }

        private UIHandler _uiHandler;
        private LevelManager _levelManager;

        private int _score;
        private int _life = 3;

        private void Awake()
        {
            if (SharedInstance != null)
            {
                Destroy(gameObject);
                return;
            }

            SharedInstance = this;
        }

        private void Start()
        {
            _uiHandler = GameObject.Find("UIHandler").GetComponent<UIHandler>();
            _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }

        public void AddScore()
        {
            _score++;
            _uiHandler.SetScoreText(_score);
        }

        public void DecreaseLife()
        {
            _life--;

            _uiHandler.SetLifeText(_life);
        
            RespawnPlayer();

            if (_life == 0)
            {
                _levelManager.RestartLevel();
            }
        }

        private void RespawnPlayer()
        {
            Destroy(GameObject.FindWithTag("Player"));

            var newPlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            newPlayer.transform.position = new Vector3(0, -4.591f);
        }
    }
}