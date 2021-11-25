using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Escola
{
	public static class Disciplina
	{
		public static string nome;
		private static Turma turma;
		private static Avaliacao[] avaliacoes;
		private static int momentosAvaliacao;
		private static Random notas = new Random();


		//inicializa a classe , deve ser feita manualmente.

		public static void Init(string nome, Turma turma, int momentosAvaliacao)
		{


			Disciplina.nome = nome;
			Disciplina.turma = turma;
			Disciplina.momentosAvaliacao = momentosAvaliacao;
			// o numero de avaliacoes total é igual ao numero de alunos x navaliacoest
			Disciplina.avaliacoes = new Avaliacao[momentosAvaliacao * turma.nalunos];
			InicializarAvaliacoes();
			GerarAvaliacoesAleatorias();
		}

		/// <summary>
		/// obtem a avaliação de um aluno num determinado momento
		/// </summary>
		/// <param name="aluno"></param>
		/// <param name="momento"></param>
		/// <returns></returns>
		public static int ObterAvaliacaoAlunoPorMomento(Aluno aluno, int momento)
		{
			for (int i = 0; i < avaliacoes.Length; i++)
			{
				if (avaliacoes[i].aluno == aluno && avaliacoes[i].momento == momento)
				{
					
					return avaliacoes[i].nota;
				}
			}

			return 0;
		}

		/// <summary>
		/// obtem a média do aluno
		/// </summary>
		/// <param name="aluno"></param>
		/// <returns></returns>
		public static int ObterMediaAluno(Aluno aluno)
		{
			int[] notas = ObterAvaliacoesAluno(aluno);
			float soma = 0;
			for (int i = 0; i < notas.Length; i++)
			{
				soma += notas[i];

			}
			

			return (int)(soma / momentosAvaliacao);
		}
		/// <summary>
		/// obtem as avaliações dos diferentes momentos de um det aluno
		/// </summary>
		/// <param name="aluno"></param>
		/// <returns></returns>

		public static int[] ObterAvaliacoesAluno(Aluno aluno)
		{
			int[] notas = new int[momentosAvaliacao];
			for (int i = 0; i < momentosAvaliacao; i++)
			{

				 //Console.WriteLine("nota momento" + ObterAvaliacaoAlunoPorMomento(aluno, i + 1));
				notas[i] = ObterAvaliacaoAlunoPorMomento(aluno, i + 1);
			// Console.WriteLine("nota" + notas[i]);

			}

			return notas;
		}


		/// <summary>
		/// lista todas as notas da turma na disciplina
		/// 
		/// </summary>
		public static void ListarNotas()
		{

			Console.WriteLine("--------------- Lista Notas -----------");
			;
			for (int i = 0; i < avaliacoes.Length; i += momentosAvaliacao) //reparar que salta com um incremento do numero de momentos de avaliação
			{

				Console.WriteLine(" Aluno: {0} {1}", avaliacoes[i].aluno.pnome, avaliacoes[i].aluno.unome);
				Console.WriteLine(" momento1: " + avaliacoes[i].nota);
				Console.WriteLine(" momento2: " + avaliacoes[i + 1].nota);
				Console.WriteLine(" momento3: " + avaliacoes[i + 2].nota);
				Console.WriteLine("");

			}

			Console.WriteLine("--------------- FIM Lista Notas -----------");
		}


		private static void GerarAvaliacoesAleatorias()
		{

			//numero de momentos por aluno

			for (int i = 0; i < avaliacoes.Length; i += momentosAvaliacao)
			{

				for (int j = 0; j<momentosAvaliacao; j++)
				{
					avaliacoes[i+j].nota = notas.Next(0, 20); //-1 nota default ou seja nao foi inserida
					avaliacoes[i+j].momento = j;

				}

			}
		}


		private static void InicializarAvaliacoes() //cria o vetor e associa objetos de avaliacao por preencher
		{

			//numero de momentos por aluno
			var tempAlunos = turma.ObterAlunos();
			var indexAluno = 0;
			for (int i = 0; i < avaliacoes.Length; i += momentosAvaliacao)
			{

				avaliacoes[i] = new Avaliacao(tempAlunos[indexAluno], 1, -1); //-1 nota default ou seja nao foi inserida
				avaliacoes[i + 1] =new Avaliacao(tempAlunos[indexAluno], 2, -1); //-1 nota default ou seja nao foi inserida
				avaliacoes[i + 2] =new Avaliacao(tempAlunos[indexAluno], 3, -1); //-1 nota default ou seja nao foi inserida
				indexAluno++;

			}
		}

	

		public static void ListarMediasFinais()
		{
			var temp = turma.ObterAlunos();
			Console.WriteLine("--------------- Medias Finais---------------");
			for (int i = 0; i < turma.nalunos; i++)
			{
				float media = ObterMediaAluno(temp[i]);
				Console.WriteLine(" Aluno: {0} {1} CF:{2}", turma.ObterAlunos()[i].pnome, turma.ObterAlunos()[i].unome,
					media);
			}
			Console.WriteLine("--------------- FIM Medias Finais---------------");



		}
		public static void ListarNotasMinMax(int min, int max, int momento)
		{
			int[] notas;
			int conta = 0;
			for (int i = 0; i < avaliacoes.Length; i++)
			{
				if (avaliacoes[i]!=null && avaliacoes[i].nota >= min && avaliacoes[i].nota < max && avaliacoes[i].momento == momento)
				{

					Console.WriteLine("------ Lista Notas Entre {0} e {1} no momento {2} ", min, max, momento);
					Console.WriteLine("{0} {1} {2}", avaliacoes[i].aluno.pnome, avaliacoes[i].aluno.unome,
						avaliacoes[i].nota);
					conta++;
				}
				
			}

			if(conta==0) Console.WriteLine("não há registos com esses critérios");


			Console.WriteLine("------ Fim Lista Notas -----");

		}


		public static int ObterNumeroNegativas()
		{
			int conta = 0;
			var temp = turma.ObterAlunos();

			for (int i = 0; i < turma.nalunos; i++)
			{
				int media = (int)ObterMediaAluno(temp[i]);

				if (media >= 10) conta++;

			}
			return conta;
		}

		public static int ObterNumerPositivas()
		{

			int conta = 0;
			var temp = turma.ObterAlunos();

			for (int i = 0; i < turma.nalunos; i++)
			{
				int media = (int)ObterMediaAluno(temp[i]);
				if (media < 10) conta++;

			}
			Console.WriteLine("positivas"+conta);
			return conta++;


		}
		public static float ObterPercentagemPositivas()
		{
			
			return (float)ObterNumerPositivas() / (float) turma.nalunos;
		}



		public static float ObterPercentagemNegativas()
		{
			return (float)ObterNumeroNegativas() / (float)turma.nalunos;
		}


	






	}
}
