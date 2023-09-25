using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class StoreDashboard : MonoBehaviour
    {
        private Inventory buyer;

        [SerializeField] private Button _exitButton;
        [SerializeField] private StoreArticleCard _articleCard;
        [SerializeField] private Transform _underwearContainer;
        [SerializeField] private Transform _armorContainer;
        [SerializeField] private Transform _headContainer;




        public void Init(Inventory buyer, StoreArticle[] _articles, UnityAction OnCloseDashboard)
        {
            this.buyer = buyer;
            _exitButton?.onClick.AddListener(OnCloseDashboard);
            if (!_articleCard) return;

            foreach (var article in _articles)
            {
                if (!article) continue;
                StoreArticleCard newCard = Instantiate(_articleCard, GetContainer(article));
                newCard.Construct(article, buyer, ArticleBought);
            }
        }//Closes PopulateCards method


        private void ArticleBought(StoreArticle article)
        {
            if (!article || !buyer || buyer.HasArticle(article)) return;

            if (buyer.Charge(article.Price)) buyer.GiveArticle(article);

        }//Closes ArticleBought method

        private Transform GetContainer(StoreArticle article)
        {
            switch (article.Type)
            {
                case StoreArticle.ArticleType.Underwear: return _underwearContainer ? _underwearContainer : transform;

                case StoreArticle.ArticleType.Armor: return _armorContainer ? _armorContainer : transform;

                case StoreArticle.ArticleType.Head: return _headContainer ? _headContainer : transform;


                default:
                    return transform;
            }


        }//Closes GetContainer method

    }//Closes StoreDashboard monobehaviour
}//Closes Namespace declaration
