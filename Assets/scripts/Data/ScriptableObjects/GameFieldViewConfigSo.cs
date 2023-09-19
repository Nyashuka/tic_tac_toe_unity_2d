using Data.AssetsReferences;
using UnityEngine;

namespace Data.ScriptableObjects
{

    [CreateAssetMenu(fileName = "GameFieldViewConfig", menuName = "ScriptableObjects/GameFieldViewConfig")]
    public class GameFieldViewConfigSo : ScriptableObject
    {
        [SerializeField] private GameFieldViewConfig gameFieldViewConfig;

        public GameFieldViewConfig GameFieldViewConfig => gameFieldViewConfig;
    }
}