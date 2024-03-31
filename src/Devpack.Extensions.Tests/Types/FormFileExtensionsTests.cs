using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using Xunit;
using Devpack.Extensions.Types;
using System.Net.Http;
using System;
using FluentAssertions;
using System.Threading.Tasks;

namespace Devpack.Extensions.Tests.Types
{
    public class FormFileExtensionsTests
    {
        [Fact]
        public async Task ToBase64_WhenSuccess()
        {
            // Arrange
            using var fileStreamSource = new FileStream("Common/file.txt", FileMode.Open);
            IFormFile formFile = new FormFile(fileStreamSource, 0, fileStreamSource.Length, "file", "fileName");

            // Act
            var base64 = formFile.ToBase64();

            var bytes = Convert.FromBase64String(base64);
            using var fileStreamTarget = new StreamContent(new MemoryStream(bytes));

            var text = await fileStreamTarget.ReadAsStringAsync();

            // Asserts
            text.Should().Be("Test100");
        }
    }
}