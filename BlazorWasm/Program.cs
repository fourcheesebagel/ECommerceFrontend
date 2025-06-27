using BlazorWasm;
using BlazorWasm.Authentication;
using ClientLibrary.Helper;
using ClientLibrary.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.Components.DataGrid;
using NetcodeHub.Packages.WebAssembly.Storage.Cookie;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddNetcodeHubCookieStorageService();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();
builder.Services.AddScoped<IApiCallHelper, ApiCallHelper>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<RefreshTokenHandler>();
builder.Services.AddHttpClient(Constant.ApiClient.Name, option =>
{
    option.BaseAddress = new Uri("https://localhost:7063/api/");
}).AddHttpMessageHandler<RefreshTokenHandler>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddVirtualizationService();
await builder.Build().RunAsync();
