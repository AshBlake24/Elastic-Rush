using ElasticRush.Utilities;
using UnityEngine;
using UnityEngine.Audio;

namespace ElasticRush.Audio
{
    public class AudioGroupController : MonoBehaviour
    {
        public const float MinVolume = -80f;
        public const float MaxVolume = 0f;

        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private string _exposedVolumeName;

        private bool _isMuted;

        public bool IsMuted => _isMuted;

        public void Mute()
        {
            _mixer.SetFloat(_exposedVolumeName, MinVolume);
            _isMuted = true;
        }

        public void Unmute()
        {
            _mixer.SetFloat(_exposedVolumeName, MaxVolume);
            _isMuted = false;
        }
    }
}
