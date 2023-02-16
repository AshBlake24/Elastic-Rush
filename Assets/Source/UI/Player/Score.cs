using UnityEngine;
using ElasticRush.Core;
using ElasticRush.Utilities;
using Lean.Localization;
using TMPro;

namespace ElasticRush.UI
{
    public class Score : MonoBehaviour
    {
        private const string ScoreLeanPhrase = "Score";
        private const string BestLeanPhrase = "Best";

        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _currentScoreFrame;
        [SerializeField] private TMP_Text _bestScoreFrame;

        private int _bestScore;

        private void OnEnable()
        {
            UpdateBestScore();

            string score = LeanLocalization.GetTranslationText(ScoreLeanPhrase);
            string best = LeanLocalization.GetTranslationText(BestLeanPhrase);

            _currentScoreFrame.text = $"{score}: {_player.Score}";
            _bestScoreFrame.text = $"{best}: {_bestScore}";
        }

        private void UpdateBestScore()
        {
            SaveSystem.PlayerScore.Save(_player);
            _bestScore = SaveSystem.PlayerScore.Load();
        }
    }
}