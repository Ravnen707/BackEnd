using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project1.Api.Controllers;
using project1.Api.Models;
using Xunit;

namespace project1.Tests.Controllers;

public class SampleControllerTests
{
    [Fact]
    public void Get_ReturnsInitialItems()
    {
        var controller = new SampleController();
        var result = controller.Get();
        var ok = Assert.IsType<OkObjectResult>(result.Result);
        var items = Assert.IsAssignableFrom<IEnumerable<SampleModel>>(ok.Value);
        Assert.NotEmpty(items);
    }
}