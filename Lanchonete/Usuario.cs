using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete
{        namespace Lanchonete
    {
        public class Usuario { 
        
        
            private int _id;
            private string _nome;
            private string _email;
            private string _senha;
            private string _telefone;
            private string _cpf;
            private string _cep;
            private string _rua;
            private string _Bairro;
            private string _Numero_casa;

            public Usuario(string nome,
                           string email,
                           string senha,
                           string telefone,
                           string cpf)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                Cpf = cpf;
            }
            public Usuario(string Rua, string Bairro, string Numero,string cep)
            {
                _cep = cep;
                _rua = Rua;
                _Bairro = Bairro;
                _Numero_casa = Numero;

            }
            public Usuario(int id,string Rua, string Bairro, string Numero, string cep)
            {
                _id = id;
                _rua = Rua;
                _Bairro = Bairro;
                _Numero_casa = Numero;
                _cep = cep;
            }

            public Usuario(
                        int id,
                        string nome,
                        string email,
                        string senha,
                        string telefone,
                        string cpf)
            {
                Id = id;
                Nome = nome;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                Cpf = cpf;
            }

            //Propriedades
            public int Id
            {
                set { _id = value; }
                get { return _id; }
            }
            public string Nome
            {
                set {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Campo nome esta vazio");
                    _nome = value; }
                get { return _nome; }
            }
            public string Email
            {
                set {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Campo email esta vazio");
                    _email = value; }
              
                get { return _email; }
            }
            public string Senha
            {
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Campo senha esta vazio");
                    _senha = value; }
                get { return _senha; }
            }
            public string Telefone
            {
                set 
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Campo Telefone esra vazio");
                    _telefone = value; }
                get { return _telefone; }
            }
            public string Cpf
            {
                set {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("Campo CPF esta vazio");

                    _cpf = value; }
                get { return _cpf; }
            }
            public string rua
            {
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("PREENCHA O CAMPO rua ");

                    _rua = value;
                }
                get { return _rua; }

            }
            public string Bairro
            {
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("PREENCHA O CAMPO Bairro ");

                    _Bairro = value;
                }
                get { return _Bairro; }

            }
            public string Numero
            {
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("PREENCHA O CAMPO Numero da casa ");

                    _Numero_casa = value;
                }
                get { return _Numero_casa; }

            }
            public string cep
            {
                set
                {
                    if (string.IsNullOrEmpty(value))
                        throw new Exception("PREENCHA O CAMPO CEP ");

                    _cep = value;
                }
                get { return _cep; }

            }

        }
    }
}
  


    
