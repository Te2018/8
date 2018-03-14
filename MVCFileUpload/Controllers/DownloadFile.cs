using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVCFileUpload.Controllers
{
    public class DownloadFile
    {
        [Display(Name="檔案名稱")]
        public string Filename { get; set; }
        [Display(Name = "檔案大小")]
        public long Filesize { get; set; }
        [Display(Name = "上傳時間")]
        public DateTime UploadTime { get; set; }
    }
}
