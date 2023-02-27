namespace UnityEngine.UI.Extensions
{
    [RequireComponent(typeof(UI.Button))]
    public abstract class Button : MonoBehaviour
    {
        protected UI.Button ButtonComponent;

        private void Awake()
        {
            ButtonComponent = GetComponent<UI.Button>();
        }

        private void OnEnable()
        {
            ButtonComponent.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            ButtonComponent.onClick.RemoveListener(OnButtonClick);
        }

        protected abstract void OnButtonClick();
    }
}