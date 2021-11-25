using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola
{
	public class Aluno
	{
		public int id; // o id do aluno nao corresponde ao index no vetor
		public string pnome;
		public string unome;
		public DateTime dataNascimento;
		public string contato; //opcional
		private static Random random = new Random(); 
		//o random deve ser so inicializado uma vez caso contrario gera sempre o mesmo valor para diferentes instancias
		//potenciais nomes para gerar aleatoriamente
		private string[] pnomes = new string[8] { "Joao", "Jose", "Maria", "Rita", "Marco", "Alexandra","Ana","Jaime" };
		private string[] unomes = new string[8] { "Soares", "Freitas", "Fins", "Martins", "Sousa", "Freixo","Forgoes","Maciel" };

		public Aluno() //construtor sem parametros para gerar valores aleatoroios
		{
		
			this.id = random.Next(1000, 9999);
			int numero = random.Next(0, 8);
			int numero2 = random.Next(0, 8);
			this.pnome = pnomes[numero];
			this.unome = unomes[numero2];
			this.dataNascimento = ObterDataAleatória();

		}
		public Aluno(int id, string nome, string unome, string contato) : this() // sobrecarga do construtor
		{

			this.id = id;
			this.pnome = nome;
			this.unome = unome;
			this.contato = contato;
			// a data nascimento continua aleatoria

		}




		DateTime ObterDataAleatória() //método que gera uma data aleatória e guarda na data nascimento
		{
			
			DateTime dataInicio = new DateTime(1980, 1, 1);
			int intervalo = (DateTime.Today - dataInicio).Days; //determina os dias da data do inicio até hoje
			//acrescenta x dias à data de inicio e gera assim uma data nova
			return dataInicio.AddDays(random.Next(intervalo));

		}

	}
}

