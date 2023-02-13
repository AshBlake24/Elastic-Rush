using UnityEngine;

namespace ElasticRush.Audio
{
    [System.Serializable]
    public class AudioPlayer
    {
        public AudioSource AudioSource;
        public AudioClip AudioClip;

        public void PlayClip()
        {
            AudioSource?.PlayOneShot(AudioClip);
        }
    }
}
