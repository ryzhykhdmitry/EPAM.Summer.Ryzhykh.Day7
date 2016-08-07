using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookLogicLayer;
using XMLExporterInterface;


namespace XMLExporter
{
    /// <summary>
    /// Allows to work with books by XML LINQ.
    /// </summary>
    public class XMLExporterLINQ : IXMLExporter
    {
        /// <summary>
        /// Allows to work with books by XML LINQ.
        /// </summary>
        /// <param name="books">Books collection.</param>
        /// <param name="filePath">Filepath.</param>
        public void Export(IEnumerable<Book> books, string filePath)
        {
            if (ReferenceEquals(books, null)) throw new ArgumentNullException();

            XDocument doc = new XDocument(
                new XElement("Library",
                    books.Select(p =>
                        new XElement("Book",
                            new XElement("Title", p.Author),
                            new XElement("Author", p.Title),
                            new XAttribute("Year", p.Year),                           
                            new XAttribute("Pages", p.Pages)))));
            doc.Save(filePath);
        }
    }
}
