using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace LasbesToJD
{
    public partial class FrBarCode : Form
    {
        private string _strFilePath = "";
        private string _strFilePathOther = "";
        private int _iPrintDpi=100, _showDpi;
        public FrBarCode()
        {
            InitializeComponent();
            _iPrintDpi = Convert.ToInt32(ConfigurationManager.AppSettings["printDpi"].ToString());
            _showDpi = Convert.ToInt32(ConfigurationManager.AppSettings["showDpi"].ToString());
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

        private void btnOpen_Click(object sender, EventArgs e)
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
                    preLabel.CreateGraphics().Clear(System.Drawing.Color.White);
                    preLabel.Width = cm2Pix(_showDpi, 4);
                    preLabel.Height= cm2Pix(_showDpi, 3);
                    BuildLabel(_showDpi, 4, 3, preLabel.CreateGraphics());
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
                    System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                    pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocLabel_PrintPage);
                    pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", cm2Pix(_iPrintDpi,4), cm2Pix(_iPrintDpi, 3));  //4cm*3cm   (x*dpi)/2.54    x是厘米
                    //priDialog.Document = pd;
                    pd.PrinterSettings.Copies = priDialog.PrinterSettings.Copies;
                    pd.PrinterSettings.PrinterName= priDialog.PrinterSettings.PrinterName;
                    pd.Print();
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
                PreLabels();
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

 
        private void printDocLabel_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            BuildLabel(_iPrintDpi, 4, 3, e.Graphics);
        }

        /// <summary>
        /// 生成标签 
        /// </summary>
        /// <param name="iDpi">分辨率dpi</param>
        /// <param name="iwidth">宽，单位厘米</param>
        /// <param name="iHeight">高，单位厘米</param>
        /// <param name="g">Graphics g 最终图片宿主</param>
        private void BuildLabel(int iDpi,int iwidth,int iHeight,Graphics g)
        {
            EncodingOptions encodeOption = new EncodingOptions();

            encodeOption.Width = cm2Pix(iDpi, iwidth) - cm2Pix(iDpi, 0.2f);
            encodeOption.Height = cm2Pix(iDpi, 1.5f);

            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_128;
            Bitmap img = wr.Write(txtBarCode.Text);

            Bitmap bmp = new Bitmap(cm2Pix(iDpi, iwidth), cm2Pix(iDpi, iHeight));

            g.DrawImage(img, (-2f/100)*iDpi, (6f/100)*iDpi);
            g.DrawString(txtInfos.Text, new Font(new FontFamily("宋体"), (5f/100)*iDpi), System.Drawing.Brushes.Black, cm2Pix(iDpi, 0.2f), cm2Pix(iDpi, 1.7f));
        }

        /// <summary>
        /// 厘米转换到像素
        /// </summary>
        /// <param name="dpi">分辨率</param>
        /// <param name="iSource">原厘米</param>
        /// <returns></returns>
        private int cm2Pix(int dpi,float fSource) {
            return (int)Math.Abs((fSource * dpi) / 2.54);
        }
    }
}
