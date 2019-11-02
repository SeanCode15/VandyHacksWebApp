using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeLib;
using BarcodeStandard;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using Spire.Barcode;
using System.IO;
using System.Text;
using Omu.Drawing;

namespace VandyHacksWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void ScanBtn_Click(object sender, EventArgs e)
        {
            
            System.Drawing.Image image = System.Drawing.Image.FromFile(MapPath(@"Images\code.jpg"));
            System.Drawing.Image ImageResize = Omu.Drawing.Imager.Resize(image, 250, 250, true);
            Bitmap imageToSave = new Bitmap(ImageResize);
            imageToSave.Save(@"Images\Code.jpg", ImageFormat.Jpeg);
            
            
           
            CenterPicture.ImageUrl = @"Images\Code.jpg";
            LeftPicture.ImageUrl = @"Images\Code.jpg";
            RightPicture.ImageUrl = @"Images\code.jpg";
        }


    }
}   