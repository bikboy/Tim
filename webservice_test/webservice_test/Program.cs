using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication3
{
    class Program
    {
        public static string Get_info(string inn, string account)
        {
            string card = null;
            if (account.Length == 4)
            {
                card = account;
                account = null;
            }
            string ws_link = "http://d-imb-mwact:8011/USERVICES/proxy-service/dealdata";
            XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace cab = ws_link;
            var requestXML = new XDocument(
                    new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(cab + "cardinfo",
                            new XElement("inn", inn),
                            new XElement("accountno", account),
                            new XElement("card", card)))));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@ws_link);
            request.Headers.Add(@"Soap:Envelope");
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            string ECA;
            string ECA_Number;
            string credit_check_kab;
            string GiveAllowDate1;
            string firstrepaydate;
            string Requisites_Check;
            string dealstate;
            string Credit_Type;
            string Next_Payment;
            string Next_Payment_Date;
            string Payment_Interval;
            string Appeal_Date;
            string EDPROU;
            string Fullrepayment;
            string dealno;
            string corraccountno;
            string deal_date;
            string errorCode;

            
            /*using (Stream stream = request.GetRequestStream())
            {
                //requestXML.Save(stream);
            }
            */
            using (var writer = XmlWriter.Create(request.GetRequestStream()))
            {
                requestXML.Save(writer);
            }
            request.GetRequestStream().Close();
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    XDocument doc = XDocument.Parse(soapResult);

                    //Console.WriteLine(soapEnvelopeXml.ToString());

                    ECA = doc.Descendants("ECA").FirstOrDefault().Value;
                    ECA_Number = doc.Descendants("ECA_Number").FirstOrDefault().Value;
                    credit_check_kab = doc.Descendants("credit_check_kab").FirstOrDefault().Value;
                    GiveAllowDate1 = doc.Descendants("GiveAllowDate1").FirstOrDefault().Value;
                    firstrepaydate = doc.Descendants("firstrepaydate").FirstOrDefault().Value;
                    Requisites_Check = doc.Descendants("Requisites_Check").FirstOrDefault().Value;
                    dealstate = doc.Descendants("dealstate").FirstOrDefault().Value;
                    Credit_Type = doc.Descendants("Credit_Type").FirstOrDefault().Value;
                    Next_Payment = doc.Descendants("Next_Payment").FirstOrDefault().Value;
                    Next_Payment_Date = doc.Descendants("Next_Payment_Date").FirstOrDefault().Value;
                    Payment_Interval = doc.Descendants("Payment_Interval").FirstOrDefault().Value;
                    Appeal_Date = doc.Descendants("Appeal_Date").FirstOrDefault().Value;
                    EDPROU = doc.Descendants("EDPROU").FirstOrDefault().Value;
                    Fullrepayment = doc.Descendants("Fullrepayment").FirstOrDefault().Value;
                    dealno = doc.Descendants("dealno").FirstOrDefault().Value;
                    corraccountno = doc.Descendants("corraccountno").FirstOrDefault().Value;
                    deal_date = doc.Descendants("deal_date").FirstOrDefault().Value;
                    errorCode = doc.Descendants("errorCode").FirstOrDefault().Value;
                }
            }
            string result = ECA + "|" + ECA_Number + "|" + credit_check_kab + "|" + GiveAllowDate1 + "|" + firstrepaydate + "|" + Requisites_Check + "|" + dealstate + "|" + Credit_Type
                    + "|" + Next_Payment + "|" + Next_Payment_Date + "|" + Payment_Interval + "|" + Appeal_Date + "|" + EDPROU + "|" + Fullrepayment + "|" + dealno
                    + "|" + corraccountno + "|" + deal_date + "|" + errorCode;
            return result;
        }

        public static void Main()
        {
            /*
            string inn = "2044713906";
            string account = "0082";
            string card = null;

            if (account.Length == 4) { 
                    card = account;
                    account = null;
            }

            string ws_link = "http://d-imb-mwact:8011/USERVICES/proxy-service/dealdata";
            XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace cab = ws_link;
            var requestXML = new XDocument(
                    new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                    new XElement(cab + "cardinfo",
                            new XElement("inn", inn),
                            new XElement("accountno", account),
                            new XElement("card",card)))));
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@ws_link);
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
            }*/

            string result = Get_info("2044713906", "0082");
            Console.WriteLine("------------by account no------------");
            Console.WriteLine(result);

            string result2 = Get_info("2044713906", "44410551");
            Console.WriteLine("-----------by card no-------------");
            Console.WriteLine(result2);
            Console.ReadLine();
        }


    }
}
