using UnityEngine;
using ElasticRush.Core;
using ElasticRush.Utilities;
using Lean.Localization;
using TMPro;
using UnityEngine.SceneManagement;
using System;

namespace ElasticRush.UI
{
    public class Score : MonoBehaviour
    {
        private const string ScoreLeanPhrase = "Score";
        private const string BestLeanPhrase = "Best";

        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _currentScoreFrame;
        [SerializeField] private TMP_Text _bestScoreFrame;

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
            string score = LeanLocalization.GetTranslationText(ScoreLeanPhrase);
            string best = LeanLocalization.GetTranslationText(BestLeanPhrase);

            _currentScoreFrame.text = $"{score}: {_player.Score}";
            _bestScoreFrame.text = $"{best}: {_bestStageScore}";
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