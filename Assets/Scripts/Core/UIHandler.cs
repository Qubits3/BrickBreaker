using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private TMP_Text _lifeText;
        private TMP_Text _levelText;
        [SerializeField] private GameObject pauseScreen;

        private void Awake()
        {
            _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            _lifeText = GameObject.Find("LifeText").GetComponent<TMP_Text>();
            _levelText = GameObject.Find("LevelText").GetComponent<TMP_Text>();

            _levelText.text = $"Level: {SceneManager.GetActiveScene().buildIndex}";
        }

        public void SetScoreText(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    
        public void SetLifeText(int life)
        {
            _lifeText.text = $"Life: {life}";
        }

        public void GoToMainMenu()
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().GoToMainMenu();
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }

        public void ResumeGame()
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}