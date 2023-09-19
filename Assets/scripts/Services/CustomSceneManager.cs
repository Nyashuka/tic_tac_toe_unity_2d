using System.Threading.Tasks;
using Better.SceneManagement.Runtime;
using UnityEngine.SceneManagement;

namespace Services
{
    public class CustomSceneManager
    {
        public async Task LoadScene(SceneLoaderAsset asset, LoadSceneMode mode)
        {
            await SceneLoader.LoadSceneAsync(asset, new LoadSceneOptions()
            {
                SceneLoadMode = mode,
                UseIntermediate = false,
            });
        }

        public void SetActiveScene(string sceneName)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }
}