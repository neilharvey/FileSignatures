using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class UploadResultModel
    {
        public bool? Accepted { get; set; }

        public string FileName { get; set; }

        public string MediaType { get; set; }
    }
}
