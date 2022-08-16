namespace Pulsati.Core.Domain.Helpers
{
    public class ExceptionHelper
    {
        public static void LancarErroException(string mensagemErro)
        {
            throw new Exception(mensagemErro);

        }
    }
}
