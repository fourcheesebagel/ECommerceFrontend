using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Cart;
using ClientLibrary.Models.Category;

namespace ClientLibrary.Services
{
    public class CartService(IHttpClientHelper httpClient, IApiCallHelper apiHelper) : ICartService
    {
        public async Task<ServiceResponse> Checkout(Checkout checkout)
        {
            var privateClient = await httpClient.GetPrivateClientAsync();
            var apiCallModel = new ApiCall
            {
                Route = Constant.Cart.Checkout,
                Type = Constant.ApiCallType.Post,
                Client = privateClient,
                Id = null!,
                Model = checkout
            };
            var result = await apiHelper.ApiCallTypeCall<Checkout>(apiCallModel);
            if (result == null)
                return apiHelper.ConnectionError();
            else
                return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<IEnumerable<GetArchives>> GetArchives()
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.Cart.GetArchives,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!,
                Id = null!
            };
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
            if (result.IsSuccessStatusCode)
                return await apiHelper.GetServiceResponse<IEnumerable<GetArchives>>(result);
            else
                return [];
        }

        public async Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateArchive> archives)
        {
            var privateClient = await httpClient.GetPrivateClientAsync();
            var apiCallModel = new ApiCall
            {
                Route = Constant.Cart.SaveCart,
                Type = Constant.ApiCallType.Post,
                Client = privateClient,
                Id = null!,
                Model = archives
            };
            var result = await apiHelper.ApiCallTypeCall<IEnumerable<CreateArchive>>(apiCallModel);
            if (result == null)
                return apiHelper.ConnectionError();
            else
                return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }
    }
}
