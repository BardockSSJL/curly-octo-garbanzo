using Object = UnityEngine.Object;

namespace Posciones
{
    public class FabricaPosciones
    {
        private readonly ListaPosciones lista;

        public FabricaPosciones(ListaPosciones lista)
        {
            this.lista = lista;
        }

        public PoscionBase Create(string id)
        {
            var poscion = lista.GetPoscionPrefabById(id);
            return Object.Instantiate(poscion);
        }
    }
}
