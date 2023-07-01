using Microsoft.AspNetCore.Http;

namespace CardCore.Domain.Messages
{
    public class EFContextMessage
    {
        public HttpContext HttpContext {get; private set;}

        public int UserId { get; private set; }
        public DateTime ActionAt { get; private set; }
        public EFContextMessage(HttpContext httpContext, int userId, DateTime actionAt)
        {
            HttpContext = httpContext;
            UserId = userId;
            ActionAt = actionAt;
        }
    }
}