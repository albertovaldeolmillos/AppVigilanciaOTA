using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using API_Vigilancia.Models;
using System.Resources;
using API_Vigilancia.Properties;

using OPS.Components.Data;

namespace API_Vigilancia.Controllers
{
    public class M54Controller : ApiController
    {
        private readonly System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));

        [System.Web.Http.Route("M54")]
        public IHttpActionResult GetM54()
        {
            M54.ResponseDTO resultDTO = new M54.ResponseDTO();
            try
            {
                TextReader sr = new StringReader(new M54().Process()[0]);
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

                xmlTree.Elements().ToList().ForEach(o => lObjDTO.Add(new M54.M54DTO()
                {
                    //t = DateTime.Parse(o.FirstNode.ToString()).ToString(ConfigurationManager.AppSettings["DateFormat_OTS"])
                    //t = DateTime.Parse(o.FirstNode.ToString())
                }));
            }
            return lObjDTO;
        }

    }
}
