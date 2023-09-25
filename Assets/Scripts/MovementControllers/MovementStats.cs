
using UnityEngine;

namespace StoredirtVolley.MovementControllers
{
    [CreateAssetMenu(fileName = "New Movement Stats", menuName = "Movement/Stats")]

    public class MovementStats : ScriptableObject
    {

        [Header("Movement Parameters")]
        public float MoveSpeed = 5f;
        public float SprintSpeed = 5f;


    }//Closes MovementStats ScriptableObject

}//Closes Namespace declaration
