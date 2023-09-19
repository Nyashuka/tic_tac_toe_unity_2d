using Data.AssetsReferences;
using Infrastructure.ServiceLocatorModule;
using UnityEngine;

namespace Services
{
    public class AssetsProvider : MonoBehaviour, IService
    {
        [SerializeField] private UIAssets uiAssets;
        [SerializeField] private GameAssets gameAssets;
        [SerializeField] private ScenesAssets sceneAssets;

        public UIAssets UIAssets => uiAssets;
        public ScenesAssets ScenesAssets => sceneAssets;
        public GameAssets GameAssets => gameAssets;

    }
}