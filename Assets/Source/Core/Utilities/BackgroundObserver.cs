using UnityEngine;
using Agava.WebUtility;
using ElasticRush.Audio;

namespace ElasticRush
{
    public class BackgroundObserver : MonoBehaviour
    {
        [SerializeField] private AudioGroupController _master;

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnBackgroundChange;
        }

        private void OnBackgroundChange(bool isInBackground)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            if (isInBackground)
                _master.Mute();
            else
                _master.Unmute();
#endif
        }
    }
}