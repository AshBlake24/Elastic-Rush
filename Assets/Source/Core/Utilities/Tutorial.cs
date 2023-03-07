using System.Collections;
using UnityEngine;
using ElasticRush.Utilities;
using TMPro;

namespace ElasticRush.Core
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Animator _tapAnimation;
        [SerializeField] private float _animationDuration;

        private void Start()
        {
            TurnOn();
        }

        public void TurnOn()
        {
            _text.gameObject.SetActive(true);
            _tapAnimation.gameObject.SetActive(true);
        }

        public void TurnOff()
        {
            _text.gameObject.SetActive(false);
            StartCoroutine(DisableAnimationAfterDelay());
        }

        private IEnumerator DisableAnimationAfterDelay()
        {
            yield return Helpers.GetTime(_animationDuration);

            _tapAnimation.gameObject.SetActive(false);
        }
    }
}