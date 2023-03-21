using ElasticRush.Audio;
using ElasticRush.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElasticRush
{
    public class AdObserver : MonoBehaviour
    {
        [SerializeField] private AudioGroupController _master;

        private static bool _isAdPlaying;

        public static bool IsAdPlaying => _isAdPlaying;

        private void OnEnable()
        {
            AdButton.AdOpened += OnAdOpened;
            AdButton.AdClosed += OnAdClosed;
        }

        private void OnDisable()
        {
            AdButton.AdOpened -= OnAdOpened;
            AdButton.AdClosed -= OnAdClosed;
        }

        private void OnAdOpened()
        {
            _isAdPlaying = true;
            _master.Mute();
        }

        private void OnAdClosed()
        {
            _isAdPlaying = false;
            _master.Unmute();
        }
    }
}
