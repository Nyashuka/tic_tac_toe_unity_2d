using UnityEngine;

namespace Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private Game _game;

        private async void Awake()
        {
            _game = new Game();
            await _game.Initialize();
        }
    }
}