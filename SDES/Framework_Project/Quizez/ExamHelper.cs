using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project.Security;
using ForensicsCourseToolkit.Framework_Project.Security.Crypto;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    public static class ExamHelper
    {

        public static Exam GetRandomExamforTesting(int numberOfQs, int duration = 30)
        {
            List<Question> questions = new List<Question>();
            Parallel.For(0, numberOfQs,
                index =>
                {
                    Random aRandom = new Random();
                    var q = new Question(
                        $"Question{index + 1} Description", $"Question{index + 1} Asset",
                        $"Correct_AnswerforQuestion[{index + 1}]", $"CorrectAnswerForQuestion[{index + 1}]",
                        new List<string>() {
                    $"Question{index+1}_Choice_1",$"Question{index+1}_Choice_2",
                    $"Question{index+1}_Choice_3",$"Question{index+1}_Choice_4",
                    $"Correct_AnswerforQuestion[{index+1}]"},
                        aRandom.Next(1, 5), (QuizHelper.QuestionDifficulty)aRandom.Next(1, 3));

                    lock (questions)
                    {
                        questions.Add(q);
                    }
                });

            //for (int i = 0; i < numberOfQs; i++)
            //{
            //    Random aRandom = new Random();
            //    var q = new Question(
            //        $"Question{i + 1} Description", $"Question{i + 1} Asset",
            //        $"Correct_AnswerforQuestion[{i + 1}]", $"CorrectAnswerForQuestion[{i + 1}]",
            //        new List<string>() {
            //        $"Question{i+1}_Choice_1",$"Question{i+1}_Choice_2",
            //        $"Question{i+1}_Choice_3",$"Question{i+1}_Choice_4",
            //        $"Correct_AnswerforQuestion[{i+1}]"},
            //        aRandom.Next(1, 5), (QuizHelper.QuestionDifficulty)aRandom.Next(1, 3));

            //    questions.Add(q);
            //}
            return new Exam(questions, "123456", "Performance Test Exam", duration);

            // return GetExamFileWithoutSave(anExam, "123456","",FilterationSecurityLevel.Moderate);//This moderate does not mean that the system is moderate, the next step in the connection defines the security requirement
        }
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        static string temp_ser;
        public static bool ValidateExamCopy(string examCopy, string studentPassword, Logger aLogger, string sharedKeyIS, FilterationSecurityLevel secLevel, string SequenceNumberOriginal)
        {
            try
            {
                var x = GetExamFromByteArray(examCopy, studentPassword, sharedKeyIS, secLevel);

                long orgSN = long.Parse(SequenceNumberOriginal);
                long newSN = long.Parse(x.RequiredStudentDetails.SequenceNumber);
                if (orgSN == newSN - 1)
                {
                    aLogger.LogMessage("[Correct Sequence Number ::: Exam Validated Correctly]", LogMsgType.Verbose);
                    return true;
                }
                else
                {
                    aLogger.LogMessage($"[Incorrect Sequence Number ::: Wrong Exam ... OriginalSN:[{SequenceNumberOriginal}], ReceivedSN:[{x.RequiredStudentDetails.SequenceNumber}]", LogMsgType.Verbose);
                    return false;
                }
            }
            catch (Exception ex)
            {
                aLogger.LogMessage("INVALID EXAM FILE OR PASSWORD:" + ex.ToString(), LogMsgType.Error);
                return false;
            }
        }
        public static bool ValidateExamCopy(string examCopy, string studentPassword, string sharedKeyIS, FilterationSecurityLevel secLevel)
        {
            try
            {
                var x = GetExamFromByteArray(examCopy, studentPassword, sharedKeyIS, secLevel);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static void ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    throw new Exception("Please create a new file, we cannot overrite an existing file.");
                }

                using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception caught in process: {0}", ex);

            }
        }
        public static void ByteArrayToFile(string fileName, string str)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    throw new Exception("Please create a new file, we cannot overrite an existing file.");
                }


                File.WriteAllText(fileName, str);
   
            }
            catch (Exception ex)
            {
                throw new Exception("Exception caught in process: {0}", ex);

            }
        }

        public static void CreateExamAndSafeXMLToFile(List<Question> FinalQuestions, string examDescription, int examDuration, string instructorPassword, string studentPassword, string saveLocation)
        {
            try
            {
                //Create Exam
                Exam anExam = new Exam(FinalQuestions, instructorPassword, examDescription, examDuration,dontEncrypt:true);
                //Export the Exam 
                SaveExamXMLToFile(anExam, saveLocation);
            }
            catch (Exception ex)
            {
                throw new Exception("[Exception: Cannot Create exam in Exam Helper] [inner: " + ex.ToString());
            }
        }

        public static void CreateExamAndSafeToFile(List<Question> FinalQuestions, string examDescription, int examDuration, string instructorPassword, string studentPassword, string saveLocation)
        {
            try
            {
                //Create Exam
                Exam anExam = new Exam(FinalQuestions, instructorPassword, examDescription, examDuration);
                //Export the Exam 
                SaveExamToFile(anExam, studentPassword, saveLocation);
            }
            catch (Exception ex)
            {
                throw new Exception("[Exception: Cannot Create exam in Exam Helper] [inner: " + ex.ToString());
            }
        }
        public static void SaveExamXMLToFile(Exam anExam,  string saveLocation)
        {
            try
            {
                //Serialize
                var ser = Framework_Project.Serialization.SerializationHelper.SerializeXML(anExam);
                File.WriteAllText(saveLocation,ser);
                }
            catch (Exception ex)
            {
                throw new Exception("[Exception: Cannot Create exam in Exam Helper SaveExamXMLToFile] [inner: " + ex.ToString());
            }
        }

        public static void SaveExamToFile(Exam anExam, string studentPassword, string saveLocation)
        {
            try
            {
                //Serialize
                var ser = Framework_Project.Serialization.SerializationHelper.Serialize(anExam);
                //Add special string at loca{0-2} to check for description in the future
                temp_ser = ser;
                ser = "FCT" + ser;

                //compress before encryption is better to reduce size

                var compressed = Framework_Project.Compression.CompressionHelper.Zip(ser);
                //Encrypt using student password
               string encrypted = AESGCM.SimpleEncryptWithPassword(compressed, studentPassword);

                ByteArrayToFile(saveLocation, encrypted);
            }
            catch (Exception ex)
            {
                throw new Exception("[Exception: Cannot Create exam in Exam Helper SaveExamToFile] [inner: " + ex.ToString());
            }
        }

        public static string GetExamFileWithoutSave(Exam anExam, string examKey, string sharedKeyIS, FilterationSecurityLevel secLevel)
        {
            try
            {
                //Serialize
                var ser = Framework_Project.Serialization.SerializationHelper.Serialize(anExam);
                //Add special string at loca{0-2} to check for description in the future
                temp_ser = ser;
                ser = "FCT" + ser;

                if (secLevel == FilterationSecurityLevel.Moderate)
                {
                    //compress before encryption is better to reduce size
                    var compressed = Framework_Project.Compression.CompressionHelper.Zip(ser);
                    //Encrypt using Exam Key
                    var encrypted = AESGCM.SimpleEncryptWithPassword(compressed, examKey);

                    return encrypted;
                }
                else if (secLevel == FilterationSecurityLevel.High) //REMOVE DOUBLE ENCRYPTION FROM ALGO IN PAPER
                {
                    //compress before encryption is better to reduce size

                    var compressed = Framework_Project.Compression.CompressionHelper.Zip(ser);
                    //Encrypt using student password SharedKeyIS
                    var encrypted = AESGCM.SimpleEncryptWithPassword(compressed, sharedKeyIS);

                    return encrypted;
                }


                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("[Exception: Cannot Create exam in Exam Helper SaveExamToFile] [inner: " + ex.ToString());
            }
        }

        public static byte[] GetExamFileAsBytes(string fileLocation)
        {
            return File.ReadAllBytes(fileLocation);
        }
        public static string GetExamFileAsString(string fileLocation)
        {
            return File.ReadAllText(fileLocation);
        }
        public static Exam GetExamFromFile(string fileLocation, string studentPassword, string sharedKeyIS, FilterationSecurityLevel secLevel)
        {
            //Get byte array from file name 
            //var encrypted = GetExamFileAsBytes(fileLocation);

            var encrypted = File.ReadAllText(fileLocation);
            return GetExamFromByteArray(encrypted, studentPassword, sharedKeyIS, secLevel);
        }


        public static Exam GetExamFromString(string zippedFile, string studentPassword, string sharedKeyIS, FilterationSecurityLevel secLevel)
        {
           //string byteArray = "";
           // int indexBA = 0;
           // foreach (char item in zippedFile.ToCharArray())
           // {
           //     byteArray[indexBA++] = (byte)item;
           // }
            return GetExamFromByteArray(zippedFile, studentPassword, sharedKeyIS, secLevel);
        }
        public static Exam GetExamFromByteArray(string encryptedFile, string examKey, string sharedKeyIS, FilterationSecurityLevel secLevel)
        {
            string decrypted;
            if (secLevel == FilterationSecurityLevel.Moderate)
            {
                decrypted = AESGCM.SimpleDecryptWithPassword(encryptedFile, examKey);
            }
            else
            {
                decrypted = AESGCM.SimpleDecryptWithPassword(encryptedFile, sharedKeyIS);
            }
            //unzip

            if(decrypted== null)
            {
                int x = 10;
            }
            var unzippedFile = Framework_Project.Compression.CompressionHelper.Unzip(decrypted);


            if (unzippedFile.Substring(0, 3) != "FCT")
            {
                throw new InvalidStudentPasswordException("In GetExamFromFile");
            }
            unzippedFile = unzippedFile.Substring(3, unzippedFile.Length - 3);
            try
            {

                var exmp = Framework_Project.Serialization.SerializationHelper.Deserialize<Exam>(unzippedFile);
                return exmp;
            }
            catch (Exception ex)
            {
                throw new Exception("in GetExamFromFile, cannot cast the XML to Exam Class. ");
            }
        }




        public static string GetVAsByteArray(InstructorValidationData aV, string instructorPassword)
        {
            try
            {
                //Serialize
                var ser = Framework_Project.Serialization.SerializationHelper.Serialize(aV);
                //Add special string at loca{0-2} to check for description in the future
                temp_ser = ser;
                ser = "FCT" + ser;

                //compress before encryption is better to reduce size

               // var compressed = Framework_Project.Compression.CompressionHelper.Zip(ser);
                //Encrypt using student password
                string encrypted = AESGCM.SimpleEncryptWithPassword(ser, instructorPassword);

                int x;
                for (int i = 0; i < 100; i++)
                {
                    x = i;
                }
         
                return encrypted;

            }
            catch (Exception ex)
            {
                throw new Exception("[Exception: Cannot Create GetVAsByteArray in Exam Helper ] [inner: " + ex.ToString());
            }
        }

        public static InstructorValidationData GetVFromByteArray(string encryptedFile, string instructorPassword)
        {
            try
            {
        
                var decrypted = AESGCM.SimpleDecryptWithPassword(encryptedFile, instructorPassword);
                //unzip
                //  var unzippedFile = Framework_Project.Compression.CompressionHelper.Unzip(decrypted);

                var unzippedFile = decrypted;

                if (unzippedFile.Substring(0, 3) != "FCT")
                {
                    throw new InvalidInstructorPasswordException("In GetVFromByteArray");
                }
                unzippedFile = unzippedFile.Substring(3, unzippedFile.Length - 3);
                try
                {

                    var exmp = Framework_Project.Serialization.SerializationHelper.Deserialize<InstructorValidationData>(unzippedFile);
                    return exmp;
                }
                catch (Exception ex)
                {
                    throw new Exception("in GetVFromByteArray, cannot cast the XML to Exam Class. ");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("L5:::" + ex.ToString());
                throw ex;
            }
        }
    }
}
