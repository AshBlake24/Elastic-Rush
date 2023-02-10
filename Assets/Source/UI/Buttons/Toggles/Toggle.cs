namespace UnityEngine.UI.Extensions
{
    [RequireComponent(typeof(UI.Toggle))]
    public abstract class Toggle : MonoBehaviour
    {
        [SerializeField] protected Sprite EnabledSprite;
        [SerializeField] protected Sprite DisabledSprite;
        [SerializeField] private Image _image;

        private UI.Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<UI.Toggle>();
        }

        protected virtual void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnToggleClick);
        }

        protected virtual void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnToggleClick);
        }

        protected void Enable()
        {
            _image.sprite = EnabledSprite;
            _toggle.isOn = true;
        }

        protected void Disable()
        {
            _image.sprite = DisabledSprite;
            _toggle.isOn = false;
        }

        protected abstract void OnToggleClick(bool toggleState);
    }
}