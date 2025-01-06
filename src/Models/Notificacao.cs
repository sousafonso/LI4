using System;

namespace LI4.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public bool Lida { get; set; } // maybe not usable

        public Notificacao(int id, string mensagem, DateTime data, bool lida = false)
        {
            Id = id;
            Mensagem = mensagem;
            Data = data;
            Lida = lida;
        }

        public void MarcarComoLida()
        {
            Lida = true;
        }

        public override string ToString()
        {
            return $"Notificacao(Id: {Id}, Mensagem: {Mensagem}, Data: {Data}, Lida: {Lida})";
        }
    }
}