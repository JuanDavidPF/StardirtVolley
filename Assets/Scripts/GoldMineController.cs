using System;
using System.Collections;

using StoredirtVolley.Interactors;
using UnityEngine;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class GoldMineController : MonoBehaviour, IInteractuable
    {
        [SerializeField] private Rigidbody _goldOrePrefab;
        [SerializeField] private Image _progressBar;
        [SerializeField] private string _interactionName;

        private Interaction interaction;

        private void Start()
        {
            interaction = new Interaction(_interactionName, HandleInteraction, DropGoldNuggets);

        }//Closes Start method

        private void HandleInteraction(IInteractionManager interactor)
        {
            interactor.OnInteractionStarted(interaction);
            StartCoroutine(StartMiningGold());

        }//Closes HandleInteraction method

        private void DropGoldNuggets(IInteractionManager interactor)
        {
            if (!_goldOrePrefab) return;

            int amount = UnityEngine.Random.Range(3, 10);

            for (int i = 0; i < amount; i++)
            {
                Rigidbody newOre = Instantiate(_goldOrePrefab);
                newOre.transform.position = transform.position + new Vector3(0, 0.5f, 0) + UnityEngine.Random.insideUnitSphere;
                newOre.AddExplosionForce(200, transform.position, 200, 200);
            }

        }//Closes DropGoldNuggets method

        private IEnumerator StartMiningGold()
        {
            WaitForSeconds delay = new(3);

            StartCoroutine(AnimateProgressBar(3));
            yield return delay;

            interaction.FinishInteraction();

        }//Closes StartMiningGold Coroutine

        private IEnumerator AnimateProgressBar(float duration)
        {
            if (!_progressBar) yield break;

            _progressBar.enabled = true;
            float progress = 0;

            while (progress < duration)
            {
                progress += Time.deltaTime;
                _progressBar.fillAmount = progress / 3;
                yield return null;
            }
            _progressBar.fillAmount = 1;
            _progressBar.enabled = false;
        }//Closes AnimateProgressBar Coroutine


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

    }//Closes GoldMineController class
}//Closes Namespace controller
