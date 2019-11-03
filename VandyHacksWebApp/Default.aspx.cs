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
                picLbl3.Visible = false;
                PlaceholderLbl.Visible = true;
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
            picLbl3.Visible = true;
            PlaceholderLbl.Visible = false;
            gloveLabel.Text = sizeToDisplay;


            CenterPicture.ImageUrl = "Output-Skeleton.jpg"; //@"Images\code.jpg";
            LeftPicture.ImageUrl = "Output-Keypoints.jpg"; //@"Images\code.jpg";
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
                if (circ < 19)
                {
                    return "Extra Small";
                }
                else if (19 <= circ && circ < 21.5)
                {
                    return "Small";
                }
                else if (21.5 <= circ && circ < 24)
                {
                    return "Medium";
                }
                else if (24 <= circ && circ < 26.5)
                {
                    return "Large";
                }
                else if (26.5 <= circ && circ < 29)
                {
                    return "Extra Large";
                }
                else
                {
                    return "Extra Extra Large";
                }
            }
            else
            {
                if (circ < 15.875)
                {
                    return "Extra Small";
                }
                else if (15.875 <= circ && circ < 17.125)
                {
                    return "Small";
                }
                else if (17.125 <= circ && circ < 18.375)
                {
                    return "Medium";
                }
                else if (18.375 <= circ && circ < 19.625)
                {
                    return "Large";
                }
                else
                {
                    return "Extra Large";
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