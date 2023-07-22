using FluentValidation;

namespace StudentEnrollment.API.Filters
{
    public class ValidationFilter<T> : IEndpointFilter where T : class
    {
        private IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator) { 
            _validator = validator;        
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            // Runs before endpoint code
            var objectToValidate = context.GetArgument<T>(0);

            var validationResult = await _validator.ValidateAsync(objectToValidate);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.ToDictionary());
            }

            var result = await next(context);

            // Anything to run after endpoint code goes here...
            //

            return result;
        }
    }
}
