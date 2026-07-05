using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModuloCategoria;
using ListaDeCompras.ConsoleApp.Modulos.ModuloListaCompras;
using ListaDeCompras.ConsoleApp.Modulos.ModuloProduto;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITelaOpcoes? telaSelecionada = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (telaSelecionada == null)
        break;

    while (true)
    {
        string? opcaoMenuInterno = telaSelecionada.ObterOpcaoMenu();

        if (opcaoMenuInterno == "S")
            break;

        if (telaSelecionada is ITelaCrud telaBase)
        {
            if (opcaoMenuInterno == "1")
                telaBase.Cadastrar();

            else if (opcaoMenuInterno == "2")
                telaBase.Editar();

            else if (opcaoMenuInterno == "3")
                telaBase.Excluir();

            else if (opcaoMenuInterno == "4")
                telaBase.VisualizarTodos(true);

            if (telaBase is TelaListaCompras telaListaCompras)
            {
                if (opcaoMenuInterno == "S")
                    telaListaCompras.AdicionarItem();

                else if (opcaoMenuInterno == "6")
                    telaListaCompras.RemoverItem();

                else if (opcaoMenuInterno == "7")
                    telaListaCompras.VisualizarItens(true);
            }
        }
    }
}