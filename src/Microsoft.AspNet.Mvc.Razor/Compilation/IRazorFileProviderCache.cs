﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.FileProviders;

namespace Microsoft.AspNet.Mvc.Razor
{
    /// <summary>
    /// An <see cref="IFileProvider"/> that caches the results of <see cref="IFileProvider.GetFileInfo(string)"/> for a
    /// duration specified by <see cref="RazorViewEngineOptions.ExpirationBeforeCheckingFilesOnDisk"/>.
    /// </summary>
    public interface IRazorFileProviderCache : IFileProvider
    {
    }
}