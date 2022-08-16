using EasyNetQ;
using Newtonsoft.Json;
using Pulsati.Core.Domain.Bus.MessagesDTO.Storage;
using Pulsati.Core.Domain.Constantes;
using Pulsati.Core.Domain.DTOs;
using Pulsati.Core.Domain.Helpers;
using Pulsati.Core.Domain.Helpers.Extensions;
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
            _bus = RabbitHutch.CreateBus("host=localhost");
        }


        public async Task<byte[]> Download(string caminhoNoFileServer)
        {
            var urlArquivo = Constante.STORAGE_SERVICE_ARQUIVOS_STATICOS + caminhoNoFileServer;

            using var client = new HttpClient();
            using var result = await client.GetAsync(urlArquivo);

            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsByteArrayAsync();

            throw new Exception("Não foi possivel baixar o arquivo do serviço de storage");
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
        public async Task<bool> ArquivosExistem(IEnumerable<string> arquivos)
        {
            if (!arquivos.Any()) return true;
            var json = JsonConvert.SerializeObject(arquivos);
            var urlArquivo = caminhoServer + "range/";

            var request = new HttpRequestMessage(HttpMethod.Get, urlArquivo)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            using var result = await _httpClient.SendAsync(request);
            var resultado = await result.Content.ReadAsStringAsync();
            return Convert.ToBoolean(resultado);
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

        public void Dispose()
        {
            _httpClient.Dispose();
            _bus.Dispose();
        }
    }
}
