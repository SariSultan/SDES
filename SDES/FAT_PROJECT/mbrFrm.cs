using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.FAT_PROJECT
{
    public partial class mbrFrm : Form
    {
        #region INITIALIZATION

        public mbrFrm()
        {
            InitializeComponent();
            richTextBox1.WordWrap = false;

            aLogger = new Logger(ref richTextBox1);
        }

        #endregion

        #region RTB EVENTS

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //click event
                //MessageBox.Show("you got it!");
                var contextMenu = new ContextMenu();
                var menuItem = new MenuItem("Cut");
                menuItem.Click += RtbExtensions.CutAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Copy");
                menuItem.Click += RtbExtensions.CopyAction;
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Paste");
                menuItem.Click += RtbExtensions.PasteAction;
                contextMenu.MenuItems.Add(menuItem);

                menuItem = new MenuItem("Covert Value to Int (Little Endian)");
                menuItem.Click += RtbExtensions.LittleEndiaCovert;
                contextMenu.MenuItems.Add(menuItem);


                richTextBox1.ContextMenu = contextMenu;
            }
        }

        #endregion RTB EVENTS

        private bool ReadImage(string fileName)
        {
            aLogger.LogMessage($" Opening file [{fileName}]", LogMsgType.Verbose);

            //anMbr = Mbr.ParseMbr(fileName, ref aLogger);
            anMbr = Common.Common.GetUnit<Mbr>(fileName, ref aLogger, 0, "MBR", null);
            if (anMbr == null)
            {
                aLogger.LogMessage($"Unable to read MBR from file [{fileName}], Operation Terminated!", LogMsgType.Error);
                return false;
            }
            aLogger.LogMessage($"Image [{fileName}], Loaded Successfully.", LogMsgType.Verbose);
            return true;
        }

        private void PrintColoredMBR(ref Mbr anMbr)
        {
            var aPrinter = new HexPrinter(ref richTextBox1, 32, anMbr.StartAddress, ref aLogger);
            aPrinter.Initialize();
            foreach (var unit in anMbr.Structure)
            {
                aPrinter.PrintValue(unit.Value, unit.UnitColor);
            }

            richTextBox1.AppendText(Environment.NewLine);
        }

        private bool PrintColoredMBRinSteps(ref Mbr anMbr, int StepNumber)
        {
            
            if (aStepsPrinter == null)
                aStepsPrinter = new HexPrinter(ref richTextBox1, 32, anMbr.StartAddress, ref aLogger);

            if (StepNumber == 1)
                aStepsPrinter.Initialize();

            var aUnit = (from u in anMbr.Structure
                where u.Order == StepNumber
                select u).FirstOrDefault();
            if (aUnit == null)
            {
                aLogger.LogMessage(
                    $"in {MethodBase.GetCurrentMethod().Name}, the structure unit @ stepnumber{StepNumber} returns null value. Exit Method.",
                    LogMsgType.Error);
                return false;
            }

            aStepsPrinter.PrintValue(aUnit.Value, aUnit.UnitColor);
            return true;
        }

        private void EnableAfterImageLoad()
        {
            stepsBtn.Visible = true;
            stepsBtn.Text = $"Step {StepsCounter}";

            printMbrValsBtn.Visible = true;
        }

        private void DisableAfterStepsFinished()
        {
            // stepsBtn.Visible = false;
            StepsCounter = 1;
        }

        private void PrintHorizentalLine(int len, char symbol, bool newline)
        {
            for (var i = 0; i < len; i++)
            {
                richTextBox1.AppendText(symbol.ToString(),
                    (richTextBox1.BackColor == Color.Black) ? Color.White : Color.Silver);
            }
            if (newline)
                richTextBox1.AppendText("\n");
        }

        private void printVbrsBtn_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }

            var vbrsList = VbrHelpers.GetVBRListFromMBR(anMbr, ref aLogger);

            foreach (var v in vbrsList)
            {
                Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);
                richTextBox1.AppendText($"Printing {v.Description}", Color.Magenta, true);
                richTextBox1.AppendText("\n");
                Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);
                if (!v.IsEmptyPartition())
                    Printer.PrintStructureValues(v.Structure, ref richTextBox1,ref aLogger);
            }
        }

        private void showVbrStructureBtn_Click(object sender, EventArgs e)
        {
            Printer.PrintEmptyStructure<Vbr>(ref aLogger, ref richTextBox1);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        #region VARIABLES

        private HexPrinter aStepsPrinter;
        private readonly int TotalNumberOfSteps = 6; //Hardcoded based on mbr.cs :( 
        private Logger aLogger;
        private Mbr anMbr;
        private int StepsCounter = 1;


        private string fileName = "";

        #endregion

        #region BUTTONS EVENTS

        private void openImageBtn_Click(object sender, EventArgs e)
        {
            DisableAfterStepsFinished();
            stepsBtn.Visible = false;
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                aLogger.LogMessage("Did not select a file!", LogMsgType.Debug);
                anMbr = null;

                return;
            }

            fileName = openFileDialog.FileName;
            if (!ReadImage(fileName))
                return;

            EnableAfterImageLoad();
            //PrintColoredMBR(anMbr);
        }

        private void stepsBtn_Click(object sender, EventArgs e)
        {
            PrintColoredMBRinSteps(ref anMbr, StepsCounter);
            StepsCounter++;
            stepsBtn.Text = $"Step {StepsCounter}";

            if (StepsCounter > TotalNumberOfSteps)
            {
                StepsCounter = 1;
                stepsBtn.Text = $"Step {StepsCounter}";
                DisableAfterStepsFinished();
                richTextBox1.AppendText("\n");
            }
        }

        private readonly char lineSeperator = '-';

        private void showMbrStructureBtn_Click(object sender, EventArgs e)
        {
            //Filesystems.Mbr testMbr = new Filesystems.Mbr();
            //int padRight = 10;


            //PrintHorizentalLine(80, lineSeperator, true);
            //richTextBox1.AppendText("Order".PadRight(padRight) + "Description".PadRight(30) + "Start".PadRight(padRight) + "End".PadRight(padRight) + "Size(0x)".PadRight(padRight) + "Size(d)".PadRight(padRight) + "\n");//+ "Size(bytes)".PadRight(padRight)
            //PrintHorizentalLine(80, lineSeperator, true);
            //foreach (var u in testMbr.Structure)
            //{
            //    richTextBox1.AppendText($"{u.Order.ToString().PadRight(padRight)} {u.UnitDescription.PadRight(30)}{u.UnitStartLocationHex.PadRight(padRight)}{u.UnitEndLocationHex.PadRight(padRight)}{u.UnitSize.ToString("X4").PadRight(padRight)}{u.UnitSize.ToString().PadRight(padRight)}\n", u.UnitColor);//{(u.UnitSize*Filesystems.Common.blockSizeInBytes).ToString().PadRight(padRight)}
            //}
            //PrintHorizentalLine(80, lineSeperator, true);
            Printer.PrintEmptyStructure<Mbr>(ref aLogger, ref richTextBox1);
        }

        private void printMbrValsBtn_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            var padRight = 30;
            foreach (var item in anMbr.Structure)
            {
                richTextBox1.AppendText($"Printing field [{item.Order}]", item.UnitColor, true);
                richTextBox1.AppendText("\n");
                PrintHorizentalLine(80, lineSeperator, true);
                richTextBox1.AppendText("Field Description::".PadRight(padRight) + item.UnitDescription, item.UnitColor);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("Start Loc. in HEX::".PadRight(padRight) + item.UnitStartLocationHex,
                    item.UnitColor);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("Start Loc. in Decimal::".PadRight(padRight) + item.UnitStartLocationInt,
                    item.UnitColor);
                richTextBox1.AppendText("\n");


                richTextBox1.AppendText("End Loc. in HEX::".PadRight(padRight) + item.UnitEndLocationHex, item.UnitColor);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("End Loc. in Decimal::".PadRight(padRight) + item.UnitEndLocationInt,
                    item.UnitColor);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("Size::".PadRight(padRight) + item.UnitSize, item.UnitColor);
                richTextBox1.AppendText("\n");

                richTextBox1.AppendText("Value parsed::".PadRight(padRight) + item.Value, item.UnitColor);
                richTextBox1.AppendText("\n");
                PrintHorizentalLine(80, lineSeperator, true);
            }
        }

        #endregion BUTTONS EVENTS
    }
}