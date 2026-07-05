using ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;

public static class GeradorIdsItemListaCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}
public class ItemListaCompras
{
    public int Id { get; private set; }
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }

    public decimal PrecoTotal
    {
        get
        {
            return Produto.Preco * Quantidade;
        }
    }

    public ItemListaCompras(Produto produto, int quantidade)
    {
        Id = GeradorIdsItemListaCompras.GerarId();
        Produto = produto;
        Quantidade = quantidade;
    }
}
