namespace Pulsati.Core.Domain.DTOs.Arquivos
{
    public class ConsultarExistenciaArquivosResultadoDTO
    {
        
        public bool TodoArquivosExistem { get; set; }
        public IEnumerable<ConsultarExistenciaArquivosResultadoItemDTO> ArquivosResultado { get; set; }
        public static ConsultarExistenciaArquivosResultadoDTO ObterConsultaDispensadaPorInexistenciaDeArquivo() => 
            new() { TodoArquivosExistem = true, ArquivosResultado = new List<ConsultarExistenciaArquivosResultadoItemDTO>() };
    }
}