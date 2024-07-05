using DidiSoft.Pgp;

namespace API.Controllers
{
    class PGPVerify
    {
        public static string CommunicationSign(){
            // message to be signed
            string plainString = "Hello World";

            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // sign
            string signedString =
            pgp.SignString(plainString,
                       new FileInfo(@".\Keys\private.asc"), // Private key
                       "private key password");

            return signedString;
        }
        public static bool CommunicationVerify(String signature){
            // create an instance of the library
            PGPLib pgp = new PGPLib();

            // check the signature and extract the data 
            SignatureCheckResult signatureCheck =
                pgp.VerifyString(signature,
                               @".\Keys\public.asc");// Public key

            if (signatureCheck == SignatureCheckResult.SignatureVerified){
                return true;
            }
            else{
                return false;
            }
        }
    }
}