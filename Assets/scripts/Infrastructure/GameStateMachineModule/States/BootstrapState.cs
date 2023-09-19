using System.Threading.Tasks;
using Infrastructure.EventBusModule;
using Infrastructure.ServiceLocatorModule;
using Services;
using UnityEngine.SceneManagement;

namespace Infrastructure.GameStateMachineModule.States
{
    public class BootstrapState : IGameState
    {
        public async Task Enter()
        {
            AssetsProvider assetsProvider = ServiceLocator.Instance.GetService<AssetsProvider>();
            CustomSceneManager sceneManager = new CustomSceneManager();

            await sceneManager.LoadScene(assetsProvider.ScenesAssets.GameScene, LoadSceneMode.Additive);
            sceneManager.SetActiveScene(assetsProvider.ScenesAssets.GameScene.Name);
        }


        public async Task Exit()
        {
            
        }
    }
}