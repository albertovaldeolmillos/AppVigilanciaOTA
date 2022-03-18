using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


namespace API_Vigilancia.Models
{
    public class M59 : OPS.Comm.Becs.Messages.Msg59
    {
        #region "Constructores"
        public M59() { }
        public M59(XmlDocument msgXml) : base() { this._docXml = msgXml; }
        #endregion


        public class ResponseDTO
        {
            public string success { get; set; }
            public string error_code { get; set; }
            public string message { get; set; }
            public List<Object> data { get; set; }
        }

        public class M59DTO
        {
            public String t { get; set; }
        }
    }
}