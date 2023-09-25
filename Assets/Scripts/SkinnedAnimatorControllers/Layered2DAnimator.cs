
using UnityEngine;

namespace StoredirtVolley.SkinnedAnimatorControllers
{
    public class Layered2DAnimator : ISkinnedAnimatorController
    {

        private Animator[] animators;
        private string currentDirection;
        private string currentState;

        public Layered2DAnimator(params Animator[] animators)
        {
            this.animators = animators;

        }//Closes Layered2DAnimator Constructor

        public void SetState(string newState, string newDirection)
        {
            if (animators.Length == 0 || (currentState == newState && currentDirection == newDirection)) return;

            foreach (var animator in animators) animator.Play($"{newState}_{newDirection}");


            currentState = newState;

        }//Closes SetState method

    }//Closes Layered2DAnimator class
}//Closes Namespace declaration
