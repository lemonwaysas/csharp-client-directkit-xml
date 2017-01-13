using System;

namespace Tuto
{
    class Program
    {
        static string wlLogin   = "society";
        static string wlPass    = "123456";
        static string language  = "en";
        static string version   = "2.0";
        static string walletIp  = "1.1.1.1";
        static string walletUa = "ua";

        static void GetWalletDetailsExample(string wallet)
        {
            LemonWayAPI.Service_mb_xmlSoapClient soapClient = new LemonWayAPI.Service_mb_xmlSoapClient();

            var request = new LemonWayAPI.GetWalletDetailsRequest(); // Method Name + "Request"

            // Bind parameters
            request.wlLogin     = wlLogin;
            request.wlPass      = wlPass;
            request.language    = language;
            request.version     = version;
            request.walletIp    = walletIp;
            request.walletUa    = walletUa;

            request.wallet      = wallet;

            var result = soapClient.GetWalletDetails(request).GetWalletDetailsResult; // Method Name + "Result"
            
            // Handle error
            if (result.E != null)
            {
                Console.WriteLine("Error: " + result.E.Error);
                Console.WriteLine("Code: " + result.E.Code);
                Console.WriteLine("Msg: " + result.E.Msg);
                Console.WriteLine("Prio: " + result.E.Prio);
                Console.WriteLine("INT_MSG: " + result.E.INT_MSG);
            }
            else
            {
                Console.WriteLine("ID: " + result.WALLET.ID);
                Console.WriteLine("BAL: " + result.WALLET.BAL);
                Console.WriteLine("NAME: " + result.WALLET.NAME);
                Console.WriteLine("EMAIL: " + result.WALLET.EMAIL);
                if (result.WALLET.DOCS != null)
                {
                    for (int i = 0; i < result.WALLET.DOCS.Length; i++)
                    {
                        Console.WriteLine("DOCS[" + i + "].ID: " + result.WALLET.DOCS[i].ID);
                        Console.WriteLine("DOCS[" + i + "].S: " + result.WALLET.DOCS[i].S);
                        Console.WriteLine("DOCS[" + i + "].TYPE: " + result.WALLET.DOCS[i].TYPE);
                        Console.WriteLine("DOCS[" + i + "].VD: " + result.WALLET.DOCS[i].VD);
                    }
                }
                if (result.WALLET.IBANS != null)
                {
                    for (int i = 0; i < result.WALLET.IBANS.Length; i++)
                    {
                        Console.WriteLine("IBANS[" + i + "].ID: " + result.WALLET.IBANS[i].ID);
                        Console.WriteLine("IBANS[" + i + "].S: " + result.WALLET.IBANS[i].S);
                        Console.WriteLine("IBANS[" + i + "].DATA: " + result.WALLET.IBANS[i].DATA);
                        Console.WriteLine("IBANS[" + i + "].SWIFT: " + result.WALLET.IBANS[i].SWIFT);
                        Console.WriteLine("IBANS[" + i + "].HOLDER: " + result.WALLET.IBANS[i].HOLDER);
                    }
                }
                Console.WriteLine("STATUS: " + result.WALLET.STATUS);
                Console.WriteLine("BLOCKED: " + result.WALLET.BLOCKED);
                if (result.WALLET.SDDMANDATES != null)
                {
                    for (int i = 0; i < result.WALLET.SDDMANDATES.Length; i++)
                    {
                        Console.WriteLine("SDDMANDATES[" + i + "].ID: " + result.WALLET.SDDMANDATES[i].ID);
                        Console.WriteLine("SDDMANDATES[" + i + "].S: " + result.WALLET.SDDMANDATES[i].S);
                        Console.WriteLine("SDDMANDATES[" + i + "].DATA: " + result.WALLET.SDDMANDATES[i].DATA);
                        Console.WriteLine("SDDMANDATES[" + i + "].SWIFT: " + result.WALLET.SDDMANDATES[i].SWIFT);
                    }
                }
                Console.WriteLine("LWID: " + result.WALLET.LWID);
                if (result.WALLET.CARDS != null)
                {
                    for (int i = 0; i < result.WALLET.CARDS.Length; i++)
                    {
                        Console.WriteLine("CARDS[" + i + "].ID: " + result.WALLET.CARDS[i].ID);
                        if (result.WALLET.CARDS[i].EXTRA != null)
                        {
                            Console.WriteLine("CARDS[" + i + "].EXTRA.IS3DS: " + result.WALLET.CARDS[i].EXTRA.IS3DS);
                            Console.WriteLine("CARDS[" + i + "].EXTRA.CTRY: " + result.WALLET.CARDS[i].EXTRA.CTRY);
                            Console.WriteLine("CARDS[" + i + "].EXTRA.AUTH: " + result.WALLET.CARDS[i].EXTRA.AUTH);
                            Console.WriteLine("CARDS[" + i + "].EXTRA.NUM: " + result.WALLET.CARDS[i].EXTRA.NUM);
                            Console.WriteLine("CARDS[" + i + "].EXTRA.EXP: " + result.WALLET.CARDS[i].EXTRA.EXP);
                            Console.WriteLine("CARDS[" + i + "].EXTRA.TYP: " + result.WALLET.CARDS[i].EXTRA.TYP);
                        }
                    }
                }
                Console.WriteLine("FirstName: " + result.WALLET.FirstName);
                Console.WriteLine("LastName: " + result.WALLET.LastName);
                Console.WriteLine("CompanyName: " + result.WALLET.CompanyName);
                Console.WriteLine("CompanyDescription: " + result.WALLET.CompanyDescription);
                Console.WriteLine("CompanyWebsite: " + result.WALLET.CompanyWebsite);
            }
        }

        static void GetWalletTransHistoryExample(string wallet)
        {
            LemonWayAPI.Service_mb_xmlSoapClient soapClient = new LemonWayAPI.Service_mb_xmlSoapClient();

            var request = new LemonWayAPI.GetWalletTransHistoryRequest(); // Method Name + "Request"

            // Bind parameters
            request.wlLogin     = wlLogin;
            request.wlPass      = wlPass;
            request.language    = language;
            request.version     = version;
            request.walletIp    = walletIp;
            request.walletUa    = walletUa;

            request.wallet      = wallet;

            var result = soapClient.GetWalletTransHistory(request).GetWalletTransHistoryResult; // Method Name + "Result"

            // Handle error
            if (result.E != null)
            {
                Console.WriteLine("Error: " + result.E.Error);
                Console.WriteLine("Code: " + result.E.Code);
                Console.WriteLine("Msg: " + result.E.Msg);
                Console.WriteLine("Prio: " + result.E.Prio);
                Console.WriteLine("INT_MSG: " + result.E.INT_MSG);
            }
            else
            {
                for (int i = 0; i < result.TRANS.Length; i++)
                {
                    Console.WriteLine("**********TRANS[" + i + "]**********");
                    Console.WriteLine("TRANS[" + i + "].ID: " + result.TRANS[i].ID);
                    Console.WriteLine("TRANS[" + i + "].DATE: " + result.TRANS[i].DATE);
                    Console.WriteLine("TRANS[" + i + "].SEN: " + result.TRANS[i].SEN);
                    Console.WriteLine("TRANS[" + i + "].REC: " + result.TRANS[i].REC);
                    Console.WriteLine("TRANS[" + i + "].DEB: " + result.TRANS[i].DEB);
                    Console.WriteLine("TRANS[" + i + "].CRED: " + result.TRANS[i].CRED);
                    Console.WriteLine("TRANS[" + i + "].COM: " + result.TRANS[i].COM);
                    Console.WriteLine("TRANS[" + i + "].MSG: " + result.TRANS[i].MSG);
                    Console.WriteLine("TRANS[" + i + "].STATUS: " + result.TRANS[i].STATUS);
                    if (result.TRANS[i].EXTRA != null)
                    {
                        Console.WriteLine("TRANS[" + i + "].EXTRA.IS3DS: " + result.TRANS[i].EXTRA.IS3DS);
                        Console.WriteLine("TRANS[" + i + "].EXTRA.CTRY: " + result.TRANS[i].EXTRA.CTRY);
                        Console.WriteLine("TRANS[" + i + "].EXTRA.AUTH: " + result.TRANS[i].EXTRA.AUTH);
                    }
                   
                    Console.WriteLine("TRANS[" + i + "].INT_MSG: " + result.TRANS[i].INT_MSG);
                    Console.WriteLine("TRANS[" + i + "].MLABEL: " + result.TRANS[i].MLABEL);
                    Console.WriteLine("TRANS[" + i + "].TYPE: " + result.TRANS[i].TYPE);
                    Console.WriteLine("TRANS[" + i + "].PRIVATE_DATA: " + result.TRANS[i].PRIVATE_DATA);
                    Console.WriteLine("TRANS[" + i + "].SCHEDULED_DATE: " + result.TRANS[i].SCHEDULED_DATE);
                    Console.WriteLine("TRANS[" + i + "].MTOKEN: " + result.TRANS[i].MTOKEN);
                    Console.WriteLine("TRANS[" + i + "].METHOD: " + result.TRANS[i].METHOD);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("----------GetWalletDetailsExample----------");
                GetWalletDetailsExample("SC");
                Console.WriteLine("----------GetWalletTransHistoryExample----------");
                GetWalletTransHistoryExample("SC");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }

            Console.ReadKey();
        }
    }
}
