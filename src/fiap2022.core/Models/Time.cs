//using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace fiap2022.core.Models
{
    public class Time
    {
        public int Id { get; set; }

        //[Remote(action:"VerificaNome", controller:"Time")]
        public string? Nome { get; set; }
        
        [Required(ErrorMessage ="Coloca a bandeira do time ai, please")]
        public string Bandeira{ get; set; }
        public string Continent { get; set; }
        public bool Publicado { get; set; }
        
        public List<Jogador>? Jogadores { get; set; }
      
    }
}
