using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloProduto;

public class Produto : EntidadeBase<Produto>
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }

    public Produto() { }

    public Produto(string nome, decimal valor) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Valor = valor;
    }

    public override void AtualizarRegistro(Produto registroEditado)
    {
        Nome = registroEditado.Nome;
        Valor = registroEditado.Valor;
    }
}