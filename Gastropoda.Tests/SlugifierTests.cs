namespace Gastropoda.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SlugifierTests
    {
        private readonly static Dictionary<string, string> validTestCases =
            new Dictionary<string, string>
            {
                { "Clothing" , "clothing" },
                { "Clothing Jackets" , "clothing-jackets" },
                { "Clothing  Jackets" , "clothing-jackets" },
                { "clothing-jackets" , "clothing-jackets" },
                { "coração ûltimatœ" , "coracao-ultimatoe" },
                { "òóôõöøőð çćčĉ òóôõöøőð" , "oooooooo-cccc-oooooooo" },
                { "ŒœŒœŒœ ßßß ìíîïı" , "oeoeoeoeoeoe-ssssss-iiiii" },
                { "THîS // , Is   /|\\ a TŒst" , "this-is-a-taest" }
            };

        [TestMethod]
        public void Slugify_WhenInputIsNull_ShouldReturnNull()
        {
            string test = null;
            Assert.IsNull(test.Slugify());
        }

        [TestMethod]
        public void Slugify_WhenInputIsStringEmpty_ShouldReturnStringEmpty()
        {
            string test = string.Empty;
            Assert.AreEqual(string.Empty, test.Slugify());
        }

        [TestMethod]
        public void Slugify_WhenThereIsProvidedAValidTestCase_ShouldReturnTheValidValue()
        {
            foreach (var item in validTestCases)
            {
                Assert.AreEqual(item.Value, item.Key.Slugify());
            }
        }
    }
}