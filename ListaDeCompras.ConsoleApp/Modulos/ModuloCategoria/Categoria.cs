using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;

public static class GeradorIdsCategoria
{
    private static int contadorIds = 1;
    public static int GerarId()
    {
        return contadorIds++;
    }
}

public enum CorCategoria
{
    Branco,
    Vermelho,
    Verde,
    Azul
}

public class Categoria : EntidadeBase
{
    public string Nome { get; set; }
    public CorCategoria Cor { get; set; }

    public Categoria()
    {

    }

    public Categoria(string nome, CorCategoria cor)
    {
        Id = GeradorIdsCategoria.GerarId();

        Nome = nome;
        Cor = cor;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }
}
