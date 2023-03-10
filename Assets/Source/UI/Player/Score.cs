using UnityEngine;
using UnityEngine.SceneManagement;
using ElasticRush.Core;
using ElasticRush.Utilities;
using Lean.Localization;
using TMPro;

namespace ElasticRush.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _bestScore;

        private Player _player;
        private int _bestStageScore;

        private void OnEnable()
        {
            if (_player != null)
            {
                _player.ScoreChanged += OnPlayerScoreChanged;
                OnPlayerScoreChanged();
            }
        }

        private void OnDisable()
        {
            if (_player != null)
                _player.ScoreChanged -= OnPlayerScoreChanged;
        }

        public void Init(Player player)
        {
            _player = player;
            _player.ScoreChanged += OnPlayerScoreChanged;
            OnPlayerScoreChanged();
        }

        private void ShowScore()
        {
            _currentScore.text = _player.Score.ToString();
            _bestScore.text = _bestStageScore.ToString();
        }

        private void UpdateBestScore()
        {
            string stage = SceneManager.GetActiveScene().name;
            SaveSystem.StageScore.Save(_player, stage);
            _bestStageScore = SaveSystem.StageScore.Load(stage);
        }

        private void OnPlayerScoreChanged()
        {
            UpdateBestScore();
            ShowScore();
        }
    }
}