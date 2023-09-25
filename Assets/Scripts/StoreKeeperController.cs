
using System.Collections;
using StoredirtVolley.Interactors;
using StoredirtVolley.PawnControllers;
using UnityEngine;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class StoreKeeperController : MonoBehaviour, IInteractuable
    {
        [SerializeField] private StoreArticle[] _articles;
        [SerializeField] private string _interactionName;
        private Interaction interaction;

        [SerializeField] private StoreDashboard _storePanelPrefab;
        private StoreDashboard currentDashboard;

        private void Start()
        {
            interaction = new Interaction(_interactionName, HandleInteraction, FinishInteraction);

        }//Closes Start method


        private void HandleInteraction(IInteractionManager interactor)
        {
            interactor.OnInteractionStarted(interaction);

            if (!_storePanelPrefab)
            {
                interaction.FinishInteraction();
                return;
            }

            currentDashboard = Instantiate(_storePanelPrefab);

            Transform interactorOwner = interactor.GetOwner();

            if (interactorOwner.TryGetComponent(out PlayerController controller)) controller.enabled = false;

            if (interactorOwner.TryGetComponent(out Inventory inventory))
            {
                currentDashboard.Init(inventory, _articles, interaction.FinishInteraction);
            }


        }//Closes HandleInteraction method


        private void FinishInteraction(IInteractionManager interactor)
        {
            if (interactor.GetOwner().TryGetComponent(out PlayerController controller)) controller.enabled = true;
            Destroy(currentDashboard.gameObject);
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



    }//Closes StoreKeeperController class
}//Closes Namespace declaration
