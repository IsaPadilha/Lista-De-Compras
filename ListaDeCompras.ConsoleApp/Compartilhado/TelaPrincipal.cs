using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;
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
        repositorioCategoria = new RepositorioCategoria();

        repositorioProduto = new RepositorioProduto();

        repositorioListaCompras = new RepositorioListaCompras();
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
