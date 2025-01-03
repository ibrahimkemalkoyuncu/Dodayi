using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Newtonsoft.Json;
using System.Text;


namespace Dodayi.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BaseService(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }
        public async Task<Response?> SendAsync(Request request)
        {
            try
            {
                HttpClient client = httpClientFactory.CreateClient("DodayiAPI");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");

                // token

                message.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (request.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    //case System.Net.HttpStatusCode.Continue:
                    //    break;
                    //case System.Net.HttpStatusCode.SwitchingProtocols:
                    //    break;
                    //case System.Net.HttpStatusCode.Processing:
                    //    break;
                    //case System.Net.HttpStatusCode.EarlyHints:
                    //    break;
                    //case System.Net.HttpStatusCode.OK:
                    //    break;
                    //case System.Net.HttpStatusCode.Created:
                    //    break;
                    //case System.Net.HttpStatusCode.Accepted:
                    //    break;
                    //case System.Net.HttpStatusCode.NonAuthoritativeInformation:
                    //    break;
                    //case System.Net.HttpStatusCode.NoContent:
                    //    break;
                    //case System.Net.HttpStatusCode.ResetContent:
                    //    break;
                    //case System.Net.HttpStatusCode.PartialContent:
                    //    break;
                    //case System.Net.HttpStatusCode.MultiStatus:
                    //    break;
                    //case System.Net.HttpStatusCode.AlreadyReported:
                    //    break;
                    //case System.Net.HttpStatusCode.IMUsed:
                    //    break;
                    //case System.Net.HttpStatusCode.Ambiguous:
                    //    break;
                    //case System.Net.HttpStatusCode.MultipleChoices:
                    //    break;
                    //case System.Net.HttpStatusCode.Moved:
                    //    break;
                    //case System.Net.HttpStatusCode.MovedPermanently:
                    //    break;
                    //case System.Net.HttpStatusCode.Found:
                    //    break;
                    //case System.Net.HttpStatusCode.Redirect:
                    //    break;
                    //case System.Net.HttpStatusCode.RedirectMethod:
                    //    break;
                    //case System.Net.HttpStatusCode.SeeOther:
                    //    break;
                    //case System.Net.HttpStatusCode.NotModified:
                    //    break;
                    //case System.Net.HttpStatusCode.UseProxy:
                    //    break;
                    //case System.Net.HttpStatusCode.Unused:
                    //    break;
                    //case System.Net.HttpStatusCode.RedirectKeepVerb:
                    //    break;
                    //case System.Net.HttpStatusCode.TemporaryRedirect:
                    //    break;
                    //case System.Net.HttpStatusCode.PermanentRedirect:
                    //    break;
                    //case System.Net.HttpStatusCode.BadRequest:
                    //    break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new Response { IsSuccess = false, Message = "Unauthorized" };
                       
                    //case System.Net.HttpStatusCode.PaymentRequired:
                    //    break;
                    case System.Net.HttpStatusCode.Forbidden:
                        return new Response { IsSuccess = false, Message = "Access Denied" };
                       
                    case System.Net.HttpStatusCode.NotFound:
                        return new Response { IsSuccess = false, Message = "Not Found" };
                       
                    //case System.Net.HttpStatusCode.MethodNotAllowed:
                    //    break;
                    //case System.Net.HttpStatusCode.NotAcceptable:
                    //    break;
                    //case System.Net.HttpStatusCode.ProxyAuthenticationRequired:
                    //    break;
                    //case System.Net.HttpStatusCode.RequestTimeout:
                    //    break;
                    //case System.Net.HttpStatusCode.Conflict:
                    //    break;
                    //case System.Net.HttpStatusCode.Gone:
                    //    break;
                    //case System.Net.HttpStatusCode.LengthRequired:
                    //    break;
                    //case System.Net.HttpStatusCode.PreconditionFailed:
                    //    break;
                    //case System.Net.HttpStatusCode.RequestEntityTooLarge:
                    //    break;
                    //case System.Net.HttpStatusCode.RequestUriTooLong:
                    //    break;
                    //case System.Net.HttpStatusCode.UnsupportedMediaType:
                    //    break;
                    //case System.Net.HttpStatusCode.RequestedRangeNotSatisfiable:
                    //    break;
                    //case System.Net.HttpStatusCode.ExpectationFailed:
                    //    break;
                    //case System.Net.HttpStatusCode.MisdirectedRequest:
                    //    break;
                    //case System.Net.HttpStatusCode.UnprocessableEntity:
                    //    break;
                    //case System.Net.HttpStatusCode.UnprocessableContent:
                    //    break;
                    //case System.Net.HttpStatusCode.Locked:
                    //    break;
                    //case System.Net.HttpStatusCode.FailedDependency:
                    //    break;
                    //case System.Net.HttpStatusCode.UpgradeRequired:
                    //    break;
                    //case System.Net.HttpStatusCode.PreconditionRequired:
                    //    break;
                    //case System.Net.HttpStatusCode.TooManyRequests:
                    //    break;
                    //case System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge:
                    //    break;
                    //case System.Net.HttpStatusCode.UnavailableForLegalReasons:
                    //    break;
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new Response { IsSuccess = false, Message = "Internal Server Error" };
                       
                    //case System.Net.HttpStatusCode.NotImplemented:
                    //    break;
                    //case System.Net.HttpStatusCode.BadGateway:
                    //    break;
                    //case System.Net.HttpStatusCode.ServiceUnavailable:
                    //    break;
                    //case System.Net.HttpStatusCode.GatewayTimeout:
                    //    break;
                    //case System.Net.HttpStatusCode.HttpVersionNotSupported:
                    //    break;
                    //case System.Net.HttpStatusCode.VariantAlsoNegotiates:
                    //    break;
                    //case System.Net.HttpStatusCode.InsufficientStorage:
                    //    break;
                    //case System.Net.HttpStatusCode.LoopDetected:
                    //    break;
                    //case System.Net.HttpStatusCode.NotExtended:
                    //    break;
                    //case System.Net.HttpStatusCode.NetworkAuthenticationRequired:
                    //    break;
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<Response>(apiContent);
                        return apiResponseDto;
                       
                }

            }
            catch (Exception ex)
            {
                var dto = new Response { IsSuccess = false, Message = ex.Message.ToString() };

                return dto;
            }

            
        }
    }

}
