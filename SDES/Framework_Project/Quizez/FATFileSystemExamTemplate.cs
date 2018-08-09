using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.Common.Helpers;

namespace ForensicsCourseToolkit.Framework_Project.Quizez
{
    [Serializable]
   public  class FATFileSystemExamTemplate
    {
        public FATFileSystemExamTemplate()
        {

        }
        Mbr anMbr;
        Logger aLogger;
        #region STATIC QUESTIONS
        public FATFileSystemExamTemplate(Logger logger, ref Mbr mbr)
        {
            anMbr = mbr;
            aLogger = logger;
        }


        private string GetMBRString(ref Mbr anMbr)
        {

            var aPrinter = new StringHexPrinter(32, anMbr.StartAddress, ref aLogger);
            aPrinter.Initialize();
            foreach (var unit in anMbr.Structure)
            {
                aPrinter.PrintValue(unit.Value, unit.UnitColor);
            }
            string mbrString = aPrinter.rtb;
            mbrString = mbrString + (Environment.NewLine);
            return mbrString;
        }

       

        public List<QuestionForms> GetStaticFATQuestions
        { get {
            var lst = new List<QuestionForms>();
            try
            {
                lst= new List<QuestionForms>(){
                    //1. Disk Signature Question - Easy - 1 Grade 
                    new QuestionForms(new Question("Value of disk signature for MBR",
                        GetMBRString(ref anMbr),  "55AA",
                        "The value of disk signature always 55AA, check MBR strcture last field",
                        new List<string> { "55AA", "55BB", "AA55", "BB55" }, 1, QuizHelper.QuestionDifficulty.Easy), QuizHelper.InputValueType.String),

                    //2. maximum number of primary partitions in MBR
                    new QuestionForms(new Question("Maximum number of primary partitions in MBR",
                        "",  "4",
                        "The maximum number of primary partitions in MBR is 4, this is one of the limitations of MBR. Hence, Extended MBR is used.",
                        new List<string> { "1", "2", "3", "4" }, 2, QuizHelper.QuestionDifficulty.Medium), QuizHelper.InputValueType.Integer),

                    //3. size of each volume boot record (VBR)
                    new QuestionForms(new Question("Size of each volume boot record (VBR) [in bytes]",
                        "",  "16",
                        "Size of each MBR is 16 bytes.",
                        new List<string> { "8", "16", "32", "64" }, 2, 
                        QuizHelper.QuestionDifficulty.Medium), QuizHelper.InputValueType.Integer),
                    //4. to increase the number of partition above MBR limitation
                    new QuestionForms(new Question("To increase the number of partition above MBR limitation we use",
                        "", "Extended MBR",
                        "The limitation of MBR is 4 Partition which leads to using extended MBR to craete more partitions.",
                        new List<string> { "Extended MBR", "Parition Table", "Grub", "FAT Mapping Table" }, 2, 
                        QuizHelper.QuestionDifficulty.Medium), QuizHelper.InputValueType.Integer),
                     //5. A bootable volume has its bootable flag
                    new QuestionForms(new Question("A bootable volume has its bootable flag",
                        "", "0x80",
                        "A bootable volume has its bootable flag to 0x80.",
                        new List<string> { "0x80", "0x00", "0x01", "0xFF","0x90","0xAA" }, 2,
                        QuizHelper.QuestionDifficulty.Medium), QuizHelper.InputValueType.HexVlaue),
                     //6. The LBA address is written as little Endian
                    new QuestionForms(new Question("The LBA address is written ",
                         "", "Little Endian" ,
                        "Little Endian is Used",
                        new List<string> { "Little Endian", "Big Endian", "Integer", "Double"}, 1,
                        QuizHelper.QuestionDifficulty.Easy), QuizHelper.InputValueType.String),
                     //7. The volume size is represented in
                    new QuestionForms(new Question("The volume size is represented in",
                        "",   "Little Endian",
                        "Little Endian is Used",
                        new List<string> { "Little Endian", "Big Endian", "Integer", "Double"}, 1,
                        QuizHelper.QuestionDifficulty.Easy), QuizHelper.InputValueType.String),
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " Operation Aborted!");
            }

            return lst;

        }}

        #endregion

        #region DYNAMIC QUESTIONS

        public List<QuestionForms> GetDynamicFATQuestions
        {
            get
            {
                var lst = new List<QuestionForms>();
                try
                {
                    lst = new List<QuestionForms>(){
                    //1. umber of active partition in the disk
                    new QuestionForms(new Question("number of active partition in the disk",
                         GetMBRString(ref anMbr),  howmanyactivedisksanswer().ToString(),
                        "Student should check the VBR that are not set to zeros",
                        new List<string> { "1", "2", "3", "4" }, 2, QuizHelper.QuestionDifficulty.Medium), QuizHelper.InputValueType.Integer),
                };

                    lst.AddRange(GetVBRStartAddressandSizeQuestions(anMbr));

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + " Operation Aborted!");
                }

                return lst;

            }
        }



        public List<QuestionForms> GetVBRStartAddressandSizeQuestions(Mbr anMbr)
        {
            var questionList = new List<QuestionForms> { };
            var vbrsList = VbrHelpers.GetVBRListFromMBR(anMbr, ref aLogger);
            Random rnd = new Random();
            var number = 1;
            foreach (var v in vbrsList)
            {
                if (v.IsEmptyPartition()) continue;
                List<string> options = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    var rndNum = rnd.Next(v.BootSectorStartLocationByte()/2, v.BootSectorStartLocationByte() * 3);
                    if((rndNum & 0xFF00) == v.BootSectorStartLocationByte()) { i--; continue; }//to avoid equal to the correct answer
                    options.Add((rndNum & 0xFF00).ToString("X8"));
                }
                options.Add(v.BootSectorStartLocationByte().ToString("X8"));

                
                //Start Address Question
                questionList.Add(
                        new QuestionForms(new Question($"Start Address of Volume {number}",
                          GetMBRString(ref anMbr), v.BootSectorStartLocationByte().ToString("X8"),
                        "Convert LBA Address (see VBR Structure) From Little Endian, Then Multiply by boot sector size",
                        options, 3, QuizHelper.QuestionDifficulty.Hard), QuizHelper.InputValueType.HexVlaue));



                List<string> sizeoptions = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    var rndNum = rnd.Next(v.Size / 2, v.Size * 3);
                    if ((rndNum & 0xFF00) == v.Size) { i--; continue; }//to avoid equal to the correct answer
                    sizeoptions.Add((rndNum & 0xFF00).ToString("X8"));
                }
                sizeoptions.Add(v.Size.ToString("X8"));


                //Size Question
                questionList.Add(
                        new QuestionForms(new Question($"Size of Volume {number}",
                         GetMBRString(ref anMbr), v.Size.ToString("X8"),
                        "Convert Size (see VBR Structure) From Little Endian, Then Multiply by boot sector size",
                        sizeoptions, 3, QuizHelper.QuestionDifficulty.Hard), QuizHelper.InputValueType.HexVlaue));

            }

            return questionList;
        }




        // METHODS
        private int howmanyactivedisksanswer()
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("MBR IS EMPTY. Did you forgot to load an MBR? ", LogMsgType.Warning);
                throw new Exception("MBR IS EMPTY. Did you forgot to load an MBR? ");
            }

            var vbrList = VbrHelpers.GetVBRListFromMBR(anMbr, ref aLogger);
            int number = 0;
            foreach (var vbr in vbrList)
            {
                if (!vbr.IsEmptyPartition()) number++;
            }           
            return number;
        }

        #endregion
    }
}
