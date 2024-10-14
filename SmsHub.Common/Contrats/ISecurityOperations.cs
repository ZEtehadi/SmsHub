﻿namespace SmsHub.Common.Contrats
{
    public interface ISecurityOperations
    {
        Task<string> GetSha512Hash(string plainText);
        Guid CreateCryptographicallySecureGuid();
        string EncryptAesGcm(string plainText);
        string DecryptAesGcm(string encryptedText);

        string Base64Encode(string plainText);
        string Base64Decode(string base64EncodedData);
    }
}
