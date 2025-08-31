using static XorInterceptor.XorEncryption;

var encryptedString = Xor(/*"Hello, World"*/);
Console.WriteLine(encryptedString);
Console.WriteLine("A regular string");
