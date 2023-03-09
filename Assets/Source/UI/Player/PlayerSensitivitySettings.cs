using ElasticRush.Core;
using ElasticRush.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ElasticRush.UI
{
    public class PlayerSensitivitySettings : MonoBehaviour
    {
        [SerializeField] private PlayerController _controller;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _currentValue;

        private void Start()
        {
            _slider.value = _controller.Sensitivity.Value;

            _currentValue.text = string.Format("{0:0.00}", _controller.Sensitivity.Value);
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener((value) => OnValueChanged(value));
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener((value) => OnValueChanged(value));
        }

        private void OnValueChanged(float value)
        {
            _controller.Sensitivity.TryChangeSensitivity(value);
            _currentValue.text = string.Format("{0:0.00}", _controller.Sensitivity.Value);
            SaveSystem.Settings.SaveSensitivity(_controller.Sensitivity.Value);
        }
    }
}
