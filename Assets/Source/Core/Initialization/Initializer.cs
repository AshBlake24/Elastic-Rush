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
            yield return YandexGamesSdk.Initialize();

            if (PlayerAccount.HasPersonalProfileDataPermission == false)
                PlayerAccount.RequestPersonalProfileDataPermission();

            SceneLoader.Instance.LoadScene(_startScene);
        }
    }
}