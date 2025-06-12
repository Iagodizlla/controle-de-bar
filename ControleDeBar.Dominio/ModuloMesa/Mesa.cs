using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloMesa;

public class Mesa : EntidadeBase<Mesa>
{
    public int Numero { get; set; }
    public int Capacidade { get; set; }

    public Mesa() { }

    public Mesa(int numero, int quantidadeDeAssentos) : this()
    {
        Id = Guid.NewGuid();
        Numero = numero;
        Capacidade = quantidadeDeAssentos;
    }

    public override void AtualizarRegistro(Mesa registroEditado)
    {
        Numero = registroEditado.Numero;
        Capacidade = registroEditado.Capacidade;
    }
}