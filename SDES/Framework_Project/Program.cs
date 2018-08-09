using System;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Framework_Project.Security;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;
using ForensicsCourseToolkit.Framework_Project.Serialization;

namespace ForensicsCourseToolkit.Framework_Project
{
    public static class Program
    {
        public static bool[] LoggingFlags =
        {
            true,
            true,
            true,
            true,
            true
        };

        public static Color[] Messages_Colors =
        {
            Color.Green,
            Color.Magenta,
            Color.Red,
            Color.Orange,
            Color.DarkRed
        };

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

        //  TestLibraries();
            Application.Run(new mainFrm());
          //  Application.Run(new Framework_Project.Examination.PerformanceTesting());
        }

        private static void TestLibraries(bool testCompression = true, bool testEncryption = true)
        {

            var myOrgMsg = "123456";
            var encryptedx = AESGCM.SimpleEncryptWithPassword(myOrgMsg, "123456");

            var decryptedx = AESGCM.SimpleDecryptWithPassword(encryptedx, "1234567");
            try
            {
                Parallel.For(0, 1000000, i =>
                   {
                       var v = new InstructorValidationData($"Std{i}", DateTime.Now, 10, 11);
                       var serialized = SerializationHelper.Serialize<InstructorValidationData>(v);
                       if (serialized == null)
                       {
                           throw new Exception("serialized==null");
                       }


                       string compressedString = Framework_Project.Compression.CompressionHelper.Zip(serialized);
                       if (compressedString == null)
                       {
                           throw new Exception("compressed==null");
                       }
                     //  string decompressed = Framework_Project.Compression.CompressionHelper.Unzip(compressedString);


                       string encrypted = AESGCM.SimpleEncryptWithPassword(compressedString, $"Keyyy{i}");
                       if (encrypted == null)
                       {
                           throw new Exception("encrypted==null");
                       }

                       string decrypted = AESGCM.SimpleDecryptWithPassword(encrypted, $"Keyyy{i}");
                       if (decrypted == null)
                       {
                           throw new Exception("decrypted==null");
                       }

                       if (decrypted != compressedString)
                       {
                           throw new Exception("decrypted!=compressedString");
                       }

                       

                       if(!StructuralComparisons.StructuralEqualityComparer.Equals(decrypted, compressedString))
                       {                         
                               throw new Exception("decryptedBytes!=compressed");                        
                       }

                       string decompressed = Framework_Project.Compression.CompressionHelper.Unzip(decrypted);
                       if (decompressed == null)
                       {
                           throw new Exception("decompressed==null");
                       }
                       if (decompressed != serialized)
                       {
                           throw new Exception("decompressed != serialized");

                       }


                       var deserialized = SerializationHelper.Deserialize<InstructorValidationData>(serialized);

                   });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}