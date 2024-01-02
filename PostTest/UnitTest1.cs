using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Post___App.Tests.Models
{
    public class PostTests
    {
        [Fact]
        public void Content_MaxLength_ShouldBe100()
        {
            // Arrange
            var post = new Post();

            // Act
            var maxLength = post.GetType().GetProperty("Content")
                                  .GetCustomAttributes(typeof(StringLengthAttribute), true)[0]
                                  as StringLengthAttribute;

            // Assert
            Assert.Equal(100, maxLength.MaximumLength);
        }

        [Fact]
        public void Author_MaxLength_ShouldBe50()
        {
            // Arrange
            var post = new Post();

            // Act
            var maxLength = post.GetType().GetProperty("Author")
                                  .GetCustomAttributes(typeof(StringLengthAttribute), true)[0]
                                  as StringLengthAttribute;

            // Assert
            Assert.Equal(50, maxLength.MaximumLength);
        }

        [Fact]
        public void Comment_MaxLength_ShouldBe150()
        {
            // Arrange
            var post = new Post();

            // Act
            var maxLength = post.GetType().GetProperty("Comment")
                                  .GetCustomAttributes(typeof(StringLengthAttribute), true)[0]
                                  as StringLengthAttribute;

            // Assert
            Assert.Equal(150, maxLength.MaximumLength);
        }

        [Fact]
        public void Topics_ShouldBeMarkedWithValidateNever()
        {
            // Arrange
            var post = new Post();

            // Act
            var validateNeverAttribute = post.GetType().GetProperty("Topics")
                                              .GetCustomAttributes(typeof(ValidateNeverAttribute), true);

            // Assert
            Assert.NotEmpty(validateNeverAttribute);
        }
    }
}
