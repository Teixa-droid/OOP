using System;
using System.Collections.Generic;
using System.Text;

namespace Escola
{

	public class Turma
	{
		public string nome { get; set; }
		public int  ano { get; set; }
		public int nalunos //propriedade que retorna o length do vetor alunos
		{
			get { return alunos.Length; }
		}

		private Aluno[] alunos; //proteger o array de alunos e aceder via métodos

		public Turma(int ano, string nome, int nAlunos)
		{
			this.nome = nome;
			this.ano = ano;
			GerarAlunos(nAlunos);

		}

		public void ImprimirAlunosTurma()
		{
			Console.WriteLine("----------- Lista Alunos------------");
			for (int i = 0; i < alunos.Length; i++)
			{
				
				Console.WriteLine("{0} {1}",alunos[i].pnome,alunos[i].unome);

			}
			Console.WriteLine("----------- Fim Alunos------------");

		}
		private void GerarAlunos(int nAlunos)
		{
			alunos=new Aluno[nAlunos];

			for (int i = 0; i < nAlunos; i++)
			{
				alunos[i]=new Aluno(); //gera um aluno aleatorio e guarda no vetor
			}


		}

		private int ObterIndexAluno(int idAluno) //obtem index no vetor
		{
			for (int i = 0; i < alunos.Length; i++)
			{
				if (alunos[i].id == idAluno)
				{
					return i;
				}
			}

			return -1;
		}


		public  Aluno ObterAlunoPeloNumero(int id) //obter aluno pelo numero
		{
			for (int i = 0; i < alunos.Length; i++)
			{
				if (alunos[i].id == id)
				{
					return alunos[i];
				}
			}

			return null;

		}

		public Aluno[]ObterAlunos() //retorna todo o vetor
		{
			return alunos;
		}

	}
}
