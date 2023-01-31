using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush
{
    public class PlayerFollower : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Vector3 _offset;

        private void OnEnable()
        {
            _player.Died += OnPlayerDied;
        }

        private void Start()
        {
            _offset = transform.position - _player.transform.position;
        }

        private void Update()
        {
            transform.position = _player.transform.position + _offset;
        }

        private void OnDisable()
        {
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            Destroy(gameObject);
        }
    }
}