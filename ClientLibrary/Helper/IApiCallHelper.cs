using ClientLibrary.Models;

namespace ClientLibrary.Helper
{
    public interface IApiCallHelper
    {
        Task<HttpResponseMessage> ApiCallTypeCall<TModel>(ApiCall apiCall);
        Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message); //we have a service and login response so we want it to be able to receive either one
        ServiceResponse ConnectionError();
    }
}
