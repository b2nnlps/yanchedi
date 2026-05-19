using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 验车帝
{
    public partial class Form1 : Form
    {
        string basePath;
        public static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

       /* public void GetPicFromVideo(string videoName, string widthAndHeight, string cutTimeFrame)
        {
            var fileName = Path.GetFileNameWithoutExtension(videoName);

            //ffmpeg.exe路径
            var ffmpeg = basePath + "ffmpeg.exe";
            var srcName = videoName.Replace("/", "\\");
            
            //保存截取图片后路径
            var objName = basePath + @"short\" + fileName + ".jpg";
            if (File.Exists(objName)) return;
            var startInfo = new ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -i " + srcName + " -y -f image2 -ss " + cutTimeFrame + " -t 0.001 -s " + widthAndHeight + " " + objName;
            
            //startInfo.UseShellExecute = false;
            //startInfo.CreateNoWindow = true;
            try
            {
                Process.Start(startInfo);
                Thread.Sleep(60000);
                //返回图片保存路径
                Console.WriteLine(objName);

            }
            catch (Exception re)
            {
               Console.WriteLine(re.Message);
            }
        }*/

        public bool ExtractSnapshot(string videoFilePath, string outputImagePath, TimeSpan position)
        {
            try
            {
                if (!File.Exists(videoFilePath))
                {
                    Console.WriteLine("文件不存在！！！");
                    return false;
                }
                // 创建 MediaFile 对象，指定输入和输出文件路径
                var inputFile = new MediaFile { Filename = videoFilePath };
                var outputFile = new MediaFile { Filename = outputImagePath };

                // 创建 ConversionOptions 对象，并设置截图的时间点
                var conversionOptions = new ConversionOptions { Seek = position };

                // 使用Engine类来处理视频截图
                using (var engine = new Engine())
                {
                    // 获取视频文件的元数据信息
                    engine.GetMetadata(inputFile);

                    // 截取指定时间点的视频帧，并保存为图像文件
                    engine.GetThumbnail(inputFile, outputFile, conversionOptions);
                }

                Console.WriteLine($"视频截图成功：{outputImagePath}");

               // imageListLarge.Images.Add(Image.FromFile(outputImagePath));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"视频截图失败：{ex.Message}");
                logBox.Text= "视频截图失败："+ videoFilePath+" "+ ex.Message+"\r\n"+logBox.Text;
                return false;
            }
        }

        bool refreshImg = false;
        private void button2_Click(object sender, EventArgs e)
        {
            refreshImg = true;
            button1_Click(sender, e);
            //ExtractSnapshot(basePath+"video/1.mp4", basePath + @"short\1.jpg", TimeSpan.FromSeconds(10));// 截取第10秒的视频帧

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            basePath = Environment.CurrentDirectory + @"\";
            videoDirTextbox.Text = System.IO.File.ReadAllText(basePath+@"videoDir.txt");
            string historyText = System.IO.File.ReadAllText(basePath+@"historyList.txt");
            HistoryListBox.Items.Clear();
            string[] l = historyText.Split('|');
            for (int i = 0; i < l.Count(); i++) {
                if (l[i].Length<1) continue;
                HistoryListBox.Items.Add(l[i]);
            }
            string[] loveText = System.IO.File.ReadAllText(basePath + @"loveList.txt").Split('|');
            Debug.WriteLine(loveText.Length);
            videoLoveList = new List<string>();
            for (int i = 0; i < loveText.Length; i++)
            {
                if (loveText[i].Length>0)
                    videoLoveList.Add(loveText[i]);
            }
            

            form1 = this;


            string path = basePath + "fileList.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                int rowCount = 0;

                // 逐行读取文件内容
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split('|'); // 假设元素之间使用空格分隔
                    if (rowCount == 0)
                    {
                        // 根据第一行的长度确定列数
                        int columnCount = values.Length;

                        // 初始化二维数组
                        videoArr = new string[File.ReadAllLines(path).Length, columnCount+1];

                        // 再次读取文件以填充数组
                        using (StreamReader reader2 = new StreamReader(path))
                        {
                            int rowIndex = 0;
                            while ((line = reader2.ReadLine()) != null)
                            {
                                values = line.Split('|');
                                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                                {
                                    videoArr[rowIndex, columnIndex] = values[columnIndex];
                                }
                                videoArr[rowIndex, 5] = rowIndex.ToString();
                                rowIndex++;
                            }
                        }
                    }
                    rowCount++;
                }
            }
         //   tempImg = new List<Image>();
            imageListLarge = new ImageList();
            loadImgFile();
           
            labelVideoNum.Text = videoArr.GetLength(0).ToString();

        }


        int defaultImgCount = 300;
        void loadImgFile()
        {//加载图片文件，先同步加载200张，然后异步加载完全部
            imageListLarge = new ImageList();
            int videoLength = videoArr.GetLength(0);

            //调用下面的函数进行文件时间排序先
            useSort = true;
            radioButton1_CheckedChanged(null, null);
            //下次再调用的话就带UI操作了
            useSort = false;
            // for (int i = 0; i < videoArr.GetLength(0); i++)
            for (int i = 0; i < videoLength && i < defaultImgCount; i++)
            {
                 //Console.WriteLine(videoArr[i, 1]);
                try
                {
                    Image a = Image.FromFile(videoArr[i, 1]);
                    imageListLarge.Images.Add(a);
                  //  tempImg.Add(a);
                    videoArr[i, 5] = i.ToString();//需要按图片顺序重新排序
                }
                catch {
                    Console.WriteLine("文件不存在:"+ videoArr[i, 1]);
                }
            }
            //首先显示排序后的200张

            listView2.Visible = false;

            this.listView1.View = View.LargeIcon;
            imageListLarge.ImageSize = new Size(216, 144);
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
            this.listView1.LargeImageList = imageListLarge;
            for (int i = 0; i < imageListLarge.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = videoArr[i, 2];
                this.listView1.Items.Add(lvi);
            }

            Task.Run(() => {
                // 异步执行任务
                if (videoLength < defaultImgCount) return;
                try
                {

                    this.listView1.View = View.LargeIcon;
                    imageListLarge.ImageSize = new Size(216, 144);
                    imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
                    this.listView1.LargeImageList = imageListLarge;

                    int beginImg = defaultImgCount;
                    int endImg = defaultImgCount + defaultImgCount;
                    imgWork = true;//开始标记干活
                    for (int i = defaultImgCount; i < videoLength; i++)
                    {
                        if (imgWork == false) return;
                        try
                        {
                            Image a = Image.FromFile(videoArr[i, 1]);
                            imageListLarge.Images.Add(a);
                            //  tempImg.Add(a);

                            workStatus.Text = "加载图片" + i.ToString() + "/" + videoLength.ToString();
                        }
                        catch
                        {
                            Console.WriteLine("文件不存在:" + videoArr[i, 1]);
                        }
                        if ((i + 1) % defaultImgCount == 0)
                        {
                            for (int j = beginImg; j < endImg && j < imageListLarge.Images.Count; j++)
                            {
                                if (imgWork == false) return;
                                // Console.WriteLine(j);
                                ListViewItem lvi = new ListViewItem();
                                lvi.ImageIndex = j;
                                lvi.Text = videoArr[j, 2];
                                this.listView1.Items.Add(lvi);
                            }
                            beginImg = endImg;
                            endImg = endImg + defaultImgCount;
                        }
                        videoArr[i, 5] = i.ToString();//需要按图片顺序重新排序
                    }
                    //再补一次图片
                    for (int j = beginImg; j < endImg && j < imageListLarge.Images.Count; j++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = j;
                        lvi.Text = videoArr[j, 2];
                        this.listView1.Items.Add(lvi);
                    }
                    workStatus.Text = "Enjoy." + imageListLarge.Images.Count.ToString();
                }
                catch {
                    workStatus.Text = "重新生成列表";
                }
              
                imgWork = false;
            });
        }

        bool imgWork = false;

        private void videoDirTextbox_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(basePath + @"videoDir.txt", videoDirTextbox.Text);
        }


        public void getDirFiles(string baseDir)
        {//通过递归实现获取目录下所有文件，因为直接写盘符的话自带的函数不支持
            DirectoryInfo folder = new DirectoryInfo(baseDir);
            try {
                if (checkBox1.Checked)
                {
                    foreach (var temp in folder.GetDirectories())
                    {
                        string name = temp.Name;
                        if (name.Contains("RECYCLE") ||
                        name.Contains("Recycle") ||
                        name.Contains("Documents and Settings") ||
                        name.Contains("Windows") ||
                        name.Contains("System"))
                            continue;
                        getDirFiles(temp.FullName);
                    }
                }
            foreach (var file in folder.GetFiles())
            {
                fileList.Add(file.FullName);
                    //Console.WriteLine(file.FullName);
            }
            }
            catch { }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern Int32 SendMessage(IntPtr hwnd, Int32 wMsg, Int32 wParam, Int32 lParam);
        const int LVM_FIRST = 0x1000;
        const int LVM_SETICONSPACING = LVM_FIRST + 53;

        //x 是左右间距，y是上下间距
        private void SetInterval(int x, int y)
        {
            SendMessage(this.listView1.Handle, LVM_SETICONSPACING, 0, x * 65536 + y);
            this.listView1.Refresh();
        }

        int totalVideoNum = 0;
        List<string> videoList,fileList, videoLoveList;
        public string[,] videoArr, videoArrTemp;
        ImageList imageListLarge;
        private void button1_Click(object sender, EventArgs e)
        {
            imgWork = false;//停止图片加载任务
            imageListLarge = new ImageList();
            totalVideoNum = 0;
            videoList = new List<string>();
            fileList = new List<string>();
          //  tempImg = new List<Image>();
            SetInterval(170,250);
            

            string[] dir = videoDirTextbox.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string directoryPath in dir)
            {
                //Console.WriteLine(directoryPath);
                workStatus.Text = "遍历文件中";
                getDirFiles(directoryPath);
                workStatus.Text = "筛选文件中";  
            }
            foreach (var item in fileList)
            {
                try
                {
                    FileInfo file = new FileInfo(item);
                    if (file.Length < 100000000) continue;//如果文件太小就跳过
                    totalVideoNum++;
                    // 处理每个文件
                    var filename = file.FullName;
                    var fileExtension = file.Extension.ToLower();
                    if (fileExtension != ".mp4" && fileExtension != ".avi" && fileExtension != ".wmv" && fileExtension != ".mkv") continue;
                    // Console.WriteLine(filename);
                    videoList.Add(filename);
                }
                catch { }
            }
            labelVideoNum.Text = totalVideoNum.ToString();
            workStatus.Text = "缩略图生成中";
            int progress = 0,j=0;
            videoArr = new string[videoList.Count, 6];//根据列表长度初始化视频数组
            
            foreach (var filename in videoList)
            {
                string Name = filename.Substring(filename.LastIndexOf("\\") + 1);
                progress++;
                // GetPicFromVideo(filename, "1280*720", n.ToString());
                var shortName = basePath + @"short\" + Name + ".jpg";
                labelVideoNum.Text = progress.ToString()+"/"+totalVideoNum.ToString();

                if (!File.Exists(shortName) || refreshImg)
                {
                    Random ran = new Random();
                    int n = ran.Next(300)+300;
                    //Console.WriteLine(shortName);
                    ExtractSnapshot(filename, shortName, TimeSpan.FromSeconds(n));// 截取第n秒的视频帧
                }

                if (File.Exists(shortName))
                {
                    try
                    {
                    FileInfo fileinfo = new FileInfo(filename);
                    videoArr[j,0] = filename;//文件名带路径
                    videoArr[j,1] = shortName;//截图文件路径
                    videoArr[j,2] = Name;//文件名
                    videoArr[j,3] = fileinfo.Length.ToString();//文件大小
                    DateTime startTime = new DateTime(1970, 1, 1, 8, 0, 0);
                    videoArr[j,4] = Convert.ToInt64(fileinfo.LastWriteTime.Subtract(startTime).TotalSeconds).ToString();//文件时间
                    j++;
                    }
                    catch(Exception ee)
                    {
                        logBox.AppendText(ee.ToString());
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(basePath+"fileList.txt"))
            {
                for (int i = 0; i < videoArr.GetLength(0); i++)
                {
                    if (videoArr[i,0] != null)
                        writer.WriteLine(videoArr[i, 0] + "|" + videoArr[i, 1] + "|" + videoArr[i, 2] + "|" + videoArr[i, 3] + "|" + videoArr[i, 4]);
                }
            }
            workStatus.Text = "生成完成";

            Application.Restart();
            Environment.Exit(0);

            //this.listView1.Clear();
            //重新调用加载图片程序
            //Form1_Load(null,null);

            //radioButton1_CheckedChanged(sender, EventArgs.Empty);
            //此处省略，使用其他函数生成图片
            /*this.listView1.Clear();
            this.listView1.View = View.LargeIcon;
            imageListLarge.ImageSize = new Size(216, 144);
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
            this.listView1.LargeImageList = imageListLarge;
            this.listView1.BeginUpdate();
            for (int i = 0; i < imageListLarge.Images.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = videoArr[i,2];
                this.listView1.Items.Add(lvi);
            }
            this.listView1.EndUpdate();*/
        }


       // List<Image> tempImg;
        bool useListView2 = false;
        void reloadViewByArr()
        {//展示排序后的图片
          
           /* foreach(Image img in tempImg)
            {
                img.Dispose();
            }
            tempImg.Clear();
            imageListLarge.Images.Clear();
            imageListLarge.Dispose();*/

            if (useListView2)
            {
                listView2.Visible = true;
                this.listView2.BeginUpdate();

                if (listView2.LargeImageList != null)
                {
                    listView2.LargeImageList.Images.Clear();
                }

                this.listView2.Clear();
                this.listView2.EndUpdate();

                this.listView2.View = View.LargeIcon;

                imageListLarge.ImageSize = new Size(216, 144);
                imageListLarge.ColorDepth = ColorDepth.Depth32Bit;

                this.listView2.LargeImageList = imageListLarge;

                this.listView2.BeginUpdate();

                for (int i = 0; i < imageListLarge.Images.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = i;
                    lvi.Text = videoArr[i, 2];
                    this.listView2.Items.Add(lvi);
                }
                this.listView2.EndUpdate();

                /*
                //释放内存
                foreach (Image img in tempImg)
                {
                    img.Dispose();
                }
                tempImg.Clear();*/
            }
            else {
               

               
            }
            /*
            //释放内存
            foreach (Image img in tempImg)
            {
                img.Dispose();
            }
            tempImg.Clear();*/
        }


        bool useSort = true;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {//按照最新时间排序
            if (this.radioButton1.Checked)
            {
                for(int i = 0; i < videoArr.GetLength(0); i++)
                {
                    for(int j = i+1; j < videoArr.GetLength(0); j++)
                    {
                        try { 
                            if(Int64.Parse(videoArr[j,4]) > Int64.Parse(videoArr[i, 4]))
                            {
                                var a0 = videoArr[i,0];
                                var a1 = videoArr[i,1];
                                var a2 = videoArr[i,2];
                                var a3 = videoArr[i,3];
                                var a4 = videoArr[i,4];
                                var a5 = videoArr[i,5];
                                videoArr[i, 0] = videoArr[j, 0];
                                videoArr[i, 1] = videoArr[j, 1];
                                videoArr[i, 2] = videoArr[j, 2];
                                videoArr[i, 3] = videoArr[j, 3];
                                videoArr[i, 4] = videoArr[j, 4];
                                videoArr[i, 5] = videoArr[j, 5];
                                videoArr[j, 0] = a0;
                                videoArr[j, 1] = a1;
                                videoArr[j, 2] = a2;
                                videoArr[j, 3] = a3;
                                videoArr[j, 4] = a4;
                                videoArr[j, 5] = a5;

                        }
                        }
                        catch { }
                    }
                }
                if (!useSort)
                {//仅调用本函数进行排序，则不进行UI更新
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].ImageIndex = int.Parse(videoArr[i, 5]);
                        listView1.Items[i].Text = videoArr[i, 2];

                    }
                    listView1.Refresh();
                }
                   
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//按照文件大小排序
            if (this.radioButton2.Checked)
            {
                for (int i = 0; i < videoArr.GetLength(0); i++)
                {
                    for (int j = i + 1; j < videoArr.GetLength(0); j++)
                    {
                        if (Int64.Parse(videoArr[j, 3]) > Int64.Parse(videoArr[i, 3]))
                        {
                            var a0 = videoArr[i, 0];
                            var a1 = videoArr[i, 1];
                            var a2 = videoArr[i, 2];
                            var a3 = videoArr[i, 3];
                            var a4 = videoArr[i, 4];
                            var a5 = videoArr[i, 5];
                            videoArr[i, 0] = videoArr[j, 0];
                            videoArr[i, 1] = videoArr[j, 1];
                            videoArr[i, 2] = videoArr[j, 2];
                            videoArr[i, 3] = videoArr[j, 3];
                            videoArr[i, 4] = videoArr[j, 4];
                            videoArr[i, 5] = videoArr[j, 5];
                            videoArr[j, 0] = a0;
                            videoArr[j, 1] = a1;
                            videoArr[j, 2] = a2;
                            videoArr[j, 3] = a3;
                            videoArr[j, 4] = a4;
                            videoArr[j, 5] = a5;
                            

                            //傻逼玩意，只能换图片，不能换TEXT会死机
                           /* int tempIndex = listView1.Items[i].ImageIndex;
                            listView1.Items[i].ImageIndex = listView1.Items[j].ImageIndex;
                            listView1.Items[j].ImageIndex = tempIndex;*/

                            /*listView1.Items[i].Text =videoArr[j, 2];
                            listView1.Items[j].Text =videoArr[i, 2];
                            Console.WriteLine("交换："+videoArr[j, 2]);*/
                        }
                    }
                }
                for(int i=0;i<listView1.Items.Count; i++)
                {
                    listView1.Items[i].ImageIndex = int.Parse(videoArr[i, 5]);
                    listView1.Items[i].Text = videoArr[i, 2];

                }
                listView1.Refresh();
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {//按照文件名排序
            if (this.radioButton3.Checked)
            {
                for (int i = 0; i < videoArr.GetLength(0); i++)
                {
                    for (int j = i + 1; j < videoArr.GetLength(0); j++)
                    {
                        if (videoArr[i, 2].CompareTo(videoArr[j, 2]) > 0)
                        {
                            var a0 = videoArr[i, 0];
                            var a1 = videoArr[i, 1];
                            var a2 = videoArr[i, 2];
                            var a3 = videoArr[i, 3];
                            var a4 = videoArr[i, 4];
                            var a5 = videoArr[i, 5];
                            videoArr[i, 0] = videoArr[j, 0];
                            videoArr[i, 1] = videoArr[j, 1];
                            videoArr[i, 2] = videoArr[j, 2];
                            videoArr[i, 3] = videoArr[j, 3];
                            videoArr[i, 4] = videoArr[j, 4];
                            videoArr[i, 5] = videoArr[j, 5];
                            videoArr[j, 0] = a0;
                            videoArr[j, 1] = a1;
                            videoArr[j, 2] = a2;
                            videoArr[j, 3] = a3;
                            videoArr[j, 4] = a4;
                            videoArr[j, 5] = a5;
                        }
                    }
                }
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].ImageIndex = int.Parse(videoArr[i, 5]);
                    listView1.Items[i].Text = videoArr[i, 2];

                }
                listView1.Refresh();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index = listView1.SelectedIndices[0];
            try
            {
                Console.WriteLine("打开:"+videoArr[index, 0]);
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = videoArr[index, 0],
                    UseShellExecute = true
                };

                Process process = new Process
                {
                    StartInfo = startInfo
                };

                process.Start();
                    }
                catch
                {
                    MessageBox.Show("无法打开 " + videoArr[index, 0]);
                }
            }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //ListView listView = (ListView)sender;
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                //cmsListViewItem是我们添加的菜单控件
                this.contextMenuStrip1.Show(listView1, e.X, e.Y);
                int index = listView1.SelectedIndices[0];
                Double a = Double.Parse(videoArr[index, 3]) / 1024 / 1024 / 1024;
                if(a>=1)
                    toolStripMenuItem_size.Text =((Double)Math.Round(a,2)).ToString()+" GB";
                else
                {
                    a = a * 1024;
                    toolStripMenuItem_size.Text = ((Double)Math.Round(a, 2)).ToString() + " MB";
                }
                toolStripMenuItem_locate.Text = videoArr[index, 0];   
                //toolStripMenuItem_date.Text = videoArr[index,4];
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int.Parse(videoArr[index, 4]));
                toolStripMenuItem_size.Text = toolStripMenuItem_size.Text+" - "+ dateTime.ToString("yyyy年MM月dd日");

                if (videoLoveList.Contains(videoArr[index, 2]))
                {
                    toolStripMenuItem_like.Text = "X不喜欢X";
                }
                else
                {
                    toolStripMenuItem_like.Text = "★喜欢★";
                }
            }
        }

        private void toolStripMenuItem_refresh_Click(object sender, EventArgs e)
        {
            int index = listView1.SelectedIndices[0];
            Console.WriteLine("刷新截图:" + videoArr[index, 0]);

            Form3 form3 = new Form3();
            form3.Show();
           // form3.pictureBox1.Image = Image.FromFile(videoArr[index, 1]);
       
            /* Random ran = new Random();
             int n = ran.Next(600);

             ExtractSnapshot(videoArr[index, 0],videoArr[index, 1], TimeSpan.FromSeconds(n));// 重新截图
             radioButton1_CheckedChanged(sender, EventArgs.Empty);
             radioButton2_CheckedChanged(sender, EventArgs.Empty);
             radioButton3_CheckedChanged(sender, EventArgs.Empty);*/
        }

        private void toolStripMenuItem_locate_Click(object sender, EventArgs e)
        {
            int index ;
            if (listView2.Visible == true)
            {
                index = listView2.SelectedIndices[0];
                System.Diagnostics.Process.Start("Explorer", "/select," + videoArrTemp[index, 0]);//打开并定位文件
            }
            else
            {
                index = listView1.SelectedIndices[0];
                System.Diagnostics.Process.Start("Explorer", "/select," + videoArr[index, 0]);//打开并定位文件
            }


                Console.WriteLine("定位文件:" + videoArr[index, 0]);
            
        }

        private void toolStripMenuItem_rename_Click(object sender, EventArgs e)
        {
            int index = listView1.SelectedIndices[0];
            Form2 form2 = new Form2();
            form2.Show();
            form2.textBox1.Text= videoArr[index, 2];
            form2.textBox2.Text= videoArr[index, 0];
       
            //form2.textbox = videoArr[index, 2];
        }


        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listView1.SelectedIndices[0];
                Double a = Double.Parse(videoArr[index, 3]) / 1024 / 1024 / 1024;
                if (a >= 1)
                    label_size.Text = ((Double)Math.Round(a, 2)).ToString() + " GB";
                else
                {
                    a = a * 1024;
                    label_size.Text = ((Double)Math.Round(a, 2)).ToString() + " MB";
                }
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int.Parse(videoArr[index, 4]));
                label_size.Text = dateTime.ToString("yyyy年MM月dd日 ")+ label_size.Text;
                Console.WriteLine(index);
            }
            catch { }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
            listView2.Visible = false;
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            int index = listView2.SelectedIndices[0];
            try
            {
                Console.WriteLine("打开:" + videoArrTemp[index, 0]);
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = videoArrTemp[index, 0],
                    UseShellExecute = true
                };

                Process process = new Process
                {
                    StartInfo = startInfo
                };

                process.Start();
            }
            catch
            {
                MessageBox.Show("无法打开 "+ videoArrTemp[index, 0]);
            }
            
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listView2.SelectedIndices[0];
                Double a = Double.Parse(videoArrTemp[index, 3]) / 1024 / 1024 / 1024;
                if (a >= 1)
                    label_size.Text = ((Double)Math.Round(a, 2)).ToString() + " GB";
                else
                {
                    a = a * 1024;
                    label_size.Text = ((Double)Math.Round(a, 2)).ToString() + " MB";
                }
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int.Parse(videoArrTemp[index, 4]));
                label_size.Text = dateTime.ToString("yyyy年MM月dd日 ") + label_size.Text;
                Console.WriteLine(index);
            }
            catch { }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            //ListView listView = (ListView)sender;
            ListViewItem item = listView2.GetItemAt(e.X, e.Y);
            if (item != null && e.Button == MouseButtons.Right)
            {
                //cmsListViewItem是我们添加的菜单控件
                this.contextMenuStrip1.Show(listView2, e.X, e.Y);
                int index = listView2.SelectedIndices[0];
                Double a = Double.Parse(videoArrTemp[index, 3]) / 1024 / 1024 / 1024;
                if (a >= 1)
                    toolStripMenuItem_size.Text = ((Double)Math.Round(a, 2)).ToString() + " GB";
                else
                {
                    a = a * 1024;
                    toolStripMenuItem_size.Text = ((Double)Math.Round(a, 2)).ToString() + " MB";
                }
                toolStripMenuItem_locate.Text = videoArrTemp[index, 0];
                //toolStripMenuItem_date.Text = videoArr[index,4];
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(int.Parse(videoArrTemp[index, 4]));
                toolStripMenuItem_size.Text = toolStripMenuItem_size.Text + " - " + dateTime.ToString("yyyy年MM月dd日");
                if(videoLoveList.Contains(videoArrTemp[index, 2]))
                {
                    toolStripMenuItem_like.Text = "X不喜欢X";
                }
                else
                {
                    toolStripMenuItem_like.Text = "★喜欢★";
                }
            }
        }

        private void HistoryListBox_Click(object sender, EventArgs e)
        {
            if (HistoryListBox.SelectedItem != null)
            {
                searchBox.Text = HistoryListBox.SelectedItem.ToString();
                searchBox_KeyDown(null, null);
            }
            
        }

        private void toolStripMenuItem_like_Click(object sender, EventArgs e)
        {
            string filename;
            if (!listView2.Visible)
            {
                int index = listView1.SelectedIndices[0];
                filename = videoArr[index, 2];
            }
            else
            {
                int index = listView2.SelectedIndices[0];
                filename = videoArrTemp[index, 2];
            }
           

            if(toolStripMenuItem_like.Text== "★喜欢★")
            {
                if (!videoLoveList.Contains(filename))
                {
                    videoLoveList.Add(filename);
                }
            }
            else
            {
                videoLoveList.Remove(filename);
            }



            string save = string.Join("|", videoLoveList);
            using (StreamWriter writer = new StreamWriter(basePath + "loveList.txt"))
            {
                writer.WriteLine(save);
            }

        }

        private void HistoryListBox_DoubleClick(object sender, EventArgs e)
        {
            HistoryListBox.Items.Remove(HistoryListBox.SelectedItem);
            HistoryListSave();
        }

        void HistoryListSave()
        {
            string data = "";
            for (int i = 0; i < HistoryListBox.Items.Count; i++)
            {
                data += HistoryListBox.Items[i].ToString() + "|";
            }
            using (StreamWriter writer = new StreamWriter(basePath + "historyList.txt"))
            {
                writer.WriteLine(data);
            }
        }

        private void toolStripMenuItem_delete_Click(object sender, EventArgs e)
        {
            int index;
            string path = "";
            if (listView2.Visible == true)
            {
                index = listView2.SelectedIndices[0];
                path = videoArrTemp[index, 0];
            }
            else
            {
                index = listView1.SelectedIndices[0];
                path = videoArr[index, 0];
            }
            try
            {
                // 将文件删除到回收站（第二个参数为UIOption.OnlyErrorDialogs表示仅出错时弹出对话框）
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                     path,
                    UIOption.AllDialogs,
                    RecycleOption.SendToRecycleBin
                );

                Console.WriteLine("文件已成功移到回收站！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件不存在：" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int min = 0; // 随机整数的最小值
            int max = videoArr.GetLength(0) - 1; // 随机整数的最大值
            int randomNumber = random.Next(min, max);
            try
            {
            
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = videoArr[randomNumber, 0],
                    UseShellExecute = true
                };

                Process process = new Process
                {
                    StartInfo = startInfo
                };

                process.Start();
            }
            catch
            {
                logBox.Text="无法打开 " + videoArr[randomNumber, 0];
            }
        }

        private void myLove_CheckedChanged(object sender, EventArgs e)
        {
            if (imgWork)
            {
                workStatus.Text = "请等待图片加载";
                return;
            }
            if (myLove.Checked) {
                listView2.Visible = true;

                int searchNum = 0;//搜索到的文件数量
                int j = 0;

                this.listView2.Items.Clear();
                videoArrTemp = new string[videoArr.Length, 6];

                this.listView2.View = View.LargeIcon;
                this.listView2.LargeImageList = imageListLarge;
                for (int i = 0; i < videoArr.GetLength(0); i++)
                {//第一次遍历统计搜索的数量

                    if (videoLoveList.Contains(videoArr[i,2]))
                    {
                        searchNum++;
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = int.Parse(videoArr[i, 5]);
                        lvi.Text = videoArr[i, 2];
                        this.listView2.Items.Add(lvi);
                        videoArrTemp[j, 0] = videoArr[i, 0];
                        videoArrTemp[j, 1] = videoArr[i, 1];
                        videoArrTemp[j, 2] = videoArr[i, 2];
                        videoArrTemp[j, 3] = videoArr[i, 3];
                        videoArrTemp[j, 4] = videoArr[i, 4];
                        videoArrTemp[j, 5] = videoArr[i, 5];
                        j++;
                    }
                }
            }
            else
            {
                listView2.Visible = false;
            }
        }

        private void checkSame_CheckedChanged(object sender, EventArgs e)
        {
            if (imgWork)
            {
                workStatus.Text = "请等待图片加载";
                return;
            }

            // 1. 构建不区分大小写、去除扩展名的英文数字key到索引列表的映射
            Dictionary<string, List<int>> nameDict = new Dictionary<string, List<int>>();
            for (int i = 0; i < videoArr.GetLength(0); i++)
            {
                string rawName = videoArr[i, 2];
                if (string.IsNullOrEmpty(rawName)) continue;

                string nameWithoutExt = Path.GetFileNameWithoutExtension(rawName).ToLowerInvariant();
                string key = string.Concat(System.Text.RegularExpressions.Regex.Matches(nameWithoutExt, "[a-z0-9]")
                    .Cast<System.Text.RegularExpressions.Match>()
                    .Select(m => m.Value));
                if (string.IsNullOrEmpty(key)) continue;

                if (!nameDict.ContainsKey(key))
                    nameDict[key] = new List<int>();
                nameDict[key].Add(i);
            }

            // 2. 收集所有重复项的索引
            HashSet<int> duplicateIndexes = new HashSet<int>();
            foreach (var kv in nameDict)
            {
                if (kv.Value.Count > 1)
                {
                    foreach (var idx in kv.Value)
                        duplicateIndexes.Add(idx);
                }
            }

            // 3. 展示到listView2，按文件名排序
            if (duplicateIndexes.Count > 0)
            {
                listView2.Visible = true;
                this.listView2.Items.Clear();
                videoArrTemp = new string[duplicateIndexes.Count, 6];
                this.listView2.View = View.LargeIcon;
                this.listView2.LargeImageList = imageListLarge;

                // 按文件大小排序（从大到小）
                var sortedIndexes = duplicateIndexes
                    .OrderByDescending(idx =>
                    {
                        long size = 0;
                        long.TryParse(videoArr[idx, 3], out size);
                        return size;
                    })
                    .ThenBy(idx => videoArr[idx, 2], StringComparer.CurrentCultureIgnoreCase) // 同大小再按文件名
                    .ToList();

                int j = 0;
                foreach (int i in sortedIndexes)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = int.Parse(videoArr[i, 5]);
                    lvi.Text = videoArr[i, 2];
                    this.listView2.Items.Add(lvi);

                    for (int k = 0; k < 6; k++)
                        videoArrTemp[j, k] = videoArr[i, k];
                    j++;
                }
            }
            else
            {
                listView2.Visible = false;
            }
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {//搜索
            if (imgWork)
            {
                workStatus.Text = "请等待图片加载";
                return;
            }
            if (e==null || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if(searchBox.Text.Length >0)
                {
                    listView2.Visible = true;

                    int searchNum = 0;//搜索到的文件数量
                    int j = 0;

                    this.listView2.Items.Clear();
                    videoArrTemp=new string[videoArr.Length,6];

                    this.listView2.View = View.LargeIcon;
                    this.listView2.LargeImageList = imageListLarge;
                    for (int i = 0; i < videoArr.GetLength(0); i++)
                    {//第一次遍历统计搜索的数量
                        
                        if (videoArr[i, 2].ToLower().Contains(searchBox.Text.ToLower()))
                        {
                            searchNum++;
                            ListViewItem lvi = new ListViewItem();
                            lvi.ImageIndex = int.Parse(videoArr[i, 5]);
                            lvi.Text = videoArr[i, 2];
                            this.listView2.Items.Add(lvi);
                            videoArrTemp[j,0]=videoArr[i, 0];
                            videoArrTemp[j,1]=videoArr[i, 1];
                            videoArrTemp[j,2]=videoArr[i, 2];
                            videoArrTemp[j,3]=videoArr[i, 3];
                            videoArrTemp[j,4]=videoArr[i, 4];
                            videoArrTemp[j,5]=videoArr[i, 5];
                            j++;
                        }
                    }

                    if (HistoryListBox.Items.Contains(searchBox.Text) == false && searchBox.Text.Length>0)
                    {//加入搜索记录
                        HistoryListBox.Items.Insert(0,searchBox.Text);
                        HistoryListSave();
                    }
                  
                }
                else
                {
                    listView2.Visible = false;
                }
                if(e!=null)
                    e.SuppressKeyPress = true;
            }
            
        }

        private void labelVideoNum_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 检查videoArr中英文和数字部分重复的文件名
        /// </summary>
        private void CheckDuplicateFileNames()
        {
            // key: 英文和数字组成的部分（不含扩展名，且不区分大小写），value: 索引列表
            Dictionary<string, List<int>> nameDict = new Dictionary<string, List<int>>();

            for (int i = 0; i < videoArr.GetLength(0); i++)
            {
                string rawName = videoArr[i, 2];
                if (string.IsNullOrEmpty(rawName)) continue;

                // 去除扩展名并转为小写
                string nameWithoutExt = Path.GetFileNameWithoutExtension(rawName).ToLowerInvariant();

                // 提取所有英文和数字
                string key = string.Concat(System.Text.RegularExpressions.Regex.Matches(nameWithoutExt, "[a-z0-9]")
                    .Cast<System.Text.RegularExpressions.Match>()
                    .Select(m => m.Value));

                if (string.IsNullOrEmpty(key)) continue;

                if (!nameDict.ContainsKey(key))
                    nameDict[key] = new List<int>();
                nameDict[key].Add(i);
            }

            // 输出重复项
            foreach (var kv in nameDict)
            {
                if (kv.Value.Count > 1)
                {
                    logBox.AppendText($"重复文件名: {kv.Key}，索引: {string.Join(",", kv.Value)}\r\n");
                }
            }
        }
    }
}
