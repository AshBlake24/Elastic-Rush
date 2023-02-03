using UnityEngine;

namespace ElasticRush.Core
{
    public class MoveStarter : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private WaypointFollower _follower;

        private PlayerInput _input;

        private void OnDisable()
        {
            _input.Player.Click.started -= (ctx) => OnClick();
        }

        private void Start()
        {
            _follower.enabled = false;
            _input = _playerController.Input;
            _input.Player.Click.started += (ctx) => OnClick();
        }

        private void OnClick()
        {
            _follower.enabled = true;
            enabled = false;
        }
    }
}