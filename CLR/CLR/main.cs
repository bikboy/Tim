using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLR
{
    
    public class CLRProcedures
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static SqlString GetInfo(string inn, string account)
        {
            CLR.clinfo.client_info ws = new CLR.clinfo.client_info();
            CLR.clinfo.Result res = ws.GetInfo(inn, account);
            //SqlString info = res.corraccountno;
            SqlString info = res.id_deal + "|" + res.on_date + "|" + res.fullrepayment + "|" + res.dealno + "|" + res.status_date + "|" + res.credit_check + "|" + res.GiveAllowDate + "|" + res.daysoverdue
                    + "|" + res.deal_state + "|" + res.firstrepaydate + "|" + res.Credit_Type + "|" + res.last_payment + "|" + res.Last_Payment_Date + "|" + res.currmonth_payments + "|" + res.corraccountno
                    + "|" + res.Identifycode + "|" + res.Requisites_Check + "|" + res.Next_Payment + "|" + res.Payment_interval + "|" + res.Appeal_date + "|" + res.Next_Payment_Date + "|" + res.ECA_Number
                    + "|" + res.EDRPOU + "|" + res.ECA + "|" + res.credit_check_kab + "|" + res.deal_date + "|" + res.error_code + "|" + res.first_usage + "|" + res.card_lastdiggits;
            return info;
        }
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static SqlString Get_info(string inn, string account)
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
            string id_deal;
            string on_date;
            string status_date;
            string credit_check;
            string daysoverdue;
            string last_payment;
            string Last_Payment_Date;
            string currmonth_payments;
            string Identifycode;
            string first_usage;
            string card_lastdiggits;

            string errorCode;
            

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
                    id_deal = doc.Descendants("id_deal").FirstOrDefault().Value;
                    on_date = doc.Descendants("on_date").FirstOrDefault().Value;
                    status_date = doc.Descendants("status_date").FirstOrDefault().Value;
                    credit_check = doc.Descendants("credit_check").FirstOrDefault().Value;
                    daysoverdue = doc.Descendants("daysoverdue").FirstOrDefault().Value;
                    last_payment = doc.Descendants("last_payment").FirstOrDefault().Value;
                    Last_Payment_Date = doc.Descendants("Last_Payment_Date").FirstOrDefault().Value;
                    currmonth_payments = doc.Descendants("currmonth_payments").FirstOrDefault().Value;
                    Identifycode = doc.Descendants("Identifycode").FirstOrDefault().Value;
                    first_usage = doc.Descendants("first_usage").FirstOrDefault().Value;
                    card_lastdiggits = doc.Descendants("card_lastdiggits").FirstOrDefault().Value;
                    errorCode = doc.Descendants("errorCode").FirstOrDefault().Value;
                }
            }
            /*SqlString result = ECA + "|" + ECA_Number + "|" + credit_check_kab + "|" + GiveAllowDate1 + "|" + firstrepaydate + "|" + Requisites_Check + "|" + dealstate + "|" + Credit_Type
                    + "|" + Next_Payment + "|" + Next_Payment_Date + "|" + Payment_Interval + "|" + Appeal_Date + "|" + EDPROU + "|" + Fullrepayment + "|" + dealno
                    + "|" + corraccountno + "|" + deal_date + "|" + id_deal + "|" + on_date + "|" + status_date + "|" + credit_check + "|" + daysoverdue + "|" + last_payment + "|" + Last_Payment_Date + "|"
                    + currmonth_payments + "|" + Identifycode + "|" + first_usage + "|" + card_lastdiggits + "|" + errorCode;*/

            SqlString result = id_deal + "|" + on_date + "|" + Fullrepayment + "|" + dealno + "|" + status_date + "|" + credit_check + "|" + GiveAllowDate1 + "|" + daysoverdue
                    + "|" + dealstate + "|" + firstrepaydate + "|" + Credit_Type + "|" + last_payment + "|" + Last_Payment_Date + "|" + currmonth_payments + "|" + corraccountno
                    + "|" + Identifycode + "|" + Requisites_Check + "|" + Next_Payment + "|" + Payment_Interval + "|" + Appeal_Date + "|" + Next_Payment_Date + "|" + ECA_Number
                    + "|" + EDPROU + "|" + ECA + "|" + credit_check_kab + "|" + deal_date + "|" + errorCode + "|" + first_usage + "|" + card_lastdiggits;

            return result;
        }
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static SqlString GetCardInfo(string card, string code)
        {

            var url = "http://10.155.123.28:8801/?txt=2*" + card + "*" + code + "*UAH&api=1";
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);

            bool error = content.Contains("summa");
            SqlString summa_amount;
            SqlString currency;
            if (error == true)
            {
                int summa = content.IndexOf("summa") + 7;
                int summa2 = content.IndexOf("cardNo") - 2;
                currency = "UAH";
                summa_amount = content.Substring(summa, summa2 - summa) + "/" + currency;
            }
            else
            {
                url = "http://10.155.123.28:8801/?txt=2*" + card + "*" + code + "*USD&api=1";
                syncClient = new WebClient();
                content = syncClient.DownloadString(url);
                error = content.Contains("summa");
                if (error == true)
                {
                    int summa = content.IndexOf("summa") + 7;
                    int summa2 = content.IndexOf("cardNo") - 2;
                    currency = "USD";
                    summa_amount = content.Substring(summa, summa2 - summa) + "/" + currency;

                }
                else
                {
                    url = "http://10.155.123.28:8801/?txt=2*" + card + "*" + code + "*EUR&api=1";
                    syncClient = new WebClient();
                    content = syncClient.DownloadString(url);
                    error = content.Contains("summa");
                    if (error == true)
                    {
                        int summa = content.IndexOf("summa") + 7;
                        int summa2 = content.IndexOf("cardNo") - 2;
                        currency = "EUR";
                        summa_amount = content.Substring(summa, summa2 - summa) + "/" + currency;

                    }
                    else
                    {
                        summa_amount = "error";
                    }

                }

            }
            return summa_amount;

        }
    }
}
