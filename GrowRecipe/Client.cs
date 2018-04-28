using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace GrowRecipe
{
    public class Client
    {
        public static bool Valid(Stream stream)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "./schema/recipe.xsd");

            XDocument doc = XDocument.Load(stream);

            string msg = "";
            doc.Validate(schemas, (o, e) => {
                msg += e.Message + Environment.NewLine;
            });

            if (msg == "")
            {
                return true;
            }

            return false;
        }
    }
}
