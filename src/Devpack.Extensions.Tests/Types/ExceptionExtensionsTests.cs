using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class ExceptionExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve gerar um dicionário de dados quando a exception contiver uma inner exception.")]
        [Trait("Category", "Extensions")]
        public void ToDictionary_WithInnerException()
        {
            var exception = new OutOfMemoryException(Guid.NewGuid().ToString(), new Exception());
            var result = exception.ToDictionary();

            result.Should().HaveCount(3);
            result["ExceptionType"].Should().Be(exception.GetType().Name);
            result["ExceptionMessage"].Should().Be(exception.Message);
            result["InnerExceptionMessage"].Should().Be(exception.InnerException!.Message);
        }

        [Fact(DisplayName = "Deve gerar um dicionário de dados quando a exception não contiver uma inner exception.")]
        [Trait("Category", "Extensions")]
        public void ToDictionary_WithNotInnerException()
        {
            var exception = new OutOfMemoryException(Guid.NewGuid().ToString());
            var result = exception.ToDictionary();

            result.Should().HaveCount(2);
            result["ExceptionType"].Should().Be(exception.GetType().Name);
            result["ExceptionMessage"].Should().Be(exception.Message);
        }
    }
}