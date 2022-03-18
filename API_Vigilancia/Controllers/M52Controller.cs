using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Vigilancia.Models;
using OPS.Components.Data;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Script.Services;

using System.Resources;
using API_Vigilancia.Properties;

namespace API_Vigilancia.Controllers
{
    //[Produces("application/json")]
    public class M52Controller : ApiController
    {
        private readonly System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));

        [System.Web.Http.Route("M52/{table}/{Ver?}")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<pendiente>")]
        public IHttpActionResult GetTable(string table, int Ver = 0)
        {
            M52.ResponseDTO resultDTO = new M52.ResponseDTO();
            try
            {
                //TextReader sr = new StringReader(new M52(table).Process()[0]);
                TextReader sr = new StringReader(new M52(table, Ver).Process()[0]);
                XElement xmlTree = XElement.Load(sr);
                sr.Close();

                resultDTO.data = GetObjecTable(table, xmlTree);
                resultDTO.success = "true";
            }
            catch (Exception e)
            {
                DatabaseFactory.Logger.AddLog($"M52/{table}", e);
                //return NotFound();

                resultDTO.success = "false";
                resultDTO.error_code = e.Message;
                resultDTO.message = e.StackTrace;

                return Ok(resultDTO);
            }

            return Ok(resultDTO);
        }

        public List<object> GetObjecTable(string table, XElement xmlTree)
        {
            if (xmlTree?.Name.ToString() == "nb") throw new Exception(resourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture));

            List<object> lObjTable = default;

            if ((xmlTree != null) && (xmlTree.Elements().Any()))
            {
                lObjTable = new List<Object>();
                if (string.Compare(table, "VEHCOLORS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_VEHCOLORS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        VCOL_DESCLONG = o.Element(nameof(M52.M52DTO_VEHCOLORS.VCOL_DESCLONG))?.Value,
                        VCOL_DESCSHORT = o.Element(nameof(M52.M52DTO_VEHCOLORS.VCOL_DESCSHORT))?.Value,
                        VCOL_ID = o.Element(nameof(M52.M52DTO_VEHCOLORS.VCOL_ID))?.Value,
                        VCOL_VERSION = o.Element(nameof(M52.M52DTO_VEHCOLORS.VCOL_VERSION))?.Value
                    }));
                }
                else if (string.Compare(table, "VEHMODELS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_VEHMODELS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        VMOD_DESCLONG = o.Element(nameof(M52.M52DTO_VEHMODELS.VMOD_DESCLONG))?.Value,
                        VMOD_DESCSHORT = o.Element(nameof(M52.M52DTO_VEHMODELS.VMOD_DESCSHORT))?.Value,
                        VMOD_ID = o.Element(nameof(M52.M52DTO_VEHMODELS.VMOD_ID))?.Value,
                        VMOD_VERSION = o.Element(nameof(M52.M52DTO_VEHMODELS.VMOD_VERSION))?.Value,
                        VMOD_VMAN_ID = o.Element(nameof(M52.M52DTO_VEHMODELS.VMOD_VMAN_ID))?.Value
                    }));
                }
                else if (string.Compare(table, "GROUPS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_GROUPS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        GRP_ID = o.Element(nameof(M52.M52DTO_GROUPS.GRP_ID))?.Value,
                        GRP_VERSION = o.Element(nameof(M52.M52DTO_GROUPS.GRP_VERSION))?.Value,
                        GRP_DGRP_ID = o.Element(nameof(M52.M52DTO_GROUPS.GRP_DGRP_ID))?.Value,
                        GRP_DESCSHORT = o.Element(nameof(M52.M52DTO_GROUPS.GRP_DESCSHORT))?.Value,
                        GRP_DESCLONG = o.Element(nameof(M52.M52DTO_GROUPS.GRP_DESCLONG))?.Value,
                        //GRP_PATH = o.Element(nameof(M52.M52DTO_GROUPS.GRP_PATH))?.Value,
                        GRP_COLOUR = o.Element(nameof(M52.M52DTO_GROUPS.GRP_COLOUR))?.Value
                        //GRP_TYPETREE = o.Element(nameof(M52.M52DTO_GROUPS.GRP_TYPETREE))?.Value

                    }));
                }
                else if (string.Compare(table, "GROUPS_CHILDS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_GROUPS_CHILDS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        CGRP_UNIQUE_ID = o.Element(nameof(M52.M52DTO_GROUPS_CHILDS.CGRP_UNIQUE_ID))?.Value,
                        CGRP_VERSION = o.Element(nameof(M52.M52DTO_GROUPS_CHILDS.CGRP_VERSION))?.Value,
                        CGRP_ID = o.Element(nameof(M52.M52DTO_GROUPS_CHILDS.CGRP_ID))?.Value,
                        CGRP_TYPE = o.Element(nameof(M52.M52DTO_GROUPS_CHILDS.CGRP_TYPE))?.Value,
                        CGRP_CHILD = o.Element(nameof(M52.M52DTO_GROUPS_CHILDS.CGRP_CHILD))?.Value
                    }));
                }
                else if (string.Compare(table, "USERS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_USERS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        USR_ID = o.Element(nameof(M52.M52DTO_USERS.USR_ID))?.Value,
                        USR_VERSION = o.Element(nameof(M52.M52DTO_USERS.USR_VERSION))?.Value,
                        USR_NAME = o.Element(nameof(M52.M52DTO_USERS.USR_NAME))?.Value,
                        USR_SURNAME1 = o.Element(nameof(M52.M52DTO_USERS.USR_SURNAME1))?.Value,
                        USR_SURNAME2 = o.Element(nameof(M52.M52DTO_USERS.USR_SURNAME2))?.Value,
                        USR_ROL_ID = o.Element(nameof(M52.M52DTO_USERS.USR_ROL_ID))?.Value,
                        USR_LOGIN = o.Element(nameof(M52.M52DTO_USERS.USR_LOGIN))?.Value,
                        USR_LAN_ID = o.Element(nameof(M52.M52DTO_USERS.USR_LAN_ID))?.Value,
                        USR_STATUS = o.Element(nameof(M52.M52DTO_USERS.USR_STATUS))?.Value,
                        USR_PASSWORD = o.Element(nameof(M52.M52DTO_USERS.USR_PASSWORD))?.Value
                    }));
                }
                else if (string.Compare(table, "FINES_DEF", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_FINES_DEF()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        DFIN_ID = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_ID))?.Value,
                        DFIN_VERSION = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_VERSION))?.Value,
                        DFIN_CATEGORY = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_CATEGORY))?.Value,
                        DFIN_DESCSHORT = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_DESCSHORT))?.Value,
                        DFIN_DESCLONG = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_DESCLONG))?.Value,
                        DFIN_VALUE = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_VALUE))?.Value,
                        DFIN_STATUS = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_STATUS))?.Value,
                        DFIN_SIGN = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_SIGN))?.Value,
                        DFIN_PAYINPDM = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_PAYINPDM))?.Value,
                        DFIN_NUMTICKETS = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_NUMTICKETS))?.Value,
                        DFIN_POSTPAYABLE = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_POSTPAYABLE))?.Value,
                        DFIN_FINID_OFFSET = o.Element(nameof(M52.M52DTO_FINES_DEF.DFIN_FINID_OFFSET))?.Value
                    }));
                }
                else if (string.Compare(table, "STREETS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_STREETS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        STR_ID = o.Element(nameof(M52.M52DTO_STREETS.STR_ID))?.Value,
                        STR_VERSION = o.Element(nameof(M52.M52DTO_STREETS.STR_VERSION))?.Value,
                        STR_DESC = o.Element(nameof(M52.M52DTO_STREETS.STR_DESC))?.Value,
                        STR_MIN = o.Element(nameof(M52.M52DTO_STREETS.STR_MIN))?.Value,
                        STR_MAX = o.Element(nameof(M52.M52DTO_STREETS.STR_MAX))?.Value,
                        STR_PROVINCIA = o.Element(nameof(M52.M52DTO_STREETS.STR_PROVINCIA))?.Value,
                        STR_MUNICIPIO = o.Element(nameof(M52.M52DTO_STREETS.STR_MUNICIPIO))?.Value,
                        STR_TIPOVIA = o.Element(nameof(M52.M52DTO_STREETS.STR_TIPOVIA))?.Value
                    }));
                }
                else if (string.Compare(table, "VEHMANUFACTURERS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_VEHMANUFACTURERS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        VMAN_ID = o.Element(nameof(M52.M52DTO_VEHMANUFACTURERS.VMAN_ID))?.Value,
                        VMAN_VERSION = o.Element(nameof(M52.M52DTO_VEHMANUFACTURERS.VMAN_VERSION))?.Value,
                        VMAN_DESCSHORT = o.Element(nameof(M52.M52DTO_VEHMANUFACTURERS.VMAN_DESCSHORT))?.Value,
                        VMAN_DESCLONG = o.Element(nameof(M52.M52DTO_VEHMANUFACTURERS.VMAN_DESCLONG))?.Value
                    }));
                }
                else if (string.Compare(table, "STREETS_STRETCHS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_STREETS_STRETCHS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        SS_ID = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_ID))?.Value,
                        SS_VERSION = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_VERSION))?.Value,
                        SS_GRP_ID = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_GRP_ID))?.Value,
                        SS_STR_ID = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_STR_ID))?.Value,
                        SS_STR_SS_ID = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_STR_SS_ID))?.Value,
                        SS_EVEN = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_EVEN))?.Value,
                        SS_STR_ID_DESDE = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_STR_ID_DESDE))?.Value,
                        SS_STR_ID_HASTA = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_STR_ID_HASTA))?.Value,
                        SS_DESC = o.Element(nameof(M52.M52DTO_STREETS_STRETCHS.SS_DESC))?.Value
                    }));
                }
                else if (string.Compare(table, "WORKS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_WORKS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        WORK_PDA_ID = o.Element(nameof(M52.M52DTO_WORKS.WORK_PDA_ID))?.Value,
                        WORK_VERSION = o.Element(nameof(M52.M52DTO_WORKS.WORK_VERSION))?.Value,
                        WORK_ID = o.Element(nameof(M52.M52DTO_WORKS.WORK_ID))?.Value,
                        WORK_SS_ID = o.Element(nameof(M52.M52DTO_WORKS.WORK_SS_ID))?.Value,
                        WORK_USR_ID = o.Element(nameof(M52.M52DTO_WORKS.WORK_USR_ID))?.Value,
                        WORK_UNI_ID = o.Element(nameof(M52.M52DTO_WORKS.WORK_UNI_ID))?.Value,
                        WORK_NUM_PARK_SPACES = o.Element(nameof(M52.M52DTO_WORKS.WORK_NUM_PARK_SPACES))?.Value,
                        WORK_REMARKS = o.Element(nameof(M52.M52DTO_WORKS.WORK_REMARKS))?.Value,
                        WORK_LICEN_NUMBER = o.Element(nameof(M52.M52DTO_WORKS.WORK_LICEN_NUMBER))?.Value,
                        WORK_LICEN_CORP = o.Element(nameof(M52.M52DTO_WORKS.WORK_LICEN_CORP))?.Value,
                        WORK_INI_DATE = o.Element(nameof(M52.M52DTO_WORKS.WORK_INI_DATE))?.Value,
                        WORK_END_DATE = o.Element(nameof(M52.M52DTO_WORKS.WORK_END_DATE))?.Value
                    }));
                }
                else if (string.Compare(table, "RESIDENTS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_RESIDENTS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        RES_ID = o.Element(nameof(M52.M52DTO_RESIDENTS.RES_ID))?.Value,
                        RES_VERSION = o.Element(nameof(M52.M52DTO_RESIDENTS.RES_VERSION))?.Value,
                        RES_VEHICLEID = o.Element(nameof(M52.M52DTO_RESIDENTS.RES_VEHICLEID))?.Value,
                        RES_GRP_ID = o.Element(nameof(M52.M52DTO_RESIDENTS.RES_GRP_ID))?.Value,
                        RES_DART_ID = o.Element(nameof(M52.M52DTO_RESIDENTS.RES_DART_ID))?.Value
                    }));
                }
                else if (string.Compare(table, "VIPS", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_VIPS()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_VEHMODELS.OP_TYPE))?.Value,
                        VIP_ID = o.Element(nameof(M52.M52DTO_VIPS.VIP_ID))?.Value,
                        VIP_VERSION = o.Element(nameof(M52.M52DTO_VIPS.VIP_VERSION))?.Value,
                        VIP_VEHICLEID = o.Element(nameof(M52.M52DTO_VIPS.VIP_VEHICLEID))?.Value,
                        VIP_GRP_ID = o.Element(nameof(M52.M52DTO_VIPS.VIP_GRP_ID))?.Value,
                        VIP_DART_ID = o.Element(nameof(M52.M52DTO_VIPS.VIP_DART_ID))?.Value,
                        VIP_TEXT = o.Element(nameof(M52.M52DTO_VIPS.VIP_TEXT))?.Value,
                        VIP_DAYOFWEEK = o.Element(nameof(M52.M52DTO_VIPS.VIP_DAYOFWEEK))?.Value,
                        VIP_INIHOUR = o.Element(nameof(M52.M52DTO_VIPS.VIP_INIHOUR))?.Value,
                        VIP_INIMINUTE = o.Element(nameof(M52.M52DTO_VIPS.VIP_INIMINUTE))?.Value,
                        VIP_ENDHOUR = o.Element(nameof(M52.M52DTO_VIPS.VIP_ENDHOUR))?.Value,
                        VIP_ENDMINUTE = o.Element(nameof(M52.M52DTO_VIPS.VIP_ENDMINUTE))?.Value,
                        VIP_INIDATE = o.Element(nameof(M52.M52DTO_VIPS.VIP_INIDATE))?.Value,
                        VIP_ENDDATE = o.Element(nameof(M52.M52DTO_VIPS.VIP_ENDDATE))?.Value
                    }));
                }
                else if (string.Compare(table, "GROUPS_PDA", true, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    xmlTree.Elements().ToList().ForEach(o => lObjTable.Add(new M52.M52DTO_GROUPS_PDA()
                    {
                        OP_TYPE = o.Element(nameof(M52.M52DTO_GROUPS_PDA.OP_TYPE))?.Value,
                        GPDA_VERSION = o.Element(nameof(M52.M52DTO_GROUPS_PDA.GPDA_VERSION))?.Value,
                        GPDA_ID = o.Element(nameof(M52.M52DTO_GROUPS_PDA.GPDA_ID))?.Value,
                        GPDA_GRP_ID = o.Element(nameof(M52.M52DTO_GROUPS_PDA.GPDA_GRP_ID))?.Value,
                        GPDA_GRP_ID_CHILD = o.Element(nameof(M52.M52DTO_GROUPS_PDA.GPDA_GRP_ID_CHILD))?.Value,
                        GPDA_DESC = o.Element(nameof(M52.M52DTO_GROUPS_PDA.GPDA_DESC))?.Value                        
                    }));
                }
            }

            return lObjTable;
        }
    }
}