using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Pessoa
    {
        protected string nome;
        protected string email;

        public Pessoa()
        {
            nome = "";
            email = "";
        }

        public Pessoa(string nome, string email)
        {
            this.nome = nome;
            this.email = email;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public string GetNome()
        {
            return nome;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetEmail()
        {
            return email;
        }
    }
}
