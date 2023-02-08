using ElasticRush.Core;
using ElasticRush.Utilities;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _currentScoreFrame;
        [SerializeField] private TMP_Text _bestScoreFrame;

        private int _bestScore;

        private void OnEnable()
        {
            UpdateBestScore();

            _currentScoreFrame.text = _player.Score.ToString();
            _bestScoreFrame.text = $"Best: {_bestScore}";
        }

        private void UpdateBestScore()
        {
            SaveSystem.PlayerScore.Save(_player);
            _bestScore = SaveSystem.PlayerScore.Load();
        }
    }
}