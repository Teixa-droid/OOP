using System;
using System.Collections.Generic;
using System.Text;

namespace Escola
{
	public class Avaliacao
	{
		public Aluno aluno; //permite saber qual o aluno foi alvo da avaliacao
		public int momento;
		public int nota;

		public Avaliacao(Aluno aluno, int monento, int nota)
		{
			this.aluno = aluno;
			this.momento = momento;
			this.nota = nota;

		}
	}
}
