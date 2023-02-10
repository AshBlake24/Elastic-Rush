using UnityEngine;

namespace ElasticRush.Audio
{
    [System.Serializable]
    public class AudioPlayer
    {
        public AudioSource AudioSource;
        public AudioClip AudioClip;

        public void Play()
        {
            AudioSource?.PlayOneShot(AudioClip);
        }
    }
}
