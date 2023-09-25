
using TMPro;
using UnityEngine;

namespace StoredirtVolley.Interactors
{
    public class PlayerInteractionsController : MonoBehaviour, IInteractionManager
    {

        [Header("Interaction Parameters")]
        [SerializeField] private KeyCode _interactionKey;
        [SerializeField] private TextMeshProUGUI _interactionLabel;
        private Interaction executingInteraction = null;
        private Interaction closeInteraction = null;

        private void Awake()
        {
            TurnInteractionSign(false);

        }//Closes Awake method

        private void Update()
        {
            if (_interactionLabel) _interactionLabel.color = executingInteraction ? Color.gray : Color.white;

            if (executingInteraction || !closeInteraction) return;

            if (Input.GetKeyDown(_interactionKey)) closeInteraction.StartInteraction(this);

        }//Closes Update method

        public void OnInteractionReceived(Interaction interaction)
        {
            if (!interaction) return;

            TurnInteractionSign(true);
            _interactionLabel?.SetText($"Press [ {_interactionKey} ] to {interaction.actionName}");
            closeInteraction = interaction;

        }//Closes OnInteractionReceived method

        public void OnInteractionDismissed(Interaction interaction)
        {
            TurnInteractionSign(false);
            if (interaction == closeInteraction) closeInteraction = null;

        }//Closes OnInteractionDismissed method

        public void OnInteractionFinished(Interaction interaction)
        {
            executingInteraction = null;

        }//Closes OnInteractionFinished method

        public void OnInteractionStarted(Interaction interaction)
        {
            if (!interaction) return;
            executingInteraction = interaction;

        }//Closes OnInteractionStarted method

        private void TurnInteractionSign(bool turn)
        {
            _interactionLabel?.gameObject.SetActive(turn);
        }//Closes TurnInteractionSign method

        public Transform GetOwner()
        {
            return transform;
        }//Closes GetOwner metho

    }//Closes PlayerInteractionsController class
}//Closes Namespace declaration
