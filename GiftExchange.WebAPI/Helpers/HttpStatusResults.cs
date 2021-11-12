using Microsoft.AspNetCore.Mvc;

namespace GiftExchange.WebAPI.Helpers
{
    public static class HttpStatusResults
    {
        public static IActionResult SeeOtherStatus(ControllerBase controller, string routeName, object values)
        {
            var url = controller.Url.Link(routeName, values);
            controller.Response.Headers.Add("Location", url);
            return controller.StatusCode(303);
        }
    }
}
