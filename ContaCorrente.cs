

namespace ByteBank
{
    class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        private double _saldo; //Utiliza '_' para dizer que o objeto é privado

        public double Saldo {
            get { return _saldo; }
            set { _saldo = value; } 
        }
        public static int TotaldeContasCriadas { get; private set; } //static significa que pertence a classe e não ao objeto

        public ContaCorrente(int agencia, int conta)
        {
            Agencia = agencia;
            Conta = conta;

            ContaCorrente.TotaldeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (this._saldo < valor)
            { return false; }
            else
            {
                this._saldo -= valor;
                return true;
            }
        }

        public void Depositar(double valor)
        { this._saldo += valor; }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this._saldo < valor)
            { return false; }
            else {
                this._saldo -= valor;
                contaDestino.Depositar(valor);
                return true;
            }
        }
    }
}

