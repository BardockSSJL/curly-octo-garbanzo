using Object = UnityEngine.Object;

namespace Pociones
{
    public class FabricaPociones
    {
        private readonly ListaPociones lista;

        public FabricaPociones(ListaPociones lista)
        {
            this.lista = lista;
        }

        public PocionBase Create(string id)
        {
            var pocion = lista.GetPocionPrefabById(id);
            return Object.Instantiate(pocion);
        }
    }
}
