using ElasticRush.Core;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _score;

        private void OnEnable()
        {
            _player.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            _player.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged()
        {
            _score.text = $"$: {_player.Score}";
        }
    }
}