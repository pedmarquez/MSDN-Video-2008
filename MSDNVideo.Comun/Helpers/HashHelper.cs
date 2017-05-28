using System.Security.Cryptography;
using System;

public class HashHelper
{
    private const int _longitudSalt = 4;
    private const int _longitudClaveMax = 20;

    public static string CalcularHash(string clave)
    {
        byte[] claveBinaria;
        byte[] salt;
        byte[] claveHashedYHash;

        // Recorto la clave si supera el máximo
        if(clave.Length > _longitudClaveMax)
            clave = clave.Substring(0, _longitudClaveMax);

        claveBinaria = System.Text.Encoding.Unicode.GetBytes(clave);
        salt = CrearSalt(_longitudSalt);

        claveHashedYHash = CalcularHash(claveBinaria, salt);

        // Convertimos a texto y devolvemos
        return Convert.ToBase64String(claveHashedYHash);

    }

    public static bool ValidarClave(string clave1, string clave2Hashed)
    {
        byte[] salt;
        int saltOffset;
        byte[] clave2HashedBinaria;
        byte[] clave1Hashed;

        // Recuperamos el hash almacenado
        clave2HashedBinaria = Convert.FromBase64String(clave2Hashed);
        salt = new byte[_longitudSalt];
        saltOffset = clave2HashedBinaria.Length - _longitudSalt;
        int i;
        for(i=0;i<_longitudSalt;i++)
        {
            salt[i] = clave2HashedBinaria[saltOffset + i];
        }

        // Realizamos el hash para compararlo
        clave1Hashed = CalcularHash(System.Text.Encoding.Unicode.GetBytes(clave1), salt);

        return CompararClaves(clave1Hashed, clave2HashedBinaria);
    }

    private static byte[] CrearSalt(int size)
    {
        // Generamos un código aleatorio para el cifrado.
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];

        rng.GetBytes(buff);
        return buff;
    }

    private static byte[] CalcularHash(byte[] clave, byte[] salt)
    {
        byte[] claveSalted;
        byte[] claveHashed;
        byte[] claveHashedYHash;

        // Concatenamos clave y valor salt
        claveSalted = new byte[clave.Length + salt.Length];
        clave.CopyTo(claveSalted, 0);
        salt.CopyTo(claveSalted, clave.Length);

        // Generamos el hash de la unión
        HashAlgorithm  ha = new SHA1CryptoServiceProvider();
        claveHashed = ha.ComputeHash(claveSalted);

        // Añadimos el salt al hash en texto claro
        claveHashedYHash = new byte[claveHashed.Length + salt.Length];
        claveHashed.CopyTo(claveHashedYHash, 0);
        salt.CopyTo(claveHashedYHash, claveHashed.Length);

        return claveHashedYHash;
    }

    

    private static bool CompararClaves(byte[] clave1, byte[] clave2)
    {
        int i;

        if (clave1.Length != clave2.Length)
            return false;

        for(i=0;i<clave1.Length;i++)
        {
            if (clave1[i] != clave2[i])
                return false;
        }

        return true;
    }
}

