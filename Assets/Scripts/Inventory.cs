using System.Collections;
using System.Collections.Generic;
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

    }//Closes Inventory class
}//Closes Namespace declaration
