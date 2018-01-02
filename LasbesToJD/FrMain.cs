using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using ZXing;
using ZXing.Common;

namespace LasbesToJD
{
    public partial class FrMain : Form
    {
        private string _strFilePath = "";
        private string _strFilePathOther = "";
        private bool _bIsDoubleStart = false;
        public FrMain()
        {
            InitializeComponent();
            if (Environment.GetCommandLineArgs().Count() > 1)
            {
                LoadTemplate(Environment.GetCommandLineArgs()[1]);//双击模板打开事件处理
            }
        }
    
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
                PreLabels();
        }

        private void txtInfos_TextChanged(object sender, EventArgs e)
        {
                PreLabels();
        }


        private void txtInfoOther_TextChanged(object sender, EventArgs e)
       {
            PreLabels();
        }
        /// <summary>
        /// 生成预览标签
        /// </summary>
        private void PreLabels()
        {
            try
            {

                if (this.tabProLabel.SelectedIndex == 0)
                {
                    this.report1 = this.report1 ?? new FastReport.Report();
                    this.report1.Load(@"labeltemplate1.frx");

                    //if (this.report1.FindObject("bcPro").GetType() == typeof(FastReport.Barcode.BarcodeObject))
                    //{
                    //    (this.report1.FindObject("bcPro") as FastReport.Barcode.BarcodeObject).Text = this.txtBarCode.Text.Trim();
                    //}
                    //else {
                    //    (this.report1.FindObject("bcPro") as FastReport.TextObject).Text = this.txtBarCode.Text.Trim();
                    //    (this.report1.FindObject("bcProDis") as FastReport.TextObject).Text = this.txtBarCode.Text.Trim();    
                    //}


                    FastReport.PictureObject pojBarPic = this.report1.FindObject("bcProPic") as FastReport.PictureObject;
                    pojBarPic.Image=GetBarCodeImg(this.txtBarCode.Text);
                    MessageBox.Show(this.txtBarCode.Text);
                    pojBarPic.Width = pojBarPic.Image.Width;
                    pojBarPic.Height = pojBarPic.Image.Height;

                    (this.report1.FindObject("txtName") as FastReport.TextObject).Text = this.txtInfos.Text;
                    this.report1.Preview = this.previewControl1;
                    this.report1.Show();
                    this.previewControl1.Zoom = 1.6f;
                }
                else
                {
                    this.report2 = this.report2 ?? new FastReport.Report();
                    this.report2.Load(@"labeltemplate2.frx");
                    (this.report2.FindObject("txtInfo") as FastReport.TextObject).Text = this.txtInfoOther.Text;
                    this.report2.Preview = this.previewControl2;
                    this.report2.Show();
                    this.previewControl2.Zoom = 1f;
                   
                }
            }
            catch { }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (priDialog.ShowDialog() == DialogResult.OK)
            {
                if (this.tabProLabel.SelectedIndex == 0)
                {
                    this.report1.PrintSettings.ShowDialog = false;
                    this.report1.PrintSettings.Copies = priDialog.PrinterSettings.Copies;
                    this.report1.PrintSettings.Printer = priDialog.PrinterSettings.PrinterName;
                    this.report1.Print();
                }
                else
                {

                    this.report2.PrintSettings.ShowDialog = false;
                    this.report2.PrintSettings.Copies = priDialog.PrinterSettings.Copies;
                    this.report2.PrintSettings.Printer = priDialog.PrinterSettings.PrinterName;
                    this.report2.Print();
                }
            }
        } 
        
    

        
        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbOpen_Click(object sender, EventArgs e)
        {
            openFileLabel.FileName = "";
            if (openFileLabel.ShowDialog() == DialogResult.OK)
            {
                LoadTemplate(openFileLabel.FileName);
            }
        }

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="strFilePath"></param>
        private void LoadTemplate(string strFilePath)
        {
            if (strFilePath.ToLower().IndexOf("ltj") > 0)
            {
                string strSaveChars = System.IO.File.ReadAllText(strFilePath);
                string[] strArTexts = strSaveChars.Split(new string[] { "\r\n-----------------\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (strArTexts.Length >= 2)
                {
                    if (strArTexts[0].ToLower() == "pro")//商品标签
                    {
                        this.txtBarCode.Text = strArTexts[1];
                        this.txtInfos.Text = strArTexts[2];
                        this.tabProLabel.SelectedIndex = 0;//加载完切换到tab标签
                        _strFilePath = strFilePath;
                    }
                    else
                    {
                        this.txtInfoOther.Text = strArTexts[1];
                        this.tabProLabel.SelectedIndex = 1;
                        _strFilePathOther = strFilePath;
                    }
                }
            }

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSave_Click(object sender, EventArgs e)
        {
            if (this.tabProLabel.SelectedIndex == 0)
            {
                if (_strFilePath.Length > 0)
                {
                    try
                    {
                        Save(_strFilePath);
                        MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    tbSaveAs_Click(null, null);
                }
            }
            else {

                if (_strFilePathOther.Length > 0)
                {
                    try
                    {
                        Save(_strFilePathOther);
                        MessageBox.Show("保存成功","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    tbSaveAs_Click(null, null);
                }
            }
        }

        /// <summary>
        /// 另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSaveAs_Click(object sender, EventArgs e)
        {
            saveFileLabel.FileName = "";
            if (saveFileLabel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Save(saveFileLabel.FileName);
                    _strFilePath = saveFileLabel.FileName;
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
        /// <summary>
        /// 保存模板
        /// </summary>
        /// <param name="strFilePath"></param>
        private void Save(string strFilePath)
        {
            System.IO.File.WriteAllText(strFilePath, GetFormateTexts());
        }

        /// <summary>
        /// 获得待保存内容
        /// </summary>
        /// <returns></returns>
        private string GetFormateTexts() {

            if (this.tabProLabel.SelectedIndex == 0) {//商品标签
                return string.Format("pro\r\n-----------------\r\n{0}\r\n-----------------\r\n{1}", txtBarCode.Text, txtInfos.Text);
            }
            else {
                return string.Format("other\r\n-----------------\r\n{0}\r\n-----------------\r\n{1}", "", txtInfoOther.Text);
            }
        }

        private Image GetBarCodeImg(string strCode)
        {
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 50; // 必须制定高度、宽度
            encodeOption.Width = 155;
            // 2.生成条形码图片并保存
            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128; // 条形码规格：EAN13规格：12（无校验位）或13位数字
            Bitmap img = wr.Write(strCode); // 生成图片
            return img;
        }
       
    }
}
