using Domain.Implementations;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
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

        [TestMethod]
        public void AUserShouldBeAbleToSwitchEncryptionTextFile()
        {
            IEncryptor encryptor = new ReverseEncryptor();
            var fileReader = new TextFileReader(encryptor);

            var filename = $@"{_currentDirectory}\files\textFile.txt";

            var actualReversedText = fileReader.Read(filename);

            fileReader.SetEncryptor(VoidEncryptor.Instance);

            var actualText = fileReader.Read(filename);

            Assert.AreEqual("!dlrow olleH", actualReversedText);
            Assert.AreEqual("Hello world!", actualText);
        }

        [TestMethod]
        public void AAdminShouldBeAbleToReadAllXMLFilesInRoleBasedSecurityContext()
        {
            IFileReader fileReader = new XmlFileReader();
            Authorization adminAuthorization = new AdminAuthorization(fileReader);

            var filename = $@"{_currentDirectory}\files\admin.xml";

            var actual = XElement.Parse(adminAuthorization.Read(filename));

            var expected = XElement.Parse("<?xml version=\"1.0\"?><text>Hello admin!</text>");

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void AUserShouldBeAbleToReadLimitedXMLFilesInRoleBasedSecurityContext()
        {
            IFileReader fileReader = new XmlFileReader();
            Authorization userAuthorization = new UserAuthorization(fileReader);

            var adminFilename = $@"{_currentDirectory}\files\admin.xml";
            var filename = $@"{_currentDirectory}\files\xmlFile.xml";

            var actualAdmin = userAuthorization.Read(adminFilename);
            var actual = XElement.Parse(userAuthorization.Read(filename));

            var expected = XElement.Parse("<?xml version=\"1.0\"?><text>Hello world!</text>");

            Assert.AreEqual(string.Empty, actualAdmin);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void AUserShouldBeAbleToReadAnEncryptedXMLFile()
        {
            IEncryptor encryptor = new ReverseEncryptor();
            IFileReader fileReader = new XmlFileReader(encryptor);

            var filename = $@"{_currentDirectory}\files\xmlFile.xml";

            var actual = fileReader.Read(filename);
            
            Assert.AreEqual("\n\r>txet/<!dlrow olleH>txet<\n\r>?\"0.1\"=noisrev lmx?<", actual);
        }

        [TestMethod]
        public void AUserShouldBeAbleToSwitchEncryptionXmlFile()
        {
            IEncryptor encryptor = new ReverseEncryptor();
            var fileReader = new XmlFileReader(encryptor);

            var filename = $@"{_currentDirectory}\files\xmlFile.xml";

            var actualReversedXml = fileReader.Read(filename);

            fileReader.SetEncryptor(VoidEncryptor.Instance);

            var actualXml = fileReader.Read(filename);

            Assert.AreEqual("\n\r>txet/<!dlrow olleH>txet<\n\r>?\"0.1\"=noisrev lmx?<", actualReversedXml);
            Assert.AreEqual("<?xml version=\"1.0\"?>\r\n<text>Hello world!</text>\r\n", actualXml);
        }

        [TestMethod]
        public void AAdminShouldBeAbleToReadAllTextFilesInRoleBasedSecurityContext()
        {
            IFileReader fileReader = new TextFileReader();
            Authorization adminAuthorization = new AdminAuthorization(fileReader);

            var filename = $@"{_currentDirectory}\files\admin.txt";

            var actual = adminAuthorization.Read(filename);

            Assert.AreEqual("Hello admin!", actual.ToString());
        }

        [TestMethod]
        public void AUserShouldBeAbleToReadLimitedTextFilesInRoleBasedSecurityContext()
        {
            IFileReader fileReader = new TextFileReader();
            Authorization userAuthorization = new UserAuthorization(fileReader);

            var adminFilename = $@"{_currentDirectory}\files\admin.txt";
            var filename = $@"{_currentDirectory}\files\textFile.txt";

            var actualAdmin = userAuthorization.Read(adminFilename);
            var actual = userAuthorization.Read(filename);

            Assert.AreEqual(string.Empty, actualAdmin);
            Assert.AreEqual("Hello world!", actual.ToString());
        }

        [TestMethod]
        public void AUserShouldBeAbleToReadAJsonFile()
        {
            IFileReader fileReader = new JsonFileReader();

            var filename = $@"{_currentDirectory}\files\jsonFile.json";

            var actual = fileReader.Read(filename);

            Assert.AreEqual("{\r\n  \"text\": \"Hello world!\"\r\n}", actual);
        }

        [TestMethod]
        public void AUserShouldBeAbleToReadAEncryptedJsonFile()
        {
            IEncryptor encryptor = new ReverseEncryptor();
            IFileReader fileReader = new JsonFileReader(encryptor);

            var filename = $@"{_currentDirectory}\files\jsonFile.json";

            var actual = fileReader.Read(filename);
            
            Assert.AreEqual("}\n\r\"!dlrow olleH\" :\"txet\"  \n\r{", actual);
        }

        [TestMethod]
        public void AUserShouldBeAbleToSwitchEncryptionJsonFile()
        {
            IEncryptor encryptor = new ReverseEncryptor();
            var fileReader = new JsonFileReader(encryptor);

            var filename = $@"{_currentDirectory}\files\jsonFile.json";

            var actualReversedText = fileReader.Read(filename);

            fileReader.SetEncryptor(VoidEncryptor.Instance);

            var actualText = fileReader.Read(filename);

            Assert.AreEqual("}\n\r\"!dlrow olleH\" :\"txet\"  \n\r{", actualReversedText);
            Assert.AreEqual("{\r\n  \"text\": \"Hello world!\"\r\n}", actualText);
        }

        [TestMethod]
        public void AAdminShouldBeAbleToReadAllJsonFilesInRoleBasedSecurityContext()
        {
            IFileReader fileReader = new JsonFileReader();
            Authorization adminAuthorization = new AdminAuthorization(fileReader);

            var filename = $@"{_currentDirectory}\files\admin.json";

            var actual = adminAuthorization.Read(filename);

            Assert.AreEqual("{\r\n  \"text\": \"Hello admin!\"\r\n}", actual.ToString());
        }
    }
}
