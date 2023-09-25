

using UnityEngine;

namespace StoredirtVolley.Interactors
{
    public interface IInteractionManager
    {
        public abstract Transform GetOwner();
        public abstract void OnInteractionReceived(Interaction interaction);
        public abstract void OnInteractionStarted(Interaction interaction);
        public abstract void OnInteractionDismissed(Interaction interaction);
        public abstract void OnInteractionFinished(Interaction interaction);

    }//Closes IIinteractor interface
}//Closes Namespace declaration
