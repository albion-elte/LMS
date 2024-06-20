namespace LMS.Infrastructure.Network
{
    public interface IHttpClientWrapper
    {
        void Post(string address, string json);
    }
}