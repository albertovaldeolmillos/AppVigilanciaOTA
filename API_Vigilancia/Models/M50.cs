using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace API_Vigilancia.Models
{
    public class M50 : OPS.Comm.Becs.Messages.Msg50
    {
        #region "Constructores"
        public M50() { }
        public M50(XmlDocument msgXml) : base() { 
            this._docXml = msgXml;
            this._root = msgXml.DocumentElement;
            this.DoParseMessage();
        }
        #endregion

        public class ResponseDTO
        {
            public string success { get; set; }
            public string error_code { get; set; }
            public string message { get; set; }
            public List<Object> data { get; set; }
        }

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Category { get; set; }
        //public decimal Price { get; set; }

        //public string r { get; set; }
        //public string d { get; set; }
        //public string rein { get; set; }
        //public string vip { get; set; }
        //public string rise { get; set; }
        //public string bl { get; set; }

        //public class M50B : M50
        //{
        //    public string enforce_out3 { get; set; }
        //}

        public class M50DTO
        {
            public string r { get; set; }
            public string d { get; set; }
            public string rein { get; set; }
            public string vip { get; set; }
            public string resi { get; set; }
            public string bl { get; set; }
            public string tick { get; set; }
        }
    }
}