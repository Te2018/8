using MVCFileUpload.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace MVCFileUpload
{
    /// <summary>
    ///WebService1 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        CartsEntities dc = new CartsEntities();

        [WebMethod]
        public string word(string aaa)
        {
            var b = aaa;
             
            Accept c = new Accept();

            c.acceptAstring = aaa;
            
            dc.Accept.Add(c);

            try
            {
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
          
            return aaa+"hello";
        }

        [WebMethod]
        public string pic(IEnumerable<HttpPostedFileBase> filefile)
        {
            int number = 0;
            if (null!=filefile && 0 < filefile.Count())
            {
                foreach (HttpPostedFileBase file in filefile)
                {
                    if (5<=number)
                    {
                        break;
                    }

                    try
                    {
                        string fileName = Path.GetFileName(file.FileName);

                        string directoryPath = Server.MapPath("~/Uploads/");
                        string path = Path.Combine(directoryPath, fileName);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                            SetFileRole(directoryPath);
                        }
                        file.SaveAs(path);
                    }
                    catch(Exception e)
                    {
                        return "errorPic";    
                    }
                    finally
                    {
                        number++;
                    }
                }

            }
            
            return  "picOK";
        }

        private void SetFileRole(string foldPath)
        {
            DirectorySecurity fsec = new DirectorySecurity();
            fsec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, 
                AccessControlType.Allow));
            System.IO.Directory.SetAccessControl(foldPath, fsec);
        }
    }
}
