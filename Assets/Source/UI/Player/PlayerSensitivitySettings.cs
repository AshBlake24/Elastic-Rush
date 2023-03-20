using ElasticRush.Core;
using ElasticRush.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ElasticRush.UI
{
    public class PlayerSensitivitySettings : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _currentValue;

        private Sensitivity _playerSensitivity;

        public void Init(Sensitivity playerSensitivity)
        {
            _playerSensitivity = playerSensitivity;
            _slider.minValue = _playerSensitivity.MinValue;
            _slider.maxValue = _playerSensitivity.MaxValue;
            _slider.value = _playerSensitivity.Value;
            _currentValue.text = string.Format("{0:0.00}", _playerSensitivity.Value);
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
            _playerSensitivity.TryChangeSensitivity(value);
            _currentValue.text = string.Format("{0:0.00}", _playerSensitivity.Value);
            SaveSystem.Settings.SaveSensitivity(_playerSensitivity.Value);
        }
    }
}
