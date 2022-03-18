using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace API_Vigilancia.Models
{
    public class M53 : OPS.Comm.Becs.Messages.Msg53
    {
        #region "Constructores"
        public M53() {}
        public M53(XmlDocument msgXml) : base() { 
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

        public class M53DTO_Request
        {
            /// <summary>
            /// fine ID (generated locally by the PDA) (FIN_ID)
            /// </summary>
            public string f { get; set; }
            /// <summary>
            /// fine type (including annulments and cancellations) (FIN_DFIN_ID)
            /// </summary>
            public string y { get; set; }
            /// <summary>
            /// license plate (FIN_VEHICLEID)
            /// </summary>
            public string m { get; set; }
            /// <summary>
            /// vehicle class (text) (FIN_MODEL)
            /// </summary>
            public string j { get; set; }
            /// <summary>
            /// vehicle brand (text) (FIN_MANUFACTURER)
            /// </summary>
            public string k { get; set; }
            /// <summary>
            /// vehicle color (text) (FIN_COLOUR)
            /// </summary>
            public string l { get; set; }
            /// <summary>
            /// enforcement route (FIN_GRP_ID_ROUTE)
            /// </summary>
            public string r { get; set; }
            /// <summary>
            /// group ID (FIN_GRP_ID_ZONE)
            /// </summary>
            public string g { get; set; }
            /// <summary>
            /// street (ID FIN_STR_ID)
            /// </summary>
            public string w { get; set; }
            /// <summary>
            /// street number (FIN_STRNUMBER)
            /// </summary>
            public string n { get; set; }
            /// <summary>
            /// street position (Default 0 -> in front of, 1 -> next to) (FIN_POSITION)
            /// </summary>
            public string p { get; set; }
            /// <summary>
            /// observations (FIN_COMMENTS)
            /// </summary>
            public string e { get; set; }
            /// <summary>
            /// date in format yyyyMMddHHmmss (.config "DateFormat_OTS"="yyyyMMddHHmmss") (FIN_DATE)
            /// </summary>
            public string d { get; set; }
            /// <summary>
            /// unit ID (FIN_UNI_ID)
            /// </summary>
            public string u { get; set; }
            /// <summary>
            /// agent ID (FIN_USR_ID)
            /// </summary>
            public string z { get; set; }
            /// <summary>
            /// street letter  (FIN_LETTER)
            /// </summary>
            public string nl { get; set; }
            /// <summary>
            /// current state: (FIN_STATUS)
            /// <list type="bullet">
            /// <item><description>20: Interrupted before finishing</description></item>
            /// <item><description>30: Generated OK</description></item>
            /// <item><description>40: Cancellation of another fine</description></item>
            /// <item><description>50: Annulment of another fine</description></item>
            /// </list>
            /// </summary>
            public string s { get; set; }
            /// <summary>
            /// latitude 
            /// </summary>
            public string lt { get; set; }
            /// <summary>
            /// longitude 
            /// </summary>
            public string lg { get; set; }
        }

        public class M53DTO
        {
            public string r { get; set; }
        }
    }
}