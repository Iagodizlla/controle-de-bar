using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WebApp.Models;

namespace ControleDeBar.WebApp.Extensions;

public static class GarcomExtensions
{
    public static Garcom ParaEntidade(this FormularioGarcomViewModel formularioVM)
    {
        return new Garcom(formularioVM.Nome, formularioVM.Cpf);
    }

    public static DetalhesGarcomViewModel ParaDetalhesVM(this Garcom garcom)
    {
        return new DetalhesGarcomViewModel(
                garcom.Id,
                garcom.Nome,
                garcom.Cpf
        );
    }
}