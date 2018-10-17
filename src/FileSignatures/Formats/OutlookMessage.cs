using System;
using System.Collections.Generic;
using System.Text;

namespace FileSignatures.Formats
{
    public class OutlookMessage : OleCompoundFile
    {
        public OutlookMessage() : base(new byte[] {
            0x52, 0x00, 0x6F, 0x00, 0x6F, 0x00, 0x74, 0x00,
            0x20, 0x00, 0x45, 0x00, 0x6E, 0x00, 0x74, 0x00,
            0x72, 0x00, 0x79, 0x00 }, 
            "application/vnd.ms-outlook", 
            "ppt")
        {
        }
    }
}
