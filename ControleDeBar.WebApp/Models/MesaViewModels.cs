using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public abstract class FormularioMesaViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [Range(1, 100, ErrorMessage = "O campo \"Nome\" precisa conter um valor entre 1 e 100.")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "O campo \"Capacidade\" é obrigatório.")]
    [Range(1, 100, ErrorMessage = "O campo \"Capacidade\" precisa conter um valor entre 1 e 100.")]
    public int Capacidade { get; set; }
}

public class CadastrarMesaViewModel : FormularioMesaViewModel
{
    public CadastrarMesaViewModel() { }

    public CadastrarMesaViewModel(int numero, int capacidade) : this()
    {
        Numero = numero;
        Capacidade = capacidade;
    }
}

public class EditarMesaViewModel : FormularioMesaViewModel
{
    public Guid Id { get; set; }

    public EditarMesaViewModel() { }

    public EditarMesaViewModel(Guid id, int numero, int capacidade) : this()
    {
        Id = id;
        Numero = numero;
        Capacidade = capacidade;
    }
}

public class ExcluirMesaViewModel
{
    public Guid Id { get; set; }
    public int Numero { get; set; }

    public ExcluirMesaViewModel() { }

    public ExcluirMesaViewModel(Guid id, int numero) : this()
    {
        Id = id;
        Numero = numero;
    }
}

public class VisualizarMesasViewModel
{
    public List<DetalhesMesaViewModel> Registros { get; }

    public VisualizarMesasViewModel(List<Mesa> mesas)
    {
        Registros = [];

        foreach (var m in mesas)
        {
            var detalhesVM = m.ParaDetalhesVM();

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesMesaViewModel
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public int Capacidade { get; set; }

    public DetalhesMesaViewModel(Guid id, int numero, int capacidade)
    {
        Id = id;
        Numero = numero;
        Capacidade = capacidade;
    }
}

public class SelecionarMesaViewModel
{
    public Guid Id { get; set; }
    public int Numero { get; set; }

    public SelecionarMesaViewModel(Guid id, int numero)
    {
        Id = id;
        Numero = numero;
    }
}