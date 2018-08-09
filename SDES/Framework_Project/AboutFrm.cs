using System.Windows.Forms;

namespace ForensicsCourseToolkit.Framework_Project
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            InitializeComponent();
            versionLbl.Text = $"v{Application.ProductVersion}";
        }
    }
}