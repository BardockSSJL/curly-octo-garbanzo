using UnityEngine;


namespace Pociones
{
    public abstract class PocionBase : MonoBehaviour
    {
        [SerializeField] protected string id;

        public string Id=>id;
    }
}