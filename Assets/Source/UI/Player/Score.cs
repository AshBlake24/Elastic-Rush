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
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _bestScore;

        private int _bestStageScore;

        private void OnEnable()
        {
            _player.ScoreChanged += OnPlayerScoreChanged;

            OnPlayerScoreChanged();
        }

        private void OnDisable()
        {
            _player.ScoreChanged -= OnPlayerScoreChanged;
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