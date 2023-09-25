
using System.Collections;
using StoredirtVolley.Interactors;
using UnityEngine;

namespace StoredirtVolley
{
    public class GoldOre : MonoBehaviour, IInteractuable
    {
        [SerializeField] private int _price = 1;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10);
            Destroy(gameObject);

        }//Closes Start coroutine

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractionManager interactionManager) && other.TryGetComponent(out Inventory inventory))
            {
                inventory.Pay(_price);
                Destroy(gameObject);
            }
        }//Closes OnTriggerEnter method

    }//Closes GoldOre class
}//Closes Namespace declaration
