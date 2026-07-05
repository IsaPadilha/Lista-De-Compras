using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;
using ListaDeCompras.ConsoleApp.Modulos.ModuloItemListaCompras;
using ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;
using ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly RepositorioCategoria repositorioCategoria;
    private readonly RepositorioProduto repositorioProduto;
    private readonly RepositorioListaCompras repositorioListaCompras;
    public TelaPrincipal()
    {
        Categoria categoriaTeste = new Categoria("Produtos de Limpeza", CorCategoria.Vermelho);

        repositorioCategoria = new RepositorioCategoria();
        repositorioCategoria.Cadastrar(categoriaTeste);

        Produto produtoTeste = new Produto(
            "Detergente Limpol",
            categoriaTeste,
            1,
            UnidadeDeMedida.Litro,
            18.50m);

        repositorioProduto = new RepositorioProduto();
        repositorioProduto.Cadastrar(produtoTeste);

        ListaCompras listaTeste = new ListaCompras("Compras do Mês");
        listaTeste.AdicionarItem(new ItemListaCompras(produtoTeste, 3));

        repositorioListaCompras = new RepositorioListaCompras();
        repositorioListaCompras.Cadastrar(listaTeste);

    }

    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista De Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar lista de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria, repositorioProduto);

        if (opcaoMenuPrincipal == "2")
            return new TelaProduto(repositorioProduto, repositorioCategoria);

        if (opcaoMenuPrincipal == "3")
            return new TelaListaCompras(repositorioListaCompras, repositorioProduto);

        return null;
    }
}
