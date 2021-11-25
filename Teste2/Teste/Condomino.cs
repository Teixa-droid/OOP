using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Condomino:Pessoa
    {
        private string apartamento;

        public Condomino()
        {
            nome = "";
            email = "";
            apartamento = "";
        }

        public Condomino(string nome, string email, string apartamento)
        {
            this.nome = nome;
            this.email = email;
            this.apartamento = apartamento;
        }

        public void SetApartamento(string apartamento)
        {
            this.apartamento = apartamento;
        }
        public string GetApartamento()
        {
            return apartamento;
        }
        public string Guardar()
        {
            return nome + ";" + email + ";" + apartamento;
        }
        public override string ToString()
        {
            return nome + " - " + apartamento;
        }
    }
}
