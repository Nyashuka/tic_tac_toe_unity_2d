using Data.AssetsReferences;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "UIAssetsSo", menuName = "ScriptableObjects/UIAssetsSo", order = 1)]
    public class UIAssetsSo : ScriptableObject
    { 
        [SerializeField] private UIAssets uiAssets;

        public UIAssets UIAssets => uiAssets;
    }
}