using Infrastructure.EventBusModule;
using Infrastructure.ServiceLocatorModule;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button himselfButton;

        private EventBus _eventBus;
        
        private void Start()
        {
            _eventBus = ServiceLocator.Instance.GetService<EventBus>();
            
            himselfButton.onClick.AddListener(OnHimselfClicked);
        }

        private void OnHimselfClicked()
        {
            _eventBus.Raise(EventBusDefinitions.HimselfGameSelected, new EmptyEventBusArgs());
            Destroy(himselfButton.gameObject);
        }
    }
}