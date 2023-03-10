using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private PlayerSensitivitySettings _playerSensitivitySettings;

        private float _lastTimeScale = 1;

        private void OnEnable()
        {
            _lastTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = _lastTimeScale;
        }

        public void Init(PlayerController playerController)
        {
            _playerSensitivitySettings.Init(playerController);
        }
    }
}