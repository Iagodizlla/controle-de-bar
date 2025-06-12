using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.ModuloConta;

public class RepositorioContaEmArquivo : IRepositorioConta
{
    private readonly ContextoDados contexto;
    protected readonly List<Conta> registros;

    public RepositorioContaEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;
        registros = contexto.Contas;
    }

    public void CadastrarConta(Conta novaConta)
    {
        registros.Add(novaConta);

        contexto.Salvar();
    }

    public Conta SelecionarPorId(Guid idRegistro)
    {
        foreach (var item in registros)
        {
            if (item.Id == idRegistro)
                return item;
        }

        return null;
    }


    public List<Conta> SelecionarContas()
    {
        return registros;
    }

    public List<Conta> SelecionarContasAbertas()
    {
        var contasAbertas = new List<Conta>();

        foreach (var item in registros)
        {
            if (item.EstaAberta)
                contasAbertas.Add(item);
        }

        return contasAbertas;
    }

    public List<Conta> SelecionarContasFechadas()
    {
        var contasFechadas = new List<Conta>();

        foreach (var item in registros)
        {
            if (!item.EstaAberta)
                contasFechadas.Add(item);
        }

        return contasFechadas;
    }
}