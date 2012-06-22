using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Remote.Web.Test
{
    public static class AssertHelper
    {
        public static void ListEqual<T>(List<T> expected, List<T> actual, string message = null)
        {
            if (expected.Count < actual.Count)
            {
                Assert.Fail(message ?? "There were too many entries returned");
            }
            else if (expected.Count > actual.Count)
            {
                Assert.Fail(message ?? "There were not enough entries returned");
            }
            else
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i], actual[i], message ?? "The lists' data were not the same");
                }
            }
        }
    }
}
