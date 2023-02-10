using ElasticRush.Audio;
using UnityEngine;

namespace ElasticRush.UI
{
    [RequireComponent(typeof(AudioGroupController))]
    public class AudioToggle : UnityEngine.UI.Extensions.Toggle
    {
        [SerializeField] private AudioGroupController _audioGroupController;

        protected override void OnEnable()
        {
            base.OnEnable();
            CheckVolume();
        }

        protected override void OnToggleClick(bool toggleState)
        {
            if (toggleState == false)
            {
                _audioGroupController.Mute();
                Disable();
            }
            else
            {
                _audioGroupController.Unmute();
                Enable();
            }
        }

        private void CheckVolume()
        {
            if (_audioGroupController.IsMuted)
                Disable();
            else
                Enable();
        }
    }
}