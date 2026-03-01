using Microsoft.AspNetCore.Mvc;

namespace AI_CampaignGenerator.Web.Factory
{
    public class ApiResponseFactory
    {
            public static IActionResult GenerateApiValidationResponse(ActionContext context)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                var problem = new ProblemDetails
                {
                    Title = "Validation Errors",
                    Detail = "One or more validation errors occurred.",
                    Status = StatusCodes.Status400BadRequest
                };

                problem.Extensions.Add("Errors", errors);

                return new BadRequestObjectResult(problem);
            }
        }
    }

