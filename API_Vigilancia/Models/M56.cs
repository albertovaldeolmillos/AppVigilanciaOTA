using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace API_Vigilancia.Models
{
    public class M56 : OPS.Comm.Becs.Messages.Msg55
    {
        #region "Constructores"
        public M56() { }
        public M56(XmlDocument msgXml) : base() { this._docXml = msgXml; }
        #endregion

        public class ResponseDTO
        {
            public string success { get; set; }
            public string error_code { get; set; }
            public string message { get; set; }
            public List<Object> data { get; set; }
        }

        public class M56DTO
        {
            //public String t { get; set; }
        }
    }
}