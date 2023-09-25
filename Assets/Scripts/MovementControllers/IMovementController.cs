
using UnityEngine;

namespace StoredirtVolley.MovementControllers
{
    public interface IMovementController
    {
        public abstract void FixedUpdateMovement();
        public abstract void UpdateMovement();
        public abstract void LateUpdateMovement();

        public abstract void SetMovementStats(MovementStats movementStats);
        public abstract void SetMovementState(MovementState movementState);

    }//Closes IMovementController Interface
}//Closes Namespace declaration
