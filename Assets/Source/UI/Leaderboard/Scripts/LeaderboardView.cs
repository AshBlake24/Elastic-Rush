using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using ElasticRush.Utilities;

namespace ElasticRush.UI
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;
        [SerializeField] private Transform _entriesContainer;
        [SerializeField] private Transform _playerContainer;

        private readonly List<LeaderboardEntryView> _leaderboardEntryViews = new();

        private void OnEnable()
        {
            LoadData();
        }

        private void OnDisable()
        {
            ClearViews();
        }

        private void LoadData()
        {
            LoadEntries();
            LoadPlayerEntry();
        }

        private void LoadEntries()
        {
            Leaderboard.GetEntries(Config.LeaderboardName, (result) =>
            {
                foreach (var entry in result.entries)
                {
                    Debug.Log($"Name - {entry.player.publicName} | Rank - {entry.rank} | Score - {entry.score}");
                    CreateView(entry, _entriesContainer);
                }
            }, null, Config.TopPlayersCount);
        }

        private void LoadPlayerEntry()
        {
            Leaderboard.GetPlayerEntry(Config.LeaderboardName, (result) =>
            {
                if (result == null)
                {
                    Debug.Log("Player is not present in the leaderboard.");
                    CreateView(result, _playerContainer);
                }
                else
                {
                    Debug.Log($"My rank = {result.rank}, score = {result.score}");
                    CreateView(result, _playerContainer);
                }                
            });
        }

        private void CreateView(LeaderboardEntryResponse entry, Transform container)
        {
            LeaderboardEntryView view = Instantiate(_leaderboardEntryViewPrefab, container);
            view.SetData(new LeaderboardEntry(entry));
            _leaderboardEntryViews.Add(view);
        }

        private void ClearViews()
        {
            foreach (var entry in _leaderboardEntryViews)
                Destroy(entry.gameObject);

            _leaderboardEntryViews.Clear();
        }
    }
}
