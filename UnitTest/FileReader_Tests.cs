using Domain.Implementations;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

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

        [TestMethod]
        public void AUserShouldBeAbleToReadAXMLFile()
        {
            IFileReader fileReader = new XmlFileReader();

            var filename = $@"{_currentDirectory}\files\xmlFile.xml";

            var actual = XElement.Parse(fileReader.Read(filename));

            var expected = XElement.Parse("<?xml version=\"1.0\"?><text>Hello world!</text>");

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void AUserShouldBeAbleToReadAEncryptedTextFile()
        {
            IEncryptor encryptor = new ReverseEncryptor();
            IFileReader fileReader = new TextFileReader(encryptor);

            var filename = $@"{_currentDirectory}\files\textFile.txt";

            var actual = fileReader.Read(filename);
            ;
            Assert.AreEqual("!dlrow olleH", actual);
        }
    }
}
