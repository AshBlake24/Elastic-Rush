using UnityEngine;

namespace ElasticRush.Utilities
{
    public class FocusAppController : MonoBehaviour
    {
        private void OnApplicationFocus(bool hasFocus)
        {
            Mute(!hasFocus);
        }

        private void Mute(bool isMute)
        {
            AudioListener.volume = isMute ? 0f : 1f;
        }
    }
}