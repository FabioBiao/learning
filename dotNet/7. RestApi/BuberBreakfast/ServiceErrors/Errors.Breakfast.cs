using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        // Error types:
        /** 
                Failure = 0,
        Unexpected = 1,
        Validation = 2,
        Conflict = 3,
        NotFound = 4
        **/

        public static Error InvalidName => Error.Validation(
            code: "Breakfast.InvalidName",
            description: $"Breakfast name must be at least {Models.Breakfast.MinNameLength}" +
                $" characters long and at most {Models.Breakfast.MaxNameLength} characters long.");

        public static Error InvalidDescription => Error.Validation(
            code: "Breakfast.InvalidDescription",
            description: $"Breakfast description must be at least {Models.Breakfast.MinDescriptionLength}" +
                $" characters long and at most {Models.Breakfast.MaxDescriptionLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast not found");
    }
}