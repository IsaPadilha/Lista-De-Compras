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
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public int ValorUnidadeMedida { get; set; }
    public UnidadeDeMedida UnidadeDeMedida { get; set; }
    public decimal Preco { get; set; }

    public Produto()
    {

    }

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

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" deve ser preenchido.");

        if (ValorUnidadeMedida == 0)
            erros.Add("O campo \"Valor da Unidade de Medida\" não pode conter o valor zero.");

        if (!Enum.IsDefined(UnidadeDeMedida))
            erros.Add("O campo \"Unidade de Medida\" deve conter uma seleção permitida (Unidade, Caixa, Dúzia, Kg, L, ml, g).");

        if (Preco == 0)
            erros.Add("O campo \"Preço\" não pode conter o valor zero.");

        return erros;
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
