using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookLogicLayer;
using XMLExporterInterface;

namespace XMLExporter
{
    /// <summary>
    /// Allows to work with books by XML writer.
    /// </summary>
    public class XMLExporterXmlWriter : IXMLExporter
    {
        /// <summary>
        /// Export books to the XML file.
        /// </summary>
        /// <param name="books">Books collection.</param>
        /// <param name="filePath">Filepath.</param>
        public void Export(IEnumerable<Book> books, string filePath)
        {
            if (ReferenceEquals(books, null)) throw new ArgumentNullException();
            using (var xmlWriter = XmlWriter.Create(filePath, null))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Library");
                foreach (var book in books)
                {
                    xmlWriter.WriteStartElement("Book");
                    xmlWriter.WriteAttributeString("Year", book.Year.ToString());                    
                    xmlWriter.WriteAttributeString("Pages", book.Pages.ToString());
                    xmlWriter.WriteElementString("Title", book.Title);
                    xmlWriter.WriteElementString("Author", book.Author);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
        }
    }
}
