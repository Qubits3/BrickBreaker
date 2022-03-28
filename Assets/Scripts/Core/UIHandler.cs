using TMPro;
using UnityEngine;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private TMP_Text _lifeText;

        private void Start()
        {
            _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            _lifeText = GameObject.Find("LifeText").GetComponent<TMP_Text>();
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
    }
}