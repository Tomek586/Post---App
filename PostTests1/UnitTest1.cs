using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Post___App.Controllers;
using Post___App.Models;
using Xunit;

namespace Post___App.Tests.Controllers
{
    public class PostControllerTests
    {
        [Fact]
        public void Index_ReturnsView()
        {
         
            var postServiceMock = new Mock<IPostService>();
            var controller = new PostController(postServiceMock.Object);

            var result = controller.Index(null);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_ReturnsView()
        {
     
            var postServiceMock = new Mock<IPostService>();
            var controller = new PostController(postServiceMock.Object);

            var result = controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_RedirectsToIndex()
        {
            var postServiceMock = new Mock<IPostService>();
            postServiceMock.Setup(repo => repo.Add(It.IsAny<Post>()));
            var controller = new PostController(postServiceMock.Object);
            var model = new Post();

            var result = controller.Create(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Update__ReturnsView()
        {
            var postServiceMock = new Mock<IPostService>();
            postServiceMock.Setup(repo => repo.FindById(It.IsAny<int>())).Returns(new Post { Id = 1 });
            var controller = new PostController(postServiceMock.Object);

            var result = controller.Update(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Update_RedirectsToIndex()
        {
            var postServiceMock = new Mock<IPostService>();
            postServiceMock.Setup(repo => repo.Update(It.IsAny<Post>()));
            var controller = new PostController(postServiceMock.Object);
            var model = new Post();

            var result = controller.Update(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Details_ReturnsView()
        {
            var postServiceMock = new Mock<IPostService>();
            var controller = new PostController(postServiceMock.Object);

            var result = controller.Details(1);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Delete()
        {
            var postServiceMock = new Mock<IPostService>();
            postServiceMock.Setup(repo => repo.FindById(1)).Returns(new Post());
            var controller = new PostController(postServiceMock.Object);

            var result = controller.Delete(1);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

    

  
   

        [Fact]
        public void PagedIndex_View()
        {
            var postServiceMock = new Mock<IPostService>();
            var controller = new PostController(postServiceMock.Object);

            var result = controller.PagedIndex(1, 2);

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Content_MaxLength100()
        {

            var post = new Post();

            var maxLengthAttribute = post.GetType()
                .GetProperty("Content")
                .GetCustomAttributes(typeof(StringLengthAttribute), true)[0]
                as StringLengthAttribute;

            Assert.Equal(100, maxLengthAttribute.MaximumLength);
        }

        [Fact]
        public void Author_MaxLength50()
        {
            var post = new Post();

            var maxLengthAttribute = post.GetType()
                .GetProperty("Author")
                .GetCustomAttributes(typeof(StringLengthAttribute), true)[0]
                as StringLengthAttribute;

            Assert.Equal(50, maxLengthAttribute.MaximumLength);
        }

        [Fact]
        public void Comment_MaxLength150()
        {
            var post = new Post();

            var maxLengthAttribute = post.GetType()
                .GetProperty("Comment")
                .GetCustomAttributes(typeof(StringLengthAttribute), true)[0]
                as StringLengthAttribute;

            Assert.Equal(150, maxLengthAttribute.MaximumLength);
        }

        [Fact]
        public void Topics_ValidateNever()
        {
            var post = new Post();

            var validateNeverAttribute = post.GetType()
                .GetProperty("Topics")
                .GetCustomAttributes(typeof(ValidateNeverAttribute), true);

            Assert.NotEmpty(validateNeverAttribute);
        }
    }
}
