using System.Collections;
using UnityEngine;
using Agava.YandexGames;

namespace ElasticRush
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private string _startScene;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            SceneLoader.Instance.LoadScene(_startScene); // temporary
            yield break;
#endif

            yield return YandexGamesSdk.Initialize();

            if (YandexGamesSdk.IsInitialized)
                SceneLoader.Instance.LoadScene(_startScene);
        }
    }
}