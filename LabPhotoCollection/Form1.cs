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
        private readonly string[] fileExtensions = new[] { "jpg", "gif" };
        private string filePath;
        private List<string> fullFileNames;
        private Dictionary<string, string> dicExifDatas;
        private string fileListText = "File List (Count：{0})";
        private string fileErrorListText = "Error File List (Count：{0})";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                folderBrowserDialog1.ShowDialog();
                this.filePath = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                this.filePath = textBox1.Text;
            }

            if (string.IsNullOrWhiteSpace(this.filePath))
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

            lblFileList.Text = string.Format(this.fileListText, boxPhoto.Items.Count);

            List<string> errorFileNames;
            dicExifDatas = this.GetExifDateTime(fullFileNames, out errorFileNames);

            boxErrorFile.Items.Clear();
            lblErrorFileList.Text = string.Format(this.fileErrorListText, string.Empty);

            foreach (var errorFileName in errorFileNames)
            {
                boxErrorFile.Items.Add(errorFileName);
            }

            lblErrorFileList.Text = string.Format(this.fileErrorListText, boxErrorFile.Items.Count);
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
                        if (!this.CheckFileIsExists(newPath + "\\" + fileInfo.Name))
                        {
                            fileInfo.MoveTo(newPath + "\\" + fileInfo.Name);
                        }
                        else
                        {
                            ////存在時就 rename 一次
                            var extensionIndex = fileInfo.Name.LastIndexOf(".", StringComparison.Ordinal);
                            var newFileName = fileInfo.Name.Substring(0, extensionIndex) + "_1" + fileInfo.Extension;

                            if (!this.CheckFileIsExists(newPath + "\\" + newFileName))
                            {
                                fileInfo.MoveTo(newPath + "\\" + newFileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            this.Reset();

            MessageBox.Show("Done..");
        }

        private void Reset()
        {
            this.filePath = string.Empty;
            this.fullFileNames = new List<string>();
            this.dicExifDatas = new Dictionary<string, string>();

            this.boxPhoto.Items.Clear();

            lblFileList.Text = string.Format(this.fileListText, string.Empty);
        }

        private bool CheckFileIsExists(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Exists;
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
