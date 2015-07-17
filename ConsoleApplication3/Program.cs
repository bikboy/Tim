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
            string inn = "2044713906";
            string account = "44410551";
            string card = "0082";
            string ws_link = "http://d-imb-mwact:8011/USERVICES/proxy-service/dealdata";
            XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            //XNamespace cab = "https://edwdevel/cabinet/";
            XNamespace cab = ws_link;
            var requestXML = new XDocument(
                    new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(cab + "cardinfo",
                            new XElement("inn", inn),
                            /*new XElement("accountno", "44410551")*/
                            new XElement("card",card)))));
            XmlDocument doc1 = new XmlDocument();
            //doc1.LoadXml(requestXML.ToString());
            //Console.WriteLine(requestXML);

            //HttpWebRequest request = ConsoleApplication3.Program.CreateWebRequest();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@ws_link);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://edwdevel/cabinet/index.php");
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

                    var ECA = doc.Descendants("ECA").FirstOrDefault().Value;
                    var ECA_Number = doc.Descendants("ECA_Number").FirstOrDefault().Value;
                    var credit_check_kab = doc.Descendants("credit_check_kab").FirstOrDefault().Value;
                    var GiveAllowDate1 = doc.Descendants("GiveAllowDate1").FirstOrDefault().Value;
                    var firstrepaydate = doc.Descendants("firstrepaydate").FirstOrDefault().Value;
                    var Requisites_Check = doc.Descendants("Requisites_Check").FirstOrDefault().Value;
                    var dealstate = doc.Descendants("dealstate").FirstOrDefault().Value;
                    var Credit_Type = doc.Descendants("Credit_Type").FirstOrDefault().Value;
                    var Next_Payment = doc.Descendants("Next_Payment").FirstOrDefault().Value;
                    var Next_Payment_Date = doc.Descendants("Next_Payment_Date").FirstOrDefault().Value;
                    var Payment_Interval = doc.Descendants("Payment_Interval").FirstOrDefault().Value;
                    var Appeal_Date = doc.Descendants("Appeal_Date").FirstOrDefault().Value;
                    var EDPROU = doc.Descendants("EDPROU").FirstOrDefault().Value;
                    var Fullrepayment = doc.Descendants("Fullrepayment").FirstOrDefault().Value;
                    var dealno = doc.Descendants("dealno").FirstOrDefault().Value;
                    var corraccountno = doc.Descendants("corraccountno").FirstOrDefault().Value;
                    var deal_date = doc.Descendants("deal_date").FirstOrDefault().Value;
                    var errorCode = doc.Descendants("errorCode").FirstOrDefault().Value;

                    Console.WriteLine("ECA = " + ECA);
                    Console.WriteLine("ECA_Number = " + ECA_Number);
                    Console.WriteLine("credit_check_kab = " + credit_check_kab);
                    Console.WriteLine("GiveAllowDate1 = " + GiveAllowDate1);
                    Console.WriteLine("firstrepaydate = " + firstrepaydate);
                    Console.WriteLine("Requisites_Check = " + Requisites_Check);
                    Console.WriteLine("dealstate = " + dealstate);
                    Console.WriteLine("Credit_Type = " + Credit_Type);
                    Console.WriteLine("Next_Payment = " + Next_Payment);
                    Console.WriteLine("Next_Payment_Date = " + Next_Payment_Date);
                    Console.WriteLine("Payment_Interval = " + Payment_Interval);
                    Console.WriteLine("Appeal_Date = " + Appeal_Date);
                    Console.WriteLine("EDPROU = " + EDPROU);
                    Console.WriteLine("Fullrepayment = " + Fullrepayment);
                    Console.WriteLine("dealno = " + dealno);
                    Console.WriteLine("corraccountno = " + corraccountno);
                    Console.WriteLine("deal_date = " + deal_date);
                    Console.WriteLine("errorCode = " + errorCode);


                    //Console.WriteLine(doc);

                    Console.ReadLine();
                }
            }
        }
        
        
    }
}
