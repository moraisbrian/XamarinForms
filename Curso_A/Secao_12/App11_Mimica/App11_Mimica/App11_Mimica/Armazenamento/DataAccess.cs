using App11_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App11_Mimica.Armazenamento
{
    public class DataAccess
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }

        public static string[][] Palavras =
        {
            // Fácil
            new string[] { "Olho", "Língua", "Chinelo", "Milho", "Penalti", "Bola", "Ping-pong" },

            // Médio
            new string[] { "Carpinteiro", "Amarelo", "Limão", "Abelha" },

            // Difícil
            new string[] { "Cisterna", "Lanterna", "Batman vs Superman", "Notebook" }
        };
    }
}
