using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace API_Vigilancia.Models
{
    public class M54 : OPS.Comm.Becs.Messages.Msg54
    {
        #region "Constructores"
        public M54() { }
        public M54(XmlDocument msgXml) : base() { this._docXml = msgXml; }
        #endregion

        public class ResponseDTO
        {
            public string success { get; set; }
            public string error_code { get; set; }
            public string message { get; set; }
            public List<Object> data { get; set; }
        }

        public class M54DTO
        {
            public String t { get; set; }
        }
    }
}