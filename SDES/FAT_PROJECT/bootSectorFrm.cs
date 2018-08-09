using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common;
using ForensicsCourseToolkit.Common.Helpers;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.FAT_PROJECT
{
    public partial class bootSectorFrm : Form
    {
        #region VARIABLES

        private Logger aLogger;
        private Mbr anMbr;
        private List<Vbr> vbrsList;
        private List<BootSector> bootSectors;
        private string fileName = "";

        #endregion
        #region INITIALIZATION

        public bootSectorFrm()
        {
            InitializeComponent();
            richTextBox1.WordWrap = false;

            aLogger = new Logger(ref richTextBox1);
        }

        #endregion

        #region BUTTONS EVENTS

        private void openImageBtn_Click(object sender, EventArgs e)
        {
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
            parseVbr();
        }

        #endregion BUTTONS EVENTS

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
            anMbr = Common.Common.GetUnit<Mbr>(fileName, ref aLogger,0,"MBR",null);
            if (anMbr == null)
            {
                aLogger.LogMessage($"Unable to read MBR from file [{fileName}], Operation Terminated!", LogMsgType.Error);
                return false;
            }
            aLogger.LogMessage($"Image [{fileName}], Loaded Successfully.", LogMsgType.Verbose);
            return true;
        }

        private void parseVbr()
        {
            var vbrRAWList = (from u in anMbr.Structure
                              where u.Type == UnitType.Vbr
                              select u).ToList();

            if (vbrRAWList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            vbrsList = new List<Vbr>();
            foreach (var v in vbrRAWList)
            {
                //var aVbr = new Vbr(v.Value, , ref aLogger);

                var aVbr = Common.Common.GetUnit<Vbr>(v.Value, ref aLogger, -1, $"VBR[{(v.Order - 1).ToString("X2")}]", null);
                vbrsList.Add(aVbr);
            }
        }

        private void printVbrsBtn_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }

            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
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

        private void showBootSectorStructureBtn_Click(object sender, EventArgs e)
        {
            Printer.PrintEmptyStructure<BootSector>(ref aLogger, ref richTextBox1);
        }

        private void PrintBootSectorsBtn_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            Printer.PrintVbrListWithBootSectors(fileName, ref vbrsList, ref aLogger, ref richTextBox1,true);
            //foreach (var vbr in vbrsList)
            //{
            //   // var bs = BootSector.ParseBootSector(fileName, vbr, ref aLogger);
            //    var bs = Common.GetUnit<BootSector>(fileName, ref aLogger, vbr.BootSectorStartLocationByte(), $"Boot sector {vbr.Description}");
            //    if (vbr.IsEmptyPartition())
            //    {
            //        richTextBox1.AppendText($"Printing {bs.Description} + EMPTY PARTITION", Color.DarkCyan, true);
            //    }
            //    else
            //    {
            //        Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);
            //        richTextBox1.AppendText($"Printing {bs.Description}", Color.DarkCyan, true);
            //        richTextBox1.AppendText("\n");
            //        Printer.PrintHorizentalLine(ref richTextBox1, 80, '-', true);

            //        var aHexPrinter = new HexPrinter(ref richTextBox1, 32, bs.GetStartAddress(), ref aLogger);
            //        aHexPrinter.PrintColoredStructure(bs);
            //    }
            //    richTextBox1.AppendText("\n");
            //}
        }

        private void PrintBootSectorVals_Click(object sender, EventArgs e)
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }

            Printer.PrintVbrListWithBootSectors(fileName,ref vbrsList, ref aLogger, ref richTextBox1,false);
        }



        private void FatDirectoryStructureBtn_Click(object sender, EventArgs e)
        {
            Printer.PrintEmptyStructure<FatDirectoryArea>(ref aLogger, ref richTextBox1);
        }

        private void FatTableBtn_Click(object sender, EventArgs e)
        {
            ParseBootSector();
            if (bootSectors.Count == 0)
            {
                aLogger.LogMessage($"{System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()}:: Empty bootSectors list, operation terminated! ", LogMsgType.Error);
                return;
            }
            foreach (var bs in bootSectors)
            {
                int dataAreaStartLoc = bs.GetRootDirectoryStartByte();
                aLogger.LogMessage($"{System.Reflection.MethodBase.GetCurrentMethod().Name}:: Data Area starts at 0x{dataAreaStartLoc:X8} ", LogMsgType.Verbose);
                while (true)
                {
                    
                    //var directory= Filesystems.FatDirectoryArea.ParseDirectoryArea(dataAreaStartLoc, fileName, bs, ref aLogger);
                    var directory = Common.Common.GetUnit<FatDirectoryArea>(fileName, ref aLogger, dataAreaStartLoc,
                      "DirectoryArea-" + bs.Description  ,null);
                    //printing hex table
                    HexPrinter aHexPrinter=new HexPrinter(ref richTextBox1,32,dataAreaStartLoc,ref aLogger);
                    aHexPrinter.PrintColoredStructure(directory);
                    //printing values
                    Printer.PrintStructureValues(directory.Structure,ref richTextBox1,ref aLogger);

                    richTextBox1.AppendText("\n\n\n");
                    dataAreaStartLoc += Common.Common.FatDirectoryAreaSizeBytes;
                    if(directory.IsEmpty) break;
                }
            }

        }

        private void ParseBootSector()
        {
            if (anMbr == null)
            {
                aLogger.LogMessage("mbr is empty (maybe not loaded yet!), end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList == null)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            if (vbrsList.Count == 0)
            {
                aLogger.LogMessage("vbr list is empty, end function!", LogMsgType.Warning);
                return;
            }
            bootSectors = new List<BootSector>();
            foreach (var vbr in vbrsList)
            {
                var bs = Common.Common.GetUnit<BootSector>(fileName, ref aLogger, vbr.BootSectorStartLocationByte(), $"Boot sector {vbr.Description}", null);
                if (!vbr.IsEmptyPartition())
                {
                    bootSectors.Add(bs);
                }
            }
        }
    }
}