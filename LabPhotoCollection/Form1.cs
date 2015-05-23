using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabPhotoCollection
{
    public partial class Form1 : Form
    {
        private readonly string[] fileExtensions = new[] { "jpg" };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            var selectPath = folderBrowserDialog1.SelectedPath;
            if (string.IsNullOrWhiteSpace(selectPath))
            {
                MessageBox.Show("請選擇資料夾");
            }

            var files = this.GetFiles(selectPath);
            boxPhoto.Items.Clear();

            foreach (var file in files)
            {
                boxPhoto.Items.Add(file);
            }
        }

        private List<string> GetFiles(string path)
        {
            var files = new List<string>();

            foreach (var extension in fileExtensions)
            {
                var tempFiles = Directory.GetFiles(path, "*." + extension);

                if (tempFiles.Length == 0)
                {
                    continue;
                }

                foreach (var tempFile in tempFiles)
                {
                    var fileInfo = new FileInfo(tempFile);
                    files.Add(fileInfo.Name);
                }
            }

            return files;
        }
    }
}
