using UnityEngine;
using ElasticRush.Audio;
using ElasticRush.Utilities;

namespace ElasticRush
{
    public class AudioSettingsLoader : MonoBehaviour
    {
        [SerializeField] private AudioGroupController _soundGroup;
        [SerializeField] private AudioGroupController _musicGroup;

        private void Start()
        {
            SetSoundVolume();
            SetMusicVolume();
        }

        private void SetAudioVolume(AudioGroupController audioController, bool isMuted)
        {
            if (isMuted)
                audioController.Mute();
            else
                audioController.Unmute();
        }

        private void SetSoundVolume() => SetAudioVolume(_soundGroup, CheckSoundGroup());

        private void SetMusicVolume() => SetAudioVolume(_musicGroup, CheckMusicGroup());

        private bool CheckSoundGroup() => SaveSystem.Settings.LoadSound();

        private bool CheckMusicGroup() => SaveSystem.Settings.LoadMusic();
    }
}