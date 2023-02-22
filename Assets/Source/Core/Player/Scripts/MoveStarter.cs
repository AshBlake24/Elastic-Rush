using ElasticRush.Utilities;
using System;
using TMPro;
using UnityEngine;

namespace ElasticRush.Core
{
    public class MoveStarter : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private WaypointFollower _follower;
        [SerializeField] private TMP_Text _startInfo;

        private PlayerInput _input;

        public event Action MoveStarted;

        private void OnDisable()
        {
            _input.Player.Click.started -= (ctx) => OnClick();
        }

        private void Start()
        {
            _startInfo.gameObject.SetActive(true);
            _follower.enabled = false;
            _input = _playerController.Input;
            _input.Player.Click.started += (ctx) => OnClick();
        }

        private void OnClick()
        {
            if (Helpers.IsOverUI())
                return;

            MoveStarted?.Invoke();
            _startInfo.gameObject.SetActive(false);
            _follower.enabled = true;
            enabled = false;
        }
    }
}