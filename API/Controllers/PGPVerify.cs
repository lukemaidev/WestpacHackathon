using PgpCore;

namespace API.Controllers
{
    class PGPVerify
    {
        public static async Task<string> CommunicationSign(string plainString){

            // Load keys
            string privateKey = File.ReadAllText(@".\Keys\private.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(privateKey, "password");

            // create an instance of the library with keys
            PGP pgp = new PGP(encryptionKeys);

            // sign
            string signedString = await pgp.SignAsync(plainString);

            return signedString;
        }
        public static async Task<bool> CommunicationVerify(string signature){

            // Load keys
            string publicKey = File.ReadAllText(@".\Keys\public.asc");
            EncryptionKeys encryptionKeys = new EncryptionKeys(publicKey);

            // Create an instance of hte library with keys
            PGP pgp = new PGP(encryptionKeys);

            // Verify
            bool verified = await pgp.VerifyAsync(signature);

            return verified;
        }
    }
}