using UnityEngine;

namespace ElasticRush
{
    public class Settings : MonoBehaviour
    {
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
    }
}