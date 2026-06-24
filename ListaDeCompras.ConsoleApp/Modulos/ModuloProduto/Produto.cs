using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;

public enum UnidadeDeMedida
{
    Kg,
    Unidade,
    Litro,
    Caixa
}
public class Produto : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }

    public UnidadeDeMedida UnidadeDeMedida { get; private set; }

    public decimal Preco { get; private set; }

    public Produto(
        string nome,
        Categoria categoria,
        UnidadeDeMedida unidadeDeMedida,
        decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O Nome é obrigatório.");

        if (nome.Length < 2 || nome.Length > 100)
            throw new ArgumentException("O Nome deve ter entre 2 e 100 caracteres.");

        if (categoria == null)
            throw new ArgumentException("A Categoria é obrigatória.");

        if (preco <= 0)
            throw new ArgumentException("O Preço deve ser maior que 0.");

        Nome = nome;
        Categoria = categoria;
        UnidadeDeMedida = unidadeDeMedida;
        Preco = preco;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        UnidadeDeMedida = produtoAtualizado.UnidadeDeMedida;
        Preco = produtoAtualizado.Preco;

    }
}
