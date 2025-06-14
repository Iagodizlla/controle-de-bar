using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models;

public class AbrirContaViewModel
{
    [Required(ErrorMessage = "O campo \"Titular\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo \"Titular\" precisa conter ao menos 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Titular\" precisa conter no máximo 100 caracteres.")]
    public string Titular { get; set; }

    [Required(ErrorMessage = "O campo \"Mesa\" é obrigatório.")]
    public Guid MesaId { get; set; }
    public List<SelectListItem> MesasDisponiveis { get; set; }

    [Required(ErrorMessage = "O campo \"Garçom\" é obrigatório.")]
    public Guid GarcomId { get; set; }
    public List<SelectListItem> GarconsDisponiveis { get; set; }

    public AbrirContaViewModel()
    {
        MesasDisponiveis = new List<SelectListItem>();
        GarconsDisponiveis = new List<SelectListItem>();
    }

    public AbrirContaViewModel(List<Mesa> mesas, List<Garcom> garcons) : this()
    {
        foreach (var m in mesas)
        {
            var mesaDisponivel = new SelectListItem(m.Numero.ToString(), m.Id.ToString());

            MesasDisponiveis.Add(mesaDisponivel);
        }

        foreach (var g in garcons)
        {
            var nomeDisponivel = new SelectListItem(g.Nome.ToString(), g.Id.ToString());

            GarconsDisponiveis.Add(nomeDisponivel);
        }
    }
}

public class FecharContaViewModel
{
    public Guid Id { get; set; }
    public string Titular { get; set; }
    public int Mesa { get; set; }
    public string Garcom { get; set; }
    public decimal ValorTotal { get; set; }

    public FecharContaViewModel(Guid id, string titular, int mesa, string garcom, decimal valorTotal)
    {
        Id = id;
        Titular = titular;
        Mesa = mesa;
        Garcom = garcom;
        ValorTotal = valorTotal;
    }
}

public class VisualizarContasViewModel
{
    public List<DetalhesContaViewModel> Registros { get; set; }

    public VisualizarContasViewModel(List<Conta> contas)
    {
        Registros = new List<DetalhesContaViewModel>();

        foreach (var g in contas)
            Registros.Add(g.ParaDetalhesVM());
    }
}

public class DetalhesContaViewModel
{
    public Guid Id { get; set; }
    public string Titular { get; set; }
    public int Mesa { get; set; }
    public string Garcom { get; set; }
    public bool EstaAberta { get; set; }
    public decimal ValorTotal { get; set; }
    public List<PedidoContaViewModel> Pedidos { get; set; }

    public DetalhesContaViewModel(
        Guid id,
        string titular,
        int mesa,
        string garcom,
        bool estaAberta,
        decimal valorTotal,
        List<Pedido> pedidos
    )
    {
        Id = id;
        Titular = titular;
        Mesa = mesa;
        Garcom = garcom;
        EstaAberta = estaAberta;
        ValorTotal = valorTotal;

        Pedidos = new List<PedidoContaViewModel>();

        foreach (var item in pedidos)
        {
            var pedidoVM = new PedidoContaViewModel(
                item.Id,
                item.Produto.Nome,
                item.QuantidadeSolicitada,
                item.CalcularTotalParcial()
            );

            Pedidos.Add(pedidoVM);
        }
    }
}

public class PedidoContaViewModel
{
    public Guid Id { get; set; }
    public string Produto { get; set; }
    public int QuantidadeSolicitada { get; set; }
    public decimal TotalParcial { get; set; }

    public PedidoContaViewModel(Guid id, string produto, int quantidadeSolicitada, decimal totalParcial)
    {
        Id = id;
        Produto = produto;
        QuantidadeSolicitada = quantidadeSolicitada;
        TotalParcial = totalParcial;
    }
}

public class GerenciarPedidosViewModel
{
    public DetalhesContaViewModel Conta { get; set; }
    public List<SelectListItem> Produtos { get; set; }

    public GerenciarPedidosViewModel() { }

    public GerenciarPedidosViewModel(Conta conta, List<Produto> produtos) : this()
    {
        Conta = conta.ParaDetalhesVM();

        Produtos = new List<SelectListItem>();

        foreach (var p in produtos)
        {
            var selectItem = new SelectListItem(p.Nome, p.Id.ToString());

            Produtos.Add(selectItem);
        }
    }
}

public class AdicionarPedidoViewModel
{
    public Guid IdProduto { get; set; }
    public int QuantidadeSolicitada { get; set; }
}

public class FaturamentoViewModel
{
    public List<DetalhesContaViewModel> Registros { get; set; }
    public decimal Total { get; set; }

    public FaturamentoViewModel(List<Conta> contas)
    {
        Registros = new List<DetalhesContaViewModel>();

        foreach (var c in contas)
        {
            Total += c.CalcularValorTotal();

            Registros.Add(c.ParaDetalhesVM());
        }
    }
}