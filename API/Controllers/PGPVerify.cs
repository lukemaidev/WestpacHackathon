using System;
using System.IO;
using DidiSoft.Pgp;

namespace API.Controllers
{
    class PGPVerify
    {
        public static string CommunicationSign()
        {
            // message to be signed
            string plainString = "Hello World";

            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // sign
            string signedString =
            pgp.SignString(plainString,
                       new FileInfo(@".private_key.asc"),
                       "private key password");

            Console.WriteLine(signedString);
            return signedString;
        }
        public static bool CommunicationVerify()
        {
            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // check the signature and extract the data 
            SignatureCheckResult signatureCheck =
                pgp.VerifyFile(@"C:\Test\INPUT.pgp", // Input
                               @"C:\Test\public_key.asc", // Public key
                               @"C:\Test\OUTPUT.txt"); // Output

            if (signatureCheck == SignatureCheckResult.SignatureVerified)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}