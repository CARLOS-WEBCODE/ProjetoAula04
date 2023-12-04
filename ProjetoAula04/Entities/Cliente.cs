using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula04.Entities
{
    /// <summary>
    /// Classe de entidade
    /// </summary>
    public class Cliente
    {
        public Guid IdCliente { get; set; }

        private string _nome; //atribute
        public string Nome 
        {
            get => _nome; //retornando o valor do atributo 
            set //receber o valor do campo
            {
                //validar se o nome está vazio
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Nome do cliente é obrigatório.");

                //validar se o nome possui de 10 a 150 caracteres
                else if (value.Length < 10 || value.Length > 150)
                    throw new ArgumentException("Nome do cliente dev ter de 10 a 150 caracteres.");

                else
                    _nome = value; //armazenando o valor recebido
            }
        }

        private string _cpf; //atributo
        public string Cpf 
        {
            get => _cpf; //retornando o valor do atributo; 
            set
            {
                //validar se o cpf está vazio
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("CPF do cliente é obrigatório.");

                //validar se i cpf possui 11 digítos numericos
                else if (!new Regex("^[0-9]{11}$").IsMatch(value))
                    throw new ArgumentException("CPF deve ter exatamente 11 dígitos númericos.");

                else
                    _cpf = value; //armazenando o valor recebido
            }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento 
        { 
            get => _dataNascimento;
            set
            {
                //Não permitir clientes menores de idade
                var idade = DateTime.Now.Year - value.Year;

                if (DateTime.Now.DayOfYear < value.DayOfYear)
                    idade--;

                if (idade < 18)
                    throw new ArgumentException("O cliente deve ser maior de idade.");

                else
                    _dataNascimento = value;
            }
        }
    }
}
