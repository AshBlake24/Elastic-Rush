using ElasticRush.Core;
using ElasticRush.UI;
using UnityEngine;

namespace ElasticRush
{
    public class UIStarter : MonoBehaviour
    {
        [SerializeField] private UserInterface _userInterfacePrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private MoveStarter _moveStarter;

        private void Start()
        {
            UserInterface ui = Instantiate(_userInterfacePrefab);
            ui.Init(_camera, _player, _playerController);
            _moveStarter.SetTutorial(ui.Tutorial);
        }
    }
}