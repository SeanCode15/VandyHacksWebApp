using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BarcodeLib;
using BarcodeStandard;

using System.Data;
using System.Configuration;
using System.Collections;

using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

using Spire.Barcode;
using System.IO;
using System.Text;

namespace VandyHacksWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mappedPath = MapPath(@"Images\code.jpg");
            //System.IO.Stream stream = new FileStream(, FileMode.Open);
            string[] dataFromBarCode = Spire.Barcode.BarcodeScanner.Scan(mappedPath);

            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("<script language='JavaScript' type='text/javascript'>\n");
            sbScript.Append("<!--\n");
            sbScript.Append(this.GetPostBackEventReference(this, "PBArg") + ";\n");
            sbScript.Append("// -->\n");
            sbScript.Append("</script>\n");

            this.RegisterStartupScript("AutoPostBackScript", sbScript.ToString());
        }
    }
}   