using System.Threading.Tasks;
using Better.Extensions.Runtime.AsyncExtension;
using UnityEngine.SceneManagement;

namespace Infrastructure.GameStateMachineModule.States
{
    public class BootstrapState : IGameState
    {
        private const string GameScene = "Game";
        
        public async Task Enter()
        {
            await SceneManager.LoadSceneAsync(GameScene, LoadSceneMode.Additive);
        }

        public async Task Exit()
        {
            
        }

        private void RegisterServices()
        {
            
        }
    }
}