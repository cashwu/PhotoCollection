using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExifLib;

namespace LabPhotoCollection
{
    public partial class Form1 : Form
    {
        private readonly string[] fileExtensions = new[] { "jpg" };
        private string filePath;
        private List<string> fullFileNames;
        private Dictionary<string, string> dicExifDatas;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            filePath = folderBrowserDialog1.SelectedPath;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("請選擇資料夾");
                return;
            }

            this.GetFullFileName();

            if (this.fullFileNames.Count == 0)
            {
                MessageBox.Show("資料夾裡面沒有圖片檔");
                return;
            }

            var fileNames = this.GetFileName(fullFileNames);

            boxPhoto.Items.Clear();

            foreach (var fileName in fileNames)
            {
                boxPhoto.Items.Add(fileName);
            }

            List<string> errorFileNames;
            dicExifDatas = this.GetExifDateTime(fullFileNames, out errorFileNames);

            boxErrorFile.Items.Clear();
            foreach (var errorFileName in errorFileNames)
            {
                boxErrorFile.Items.Add(errorFileName);
            }
        }

        private void boxPhoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = (ListBox)sender;
            var fileName = this.fullFileNames[box.SelectedIndex];
            imgBox.ImageLocation = fileName;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (this.dicExifDatas == null 
                || this.dicExifDatas.Count == 0)
            {
                MessageBox.Show("請選擇資料夾");
                return;
            }

            this.MovePic();
        }

        private void MovePic()
        {
            try
            {
                foreach (var dicExifData in this.dicExifDatas)
                {
                    var date = dicExifData.Value.Replace('/', '-');

                    var newPath = this.filePath + "\\" + date;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }

                    var fileInfo = new FileInfo(dicExifData.Key);
                    if (fileInfo.Exists)
                    {
                        var newFileInfo = new FileInfo(newPath + "\\" + fileInfo.Name);
                        if (!newFileInfo.Exists)
                        {
                            fileInfo.MoveTo(newPath + "\\" + fileInfo.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            MessageBox.Show("Done..");
        }

        private Dictionary<string, string> GetExifDateTime(List<string> fullFileNames, out List<string> errorFileNames)
        {
            var dic = new Dictionary<string, string>();
            errorFileNames = new List<string>();

            foreach (var fileName in fullFileNames)
            {
                try
                {
                    using (var reader = new ExifReader(fileName))
                    {
                        DateTime dt;
                        reader.GetTagValue(ExifTags.DateTimeOriginal, out dt);

                        if (!dic.ContainsKey(fileName))
                        {
                            dic.Add(fileName, dt.ToString("yyyy/MM/dd"));
                        }
                        else
                        {
                            errorFileNames.Add(fileName + " .. fileName 重複");
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorFileNames.Add(fileName + " .. 無法解析");
                }
            }
            
            return dic;
        }

        private void GetFullFileName()
        {
            this.fullFileNames = new List<string>();

            foreach (var extension in fileExtensions)
            {
                var tempFilesNames = Directory.GetFiles(this.filePath, "*." + extension);
                this.fullFileNames.AddRange(tempFilesNames);
            }
        }

        private List<string> GetFileName(List<string> fullFileName)
        {
            var fileNames = new List<string>();

            foreach (var tempFile in fullFileName)
            {
                var fileInfo = new FileInfo(tempFile);
                fileNames.Add(fileInfo.Name);
            }

            return fileNames;
        }
    }
}
