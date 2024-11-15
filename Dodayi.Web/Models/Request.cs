using static Dodayi.Web.Utility.SD;

namespace Dodayi.Web.Models
{
    public class Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }


    }
}
