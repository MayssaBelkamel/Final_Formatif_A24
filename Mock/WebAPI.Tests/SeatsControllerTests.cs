using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Services;

namespace WebAPI.Tests;

[TestClass]
public class SeatsControllerTests
{
    [TestMethod]
    public void ReserveSeat_return_()
    {
       Mock<SeatsService> serviceMock= new Mock<SeatsService>();
        var actionresult = serviceMock.Object.ReserveSeat("1", 2);
     //   var result=actionresult.
        
    }
}
