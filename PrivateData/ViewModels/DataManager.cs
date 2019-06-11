using PrivateData.Models;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace PrivateData.ViewModels
{
    public class DataManager
    {
        PData privateData;
        //public delegate void ProgressChanged(int progress, int maxValue);
        //public event ProgressChanged ProgressChanges;
        public string Title => privateData.Title;
        public string Contents => privateData.Contents;
        public Bitmap[] Images => privateData.Images.ToArray();

        public DataManager(string title, string contents)
        {
            privateData = new PData(title, contents);
        }

        public void AddImage(string pathToFile)
        {
            Bitmap image = new Bitmap(pathToFile);
            privateData.AddImage(image);
        }

        public void RemoveImage(Bitmap image)
        {
            privateData.RemoveImage(image);
        }

        public void SaveData(string filePath, string pass)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, privateData);

            byte[] encrypted = EncryptBytes(ms.ToArray(), pass);
            byte[] encAndCompressed = CompressBytes(encrypted);

            File.WriteAllBytes(filePath, encAndCompressed);
            File.SetAttributes(filePath, FileAttributes.Encrypted);
        }

        public void LoadData(string filePath, string pass)
        {
            BinaryFormatter bf = new BinaryFormatter();
            byte[] data = File.ReadAllBytes(filePath);
            byte[] dataDecompressed = DecompressBytes(data);
            byte[] dataDecompAndDecrypt = DecryptBytes(dataDecompressed, pass);
            PData result = bf.Deserialize(new MemoryStream(dataDecompAndDecrypt)) as PData;

            if (result.Images == null)
            {
                result.Images = new List<Bitmap>();
            }

            privateData = result;
        }

        private byte[] CompressBytes(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
        private byte[] DecompressBytes(byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }
        private static SymmetricAlgorithm GetAlgorithm(string password)
        {
            Rijndael algorithm = Rijndael.Create();
            Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(password, new byte[] {
        0x53,0x6f,0x64,0x69,0x75,0x6d,0x20,             // salty goodness
        0x43,0x68,0x6c,0x6f,0x72,0x69,0x64,0x65
    });
            algorithm.Padding = PaddingMode.ISO10126;
            algorithm.Key = rdb.GetBytes(32);
            algorithm.IV = rdb.GetBytes(16);
            return algorithm;
        }

        public byte[] EncryptBytes(byte[] clearBytes, string password)
        {
            SymmetricAlgorithm algorithm = GetAlgorithm(password);
            ICryptoTransform encryptor = algorithm.CreateEncryptor();
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
                return ms.ToArray();
            }
        }
        public byte[] DecryptBytes(byte[] cipherBytes, string password)
        {
            SymmetricAlgorithm algorithm = GetAlgorithm(password);
            ICryptoTransform decryptor = algorithm.CreateDecryptor();

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
            {
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();
                return ms.ToArray();
            }
        }
    }
}
