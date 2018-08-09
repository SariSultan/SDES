using System;
using System.Drawing;
using System.Windows.Forms;
using ForensicsCourseToolkit.Common.Helpers;

namespace ForensicsCourseToolkit.Framework_Project
{
    public static class RtbExtensions
    {
        public static void AddNewPage(this RichTextBox box)
        {
            box.AppendText("[NEW_PAGE_AUTOMATIC_HERE] \n");
        }
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            try { 
            if (box.InvokeRequired)
            {
                //MessageBox.Show("Called Invoke");
                box.BeginInvoke(new Action<RichTextBox, string, Color>(AppendText), box , text,color );
                return;
            }
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            ScrollToEnd(ref box);
            }
            catch(Exception ex)
            {

            }
        }

        public static void AppendText(this RichTextBox box, string text, Color color, bool highlight)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            if (highlight)
            {
                box.SelectionColor = Color.White;
                box.SelectionBackColor = color;
            }
            else
            {
                box.SelectionColor = color;
            }
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionBackColor = box.BackColor;
            ScrollToEnd(ref box);
        }

        public static void AppendText(this RichTextBox box, string text, Color color, FontStyle style)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;

            box.SelectionFont = new Font(box.Font, style);
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionFont = box.Font;

            ScrollToEnd(ref box);
        }

        public static void AppendText(this RichTextBox box, string text,  Font aFont)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            //box.SelectionColor = color;

            box.SelectionFont = aFont;
            box.AppendText(text);
            //box.SelectionColor = box.ForeColor;
            box.SelectionFont = box.Font;

            ScrollToEnd(ref box);
        }
        public static void AppendText(this RichTextBox box, string text, Font aFont,Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;

            box.SelectionFont = aFont;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionFont = box.Font;

            ScrollToEnd(ref box);
        }

        public static void AppendText(this RichTextBox box, string text, Color color, FontStyle style, bool highlight)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            if (highlight)
            {
                box.SelectionColor = Color.White;
                box.SelectionBackColor = color;
            }
            else
            {
                box.SelectionColor = color;
            }
            box.SelectionFont = new Font(box.Font, style);
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionFont = box.Font;
            box.SelectionBackColor = box.BackColor;

            ScrollToEnd(ref box);
        }

        public static void AppendText(this RichTextBox box, string text, FontStyle style)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionFont = new Font(box.Font, style);
            box.AppendText(text);
            box.SelectionFont = box.Font;

            ScrollToEnd(ref box);
        }

        private static void ScrollToEnd(ref RichTextBox box)
        {
            return;
            box.SuspendLayout();
            // set the current caret position to the end
            box.SelectionStart = box.Text.Length;
            // scroll it automatically
            box.ScrollToCaret();
            box.ResumeLayout();
        }

        public static void CutAction(object sender, EventArgs e)
        {
            var rbt = (((sender as MenuItem).Parent as ContextMenu).SourceControl as RichTextBox);
            rbt.Cut();
        }

        public static void CopyAction(object sender, EventArgs e)
        {
            var rbt = (((sender as MenuItem).Parent as ContextMenu).SourceControl as RichTextBox);
            Clipboard.SetText(rbt.SelectedText);
        }

        public static void LittleEndiaCovert(object sender, EventArgs e)
        {
            var rbt = (((sender as MenuItem).Parent as ContextMenu).SourceControl as RichTextBox);
            var selectedText = rbt.SelectedText.Replace(" ", "").Trim();
            if (!Conversion.OnlyHexInString(selectedText) || selectedText.Length%2 != 0)
            {
                MessageBox.Show("Please select a correct Hex Value", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var bigEndian = Conversion.ConvertLittleEndianToBigEndianandViceVersa(selectedText);
            var value = Conversion.HexLittleEndianToInt(selectedText);

            MessageBox.Show(
                $"Little Endian=[{selectedText}] \nBig Endian=   [{bigEndian}] \nint=          [{value}] \ncopied to clipboard. ",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(
                $"Little Endian=[{selectedText}] \nBig Endian=   [{bigEndian}] \nint=          [{value}] \ncopied to clipboard. ");
        }

        public static void PasteAction(object sender, EventArgs e)
        {
            var rbt = (((sender as MenuItem).Parent as ContextMenu).SourceControl as RichTextBox);
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                rbt.SelectedRtf
                    = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }
    }
}