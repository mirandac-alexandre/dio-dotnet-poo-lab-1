using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	public class Conta
	{
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}

		public void AumentarCredito(double novoLimite)
		{
			//valida se saldo e crédito não são negativos
			//limita o aumento de crédito para o dobro do crédito atual
			if((this.Saldo < 0 || this.Credito < 0))
			{
				Console.WriteLine("Saldo ou créditos atuais da conta estão negativados!");
				Console.WriteLine("Saldo atual da conta de {0} é {1} e seu crédito é de {2}.", this.Nome, this.Saldo, this.Credito);
			}
			
			else if(novoLimite > Credito * 2 )
			{
				Console.WriteLine("O novo valor de crédito não pode ser o dobro do atual!");
				Console.WriteLine("Saldo atual da conta de {0} é {1} e seu crédito é de {2}.", this.Nome, this.Saldo, this.Credito);
			}

			else
			{
				this.Credito=novoLimite;
				Console.WriteLine("Limite de crédito da conta {0} aumentado para {1}.", this.Nome, this.Credito);
			}
		}
	}
}