namespace FuncionariosApp.Validations
{
    public class NumeroContaValidation
    {
        private const int tamanhoParteInicial = 3;
        private const int tamanhoParteMeio = 10;
        private const int tamanhoParteFinal = 2;

        public bool IsValid(string numeroConta)
        {
            var primeiroDelimitador = numeroConta.IndexOf('-');
            var segundoDelimitador = numeroConta.LastIndexOf('-');

            if (primeiroDelimitador == -1 || primeiroDelimitador == segundoDelimitador)
                throw new ArgumentException();

            var parteInicial = numeroConta.Substring(0, primeiroDelimitador);

            if (parteInicial.Length != tamanhoParteInicial)
                return false;

            var parteTemporaria = numeroConta.Remove(0, tamanhoParteInicial + 1);
            var parteMeio = parteTemporaria.Substring(0, parteTemporaria.IndexOf('-'));

            if (parteMeio.Length != tamanhoParteMeio)
                return false;

            var parteFinal = numeroConta.Substring(segundoDelimitador + 1);

            if (parteFinal.Length != tamanhoParteFinal)
                return false;

            return true;
        }
    }
}
