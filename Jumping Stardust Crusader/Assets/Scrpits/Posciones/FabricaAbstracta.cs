using Pociones;

public class FabricaAbstracta
{
    private readonly FabricaPociones fabricaPociones;

    public FabricaAbstracta(FabricaPociones fabricaPociones)
    {
        this.fabricaPociones = fabricaPociones;
    }

    public PocionBase CrearPocion(string Id)
    {
        return fabricaPociones.Create(Id);
    }

}