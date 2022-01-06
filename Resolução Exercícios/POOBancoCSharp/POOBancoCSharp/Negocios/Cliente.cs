using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POOBancoCSharp
{
    class Cliente
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }

        public Cliente()
        {
            codigo = 0;
            nome = "";
            endereco = "";
            email = "";
        }

        public Cliente(int codigo,string nome,string endereco,string email)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.endereco = endereco;
            this.email = email;
        }     
    }
}
