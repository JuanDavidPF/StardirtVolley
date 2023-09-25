
using System.Collections;
using StoredirtVolley.Interactors;
using StoredirtVolley.PawnControllers;
using UnityEngine;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class StoreKeeperController : MonoBehaviour, IInteractuable
    {

        [SerializeField] private string _interactionName;
        private Interaction interaction;

        [SerializeField] private GameObject _storePanel;
        [SerializeField] private Button _closeStorePanel;

        private void Start()
        {
            interaction = new Interaction(_interactionName, HandleInteraction, FinishInteraction);
            _closeStorePanel?.onClick.AddListener(CloseStorePanel);

        }//Closes Start method


        private void HandleInteraction(IInteractionManager interactor)
        {
            interactor.OnInteractionStarted(interaction);

            if (interactor.GetOwner().TryGetComponent(out PlayerController controller)) controller.enabled = false;

            _storePanel?.gameObject.SetActive(true);

        }//Closes HandleInteraction method

        public void CloseStorePanel()
        {
            interaction.FinishInteraction();

        }//Closes CloseStorePanel method

        private void FinishInteraction(IInteractionManager interactor)
        {
            if (interactor.GetOwner().TryGetComponent(out PlayerController controller)) controller.enabled = true;
            _storePanel?.gameObject.SetActive(false);

        }//Closes FinishInteraction method

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractionManager interactionManager))

                interactionManager.OnInteractionReceived(interaction);

        }//Closes OnTriggerEnter method

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IInteractionManager interactionManager))
                interactionManager.OnInteractionDismissed(interaction);

        }//Closes OnTriggerExit method

        private void OnDestroy()
        {
            _closeStorePanel?.onClick.RemoveListener(CloseStorePanel);

        }//Closes OnDestroy method


    }//Closes StoreKeeperController class
}//Closes Namespace declaration
