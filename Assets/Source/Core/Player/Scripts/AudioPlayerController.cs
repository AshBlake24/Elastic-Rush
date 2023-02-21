using ElasticRush.Audio;
using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush
{
    public class AudioPlayerController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private AudioPlayer _takeDamage;
        [SerializeField] private AudioPlayer _dying;

        private void OnEnable()
        {
            _player.Died += OnDied;
            _player.DamageReceived += OnDamageReceived;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
            _player.DamageReceived -= OnDamageReceived;
        }

        private void OnDied() => _dying.PlayClip();

        private void OnDamageReceived() => _takeDamage.PlayClip();
    }
}