using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;

public static class GeradorIdsListaCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}

public enum StatusListaCompras
{
    Aberta,
    Concluida
}

public class ListaCompras : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusListaCompras Status { get; private set; } = StatusListaCompras.Aberta;

    public ListaCompras(string nome)
    {
        Id = GeradorIdsListaCompras.GerarId();
        Nome = nome;
        DataCriacao = DateTime.Now;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        ListaCompras listaAtualizada = (ListaCompras)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
        Status = listaAtualizada.Status;
    }
}