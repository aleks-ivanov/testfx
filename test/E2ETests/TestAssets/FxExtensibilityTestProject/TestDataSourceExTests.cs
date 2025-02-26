﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FxExtensibilityTestProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    [TestClass]
    public class TestDataSourceExTests
    {
        [TestMethod]
        [CustomTestDataSource]
        public void CustomTestDataSourceTestMethod1(int a, int b, int c)
        {
            Assert.AreEqual(1, a % 3);
            Assert.AreEqual(2, b % 3);
            Assert.AreEqual(0, c % 3);
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CustomTestDataSourceAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            return new[] { new object[] { 1, 2, 3 }, new object[] { 4, 5, 6 } };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return string.Format(CultureInfo.CurrentCulture, "{0} ({1})", methodInfo.Name, string.Join(",", data));
            }

            return null;
        }
    }
}
