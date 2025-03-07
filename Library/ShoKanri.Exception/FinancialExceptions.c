namespace ShoKanri.Exception
{
    public class ContaNaoEncontradaException : System.Exception
    {
        public ContaNaoEncontradaException() : base(MensagensDeErro.ContaNaoEncontrada) { }
    }

    public class SaldoInsuficienteException : System.Exception
    {
        public SaldoInsuficienteException() : base(MensagensDeErro.SaldoInsuficiente) { }
    }

    public class OperacaoInvalidaException : System.Exception
    {
        public OperacaoInvalidaException() : base(MensagensDeErro.OperacaoInvalida) { }
    }
}
