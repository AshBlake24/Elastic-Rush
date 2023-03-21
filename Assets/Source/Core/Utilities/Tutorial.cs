using System.Collections;
using UnityEngine;
using ElasticRush.Utilities;
using TMPro;
using Agava.YandexGames;

namespace ElasticRush.Core
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Animator _touchAnimation;
        [SerializeField] private Animator _keyboardhAnimation;
        [SerializeField] private float _animationDuration;

        private Animator _currentAnmimation;

        private void Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (Device.Type == Agava.YandexGames.DeviceType.Desktop)
                _currentAnmimation = _keyboardhAnimation;
            else
                _currentAnmimation = _touchAnimation;
#else
            _currentAnmimation = _keyboardhAnimation;
#endif
            TurnOn();
        }

        public void TurnOn()
        {
            _text.gameObject.SetActive(true);
            _currentAnmimation.gameObject.SetActive(true);
        }

        public void TurnOff()
        {
            _text.gameObject.SetActive(false);
            StartCoroutine(DisableAnimationAfterDelay());
        }

        private IEnumerator DisableAnimationAfterDelay()
        {
            yield return Helpers.GetTime(_animationDuration);

            _currentAnmimation.gameObject.SetActive(false);
        }
    }
}