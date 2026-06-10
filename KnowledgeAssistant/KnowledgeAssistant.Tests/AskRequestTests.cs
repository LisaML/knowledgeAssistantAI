using KnowledgeAssistant.API.Models;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeAssistant.Tests;

public class AskRequestTests
{
    [Fact]
    public void AskRequest_WithQuestion_ShouldBeValid()
    {
        var request = new AskRequest
        {
            Question = "¿Qué registros hablan de calidad?"
        };

        var context = new ValidationContext(request);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            request,
            context,
            results,
            true);

        Assert.True(isValid);
    }

    [Fact]
    public void AskRequest_WithoutQuestion_ShouldBeInvalid()
    {
        var request = new AskRequest();

        var context = new ValidationContext(request);
        var results = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            request,
            context,
            results,
            true);

        Assert.False(isValid);
    }
}