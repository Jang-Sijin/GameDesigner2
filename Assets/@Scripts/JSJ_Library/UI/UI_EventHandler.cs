using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JSJ_Library
{
    public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
    {
        public event Action OnClickHandler = null;
        public event Action OnPressHandler = null;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickHandler?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPressHandler?.Invoke();
        }
    }
}