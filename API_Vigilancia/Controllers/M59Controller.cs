using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml.Linq;
using System.Web.Http;
using API_Vigilancia.Models;
using OPS.Components.Data;
using System.Configuration;

using System.Resources;
using API_Vigilancia.Properties;

namespace API_Vigilancia.Controllers
{
    public class M59Controller : ApiController
    {
        private readonly System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));

        [System.Web.Http.Route("M59")]
        public IHttpActionResult GetM59()
        {
            M59.ResponseDTO resultDTO = new M59.ResponseDTO();
            try
            {
                TextReader sr = new StringReader(new M59().Process()[0]);
                XElement xmlTree = XElement.Load(sr);
                sr.Close();
//#if DEBUG
//                DatabaseFactory.Logger.AddLog(Environment.NewLine + xmlTree.ToString(), OPS.Comm.LoggerSeverities.Debug);
//#endif
                resultDTO.data = GetDTO(xmlTree);
                resultDTO.message = $"DateTime {ConfigurationManager.AppSettings["DateFormat_OTS"]} ";
                resultDTO.success = "true";
            }
            catch (Exception e) 
            {
                DatabaseFactory.Logger.AddLog(e);

                resultDTO.success = "false";
                resultDTO.error_code = e.Message;
                resultDTO.message = e.StackTrace;

                //return NotFound();
                return Ok(resultDTO);
                throw;
            }

                return Ok(resultDTO);
        }

        public List<Object> GetDTO(XElement xmlTree)
        {
            if (xmlTree?.Name.ToString() == "nb") throw new Exception(resourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture));

            List<Object> lObjDTO = default;

            if (xmlTree.Elements().Any())
            {
                lObjDTO = new List<Object>();

                xmlTree.Elements().ToList().ForEach(o => lObjDTO.Add(new M59.M59DTO()
                {
                    t = DateTime.Parse(o.FirstNode.ToString(), System.Threading.Thread.CurrentThread.CurrentCulture).ToString(ConfigurationManager.AppSettings["DateFormat_OTS"], System.Threading.Thread.CurrentThread.CurrentCulture)
                }));
            }
            return lObjDTO;
        }
    }
}
