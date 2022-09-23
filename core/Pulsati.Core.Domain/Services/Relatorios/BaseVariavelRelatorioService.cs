using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Interfaces;
using Pulsati.Core.GeradorRelatorio.Pdfs;
using Pulsati.Core.GeradorRelatorio.Pdfs.Enums;

namespace Pulsati.Core.Domain.Services.Relatorios
{
    public abstract class BaseVariavelRelatorioService<TRelatorioModel> : IVariaveisRelatorioService<TRelatorioModel> where TRelatorioModel : class
    {
        
        public abstract IReadOnlyCollection<VariavelRelatorioDTO<TRelatorioModel>> ObterTodasVariaveis();
        
        public string AplicarValorVariaveisNoTexto(TRelatorioModel entity, string texto)
        {
            var variaveis = ObterTodasVariaveis();
            foreach (var variavel in variaveis)
            {
                if (texto.Contains(variavel.NomeFormatado))
                {
                    var valorVariavel = variavel.Valor.Invoke(entity);
                    texto = texto.Replace(variavel.NomeFormatado, valorVariavel);
                }
            }

            return texto;
        }

        public void AplicarValorVariaveisNoPdf(TRelatorioModel entity, Pdf pdf)
        {
            var pdfCabecalho = pdf.Cabecalho;
            AplicarValorDeVariavelEmPdfItem(entity, pdfCabecalho);
            foreach (var paginas in pdf.PdfPaginas)
                foreach (var item in paginas.PdfItems)
                    AplicarValorDeVariavelEmPdfItem(entity, item);
            

        }

        private void AplicarValorDeVariavelEmPdfItem(TRelatorioModel entity, PdfItem pdfItem)
        {
            if (pdfItem.TipoPdfItem == ETipoConteudoPdfItem.Texto)
                pdfItem.ConteudoTexto.Texto = AplicarValorVariaveisNoTexto(entity, pdfItem.ConteudoTexto.Texto);
          
            else if (pdfItem.TipoPdfItem == ETipoConteudoPdfItem.Tabela)
                AplicarValorDeVariavelEmTabela(entity, pdfItem.ConteudoTabela);
        }

        private void AplicarValorDeVariavelEmTabela(TRelatorioModel entity, ConteudoTabela conteudoTabela)
        {
            foreach (var tr in conteudoTabela.ConteudotabelaTrs)
            {
                foreach (var td in tr.ConteudoTabelaTrTds)
                {
                    if (td.TipoConteudoPdfItem == ETipoConteudoTd.Texto)
                        td.ConteudoTexto.Texto = AplicarValorVariaveisNoTexto(entity, td.ConteudoTexto.Texto);
                }
            }
        }
    }
}
