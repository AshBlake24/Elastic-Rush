using UnityEngine.UI.Extensions;

namespace ElasticRush.UI
{
    public class RestartButton : Button
    {
        protected override void OnButtonClick()
        {
            SceneLoader.Instance.RestartScene();
        }
    }
}