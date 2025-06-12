using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WebApp.Models;

namespace ControleDeBar.WebApp.Extensions;

public static class MesaExtensions
{
    public static Mesa ParaEntidade(this FormularioMesaViewModel formularioVM)
    {
        return new Mesa(formularioVM.Numero, formularioVM.Capacidade);
    }

    public static DetalhesMesaViewModel ParaDetalhesVM(this Mesa mesa)
    {
        return new DetalhesMesaViewModel(
                mesa.Id,
                mesa.Numero,
                mesa.Capacidade
        );
    }
}