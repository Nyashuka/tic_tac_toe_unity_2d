using System;
using Data.ScriptableObjects;
using GameFieldRendererModule;
using UnityEngine;

namespace Data.AssetsReferences
{
    [Serializable]
    public class GameAssets
    {
        [SerializeField] private GameFieldRenderer gameFieldRendererPrefab;
        [SerializeField] private GameFieldViewConfigSo gameFieldViewConfigSo;

        public GameFieldViewConfigSo GameFieldViewConfigSo => gameFieldViewConfigSo;
        public GameFieldRenderer GameFieldRenderer => gameFieldRendererPrefab;
    }
}