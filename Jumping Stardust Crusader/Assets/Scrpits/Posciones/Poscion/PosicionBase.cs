using UnityEngine;


namespace Posciones
{
    public abstract class PoscionBase : MonoBehaviour
    {
        [SerializeField] protected string id;

        public string Id=>id;
    }
}