// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormatterWebSite;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.TestHost;
using Xunit;

namespace Microsoft.AspNet.Mvc.FunctionalTests
{
    public class StreamOutputFormatterTest
    {
        private readonly IServiceProvider _provider = TestHelper.CreateServices(nameof(FormatterWebSite));
        private readonly Action<IApplicationBuilder> _app = new Startup().Configure;

        [InlineData("SimpleMemoryStream", null)]
        [InlineData("MemoryStreamWithContentType", "text/html")]
        [InlineData("MemoryStreamWithContentTypeFromProduces", "text/plain")]
        [InlineData("MemoryStreamWithContentTypeFromProducesWithMultipleValues", "text/html")]
        [InlineData("MemoryStreamOverridesContentTypeWithProduces", "text/plain")]
        [Theory]
        public async Task StreamOutputFormatter_ReturnsAppropriateContentAndContentType(string actionName, string contentType)
        {
            // Arrange
            var server = TestServer.Create(_provider, _app);
            var client = server.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/Stream/" + actionName);
            var body = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(contentType, response.Content.Headers.ContentType?.ToString());

            Assert.Equal("Sample text from a stream", body);
        }
    }
}
