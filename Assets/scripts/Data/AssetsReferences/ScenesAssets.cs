using System;
using Better.SceneManagement.Runtime;
using UnityEngine;

namespace Data.AssetsReferences
{
    [Serializable]
    public class ScenesAssets 
    {
        [SerializeField] private SceneLoaderAsset gameScene;

        public SceneLoaderAsset GameScene => gameScene;
    }
}