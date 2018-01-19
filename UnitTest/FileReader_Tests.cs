using Domain.Implementations;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class FileReader_Tests
    {
        [TestMethod]
        public void AUserShouldBeAbleToReadATextFile()
        {
            IFileReader<string> fileReader = new TextFileReader();

            var actual = fileReader.Read();

            Assert.AreEqual("Hello world!", actual);
        }
    }
}
