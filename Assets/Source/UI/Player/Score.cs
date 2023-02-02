using ElasticRush.Core;
using ElasticRush.Utilities;
using TMPro;
using UnityEngine;

namespace ElasticRush.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _bestScore;

        private PlayerData _playerData;

        private void OnEnable()
        {
            UpdatePlayerData();

            _currentScore.text = _player.Score.ToString();
            _bestScore.text = $"Best: {_playerData.BestScore}";
        }

        private void UpdatePlayerData()
        {
            SaveSystem.Player.Save(_player);
            _playerData = SaveSystem.Player.Load();
        }
    }
}