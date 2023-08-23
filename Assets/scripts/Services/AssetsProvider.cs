using Data;
using Data.AssetsReferences;
using Data.ScriptableObjects;
using Infrastructure.ServiceLocatorModule;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public class AssetsProvider : MonoBehaviour, IService
    {
        [SerializeField] private UIAssets uiAssets;
        [SerializeField] private GameAssets gameAssets;

        public UIAssets UIAssets => uiAssets;
    }
}