namespace SimpleBlogApp.API.Authentication.Middleware
{
    public interface IMiddleware
    {
        Task InvokeAsync(HttpContext context, RequestDelegate next);
    }
}
