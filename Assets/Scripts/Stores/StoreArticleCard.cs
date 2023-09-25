
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class StoreArticleCard : MonoBehaviour
    {
        private Inventory buyer;
        private StoreArticle storeArticle;
        [SerializeField] private Image _articleThumbnail;
        [SerializeField] private TextMeshProUGUI _articleName;
        [SerializeField] private TextMeshProUGUI _articlePrice;
        [SerializeField] private Button _callToAction;

        public void Construct(StoreArticle storeArticle, Inventory buyer, UnityAction<StoreArticle> OnArticleSelected)
        {
            this.storeArticle = storeArticle;
            this.buyer = buyer;

            if (!storeArticle) return;

            if (_articleThumbnail) _articleThumbnail.sprite = storeArticle.Thumbnail;

            _articleName?.SetText(storeArticle.ArticleName);
            _articlePrice?.SetText($"Get for ${storeArticle.Price}");

            if (_articleThumbnail) _articleThumbnail.sprite = storeArticle.Thumbnail;

            _callToAction?.onClick.AddListener(() => OnArticleSelected(storeArticle));
        }//Closes SetStoreArticle method


        private void Update()
        {
            ValidateAffordability();

        }//Closes Update method

        public void ValidateAffordability()
        {
            if (!buyer || !storeArticle) return;

            _callToAction.interactable = buyer.Coins >= storeArticle.Price && !buyer.HasArticle(storeArticle);

        }//Closes ValidateAffordability method

    }//Closes StoreArticleCard class
}//Closes namespace declaration
