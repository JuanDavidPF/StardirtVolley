
using StoredirtVolley.SkinnedAnimatorControllers;
using UnityEngine;

namespace StoredirtVolley.MovementControllers
{
    public class PlayerMovementController : IMovementController
    {
        private MovementState movementState;

        private readonly Transform playerTransform;
        private readonly Rigidbody playerRigidBody;
        private readonly ISkinnedAnimatorController playerLayeredAnimator;
        private MovementStats playerMovementStats;

        private string currentDirection = "Back";

        public PlayerMovementController(Rigidbody rigidbody, MovementStats movementStats)
        {
            this.playerRigidBody = rigidbody;
            if (rigidbody) this.playerTransform = rigidbody.transform;

            SetMovementStats(movementStats);

        }//Closes PlayerMovementController Constructor

        public PlayerMovementController(Rigidbody rigidbody, MovementStats movementStats, ISkinnedAnimatorController playerLayeredAnimator)
        {
            this.playerLayeredAnimator = playerLayeredAnimator;
            this.playerRigidBody = rigidbody;
            this.playerTransform = rigidbody != null ? rigidbody.transform : null;

            SetMovementStats(movementStats);

        }//Closes PlayerMovementController Constructor

        public void FixedUpdateMovement()
        {
            if (!playerRigidBody || !playerTransform || !playerMovementStats) return;


            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

            if (movement.Equals(Vector3.zero)) SetMovementState(MovementState.Idle);
            else
            {
                SetMovementState(Input.GetKey(KeyCode.LeftShift) ? MovementState.Running : MovementState.Walking);
                playerRigidBody.AddForce(GetCurrentSpeed() * Time.fixedDeltaTime * movement, ForceMode.VelocityChange);
            }

        }//Closes FixedUpdateMovement method


        public void UpdateMovement()
        {
            if (!playerRigidBody || !playerTransform || !playerMovementStats) return;



        }//Closes UpdateMovement method


   

        public void LateUpdateMovement()
        {
            playerLayeredAnimator?.SetState(GetCurrentState(), GetCurrentDirection());

        }//Closes LateUpdateMovement method

        public float GetCurrentSpeed()
        {
            if (playerMovementStats == null) return 0f;

            return movementState switch
            {
                MovementState.Walking => playerMovementStats.MoveSpeed,
                MovementState.Running => playerMovementStats.SprintSpeed,
                _ => 0f,
            };

        }//Closes GetCurrentSpeed method

        public string GetCurrentState()
        {

            return movementState switch
            {
                MovementState.Idle => "Idle",
                MovementState.Walking => "Walk",
                MovementState.Running => "Run",
                _ => "Idle",
            };

        }//Closes GetCurrentState method

        public string GetCurrentDirection()
        {
            if (!playerRigidBody || playerRigidBody.velocity.magnitude <= 0.15f) return currentDirection;

            // Define direction vectors for front, back, left, and right using Vector3 constants.
            Vector3 forwardDirection = Vector3.forward;
            Vector3 backwardDirection = Vector3.back;
            Vector3 leftDirection = Vector3.left;
            Vector3 rightDirection = Vector3.right;

            // Get the current velocity of the Rigidbody.
            Vector3 velocity = playerRigidBody.velocity;

            // Calculate the angle between velocity and each direction vector.
            float angleForward = Vector3.Angle(velocity, forwardDirection);
            float angleBackward = Vector3.Angle(velocity, backwardDirection);
            float angleLeft = Vector3.Angle(velocity, leftDirection);
            float angleRight = Vector3.Angle(velocity, rightDirection);

            // Find the minimum angle (closest direction).
            float minAngle = Mathf.Min(angleForward, angleBackward, angleLeft, angleRight);

            // Determine the matching direction based on the minimum angle.
            if (minAngle == angleBackward) currentDirection = "Back";
            else if (minAngle == angleForward) currentDirection = "Forward";
            else if (minAngle == angleLeft) currentDirection = "Left";
            else if (minAngle == angleRight) currentDirection = "Right";

            return currentDirection;
        }//Closes GetCurrentSpeed method

        public void SetMovementStats(MovementStats movementStats)
        {
            this.playerMovementStats = movementStats;

        }//Closes SetMovementStats method

        public void SetMovementState(MovementState movementState)
        {
            this.movementState = movementState;
        }//Closes SetMovementState method



    }//Closes PlayerMovementController Class

}//Closes Namespace declaration
