﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PasswordHash
/// </summary>
public class PasswordHash
{
	    private string passwd;
        private string passkey;


    public Byte[] HashIt(string password, string passkey)
    {
        passwd = password;
        this.passkey = passkey;


        //Byte arrays to store the bytes for the password
        Byte[] originalBytes;
        Byte[] encodedBytes;
        //use a modern method to hash
        SHA512 shaHash = SHA512.Create();


        //combine the passkey and the password
        string passToHash = passkey + passwd;


        //convert the string to bytes
        originalBytes = ASCIIEncoding.Default.GetBytes(passToHash);
        //take the converted string and hash it
        encodedBytes = shaHash.ComputeHash(originalBytes);


        //return the hashed password
        return encodedBytes;


    	}
}