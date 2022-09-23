using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.GeradorRelatorio.Pdfs;

namespace Pulsati.Core.Domain.Interfaces
{
    public interface IVariaveisRelatorioService<TEntity> where TEntity : class
    {
        public IReadOnlyCollection<VariavelRelatorioDTO<TEntity>> ObterTodasVariaveis();
        public string AplicarValorVariaveisNoTexto(TEntity entity, string texto);
        public void AplicarValorVariaveisNoPdf(TEntity entity, Pdf pdf);
    }
}
