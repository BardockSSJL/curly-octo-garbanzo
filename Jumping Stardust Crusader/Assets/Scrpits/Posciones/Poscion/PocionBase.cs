using UnityEngine;


namespace Pociones
{
    public abstract class PocionBase : MonoBehaviour
    {
        [SerializeField] protected string id;
        //[SerializeField] protected PocionDeteccionJugador AreaDeteccionJugador;

        protected CircleCollider2D AreaDeteccionJugador;

        public string Id=>id;

        void Awake() {
            AreaDeteccionJugador = gameObject.AddComponent<CircleCollider2D>();
            AreaDeteccionJugador.radius = 1.5f;
            AreaDeteccionJugador.isTrigger = true;
            RigidbodyConstraints2D a = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<Rigidbody2D>().constraints = a;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        }

        void OnTriggerStay2D(Collider2D otro) {
            if (otro.gameObject.tag == "Jugador") {
                gameObject.GetComponent<Rigidbody2D>().AddForce(
                    (otro.gameObject.transform.position - transform.position).normalized * 7f);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Debug.Log("recoger");
        }
    }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, 1.5f);
        }
    }

}