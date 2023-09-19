using Infrastructure.ServiceLocatorModule;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AssetsProvider assetsProvider;
        
        private Game _game;

        private async void Awake()
        {
            RegisterServices();
            
            _game = new Game();
            await _game.Initialize();
        }

        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(assetsProvider);
        }
    }
}