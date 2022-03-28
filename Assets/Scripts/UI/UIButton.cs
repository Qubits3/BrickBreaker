using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(AudioSource))]
    public class UIButton : MonoBehaviour
    {
        private Button _button;
        private AudioSource _audioSource;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
            
            _button.onClick.AddListener(PlaySound);
        }

        private void PlaySound()
        {
            _audioSource.Play();
        }
    }
}