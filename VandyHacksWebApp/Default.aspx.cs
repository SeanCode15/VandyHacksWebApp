using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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