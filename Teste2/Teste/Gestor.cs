using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Gestor : Pessoa
    {
        private string nib;

        public Gestor()
        {
            nome = "";
            email = "";
            nib = "";
        }

        public Gestor(string nome, string email, string nib)
        {
            this.nome = nome;
            this.email = email;
            this.nib = nib;
        }

        public void SetNib(string nib)
        {
            this.nib = nib;
        }
        public string GetNib()
        {
            return nib;
        }

        public string Guardar()
        {
            return nome + ";" + email + ";" + nib;
        }

        public override string ToString()
        {
            return nome;
        }
    }
}
