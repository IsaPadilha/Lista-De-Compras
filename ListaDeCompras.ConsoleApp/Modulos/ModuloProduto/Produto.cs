using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;

public static class GeradorIdsProduto
{
    private static int contadorIds = 1;
    public static int GerarId()
    {
        return contadorIds++;
    }

}
public enum UnidadeDeMedida
{
    Kg,
    Unidade,
    Duzia,
    Ml,
    G,
    Litro,
    Caixa
}
public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public int ValorUnidadeMedida { get; private set; }
    public UnidadeDeMedida UnidadeDeMedida { get; private set; }
    public decimal Preco { get; private set; }

    public Produto(
        string nome,
        Categoria categoria,
        int valorUnidadeMedida,
        UnidadeDeMedida unidadeDeMedida,
        decimal preco)
    {
        Id = GeradorIdsProduto.GerarId();

        Nome = nome;
        Categoria = categoria;
        ValorUnidadeMedida = valorUnidadeMedida;
        UnidadeDeMedida = unidadeDeMedida;
        Preco = preco;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        ValorUnidadeMedida = produtoAtualizado.ValorUnidadeMedida;
        UnidadeDeMedida = produtoAtualizado.UnidadeDeMedida;
        Preco = produtoAtualizado.Preco;

    }
}
