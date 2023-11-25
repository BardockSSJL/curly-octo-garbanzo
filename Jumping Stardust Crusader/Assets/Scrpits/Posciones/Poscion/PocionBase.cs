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
            gameObject.layer = LayerMask.NameToLayer("Etereos");
            AreaDeteccionJugador = gameObject.AddComponent<CircleCollider2D>();
            AreaDeteccionJugador.radius = 1.5f;
            AreaDeteccionJugador.isTrigger = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
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
            // TODO: Verificar ids
            if (id=="Vida"){
                collision.gameObject.GetComponent<Jugador>().agregarPocion(1);
            } else if (id=="Armadura"){
                collision.gameObject.GetComponent<Jugador>().agregarPocion(3);
            } else if (id=="Dano"){
                collision.gameObject.GetComponent<Jugador>().agregarPocion(1);
            }
            Destroy(gameObject);
        }
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, 1.5f);
        }
    }

}