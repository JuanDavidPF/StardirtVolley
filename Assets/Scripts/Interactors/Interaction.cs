using System;

using UnityEngine;

namespace StoredirtVolley.Interactors
{

    public class Interaction
    {
        public readonly string actionName;
        public readonly Action<IInteractionManager> OnInteractionStarted;
        public readonly Action<IInteractionManager> OnInteractionFinished;
        private IInteractionManager currentInteractor;

        public static implicit operator bool(Interaction interaction)
        {
            return interaction != null;
        }
        public Interaction(string actionName, Action<IInteractionManager> OnInteractionStarted, Action<IInteractionManager> OnInteractionFinished)
        {
            this.actionName = actionName;
            this.OnInteractionStarted = OnInteractionStarted;
            this.OnInteractionFinished = OnInteractionFinished;

        }//Closes Interaction contructor

        public void StartInteraction(IInteractionManager interactor)
        {
            currentInteractor = interactor;
            OnInteractionStarted?.Invoke(interactor);

        }//Closes StartInteraction method


        public void FinishInteraction()
        {
            OnInteractionFinished?.Invoke(currentInteractor);
            currentInteractor?.OnInteractionFinished(this);
            currentInteractor = null;

        }//Closes FinishInteraction method

    }//Closes Interaction class

}//Closes Namespace declaration
