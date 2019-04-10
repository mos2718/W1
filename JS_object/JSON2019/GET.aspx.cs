using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GET : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      /*
        //POST
        string xmlData;
        StreamReader reader = new StreamReader(Request.InputStream);
        //string xmlData = ;
        xmlData = reader.ReadToEnd();
        */

        // Get collection
        NameValueCollection qstr = Request.QueryString;
        
        if (qstr.GetKey(0) != "id")
        { Response.Write("查無id");
          return;
        }
     
     
        string curPath = Server.MapPath(".");

        FileInfo f = new FileInfo(curPath + "\\" + qstr.Get(0) + ".txt");
       // FileInfo f = new FileInfo("D:\\httptest\\" + qstr.Get(0) + ".txt");
        string JSONstr="", a="";
        int k = 0;
        StreamReader sr = f.OpenText();
        while (sr.Peek() >= 0)
        {
            k++;
            a += sr.ReadLine();
            if(sr.Peek() >= 0)    a += ",";
        }
        sr.Close();
        JSONstr = "[";
        JSONstr = JSONstr + a;
        JSONstr += "]";
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.Clear();
        Response.Write(JSONstr);
    }
   
  
}