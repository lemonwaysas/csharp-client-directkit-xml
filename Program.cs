using System;

namespace Tuto
{
    class Program
    {
        static string wlLogin   = "society";
        static string wlPass    = "123456";
        static string language  = "en";
        static string version   = "1.8";
        static string walletIp  = "1.1.1.1";
        static string walletUa = "ua";
        
        static LemonWayAPI.Service_mb_xmlSoapClient soapClient = new LemonWayAPI.Service_mb_xmlSoapClient();

        static void GetWalletDetailsExample(string wallet)
        {
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
                foreach (System.Reflection.PropertyInfo eProperty in result.E.GetType().GetProperties())
                {
                    Console.WriteLine(eProperty.Name + ": " + eProperty.GetValue(result.E));
                }
            }
            else
            {
                Console.WriteLine("ID: " + result.WALLET.ID);
                Console.WriteLine("BAL: " + result.WALLET.BAL);
                Console.WriteLine("NAME: " + result.WALLET.NAME);
                Console.WriteLine("EMAIL: " + result.WALLET.EMAIL);
                for (int i = 0; i < result.WALLET.DOCS.Length; i++)
                {
                    Console.WriteLine("DOCS[" + i + "].ID: " + result.WALLET.DOCS[i].ID);
                    Console.WriteLine("DOCS[" + i + "].S: " + result.WALLET.DOCS[i].S);
                    Console.WriteLine("DOCS[" + i + "].TYPE: " + result.WALLET.DOCS[i].TYPE);
                    Console.WriteLine("DOCS[" + i + "].VD: " + result.WALLET.DOCS[i].VD);
                }
                for (int i = 0; i < result.WALLET.IBANS.Length; i++)
                {
                    Console.WriteLine("IBANS[" + i + "].ID: " + result.WALLET.IBANS[i].ID);
                    Console.WriteLine("IBANS[" + i + "].S: " + result.WALLET.IBANS[i].S);
                    Console.WriteLine("IBANS[" + i + "].DATA: " + result.WALLET.IBANS[i].DATA);
                    Console.WriteLine("IBANS[" + i + "].SWIFT: " + result.WALLET.IBANS[i].SWIFT);
                    Console.WriteLine("IBANS[" + i + "].HOLDER: " + result.WALLET.IBANS[i].HOLDER);
                }
                Console.WriteLine("STATUS: " + result.WALLET.STATUS);
                Console.WriteLine("BLOCKED: " + result.WALLET.BLOCKED);
                for (int i = 0; i < result.WALLET.SDDMANDATES.Length; i++)
                {
                    Console.WriteLine("SDDMANDATES[" + i + "].ID: " + result.WALLET.SDDMANDATES[i].ID);
                    Console.WriteLine("SDDMANDATES[" + i + "].S: " + result.WALLET.SDDMANDATES[i].S);
                    Console.WriteLine("SDDMANDATES[" + i + "].DATA: " + result.WALLET.SDDMANDATES[i].DATA);
                    Console.WriteLine("SDDMANDATES[" + i + "].SWIFT: " + result.WALLET.SDDMANDATES[i].SWIFT);
                }
                Console.WriteLine("LWID: " + result.WALLET.LWID);
                for (int i = 0; i < result.WALLET.CARDS.Length; i++)
                {
                    Console.WriteLine("CARDS[" + i + "].ID: " + result.WALLET.CARDS[i].ID);
                    foreach (System.Reflection.PropertyInfo extraProterty in result.WALLET.CARDS[i].EXTRA.GetType().GetProperties())
                    {
                        Console.WriteLine("CARDS[" + i + "]." + extraProterty.Name + ": " + extraProterty.GetValue(result.WALLET.CARDS[i].EXTRA));
                    }
                }
            }
        }

        static void GetWalletTransHistoryExample(string wallet)
        {
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
                foreach (System.Reflection.PropertyInfo eProperty in result.E.GetType().GetProperties())
                {
                    Console.WriteLine(eProperty.Name + ": " + eProperty.GetValue(result.E));
                }
            }
            else
            {
                for (int i = 0; i < result.TRANS.Length; i++)
                {
                    Console.WriteLine("**********TRANS[" + i + "]**********");
                    foreach (System.Reflection.PropertyInfo transProterty in result.TRANS[i].GetType().GetProperties())
                    {
                        if (transProterty.Name == "EXTRA" && transProterty.GetValue(result.TRANS[i]) != null)
                        {
                            foreach (System.Reflection.PropertyInfo extraProterty in result.TRANS[i].EXTRA.GetType().GetProperties())
                            {
                                Console.WriteLine("TRANS[" + i + "].EXTRA." + extraProterty.Name + ": " + extraProterty.GetValue(result.TRANS[i].EXTRA));
                            }
                        }
                        else
                        {
                            Console.WriteLine("TRANS[" + i + "]." + transProterty.Name + ": " + transProterty.GetValue(result.TRANS[i]));
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("----------GetWalletDetailsExample----------");
            GetWalletDetailsExample("testSDD");
            Console.WriteLine("----------GetWalletTransHistoryExample----------");
            GetWalletTransHistoryExample("testSDD");
            Console.ReadKey();
        }
    }
}
