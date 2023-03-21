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

        private float _lastTimeScale = 1;

        private void OnEnable()
        {
            RequestData();
            LoadData();

            _lastTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            ClearViews();

            Time.timeScale = _lastTimeScale;
        }

        private void LoadData()
        {
            LoadEntries();
            LoadPlayerEntry();
        }

        private void LoadEntries()
        {
            Leaderboard.GetEntries(Config.Leaderboard.LeaderboardName, (result) =>
            {
                foreach (var entry in result.entries)
                {
                    CreateView(entry, _entriesContainer);
                }
            }, null, Config.Leaderboard.TopPlayersCount);
        }

        private void LoadPlayerEntry()
        {
            Leaderboard.GetPlayerEntry(Config.Leaderboard.LeaderboardName, (result) =>
            {
                CreateView(result, _playerContainer);
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

        private void RequestData()
        {
            if (YandexGamesSdk.IsInitialized)
            {
                if (PlayerAccount.HasPersonalProfileDataPermission == false)
                    PlayerAccount.RequestPersonalProfileDataPermission();
            }
        }
    }
}
