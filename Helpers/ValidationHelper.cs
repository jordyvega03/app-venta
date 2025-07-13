using System.ComponentModel.DataAnnotations;

namespace app_venta.Helpers;

public static class ValidationHelper
{
    public static List<string> Validate<T>(T dto)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(dto, null, null);
        Validator.TryValidateObject(dto, context, results, true);
        return results.Select(r => r.ErrorMessage!).ToList();
    }
}