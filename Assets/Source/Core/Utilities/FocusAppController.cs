using UnityEngine;

namespace ElasticRush.Utilities
{
    public class FocusAppController : MonoBehaviour
    {
        private float _lastTimeScale = 1f;

        private void OnApplicationFocus(bool hasFocus)
        {
            Mute(!hasFocus);

            if (hasFocus)
            {
                Time.timeScale = _lastTimeScale;
            }
            else
            {
                _lastTimeScale = Time.timeScale;
                Time.timeScale = 0f;
            }
        }

        private void Mute(bool isMute)
        {
            if (AdObserver.IsAdPlaying)
                AudioListener.volume = 0f;
            else
                AudioListener.volume = isMute ? 0f : 1f;
        }
    }
}