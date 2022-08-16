namespace Pulsati.Core.Domain.Helpers
{
    public static class ObjectExtension
    {
        public static bool EstaNulo(this object? objeto)
        {
            return objeto == null;
        }
    }
}
