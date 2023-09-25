
using StoredirtVolley.Interactors;
using StoredirtVolley.MovementControllers;
using StoredirtVolley.SkinnedAnimatorControllers;
using TMPro;
using UnityEngine;

namespace StoredirtVolley.PawnControllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {

        [Header("Movement Parameters")]
        [SerializeField] private Rigidbody _playerRb;
        [SerializeField] private MovementStats _playerMovementStats;
        private IMovementController movementController;

        [Header("Visual Parameters")]
        [SerializeField] private Animator _bodyAnimator;
        [SerializeField] private Animator _underWearAnimator;
        [SerializeField] private Animator _armorAnimator;
        [SerializeField] private Animator _headAnimator;

        private ISkinnedAnimatorController playerLayeredAnimator;



        private void Awake()
        {
            if (!_playerRb) TryGetComponent(out _playerRb);

        }//Closes Start method

        private void Start()
        {
            playerLayeredAnimator = new Layered2DAnimator(_bodyAnimator, _underWearAnimator, _armorAnimator, _headAnimator);
            movementController = new PlayerMovementController(_playerRb, _playerMovementStats, playerLayeredAnimator);

        }//Closes Start method

        private void Update()
        {
            movementController?.UpdateMovement();

        }//Closes Update method

        private void FixedUpdate()
        {

            movementController?.FixedUpdateMovement();

        }//Closes FixedUpdate method

        private void LateUpdate()
        {
            movementController?.LateUpdateMovement();

        }//Closes LateUpdate method




    }//Closes PlayerController class
}//Closes Namespace declaration
