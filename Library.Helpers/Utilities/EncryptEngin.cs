﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Library.Helpers.Utilities
{
    public class EncryptEngin
    {
      // string password  = Encrypt(txtUserName.Text.Trim().ToLower() + "♪" + txtPassword.Text.Trim(), "icat2056913!",true);

        public  string Encrypt(string toEncrypt, string key, bool useHashing)

        {

            byte[] keyArray;

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

 

            //System.Windows.Forms.MessageBox.Show(key);

            //If hashing use get hashcode regards to your key

            if (useHashing)

            {

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                //Always release the resources and flush data

                // of the Cryptographic service provide. Best Practice

 

                hashmd5.Clear();

            }

            else

                keyArray = UTF8Encoding.UTF8.GetBytes(key);

 

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            //set the secret key for the tripleDES algorithm

            tdes.Key = keyArray;

            //mode of operation. there are other 4 modes.

            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;

            //padding mode(if any extra byte added)

 

            tdes.Padding = PaddingMode.PKCS7;

 

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //transform the specified region of bytes array to resultArray

            byte[] resultArray =

              cTransform.TransformFinalBlock(toEncryptArray, 0,

              toEncryptArray.Length);

           //Release resources held by TripleDes Encryptor

            tdes.Clear();

            //Return the encrypted data into unreadable string format

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

 

        public  string Decrypt(string cipherString, string key, bool useHashing)

        {

            byte[] keyArray;

            //get the byte code of the string

 

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

 

            if (useHashing)

            {

                //if hashing was used get the hash code with regards to your key

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                //release any resource held by the MD5CryptoServiceProvider

 

                hashmd5.Clear();

            }

            else

            {

                //if hashing was not implemented get the byte code of the key

                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            }

 

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            //set the secret key for the tripleDES algorithm

            tdes.Key = keyArray;

            //mode of operation. there are other 4 modes.

            //We choose ECB(Electronic code Book)

 

            tdes.Mode = CipherMode.ECB;

            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

 

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(

                                 toEncryptArray, 0, toEncryptArray.Length);

            //Release resources held by TripleDes Encryptor               

            tdes.Clear();

            //return the Clear decrypted TEXT

            return UTF8Encoding.UTF8.GetString(resultArray);

        }
    }
}