using ElasticRush;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ElasticRush
{
    public class LeaderboardEntryView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _score;

        public void SetData(LeaderboardEntry entry)
        {
            if (entry == null)
                return;

            _rank.text = entry.Rank;
            _playerName.text = entry.PlayerName;
            _score.text = entry.Score;
        }
    }
}