using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WebUI
{
    /// <summary>
    /// Summary description for ShowImages
    /// </summary>
    public class ShowImages : IHttpHandler
    {
        public void ProcessRequest(HttpContext ctx)
        {
            string id = ctx.Request.QueryString["Cargo_ID"];
            byte[] image = DigDes.DSchool.SUPS.DataAccess.PresentData.CargoGuidePresent.GetImage(Int32.Parse(id));

            if (image != null)
            {
                ctx.Response.ContentType = "image/png";
                ctx.Response.OutputStream.Write(image, 0, image.Length);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}