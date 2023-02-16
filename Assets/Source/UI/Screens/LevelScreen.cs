using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class LevelScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelScreen;

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }

        private void OnActiveSceneChanged(Scene previousScene, Scene currentScene)
        {
            _levelScreen.text = currentScene.name;
        }
    }
}