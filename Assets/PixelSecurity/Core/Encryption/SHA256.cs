﻿using System;
using System.Security.Cryptography;
using System.Text;
using PixelSecurity.Constants;

/*
 * Pixel Security Toolkit
 * This is the free and open-source security
 * library with different modules to secure your
 * application.
 *
 * @developer       TinyPlay Games
 * @author          Ilya Rastorguev
 * @version         1.0.0
 * @build           1004
 * @url             https://github.com/TinyPlay/PixelSecurityToolkit/
 * @support         hello@flowsourcebox.com
 */
namespace PixelSecurity.Core.Encryption
{
    /// <summary>
    /// SHA256 Encryption Provider
    /// </summary>
    public class SHA256 : IDataEncryption
    {
        /// <summary>
        /// Encode String Data
        /// </summary>
        /// <param name="plane"></param>
        /// <returns></returns>
        public string EncodeString(string plane)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(plane));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        
        /// <summary>
        /// Encrypt Data Bytes
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public byte[] EncodeBinary(byte[] src)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                var hash = sha256.ComputeHash(src);
                return hash;
            }
        }
        
        /// <summary>
        /// SHA256 Encryption Provider
        /// </summary>
        public SHA256(){}
        
        /// <summary>
        /// Decrypt String
        /// </summary>
        /// <param name="encrypted"></param>
        /// <returns></returns>
        public string DecodeString(string encrypted)
        {
            throw new Exception(TextCodes.ENCRYPTION_HASH_DECODING_ERROR);
        }
        
        /// <summary>
        /// Decrypt Binary Data
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public byte[] DecodeBinary(byte[] src)
        {
            throw new Exception(TextCodes.ENCRYPTION_HASH_DECODING_ERROR);
        }
    }
}