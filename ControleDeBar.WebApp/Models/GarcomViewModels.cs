using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class FormularioGarcomViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo \"Nome\" precisa conter ao menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Nome\" precisa conter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo \"CPF\" é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", 
        ErrorMessage = "O campo \"CPF\" precisa seguir o formato: 000.000.000-00.")]
    public string Cpf { get; set; }
}

public class CadastrarGarcomViewModel : FormularioGarcomViewModel
{
    public CadastrarGarcomViewModel() { }

    public CadastrarGarcomViewModel(string nome, string cpf) : this()
    {
        Nome = nome;
        Cpf = nome;
    }
}

public class EditarGarcomViewModel : FormularioGarcomViewModel
{
    public Guid Id { get; set; }

    public EditarGarcomViewModel() { }

    public EditarGarcomViewModel(Guid id, string nome, string cpf) : this()
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
    }
}

public class ExcluirGarcomViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirGarcomViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarGarconsViewModel
{
    public List<DetalhesGarcomViewModel> Registros { get; set; }

    public VisualizarGarconsViewModel(List<Garcom> garcons)
    {
        Registros = new List<DetalhesGarcomViewModel>();

        foreach (var g in garcons)
            Registros.Add(g.ParaDetalhesVM());
    }
}

public class DetalhesGarcomViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public DetalhesGarcomViewModel(Guid id, string nome, string cpf)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
    }
}

public class SelecionarGarcomViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarGarcomViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}