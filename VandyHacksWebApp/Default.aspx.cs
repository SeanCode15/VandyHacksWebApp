using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using SevenTiny.Cloud.ScriptEngine;

namespace VandyHacksWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MongoDBController controller = new MongoDBController();
            //controller.Save(new DbDataset { Id="1", Circumference=10.1f, Size="Medium", Width=4.0f });
        
            if (!IsPostBack)
            {
                chooseGloveTypeBtn.BackColor = Color.Aqua;
                chooseGloveTypeBtn.Text = "Change to Women's";
                CenterPicture.Visible = false;
                LeftPicture.Visible = false;
                gloveLabel.Visible = false;
                picLbl1.Visible = false;
                picLbl2.Visible = false;
                PlaceholderLbl.Visible = true;
                superJumbo.Visible = false;
                chooseGloveTypeBtn.Visible = false;
            }
            
            //var files = FileSearcher.GetAllFileSets();
        }

        protected void ScanBtn_Click(object sender, EventArgs e)
        {
            //System.Drawing.Image image = System.Drawing.Image.FromFile(MapPath(@"Images\code.jpg"));
            //System.Drawing.Image ImageResize = Omu.Drawing.Imager.Resize(image, 150, 150, true);

            //MemoryStream ms = new MemoryStream();
            //ImageResize.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            //byte[] ImageBytes = ms.ToArray();
            //MemoryStream ms2 = new MemoryStream(ImageBytes);
            //Bitmap returnImage = new Bitmap(System.Drawing.Image.FromStream(ms2, true, true), 150, 150);
            //returnImage.Save(@"C:\Users\seanb\helloworld.png");


            //Bitmap imageToSave = new Bitmap(ImageResize);
            //imageToSave.Save(@"Images\code.jpg", ImageFormat.Jpeg);
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";

            //string fileNameWithExtension = "images/0.png";

            //startInfo.Arguments = @"/C C:\Users\seanb\Documents\handpose\HandPose>python handPoseImage.py " + fileNameWithExtension;

            //System.Diagnostics.Process.Start("CMD.exe", @"'/c C:\Users\seanb\Documents\handpose\HandPose>python handPoseImage.py " + fileNameWithExtension);
            /*var workingDirectory = MapPath("Scripts");//Path.GetFullPath("Scripts");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WorkingDirectory = workingDirectory
                }
            };
            process.Start();
            // Pass multiple commands to cmd.exe
            using (var sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    // Vital to activate Anaconda
                    sw.WriteLine("C:\\Users\\seanb\\Anaconda3\\Scripts\\activate.bat");
                    // Activate your environment
                    sw.WriteLine("Conda create -n py33 python=3.3 anaconda");
                    // Any other commands you want to run
                    //sw.WriteLine("set KERAS_BACKEND=tensorflow");
                    // run your script. You can also pass in arguments
                    sw.WriteLine("python handPoseImage.py images/0.png");
                }
            }

            // read multiple output lines
            while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }*/
            //process.StartInfo = startInfo;
            //process.Start();
            //System.Threading.Thread.Sleep(2000);
            //var ipy = Python.CreateRuntime();
            //dynamic test = ipy.UseFile(@"C:\Users\seanb\Documents\handpose\HandPose\handPoseImage.py");
            //var engine = Python.CreateEngine();

            //dynamic scope = engine.CreateScope();
            //ICollection<string> paths = pyEngine.GetSearchPaths();
            //string dir = @"C:\Python27\Lib\";
            //paths.Add(dir);
            //string dir2 = @"C:\Python27\Lib\site-packages";
            //paths.Add(dir2);
            //pyEngine.SetSearchPaths(paths);
            //string dir = Path.GetDirectoryName(@"C:\Users\seanb\Documents\handpose\HandPose\handPoseImage.py");
            //ICollection<string> paths = engine.GetSearchPaths();

            //if (!String.IsNullOrWhiteSpace(dir))
            //{
            //    paths.Add(dir);
            //}
            //else
            //{
            //    paths.Add(Environment.CurrentDirectory);
            //}
            //engine.SetSearchPaths(paths);
            //engine.ImportModule("__future__.py");
            //engine.ExecuteFile(@"C:\Users\seanb\Documents\handpose\HandPose\handPoseImage.py");
                    //var psi = new ProcessStartInfo();
                    //psi.FileName = @"C:\Users\seanb\Downloads\PyCharm\python-3.5.0-amd64.exe";
                    //var script = @"C:\Users\seanb\Documents\handpose\HandPose\handPoseImage.py";
                    //psi.Arguments=$"\"{script}\"";
                    //psi.UseShellExecute = false;
                    //psi.CreateNoWindow = true;
                    //psi.RedirectStandardOutput = true;
                    //psi.RedirectStandardError = true;
                    //var errors = string.Empty;
                    //var results = string.Empty;
                    //using (var process = Process.Start(psi))
                    //{
                    //    errors = process.StandardError.ReadToEnd();
                    //    results = process.StandardOutput.ReadToEnd();
                    //}
            SetOutputs();
        }
        private void SetOutputs()
        {
            var dimensions = FileSearcher.GetFileInfo(MapPath("OutputDimensions/Outputs.txt"));
            float circ = (float)dimensions.circumference;
            float height = (float)dimensions.height;
            bool sizeBool = false;
            if (chooseGloveTypeBtn.BackColor == Color.Aqua)
            {
                sizeBool = true;
            }
            string sizeToDisplay = RateTheSize(circ, height, sizeBool);
            if (sizeBool)
                sizeToDisplay = "Men's " + sizeToDisplay;
            else
                sizeToDisplay = "Women's " + sizeToDisplay;

            CenterPicture.Visible = true;
            LeftPicture.Visible = true;
            gloveLabel.Visible = true;
            picLbl1.Visible = true;
            picLbl2.Visible = true;
            PlaceholderLbl.Visible = false;
            superJumbo.Visible = true;
            chooseGloveTypeBtn.Visible = true;
            gloveLabel.Text = sizeToDisplay;


            CenterPicture.ImageUrl = (@"~/Images/KeypointOutput.jpg"); //@"Images\code.jpg";
            LeftPicture.ImageUrl = (@"~/Images/SkeletonOutput.jpg"); //@"Images\code.jpg";
            //RightPicture.ImageUrl = @"Images\code.jpg";

        }

        /// <summary>
        /// size is size in cm
        /// gender is 1 for male, 0 for female
        /// </summary>
        /// <param name="size"></param>
        /// <param name="gender"></param>
        public string RateTheSize(float circ, float height, bool gender)
        {
            if (gender)
            {
               
                if (circ < 16)
                {
                    return "XS";
                }
                else if (circ < 17.1)
                {
                    return "Small";
                }
                else if (circ < 18.2)
                {
                    return "Medium";
                }
                else if (circ < 19.2)
                {
                    return "Large";
                }
                else if (circ < 20.4)
                {
                    return "XL";
                }
                else
                {
                    return "XXL";
                }
            }
            else
            {
                if (circ < 15)
                {
                    return "XS";
                }
                else if (circ < 16.1)
                {
                    return "Small";
                }
                else if (circ < 17.2)
                {
                    return "Medium";
                }
                else if (circ < 18.2)
                {
                    return "Large";
                }
                else
                {
                    return "XL";
                }
            }
        }

        protected void chooseGloveTypeBtn_Click(object sender, EventArgs e)
        {
            if (chooseGloveTypeBtn.BackColor == Color.Aqua)
            {
                chooseGloveTypeBtn.Text = "Change to Men's";
                chooseGloveTypeBtn.BackColor = Color.Orange;
            }
            else
            {
                chooseGloveTypeBtn.Text = "Change to Women's";
                chooseGloveTypeBtn.BackColor = Color.Aqua;
            }
            SetOutputs();
        }
    }
}   