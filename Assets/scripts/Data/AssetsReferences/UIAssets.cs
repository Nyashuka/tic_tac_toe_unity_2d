using System;
using UIModule;
using UnityEngine;

namespace Data.AssetsReferences
{
    [Serializable]
    public class UIAssets
    {
        [SerializeField] private UIController uiController;
        public UIController UIController => uiController;
    }
}