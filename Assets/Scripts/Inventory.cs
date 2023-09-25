using System.Collections;
using System.Collections.Generic;
using StoredirtVolley.Interactors;
using StoredirtVolley.PawnControllers;
using UnityEngine;

namespace StoredirtVolley
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _coins;


        [Header("Clothes")]
        [SerializeField] private List<StoreArticle> _articles = new();
        [SerializeField] private Animator _underWearAnimator;
        [SerializeField] private Animator _armorAnimator;
        [SerializeField] private Animator _headAnimator;
        [SerializeField] private InventoryDashboard _inventoryPanelPrefab;

        private StoreArticle equippedUnderwear;
        private StoreArticle equippedArmor;
        private StoreArticle equippedHead;


        private InventoryDashboard currentDashboard;

        public int Coins
        {
            get { return _coins; }
            private set { _coins = value; }
        }

        public bool Charge(int price)
        {
            if (price > Coins) return false;

            Coins -= price;
            return true;

        }//Closes Charge method
        public void Pay(int coins)
        {
            Coins += coins;

        }//Closes Pay method


        public void GiveArticle(StoreArticle article)
        {
            if (!article || HasArticle(article)) return;
            _articles.Add(article);

        }//Closes GiveArticle method

        public bool HasArticle(StoreArticle article)
        {
            return _articles.Contains(article);

        }//Closes HasArticle method

        public bool HasEquipped(StoreArticle article)
        {
            return article.Type switch
            {
                StoreArticle.ArticleType.Underwear => equippedUnderwear == article,
                StoreArticle.ArticleType.Armor => equippedArmor == article,
                StoreArticle.ArticleType.Head => equippedHead == article,
                _ => false,
            };
        }//Closes IsEquipped method


        public void Equip(StoreArticle article)
        {
            switch (article.Type)
            {
                case StoreArticle.ArticleType.Underwear:
                    equippedUnderwear = article;
                    _underWearAnimator.runtimeAnimatorController = article.ArticleAnimator;
                    break;

                case StoreArticle.ArticleType.Armor:
                    equippedArmor = article;
                    _armorAnimator.runtimeAnimatorController = article.ArticleAnimator;
                    break;

                case StoreArticle.ArticleType.Head:
                    equippedHead = article;
                    _headAnimator.runtimeAnimatorController = article.ArticleAnimator;
                    break;
            }

        }//Closes Equip method


        public void OpenInventory()
        {
            if (!_inventoryPanelPrefab) return;

            if (TryGetComponent(out PlayerController controller)) controller.enabled = false;
            if (TryGetComponent(out PlayerInteractionsController interactions)) interactions.enabled = false;

            currentDashboard = Instantiate(_inventoryPanelPrefab);
            currentDashboard.Init(this, _articles.ToArray(), CloseInventory);

        }//Closes OpenInventory method

        public void CloseInventory()
        {
            if (TryGetComponent(out PlayerController controller)) controller.enabled = true;
            if (TryGetComponent(out PlayerInteractionsController interactions)) interactions.enabled = true;

            if (currentDashboard) Destroy(currentDashboard.gameObject);

        }//Closes CloseInventory Method

    }//Closes Inventory class
}//Closes Namespace declaration
