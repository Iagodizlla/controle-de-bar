namespace ControleDeBar.Dominio.ModuloConta;

public interface IRepositorioConta
{
    void CadastrarConta(Conta conta);
    Conta SelecionarPorId(Guid idRegistro);
    List<Conta> SelecionarContas();
    List<Conta> SelecionarContasAbertas();
    List<Conta> SelecionarContasFechadas();
}