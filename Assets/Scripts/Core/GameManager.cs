using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager SharedInstance { get; private set; }

        private UIHandler _uiHandler;
        private LevelManager _levelManager;

        private int _score;
        private int _life = 3;

        public int LastFinishedLevel { get; private set; }

        [Serializable]
        private class Data
        {
            public int lastFinishedLevel;
        }

        public void SaveData()
        {
            var data = new Data
            {
                lastFinishedLevel = SceneManager.GetActiveScene().buildIndex
            };

            var json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        private void LoadData()
        {
            var path = Application.persistentDataPath + "/savefile.json";

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var data = JsonUtility.FromJson<Data>(json);

                LastFinishedLevel = data.lastFinishedLevel;
            }
            else
            {
                LastFinishedLevel = 0;
            }
        }

        private void ResetData()
        {
            var data = new Data
            {
                lastFinishedLevel = 0
            };
            
            var json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        private void Awake()
        {
            SharedInstance = this;

            LoadData();
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
            Handheld.Vibrate();

            _life--;

            if (_life == 0)
            {
                _levelManager.RestartLevel();
            }

            _uiHandler.SetLifeText(_life);

            RespawnPlayer();
        }

        private void RespawnPlayer()
        {
            Destroy(GameObject.FindWithTag("Player"));

            var newPlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            newPlayer.transform.position = new Vector3(0, -4.591f);
        }

        public void StartNewGame()
        {
            ResetData();

            SceneManager.LoadScene(0);
        }
    }
}