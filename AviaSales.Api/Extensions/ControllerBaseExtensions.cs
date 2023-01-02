using Microsoft.AspNetCore.Mvc;

namespace AviaSales.Api.Extensions;

public static class ControllerBaseExtensions
{
    public static IActionResult ValidationProblem(this ControllerBase controller, IEnumerable<string> errors)
    {
        foreach (var error in errors)
        {
            controller.ModelState.AddModelError(string.Empty, error);
        }

        return controller.ValidationProblem(controller.ModelState);
    }
}