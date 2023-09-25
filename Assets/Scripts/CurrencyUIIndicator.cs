
using TMPro;
using UnityEngine;

namespace StoredirtVolley
{
    public class CurrencyUIIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyLabel;
        [SerializeField] private Inventory _inventory;


        private void Update()
        {
            _currencyLabel?.SetText(_inventory?.Coins.ToString());

        }//Closes Update method

    }//Closes CurrencyUIIndicator class

}//Closes Namespace declaration
