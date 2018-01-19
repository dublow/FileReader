using Domain.Implementations;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace UnitTest
{
    [TestClass]
    public class FileReader_Tests
    {
        private static string _currentDirectory = Directory.GetCurrentDirectory();

        [TestMethod]
        public void AUserShouldBeAbleToReadATextFile()
        {
            IFileReader fileReader = new TextFileReader();

            var filename = $@"{_currentDirectory}\files\textFile.txt";

            var actual = fileReader.Read(filename);

            Assert.AreEqual("Hello world!", actual);
        }
    }
}
