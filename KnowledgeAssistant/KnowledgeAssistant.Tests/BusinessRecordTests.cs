using KnowledgeAssistant.API.Models;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAssistant.Tests;

public class BusinessRecordTests
{
    [Fact]
    public void BusinessRecord_WithValidData_ShouldBeValid()
    {
        var record = new BusinessRecord
        {
            Title = "Manual de Calidad",
            Content = "Contenido de prueba",
            Department = "Calidad"
        };

        var context = new ValidationContext(record);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            record,
            context,
            results,
            true);

        Assert.True(isValid);
    }

    [Fact]
    public void BusinessRecord_WithoutTitle_ShouldBeInvalid()
    {
        var record = new BusinessRecord
        {
            Content = "Contenido de prueba",
            Department = "Calidad"
        };

        var context = new ValidationContext(record);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            record,
            context,
            results,
            true);

        Assert.False(isValid);
    }
}