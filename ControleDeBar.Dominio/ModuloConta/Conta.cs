using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloConta;

public class Conta : EntidadeBase<Conta>
{
    public string Titular { get; set; }
    public Mesa Mesa { get; set; }
    public Garcom Garcom { get; set; }
    public DateTime Abertura { get; set; }
    public DateTime Fechamento { get; set; }
    public bool EstaAberta { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Conta()
    {
        Pedidos = new List<Pedido>();
    }

    public Conta(string titular, Mesa mesa, Garcom garcom) : this()
    {
        Id = Guid.NewGuid();
        Titular = titular;
        Mesa = mesa;
        Garcom = garcom;

        Abrir();
    }

    public void Abrir()
    {
        EstaAberta = true;
        Abertura = DateTime.Now;

        Mesa.Ocupar();
    }

    public void Fechar()
    {
        EstaAberta = false;
        Fechamento = DateTime.Now;

        Mesa.Desocupar();
    }

    public Pedido RegistrarPedido(Produto produto, int quantidadeEscolhida)
    {
        Pedido novoPedido = new Pedido(produto, quantidadeEscolhida);

        Pedidos.Add(novoPedido);

        return novoPedido;
    }

    public Pedido RemoverPedido(Pedido pedido)
    {
        Pedidos.Remove(pedido);

        return pedido;
    }

    public Pedido RemoverPedido(Guid idPedido)
    {
        Pedido pedidoSelecionado = null;

        foreach (var p in Pedidos)
        {
            if (p.Id == idPedido)
                pedidoSelecionado = p;
        }

        if (pedidoSelecionado == null)
            return null;

        Pedidos.Remove(pedidoSelecionado);

        return pedidoSelecionado;
    }

    public decimal CalcularValorTotal()
    {
        decimal valorTotal = 0;

        foreach (var p in Pedidos)
            valorTotal += p.CalcularTotalParcial();

        return valorTotal;
    }

    public override void AtualizarRegistro(Conta registroAtualizado)
    {
        EstaAberta = registroAtualizado.EstaAberta;
        Fechamento = registroAtualizado.Fechamento;
    }
}