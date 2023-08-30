// ReSharper disable UnusedTypeParameter

namespace JuegoOlimpico.Transversal.Common
{
    /// <summary>
    ///     Este tipo elimina la necesidad de depender directamente de los tipos de registro de ASP.NET Core.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);

        void LogWarning(string message, params object[] args);
    }
}
