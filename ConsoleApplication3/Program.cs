using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication3
{
    class Program
    {

        public static void Main()
        {

            XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace cab = "https://edwdevel/cabinet/";
            var requestXML = new XDocument(
                //new XDeclaration("1.0", "utf-8", String.Empty),
                new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(cab + "cardinfo",
                            new XElement("inn", "2044713906"),
                            /*new XElement("accountno", "44410551")*/
                            new XElement("card","0082")))));
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(requestXML.ToString());
            Console.WriteLine(requestXML);

            //HttpWebRequest request = ConsoleApplication3.Program.CreateWebRequest();
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://d-imb-mwact:8011/USER_SERVICES/cabinet/services/cabinet");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://edwdevel/cabinet/index.php");
            //Trust all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);
            request.Headers.Add(@"Soap:Envelope");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            

            using (Stream stream = request.GetRequestStream())
            {
                requestXML.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    XDocument doc = XDocument.Parse(soapResult);

                    //Console.WriteLine(soapEnvelopeXml.ToString());

                    var result = doc.Descendants("corraccountno").FirstOrDefault().Value;

                    Console.WriteLine(result);

                    Console.WriteLine(doc);

                    Console.ReadLine();
                }
            }
        }
        
        
    }
}
