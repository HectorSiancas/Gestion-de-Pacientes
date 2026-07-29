namespace SistemaClinico.Services
{
    public interface IService
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T enviar);

        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<object>> Patch<T>(string url, T enviar);
    }
}
