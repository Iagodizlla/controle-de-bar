using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class FormularioProdutoViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo \"Nome\" precisa conter ao menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Nome\" precisa conter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo \"Valor\" é obrigatório.")]
    [DataType(DataType.Currency)]
    [Range(0, double.MaxValue,
        ErrorMessage = "O campo \"Valor\" precisa conter um valor positivo.")]
    public decimal Valor { get; set; }
}

public class CadastrarProdutoViewModel : FormularioProdutoViewModel
{
    public CadastrarProdutoViewModel() { }

    public CadastrarProdutoViewModel(string nome, decimal valor) : this()
    {
        Nome = nome;
        Valor = valor;
    }
}

public class EditarProdutoViewModel : FormularioProdutoViewModel
{
    public Guid Id { get; set; }

    public EditarProdutoViewModel() { }

    public EditarProdutoViewModel(Guid id, string nome, decimal valor) : this()
    {
        Id = id;
        Nome = nome;
        Valor = valor;
    }
}

public class ExcluirProdutoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirProdutoViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarProdutosViewModel
{
    public List<DetalhesProdutoViewModel> Registros { get; set; }

    public VisualizarProdutosViewModel(List<Produto> produtos)
    {
        Registros = new List<DetalhesProdutoViewModel>();

        foreach (var p in produtos)
            Registros.Add(p.ParaDetalhesVM());
    }
}

public class DetalhesProdutoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }

    public DetalhesProdutoViewModel(Guid id, string nome, decimal valor)
    {
        Id = id;
        Nome = nome;
        Valor = valor;
    }
}

public class SelecionarProdutoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelecionarProdutoViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}