using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ElasticRush.Utilities
{
    public static class Helpers
    {
        #region UI

        private static PointerEventData _eventDataCurrentPosition;
        private static List<RaycastResult> _results;

        public static bool IsOverUI()
        {
            _eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            _results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
            return _results.Count > 0;
        }

        #endregion
    }
}