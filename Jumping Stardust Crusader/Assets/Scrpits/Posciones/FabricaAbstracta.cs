using Posciones;

public class FabricaAbstrata
{
    private readonly FabricaPosciones fabricaPosciones;

    public FabricaAbstrata(FabricaPosciones fabricaPosciones)
    {
        this.fabricaPosciones = fabricaPosciones;
    }

    public PoscionBase CrearPoscion(string Id)
    {
        return fabricaPosciones.Create(Id);
    }

}