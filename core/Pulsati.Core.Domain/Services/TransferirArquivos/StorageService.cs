using EasyNetQ;
using Newtonsoft.Json;
using Pulsati.Core.Domain.Bus.MessagesDTO.Storage;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.DTOs.Arquivos;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Helpers.Extensions;
using Pulsati.Core.Domain.Singletons.Ambiente;
using System.Text;

namespace Pulsati.Core.Domain.Services.TransferirArquivos
{
    public class StorageService : IDisposable
    {
        private readonly HttpClient _httpClient = new();
        private readonly string caminhoServer = Constante.STORAGE_SERVICE_API;
        private readonly IBus _bus;
        public StorageService()
        {
            _bus = RabbitHutch.CreateBus("host=" + VariavelDeAmbiente.ObterInstanciaInicializada().EnderecoRabbitMq);
        }

        public async Task<byte[]> Download(string caminhoNoFileServer)
        {
            var urlArquivo = Constante.STORAGE_SERVICE_ARQUIVOS_STATICOS + caminhoNoFileServer;

            return await ArquivoHelper.DownloadAsync(urlArquivo);
        }

        public async Task<byte[]> DownloadDeArquivoTemporario(string nomeArquivo)
        {
            return await Download("tmp/" + nomeArquivo);
        }


        public async Task<bool> ArquivoExiste(string diretorioArquivo)
        {
            if (!diretorioArquivo.EstaPreenchido()) return false;
            var urlArquivo = caminhoServer + diretorioArquivo.ConverterCaminhoArquivoParaApi();

            using (var result = await _httpClient.GetAsync(urlArquivo))
            {
                var resultado = await result.Content.ReadAsStringAsync();
                return Convert.ToBoolean(resultado);
            }
        }
        public async Task<ConsultarExistenciaArquivosResultadoDTO> ArquivosExistem(IEnumerable<string> arquivos)
        {
            if (!arquivos.Any()) return ConsultarExistenciaArquivosResultadoDTO.ObterConsultaDispensadaPorInexistenciaDeArquivo();
            var json = JsonConvert.SerializeObject(arquivos);
            var urlArquivo = caminhoServer + "range/";

            var request = new HttpRequestMessage(HttpMethod.Get, urlArquivo)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            using var result = await _httpClient.SendAsync(request);
            var resultadoJson = await result.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<ConsultarExistenciaArquivosResultadoDTO>(resultadoJson);
            return resultado!;
        }

        public async Task MoverArquivo(MoverArquivoCommand moverArquivoDto)
        {
            if (moverArquivoDto == null) return;
            await _bus.PubSub.PublishAsync(moverArquivoDto);
        }

        public async Task MoverArquivoRange(IEnumerable<MoverArquivoCommand> moverArquivosDtos)
        {
            if (moverArquivosDtos == null) return;
            await _bus.PubSub.PublishAsync(moverArquivosDtos);
        }

        public async Task DisponibilizarArquivosNaPastaTemporaria(IEnumerable<InfoArquivoDTO> arquivos)
        {
            if (arquivos.EstaNulo()) return ;

            var moverArquivosDto = new List<MoverArquivoCommand>();
            foreach (var arquivo in arquivos)
            {
                var arquivoDto = new MoverArquivoCommand()
                {
                    CaminhoAtual = arquivo.DiretorioVirtualCompleto,
                    CaminhoMover = Constante.PASTA_TEMPORARIA + arquivo.Nome,
                    Substituir = true,
                    Copiar = true,
                    IgnorarErros = true
                };
                moverArquivosDto.Add(arquivoDto);
            }


            await MoverArquivoRange(moverArquivosDto);
        }
        public async Task<string> UploadAsync(string diretorioOndeOArquivoEstaSalvo)
        {
            using var conteudoFormulario = new MultipartFormDataContent();
           
            var bytes = await ArquivoHelper.ObterBytesArquivosAsync(diretorioOndeOArquivoEstaSalvo);
            var byteArrayContent = new ByteArrayContent(bytes);

            conteudoFormulario.Add(byteArrayContent, "file", diretorioOndeOArquivoEstaSalvo.ObterNomeArquivo());
            
            var resultado = await _httpClient.PostAsync(caminhoServer, conteudoFormulario);
            if (resultado.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var respostaErro = await resultado.Content.ReadAsStringAsync();
                ExceptionHelper.LancarErroException($"não foi possivel realizar o upload do arquivo, resposta: {resultado.StatusCode} - {respostaErro}");
                return "";
            }
            var nomeArquivoTemporario = JsonConvert.DeserializeObject<List<string>>(await resultado.Content.ReadAsStringAsync()).First();
            return nomeArquivoTemporario;
        }
        public void Dispose()
        {
            _httpClient.Dispose();
            _bus.Dispose();
        }
    }
}
