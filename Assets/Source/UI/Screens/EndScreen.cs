using ElasticRush.Core;
using ElasticRush.Utilities;
using System.Collections;
using UnityEngine;

namespace ElasticRush.UI
{
    public abstract class EndScreen : MonoBehaviour
    {
        [SerializeField] protected Player Player;
        [SerializeField] private GameObject _endScreen;

        private void Awake()
        {
            _endScreen.SetActive(false);
        }

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