using System;
using System.Windows.Forms;
using ForensicsCourseToolkit.Framework_Project;

namespace ForensicsCourseToolkit.Common.Helpers
{
    public class Logger
    {
        private readonly RichTextBox rtb;

        public Logger(ref RichTextBox refRtb)
        {
            rtb = refRtb;
        }

        public void LogMessage(string aMessage, LogMsgType msgType)
        {
            if (Program.LoggingFlags[(short) msgType])
                rtb.AppendText($"[{msgType} @ {DateTime.Now}]:: {aMessage} \n", Program.Messages_Colors[(short) msgType]);
        }
    }
}