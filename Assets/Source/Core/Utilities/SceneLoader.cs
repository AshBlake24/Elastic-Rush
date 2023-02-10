using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;

        private Scene _scene;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(StartLoading(sceneName));
        }

        public void ChangeScene(string nextScene, string previousScene)
        {
            UnloadScene(previousScene);
            StartCoroutine(StartLoading(nextScene));
        }

        private IEnumerator StartLoading(string sceneName)
        {
            var loadedScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (loadedScene.isDone == false)
                yield return null;

            SetLoadedSceneActive(sceneName);
        }

        private void SetLoadedSceneActive(string sceneName)
        {
            _scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(_scene);
        }

        private void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}