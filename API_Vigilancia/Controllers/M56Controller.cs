using API_Vigilancia.Models;
using OPS.Components.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

using System.Resources;
using API_Vigilancia.Properties;


namespace API_Vigilancia.Controllers
{
    public class M56Controller : ApiController
    {
        private readonly System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));

        [System.Web.Http.Route("M56")]
        public IHttpActionResult GetM56()
        {
            M56.ResponseDTO resultDTO = new M56.ResponseDTO();
            try
            {
                TextReader sr = new StringReader(new M56().Process()[0]);
                XElement xmlTree = XElement.Load(sr);
                sr.Close();
//#if DEBUG
//                DatabaseFactory.Logger.AddLog(xmlTree.ToString(), OPS.Comm.LoggerSeverities.Debug);
//#endif
                resultDTO.data = GetDTO(xmlTree);
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

                xmlTree.Elements().ToList().ForEach(o => lObjDTO.Add(new M56.M56DTO()
                {
                    //t = DateTime.Parse(o.FirstNode.ToString()).ToString(ConfigurationManager.AppSettings["DateFormat_OTS"])
                    //t = DateTime.Parse(o.FirstNode.ToString())
                }));
            }
            return lObjDTO;
        }

    }
}
