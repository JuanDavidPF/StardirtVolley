
using UnityEditor.Animations;
using UnityEngine;

namespace StoredirtVolley
{
    [CreateAssetMenu(fileName = "New Store Artice", menuName = "Store/Article")]

    public class StoreArticle : ScriptableObject
    {
        public enum ArticleType
        {
            Underwear,
            Armor,
            Head

        }

        public ArticleType Type;
        public Sprite Thumbnail;
        public string ArticleName;
        public int Price;
        public AnimatorOverrideController ArticleAnimator;


    }//Closes StoreArticle class
}//Closes Namespace declaration
