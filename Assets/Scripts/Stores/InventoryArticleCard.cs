
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class InventoryArticleCard : MonoBehaviour
    {
        private Inventory owner;
        private StoreArticle storeArticle;
        [SerializeField] private Image _articleThumbnail;
        [SerializeField] private TextMeshProUGUI _articleName;
        [SerializeField] private Button _callToAction;

        public void Construct(StoreArticle storeArticle, Inventory owner, UnityAction<StoreArticle> OnArticleSelected)
        {
            this.storeArticle = storeArticle;
            this.owner = owner;

            if (!storeArticle) return;

            if (_articleThumbnail) _articleThumbnail.sprite = storeArticle.Thumbnail;

            _articleName?.SetText(storeArticle.ArticleName);


            if (_articleThumbnail) _articleThumbnail.sprite = storeArticle.Thumbnail;

            _callToAction?.onClick.AddListener(() => OnArticleSelected(storeArticle));
        }//Closes SetStoreArticle method


        private void Update()
        {
            ValidateEquipability();

        }//Closes Update method

        public void ValidateEquipability()
        {
            if (!owner || !storeArticle) return;

            _callToAction.interactable = !owner.HasEquipped(storeArticle);

        }//Closes ValidateEquipability method


    }//Closes StoreArticleCard class
}//Closes namespace declaration
