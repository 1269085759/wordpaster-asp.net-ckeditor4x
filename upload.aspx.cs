using System;
using System.Web;
using System.IO;

namespace WordPasterCK4
{
    public partial class upload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string fname = Request.Form["UserName"];
			int len = Request.ContentLength;

			if (Request.Files.Count > 0)
			{
				DateTime timeNow = DateTime.Now;
				string uploadPath = "/upload/" + timeNow.ToString("yyyyMM") + "/" + timeNow.ToString("dd") + "/";

				string folder = Server.MapPath(uploadPath);
				//自动创建目录
				if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
				HttpPostedFile file = Request.Files.Get(0);

                //原始文件名称，由控件自动生成。
                //md5.png,crc.png,uuid.png,sha1.png
                string nameOri = file.FileName;
				string ext = Path.GetExtension(nameOri).ToLower();

				//只支持图片上传
				if (    ext == ".jpg"
                    ||  ext == ".jpeg"
                    ||  ext == ".png"
					||  ext == ".gif"
					||  ext == ".bmp")
				{
					string filePathSvr = Path.Combine(folder, nameOri);

                    //
                    if(!Directory.Exists(filePathSvr)) file.SaveAs(filePathSvr);
					Response.Write(uploadPath + nameOri);
				}
			}
		}
	}
}
