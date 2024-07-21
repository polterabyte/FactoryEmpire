﻿using UnityEngine;

namespace Common
{
    public abstract class ScreenPresenterBase<T> : IScreen where T : MonoBehaviour
    {
        protected T View { get; }

        public bool IsActive => View.gameObject.activeSelf;

        protected ScreenPresenterBase(T view)
        {
            View = view;
        }

        public void Show()
        {
            View.gameObject.SetActive(true);
        }

        public void Hide()
        {
            View.gameObject.SetActive(false);
        }
    }
}