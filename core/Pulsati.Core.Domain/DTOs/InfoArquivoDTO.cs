﻿namespace Pulsati.Core.Domain.DTOs
{
    public class InfoArquivoDTO
    {
        public InfoArquivoDTO()
        {

        }
        public InfoArquivoDTO(string pasta, string nome, string extensao)
        {
            Pasta = pasta;
            Nome = nome;
            Extensao = extensao;
        }

        public string Pasta { get; set; }
        public string Nome { get; set; }
        public string Extensao { get; set; }

        public string DiretorioVirtualCompleto { get { return Pasta + Nome; } }
    }
}
