using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloGarcom;

public class Garcom : EntidadeBase<Garcom>
{
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public Garcom() { }

    public Garcom(string nome, string cpf) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Cpf = cpf;
    }

    public override void AtualizarRegistro(Garcom registroEditado)
    {
        Nome = registroEditado.Nome;
        Cpf = registroEditado.Cpf;
    }
}
