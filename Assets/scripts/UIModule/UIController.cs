using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button himselfButton;

        private void Start()
        {
            himselfButton.onClick.AddListener(OnHimselfClicked);
        }

        private void OnHimselfClicked()
        {
            
        }
    }
}