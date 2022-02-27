using System;
using System.Collections.Generic;
using System.Linq;
using Assignment_mvc_2.Controllers;
using Assignment_mvc_2.Models;
using Assignment_mvc_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace MVC.Tests;

public class RookiesControllerTests
{
    private Mock<ILogger<PeopleController>> _loggerMock;
    private Mock<IPersonService> _personServiceMock;
    static List<Person> _people = new List<Person>
    {
        new Person{
                firstname="Phuong",
                lastname="Nguyen Nam",
                gender="Male",
                age=21,
                address="Phu Tho"
            },
            new Person{
                firstname="Nam",
                lastname="Nguyen Thanh",
                gender="Male",
                age=20,
                address="Ha Noi"
            }
    };

    [SetUp]
    public void Setup()
    {
         _loggerMock= new Mock<ILogger<PeopleController>>();
         _personServiceMock = new Mock<IPersonService>();

         //Set up
         _personServiceMock.Setup(x=> x.GetAll()).Returns(_people);

    }

    [Test]
    public void Index_ReturnViewResult_WithAllListOfPeople()
    {
        //Arange
        var controller = new PeopleController(_loggerMock.Object,_personServiceMock.Object);
        var expectedCount = _people.Count;
        //Act
        var result = controller.Index();

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result, "Invalid return type.");

        var view =(ViewResult)result;
        Assert.IsAssignableFrom<List<Person>>(view.ViewData.Model, "Invalid view data model.");

        var model  = view.ViewData.Model as List<Person>;
        Assert.IsNotNull(model, "View data model could not be null.");
        Assert.AreEqual(expectedCount,model?.Count, "Model count is not equal to exxpected count.");
    }

    [Test]
    public void Detail_AValidIndex_ReturnViewResult_WithAPerson()
    {
        //Set up
        const int index = 2;
        _personServiceMock.Setup(x => x.GetOne(index)).Throws(new ArgumentException("Index out of range"));
        var expected = _people[index-1];
        //Arange
        var controller = new PeopleController(_loggerMock.Object,_personServiceMock.Object);
        //Act
        var result = controller.Detail(index);

        //Assert
        Assert.IsInstanceOf<NotFoundObjectResult>(result, "Invalid return type.");

        var view =(ViewResult)result;
        Assert.IsAssignableFrom<Person>(view.ViewData.Model, "Invalid data model");

        var model = view.ViewData.Model as Person;
        Assert.IsNotNull(view, "View must not be null");
        Assert.AreEqual(expected,model, "Not equals.");

    }
    [Test]
    public void Detail_InvalidIndex_throwException()
    {
        //Set up
        const int index = -1;
        const string mess = "Index must be greater than 0";
        _personServiceMock.Setup(x => x.GetOne(index)).Throws(new ArgumentException(mess));

        //Arange
        var controller = new PeopleController(_loggerMock.Object,_personServiceMock.Object);
        //Act
        // var result = controller.Detail(index);

        //Assert
        var exception = Assert.Throws<ArgumentException>(()=> controller.Detail(index));
        Assert.IsNotNull(exception, "Exception must not be null");
        Assert.AreEqual(mess,exception?.Message,"Not equal");
        
    }


    [Test]
    public void create_InvalidModel_ReturnView_withErrorInModelState(){
        const string key = "ERROR";
        const string mess = "Invalid model";

        //Arrange
        var controller = new PeopleController(_loggerMock.Object,_personServiceMock.Object);
        controller.ModelState.AddModelError(key,mess);

        //Act
        var result = controller.Create(null);

        //Assert
        Assert.IsInstanceOf<ViewResult>(result, "Invalid return type.");
        var view =(ViewResult)result;
        var modelState = view.ViewData.ModelState;

        modelState.TryGetValue(key, out var value);
        var error = value?.Errors.First().ErrorMessage;
        // Assert.IsFalse(modelState.IsValid, "Invalid Model state");
        Assert.AreEqual(mess , error);
    }
    [Test]
    public void Create_ValidModel_ReturnRedirectToAction(){
        //Arrange

        var person = new Person
        {
            firstname= "a",
            lastname="b",
            address="hanoi",
            age=12,
            gender= "male"
        };
        _personServiceMock.Setup(x => x.Create(person))
        .Callback<Person>((Person p) =>
        {
            _people.Add(p);
        });

        var controller = new PeopleController(_loggerMock.Object,_personServiceMock.Object);
         
         var expected = _people.Count+1;

        //Act
        var result = controller.Create(person);

        //Assert
        Assert.IsInstanceOf<ViewResult>(result, "Invalid return type.");
        var view =(RedirectToActionResult)result;
        Assert.AreEqual("Index", view.ActionName,"Invalid action name");

        var actual = _people.Count;
        Assert.AreEqual(expected, actual, "Error");

        Assert.AreEqual(person, _people.Last(), "Not equal");

    }
    
}