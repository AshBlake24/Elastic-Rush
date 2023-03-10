using ElasticRush.Core;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class LevelScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;

        private Player _player;

        private void OnEnable()
        {
            if (_player != null)
                _player.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            if (_player != null)
                _player.ScoreChanged -= OnScoreChanged;
        }

        public void Init(Player player)
        {
            _player = player;
            _player.ScoreChanged += OnScoreChanged;
            OnScoreChanged();
        }

        private void OnScoreChanged()
        {
            _score.text = _player.Score.ToString();
        }
    }
}