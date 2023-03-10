using ElasticRush.Core;
using ElasticRush.Utilities;
using System.Collections;
using UnityEngine;

namespace ElasticRush.UI
{
    public abstract class EndScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _endScreen;
        [SerializeField] protected Score Score;

        protected Player Player;

        private void Awake()
        {
            _endScreen.SetActive(false);
        }

        public abstract void Init(Player player);

        protected void ShowEndScreen()
        {
            StartCoroutine(ShowWithDelay());
        }

        private IEnumerator ShowWithDelay()
        {
            yield return Helpers.GetTime(Config.Player.TimeBeforeEndScreen);
            _endScreen.SetActive(true);
        }
    }
}