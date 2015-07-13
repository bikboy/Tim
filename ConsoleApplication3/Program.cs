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
                            new XElement("inn","1"),
                            new XElement("accountno","1")
                            /*new XElement("card",null)*/))));
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(requestXML.ToString());
            Console.WriteLine(requestXML);

            //HttpWebRequest request = ConsoleApplication3.Program.CreateWebRequest();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://d-imb-mwact:8011/USER_SERVICES/cabinet/services/cabinet");
            request.Headers.Add(@"Soap:Envelope");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            /*XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                                      <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:cab=""http://d-imb-mwact:8011/USER_SERVICES/cabinet/services/cabinet"">
                                        <soapenv:Header/>
                                        <soapenv:Body>
                                            <cab:cardinfo>
                                                <inn>1</inn>
                                                <accountno>1</accountno>
                                                <card></card>
                                            </cab:cardinfo>
                                        </soapenv:Body>
                                      </soapenv:Envelope>");*/

            using (Stream stream = request.GetRequestStream())
            {
                //soapEnvelopeXml.Save(stream);
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

                    Console.ReadLine();
                }
            }
        }
        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://d-imb-mwact:8011/USER_SERVICES/cabinet/services/cabinet");
            webRequest.Headers.Add(@"Soap:Envelope");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
            
        }
        
    }
}
