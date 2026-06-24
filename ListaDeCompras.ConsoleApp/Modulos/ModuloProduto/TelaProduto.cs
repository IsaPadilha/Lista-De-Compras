using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;

public class TelaProduto : TelaBase, ITelaOpcoes
{
    private readonly RepositorioProduto repositorioProduto;
    private readonly RepositorioCategoria repositorioCategoria;
    public TelaProduto(
        RepositorioProduto repositorioProduto,
        RepositorioCategoria repositorioCategoria) : base("Produto", repositorioProduto)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Produto");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4}",
            "Id", "Nome", "Categoria", "Unidade", "Preço"
        );

        EntidadeBase[] produtos = repositorioProduto.SelecionarTodos();

        for (int i = 0; i < produtos.Length; i++)
        {
            Produto p = (Produto)produtos[i];

            if (p == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -25} | {2, -6} | {3, -4}",
                p.Id,
                p.Nome,
                p.Categoria,
                p.UnidadeDeMedida,
                p.Preco
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Selecione a categoria do produto: ");
        Console.WriteLine("---------------------------------");

        EntidadeBase[] categorias = repositorioCategoria.SelecionarTodos();
        foreach (Categoria c in categorias)
        {
            Console.WriteLine($"{c.Id} - {c.Nome}");
        }

        Console.Write("Digite o ID da categoria: ");
        int idCategoria = Convert.ToInt32(Console.ReadLine());
        Categoria categoriaSelecionada = (Categoria)repositorioCategoria.SelecionarPorId(idCategoria)!;

        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Kg");
        Console.WriteLine("2 - Unidade");
        Console.WriteLine("3 - Litro");
        Console.WriteLine("4 - Caixa");
        Console.WriteLine("---------------------------------");
        string escolha = Console.ReadLine()!;

        UnidadeDeMedida unidade = UnidadeDeMedida.Unidade;

        switch (escolha)
        {
            case "1":
                unidade = UnidadeDeMedida.Kg;
                break;
            case "2":
                unidade = UnidadeDeMedida.Unidade;
                break;
            case "3":
                unidade = UnidadeDeMedida.Litro;
                break;
            case "4":
                unidade = UnidadeDeMedida.Caixa;
                break;
        }
        Console.WriteLine("Informe o preço aproximado: ");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        return new Produto(nome,
        categoriaSelecionada,
        unidade,
        preco);
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(EntidadeBase entidade, int? idIgnorado = null)
    {
        Produto novoProduto = (Produto)entidade;
        EntidadeBase[] produtos = repositorioProduto.SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (p == null) continue;

            if (idIgnorado != p.Id || p.Nome == novoProduto.Nome || p.Categoria.Id == novoProduto.Categoria.Id)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe um produto chamado \"{p.Nome}\" na categoria \"{p.Categoria.Nome}\"!");
                Console.WriteLine("---------------------------------");
                return true;
            }
        }

        return base.ExisteRegistroComInformacoesExclusivas(entidade);
    }
}

