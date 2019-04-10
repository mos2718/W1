using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            // Get Method
            if (Request.RequestType != "POST")
            {
                reply(Error_("方法錯誤，請使用POST，並遵循上傳規則"));
                return;
            }

            // Get collection
            NameValueCollection qstr = Request.QueryString;
          /*  if (qstr.Count != 1)
            {
                reply(Error_("方法錯誤，請使用POST，並遵循上傳規則"));
                return;
            } */
            if (qstr.GetKey(0) != "id")
            {
                reply(Error_("方法錯誤，查無存檔id，並遵循上傳規則"));
                return;
            }
            string curPath = Server.MapPath("."); 

            FileInfo f = new FileInfo(curPath + "\\" + qstr.Get(0) + ".txt");
           // FileInfo f = new FileInfo("C:\\inetpub\\wwwroot\\httptest\\" + qstr.Get(0) + ".txt");
            StreamWriter sw;
            if (f.Exists)
            {
                sw = f.AppendText();
            }
            else
            {
                sw = f.CreateText();
            }


          //  DateTime myDate = DateTime.Now;
          //  string myDateString = myDate.ToString("yyyy-MM-dd-HH:mm:ss");
          //  string myDateString = myDate.ToString("yyyyMMddHHmmss");
          //  myDateString = "{\"dateTime\":\"" + myDateString + "\" ,"; 

            //POST
            StreamReader reader = new StreamReader(Request.InputStream);
            string rqData;
            rqData = reader.ReadToEnd();
          //  rqData = "\"rqData\":\"" + rqData +"\"} "; 
          //  rqData = myDateString + rqData;

            sw.WriteLine(rqData);
            sw.Flush();
            sw.Close();

            reply(success());

        }
        catch (Exception ex)
        {
            reply(Error_(ex.Message + "請重新傳送"));
        }
    }
    private void reply(string xml)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.Write(xml);
    }
    private string Error_(string err)
    {
        string xml = "";
          xml = "有誤";
        return xml;
    }
    private string success()
    {
        string xml = "";
       
        xml = "資料儲存成功";
        return xml;
    }
}