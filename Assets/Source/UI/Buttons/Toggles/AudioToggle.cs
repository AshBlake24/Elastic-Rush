using ElasticRush.Audio;
using ElasticRush.Utilities;
using UnityEngine;

namespace ElasticRush.UI
{
    [RequireComponent(typeof(AudioGroupController))]
    public abstract class AudioToggle : UnityEngine.UI.Extensions.Toggle
    {
        [SerializeField] private AudioGroupController _audioGroupController;

        protected bool IsMuted;

        protected override void OnEnable()
        {
            base.OnEnable();
            CheckVolume();
            SetToggleState();
        }
        protected abstract void CheckVolume();

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

        private void SetToggleState()
        {
            if (IsMuted)
                Disable();
            else
                Enable();
        }
    }
}