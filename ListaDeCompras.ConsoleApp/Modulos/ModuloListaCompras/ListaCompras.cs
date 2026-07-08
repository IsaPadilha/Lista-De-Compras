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
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; }
    public StatusListaCompras Status { get; set; } = StatusListaCompras.Aberta;
    public List<ItemListaCompras> Itens { get; set; } = new List<ItemListaCompras>();

    public ListaCompras()
    {

    }

    public ListaCompras(string nome)
    {
        Id = GeradorIdsListaCompras.GerarId();
        Nome = nome;
        DataCriacao = DateTime.Now;
    }

    public void AdicionarItem(ItemListaCompras itemLista)
    {
        Itens.Add(itemLista);
    }

    public void RemoverItem(int idItemLista)
    {
        foreach (ItemListaCompras item in Itens)
        {
            if (item.Id == idItemLista)
            {
                Itens.Remove(item);

                return;
            }
        }
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        ListaCompras listaAtualizada = (ListaCompras)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
        Status = listaAtualizada.Status;
    }
}