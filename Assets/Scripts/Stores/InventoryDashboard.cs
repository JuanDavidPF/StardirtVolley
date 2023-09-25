
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StoredirtVolley
{
    public class InventoryDashboard : MonoBehaviour
    {
        private Inventory owner;
        [SerializeField] private Button _exitButton;
        [SerializeField] private InventoryArticleCard _articleCard;
        [SerializeField] private Transform _underwearContainer;
        [SerializeField] private Transform _armorContainer;
        [SerializeField] private Transform _headContainer;


        public void Init(Inventory owner, StoreArticle[] _articles, UnityAction OnCloseDashboard)
        {
            this.owner = owner;
            _exitButton?.onClick.AddListener(OnCloseDashboard);
            if (!_articleCard) return;

            foreach (var article in _articles)
            {
                if (!article) continue;
                InventoryArticleCard newCard = Instantiate(_articleCard, GetContainer(article));
                newCard.Construct(article, owner, ArticleSelected);
            }
        }//Closes PopulateCards method


        private void ArticleSelected(StoreArticle article)
        {
            if (!article || !owner) return;

            owner.Equip(article);


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



    }//Closes InventoryDashboard method
}//Closes Namespace declaration
