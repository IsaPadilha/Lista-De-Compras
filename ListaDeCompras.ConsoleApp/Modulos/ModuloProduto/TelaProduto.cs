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
            "{0, -7} | {1, -20} | {2, -20} | {3, -10} | {4, -17}",
            "Id", "Nome", "Categoria", "Unidade", "Preço"
        );

        EntidadeBase[] registros = repositorioProduto.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Produto p = (Produto)registros[i];

            if (p == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -10} | {4, -17}",
                p.Id,
                p.Nome,
                p.Categoria.Nome,
                string.Join(" ", p.ValorUnidadeMedida, p.UnidadeDeMedida),
                p.Preco.ToString("C2")
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

        VisualizarCategorias();

        Console.WriteLine("---------------------------------");

        Console.Write("Digite o ID da categoria do produto: ");
        int idCategoria = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Categoria? categoriaSelecionada = (Categoria?)repositorioCategoria.SelecionarPorId(idCategoria)!;

        Console.WriteLine("---------------------------------");
        Console.Write("Informe o valor/quantidade da unidade de medida do produto: ");
        int valorUnidadeMedida = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Selecione uma unidade de medida disponível para o produto");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Kg");
        Console.WriteLine("2 - Unidade");
        Console.WriteLine("3 - Duzia");
        Console.WriteLine("4 - Ml");
        Console.WriteLine("5 - G");
        Console.WriteLine("6 - Litro");
        Console.WriteLine("7 - Caixa");
        Console.WriteLine("---------------------------------");
        Console.Write("Informe a unidade de medida escolhida: ");
        string? escolha = Console.ReadLine();

        UnidadeDeMedida unidade;

        switch (escolha)
        {
            case "1":
                unidade = UnidadeDeMedida.Kg;
                break;
            case "2":
                unidade = UnidadeDeMedida.Unidade;
                break;
            case "3":
                unidade = UnidadeDeMedida.Duzia;
                break;
            case "4":
                unidade = UnidadeDeMedida.Ml;
                break;
            case "5":
                unidade = UnidadeDeMedida.G;
                break;
            case "6":
                unidade = UnidadeDeMedida.Litro;
                break;
            case "7":
                unidade = UnidadeDeMedida.Caixa;
                break;

            default:
                unidade = UnidadeDeMedida.Unidade;
                break;
        }

        Console.WriteLine("Informe o preço aproximado: ");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        return new Produto(
        nome!,
        categoriaSelecionada!,
        valorUnidadeMedida,
        unidade,
        preco);
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(EntidadeBase entidade, int? idIgnorado = null)
    {
        Produto produto = (Produto)entidade;

        EntidadeBase[] produtos = repositorioProduto.SelecionarTodos();

        for (int i = 0; i < produtos.Length; i++)
        {
            Produto p = (Produto)produtos[i];

            if (p == null)
                continue;

            if (
                p.Id != idIgnorado &&
                p.Nome.ToLower() == produto.Nome.ToLower() &&
                p.Categoria == produto.Categoria
            )
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe um produto com o nome {p.Nome}na ategoria!");
                Console.WriteLine("---------------------------------");

                return true;
            }
        }
        return base.ExisteRegistroComInformacoesExclusivas(entidade, idIgnorado);
    }

    private void VisualizarCategorias()
    {
        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        EntidadeBase[] registros = repositorioCategoria.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Categoria c = (Categoria)registros[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }
    }
}

