﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace VandyHacksWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MongoDBController controller = new MongoDBController();
            controller.Save(new DbDataset { Id="1", Circumference=10.1f, Size="Medium", Width=4.0f });
        
            if (!IsPostBack)
            {
                CenterPicture.Visible = false;
                LeftPicture.Visible = false;
                RightPicture.Visible = false;
                picLbl1.Visible = false;
                picLbl2.Visible = false;
                picLbl3.Visible = false;
                PlaceholderLbl.Visible = true;
            }
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
            CenterPicture.Visible = true;
            LeftPicture.Visible = true;
            RightPicture.Visible = true;
            picLbl1.Visible = true;
            picLbl2.Visible = true;
            picLbl3.Visible = true;
            PlaceholderLbl.Visible = false;

            CenterPicture.ImageUrl = @"Images\code.jpg";
            LeftPicture.ImageUrl = @"Images\code.jpg";
            RightPicture.ImageUrl = @"Images\code.jpg";
        }

        /// <summary>
        /// size is size in cm
        /// gender is 1 for male, 0 for female
        /// </summary>
        /// <param name="size"></param>
        /// <param name="gender"></param>
        public void RateTheSize(float size, bool gender)
        {
            if (gender)
            {
                if (size < 19)
                {

                }
                else if (19 <= size && size < 21.5)
                {

                }
                else if (21.5 <= size && size < 24)
                {

                }
                else if (24 <= size && size < 26.5)
                {

                }
                else if (26.5 <= size && size < 29)
                {

                }
                else
                {

                }
            }
            else
            {
                if (size < 15.875)
                {

                }
                else if (15.875 <= size && size < 17.125)
                {

                }
                else if (17.125 <= size && size < 18.375)
                {

                }
                else if (18.375 <= size && size < 19.625)
                {

                }
                else
                {

                }
            }
        }

    }
}   