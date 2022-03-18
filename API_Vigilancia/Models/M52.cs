using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Vigilancia.Models
{
    public class M52 : OPS.Comm.Becs.Messages.Msg52
    {       
        #region "Constructores"

        public M52(){}

        public M52(string table) : base(){
            this._table = table;
        }
        public M52(string table, int Version) : base()
        {
            this._table = table;
            this._version = Version;
        }
        #endregion

        public class ResponseDTO
        {
            public string success { get; set; }
            public string error_code { get; set; }
            public string message { get; set; }
            public List<Object> data { get; set; }
        }

        public class M52DTO_VEHCOLORS : DTO_BASE
        {
            public string VCOL_ID { get; set; }
            public string VCOL_VERSION { get; set; }
            public string VCOL_DESCSHORT { get; set; }
            public string VCOL_DESCLONG { get; set; }
        }
        public class M52DTO_VEHMODELS : DTO_BASE
        {
            public string VMOD_ID { get; set; }
            public string VMOD_VERSION { get; set; }
            public string VMOD_DESCSHORT { get; set; }
            public string VMOD_DESCLONG { get; set; }
            public string VMOD_VMAN_ID { get; set; }
        }
        public class M52DTO_GROUPS : DTO_BASE
        {
            public string GRP_ID { get; set; }
            public string GRP_VERSION { get; set; }
            public string GRP_DGRP_ID { get; set; }
            public string GRP_DESCSHORT { get; set; }
            public string GRP_DESCLONG { get; set; }
            //public string GRP_PATH { get; set; }
            public string GRP_COLOUR { get; set; }
            //public string GRP_TYPETREE { get; set; }
        }
        public class M52DTO_GROUPS_CHILDS : DTO_BASE
        {
            public string CGRP_UNIQUE_ID { get; set; }
            public string CGRP_VERSION { get; set; }
            public string CGRP_ID { get; set; }
            public string CGRP_TYPE { get; set; }
            public string CGRP_CHILD { get; set; }
        }
        public class M52DTO_USERS : DTO_BASE
        {
            public string USR_ID { get; set; }
            public string USR_VERSION { get; set; }
            public string USR_NAME { get; set; }
            public string USR_SURNAME1 { get; set; }
            public string USR_SURNAME2 { get; set; }
            public string USR_ROL_ID { get; set; }
            public string USR_LOGIN { get; set; }
            public string USR_LAN_ID { get; set; }
            public string USR_STATUS { get; set; }
            public string USR_PASSWORD { get; set; }
        }
        public class M52DTO_FINES_DEF : DTO_BASE
        {
            public string DFIN_ID { get; set; }
            public string DFIN_VERSION { get; set; }
            public string DFIN_CATEGORY { get; set; }
            public string DFIN_DESCSHORT { get; set; }
            public string DFIN_DESCLONG { get; set; }
            public string DFIN_VALUE { get; set; }
            public string DFIN_STATUS { get; set; }
            public string DFIN_SIGN { get; set; }
            public string DFIN_PAYINPDM { get; set; }
            public string DFIN_NUMTICKETS { get; set; }
            public string DFIN_POSTPAYABLE { get; set; }
            public string DFIN_FINID_OFFSET { get; set; }
        }
        public class M52DTO_STREETS : DTO_BASE
        {
            public string STR_ID { get; set; }
            public string STR_VERSION { get; set; }
            public string STR_DESC { get; set; }
            public string STR_MIN { get; set; }
            public string STR_MAX { get; set; }
            public string STR_PROVINCIA { get; set; }
            public string STR_MUNICIPIO { get; set; }
            public string STR_TIPOVIA { get; set; }
        }
        public class M52DTO_VEHMANUFACTURERS : DTO_BASE
        {
            public string VMAN_ID { get; set; }
            public string VMAN_VERSION { get; set; }
            public string VMAN_DESCSHORT { get; set; }
            public string VMAN_DESCLONG { get; set; }
        }
        public class M52DTO_STREETS_STRETCHS : DTO_BASE
        {
            public string SS_ID { get; set; }
            public string SS_VERSION { get; set; }
            public string SS_GRP_ID { get; set; }
            public string SS_STR_ID { get; set; }
            public string SS_STR_SS_ID { get; set; }
            public string SS_EVEN { get; set; }
            public string SS_STR_ID_DESDE { get; set; }
            public string SS_STR_ID_HASTA { get; set; }
            public string SS_DESC { get; set; }
        }
        public class M52DTO_WORKS : DTO_BASE
        {
            public string WORK_PDA_ID { get; set; }
            public string WORK_VERSION { get; set; }
            public string WORK_ID { get; set; }
            public string WORK_SS_ID { get; set; }
            public string WORK_USR_ID { get; set; }
            public string WORK_UNI_ID { get; set; }
            public string WORK_NUM_PARK_SPACES { get; set; }
            public string WORK_REMARKS { get; set; }
            public string WORK_LICEN_NUMBER { get; set; }
            public string WORK_LICEN_CORP { get; set; }
            public string WORK_INI_DATE { get; set; }
            public string WORK_END_DATE { get; set; }
        }
        public class M52DTO_RESIDENTS : DTO_BASE
        {
            public string RES_ID { get; set; }
            public string RES_VERSION { get; set; }
            public string RES_VEHICLEID { get; set; }
            public string RES_GRP_ID { get; set; }
            public string RES_DART_ID { get; set; }
        }
        public class M52DTO_VIPS : DTO_BASE
        {
            public string VIP_ID { get; set; }
            public string VIP_VERSION { get; set; }
            public string VIP_VEHICLEID { get; set; }
            public string VIP_GRP_ID { get; set; }
            public string VIP_DART_ID { get; set; }
            public string VIP_TEXT { get; set; }
            public string VIP_DAYOFWEEK { get; set; }
            public string VIP_INIHOUR { get; set; }
            public string VIP_INIMINUTE { get; set; }
            public string VIP_ENDHOUR { get; set; }
            public string VIP_ENDMINUTE { get; set; }
            public string VIP_INIDATE { get; set; }
            public string VIP_ENDDATE { get; set; }
        }
        public class M52DTO_GROUPS_PDA : DTO_BASE
        {
            public string GPDA_ID { get; set; }
            public string GPDA_VERSION { get; set; }
            public string GPDA_GRP_ID { get; set; }
            public string GPDA_GRP_ID_CHILD { get; set; }
            public string GPDA_DESC { get; set; }
        }

        public class DTO_BASE 
        {
            public string OP_TYPE { get; set; }
        }
    }
}