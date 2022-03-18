using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;
using API_Vigilancia.Models;
using OPS.Components.Data;

using System.Resources;
using API_Vigilancia.Properties;


namespace API_Vigilancia.Controllers
{
    public class M50Controller : ApiController
    {
        private readonly System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));

        // M50[] m50 = new M50[]
        //{
        //     new M50 { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
        //     new M50 { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
        //     new M50 { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        //};

        //public async System.Threading.Tasks.Task<IEnumerable<M50>> GetAllProductsAsync()
        //{
        //    var body2 = await Request.Content.ReadAsStringAsync(); // body will be "".
        //    return m50;
        //}

        //public IEnumerable<M50> GetAllProducts_X()
        //{

        //    string body = Request.Content.ReadAsStringAsync().Result; // body will be "".

        //    return m50;
        //}

        //public M50 GetAllProducts_X()
        //{

        //    string body = Request.Content.ReadAsStringAsync().Result; // body will be "".

        //    //string response = ""; //"{""enforce_out"":{""r"":1,""d"":""120000220119"",""rein"":0,""vip":0,""resi"":1,""bl"":0}}"
        //    M50 r_out = new M50 { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 };


        //    return r_out;
        //}
        [System.Web.Http.Route("M50/{unitId}/{FechaHora}/{plate}/{groupId}")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<pendiente>")]
        public IHttpActionResult GetPlateStatus(int unitId, string FechaHora, string plate, int groupId) 
        {
            //#if DEBUG
            //            FechaHora = DateTime.Now.ToString(ConfigurationManager.AppSettings["DateFormat_OTS"]);
            // //<m50 id="14"><d>124936021120</d><m>0000AAA</m><g>60001</g><u>2000</u></m50>
            //#endif
            M50.ResponseDTO resultDTO = new M50.ResponseDTO();
            try
            {
//#if DEBUG
//                //XmlDocument msgXml = new XmlDocument();
//                ////msgXml.LoadXml("<m50 id=\"14\"><d>124936021120</d><m>0000AAA</m><g>60001</g><u>2000</u></m50>");
//                //msgXml.LoadXml($"<m50 id=\"14\"><d>{FechaHora}</d><m>{plate}</m><g>{groupId}</g><u>{unitId}</u></m50>");

//                //M50 m50 = new M50(msgXml);
//                //StringCollection sc = m50.Process();
//                //TextReader sr = new StringReader(sc[0]);

//                //XElement xmlTree = XElement.Load(sr);
//                //sr.Close();

//                /****************************************************************/
//                M50 m50 = new M50()
//                {
//                    _unitId = unitId,
//                    _date = DateTime.ParseExact(FechaHora, ConfigurationManager.AppSettings["DateFormat_OTS"], System.Globalization.CultureInfo.InvariantCulture),
//                    _vehicleId = plate,
//                    _groupId = groupId
//                };

//                TextReader sr = new StringReader(m50.Process()[0]);
//                XElement xmlTree = XElement.Load(sr);
//                sr.Close();

//                DatabaseFactory.Logger.AddLog($"XElement: {xmlTree.ToString()}", OPS.Comm.LoggerSeverities.Debug);
//#else
                TextReader sr = new StringReader(new M50()
                {
                    _unitId = unitId,
                    _date = DateTime.ParseExact(FechaHora, ConfigurationManager.AppSettings["DateFormat_OTS"], System.Globalization.CultureInfo.InvariantCulture),
                    _vehicleId = plate,
                    _groupId = groupId
                }.Process()[0]);

                XElement xmlTree = XElement.Load(sr);
                sr.Close();
//#endif
                resultDTO.data = GetDTO(xmlTree);
                resultDTO.success = "true";
            }
            catch (Exception e)
            {
                DatabaseFactory.Logger.AddLog(e);
                //return NotFound();

                resultDTO.success = "false";
                resultDTO.error_code = e.Message;
                resultDTO.message = e.StackTrace;

                return Ok(resultDTO);
            }

            return Ok(resultDTO);
        }

        public List<object> GetDTO(XElement xmlTree) 
        {
            if (xmlTree?.Name.ToString() == "nb") throw new Exception(resourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture));

            List<object> lObjDTO = default;

            if ((xmlTree != null) && (xmlTree.Elements().Any()))
            {
                lObjDTO = new List<Object>();
                lObjDTO.Add(new M50.M50DTO()
                {
                    r = xmlTree.Element(nameof(M50.M50DTO.r))?.Value,
                    bl = xmlTree.Element(nameof(M50.M50DTO.bl))?.Value,
                    d = xmlTree.Element(nameof(M50.M50DTO.d))?.Value,
                    rein = xmlTree.Element(nameof(M50.M50DTO.rein))?.Value,
                    resi = xmlTree.Element(nameof(M50.M50DTO.resi))?.Value,
                    vip = xmlTree.Element(nameof(M50.M50DTO.vip))?.Value,
                    tick = xmlTree.Element(nameof(M50.M50DTO.tick))?.Value
                });
            }
            return lObjDTO;
        }       
    }
}