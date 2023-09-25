
using UnityEngine;

namespace StoredirtVolley.SkinnedAnimatorControllers
{
    public class Layered2DAnimator : ISkinnedAnimatorController
    {

        private Animator animator;
        private string currentDirection;
        private string currentState;

        public Layered2DAnimator(Animator animator)
        {
            this.animator = animator;

        }//Closes Layered2DAnimator Constructor

        public void SetState(string newState, string newDirection)
        {
            if (!animator || (currentState == newState && currentDirection == newDirection)) return;

            animator.Play($"{newState}_{newDirection}");

            currentState = newState;

        }//Closes SetState method

    }//Closes Layered2DAnimator class
}//Closes Namespace declaration
