using API_Vigilancia.Models;
using OPS.Components.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

using System.Resources;
using API_Vigilancia.Properties;

namespace API_Vigilancia.Controllers
{
    public class M53Controller : ApiController
    {
        private readonly System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));

        [HttpPost]
        //[System.Web.Http.Route("M53/{fineId}")]
        public IHttpActionResult GetM53([FromBody] M53.M53DTO_Request m53DTO)
        {
            //public IHttpActionResult GetM53([FromBody] string text)
            //public IHttpActionResult GetM53(HttpRequest request)
            //var txt = m53DTO;
            string xml = default;
            M53.ResponseDTO resultDTO = new M53.ResponseDTO();
            try
            {

                //System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Resources", typeof(API_Vigilancia).Assembly);
                //System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(WebApiApplication).Assembly);
                //System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(Resources));

                //string s = rm.GetString("Error_OPSNET", new System.Globalization.CultureInfo("es-es"));
                //string s = resourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture);

                if (m53DTO != null)
                {
                    xml = $"<m53>" +
                    $"{(string.IsNullOrWhiteSpace(m53DTO.f) ? string.Empty : $"<f>{m53DTO.f}</f>")} " + //FIN_ID
                    $"{(string.IsNullOrWhiteSpace(m53DTO.y) ? string.Empty : $"<y>{m53DTO.y}</y>")}" + //FIN_DFIN_ID
                    $"{(string.IsNullOrWhiteSpace(m53DTO.m) ? string.Empty : $"<m>{m53DTO.m}</m>")}" + //FIN_VEHICLEID
                    $"{(string.IsNullOrWhiteSpace(m53DTO.j) ? string.Empty : $"<j>{m53DTO.j}</j>")}" + //FIN_MODEL
                    $"{(string.IsNullOrWhiteSpace(m53DTO.k) ? string.Empty : $"<k>{m53DTO.k}</k>")}" + //FIN_MANUFACTURER
                    $"{(string.IsNullOrWhiteSpace(m53DTO.l) ? string.Empty : $"<l>{m53DTO.l}</l>")}" + //FIN_MANUFACTURER
                    $"{(string.IsNullOrWhiteSpace(m53DTO.r) ? string.Empty : $"<r>{m53DTO.r}</r>")}" + //FIN_GRP_ID_ROUTE
                    $"{(string.IsNullOrWhiteSpace(m53DTO.g) ? string.Empty : $"<g>{m53DTO.g}</g>")}" + //FIN_GRP_ID_ZONE
                    $"{(string.IsNullOrWhiteSpace(m53DTO.w) ? string.Empty : $"<w>{m53DTO.w}</w>")}" + //FIN_STR_ID
                    $"{(string.IsNullOrWhiteSpace(m53DTO.n) ? string.Empty : $"<n>{m53DTO.n}</n>")}" + //FIN_STRNUMBER
                    $"{(string.IsNullOrWhiteSpace(m53DTO.p) ? string.Empty : $"<p>{m53DTO.p}</p>")}" + //FIN_POSITION
                    $"{(string.IsNullOrWhiteSpace(m53DTO.e) ? string.Empty : $"<e>{m53DTO.e}</e>")}" + //FIN_COMMENTS
                    $"{(string.IsNullOrWhiteSpace(m53DTO.d) ? string.Empty : $"<d>{m53DTO.d}</d>")}" + //FIN_DATE
                    $"{(string.IsNullOrWhiteSpace(m53DTO.u) ? string.Empty : $"<u>{m53DTO.u}</u>")}" + //FIN_UNI_ID
                    $"{(string.IsNullOrWhiteSpace(m53DTO.z) ? string.Empty : $"<z>{m53DTO.z}</z>")}" + //FIN_USR_ID
                    $"{(string.IsNullOrWhiteSpace(m53DTO.nl) ? string.Empty : $"<nl>{m53DTO.nl}</nl>")}" + //FIN_LETTER
                    $"{(string.IsNullOrWhiteSpace(m53DTO.s) ? string.Empty : $"<s>{m53DTO.s}</s>")}" + //FIN_STATUS
                    $"{(string.IsNullOrWhiteSpace(m53DTO.lt) ? string.Empty : $"<lt>{m53DTO.lt}</lt>")}" +
                    $"{(string.IsNullOrWhiteSpace(m53DTO.lg) ? string.Empty : $"<lg>{m53DTO.lg}</lg>")}" +
                    $"</m53>";
                }
                XmlDocument msgXml = new XmlDocument() { XmlResolver = null };
                System.IO.StringReader sreader = new System.IO.StringReader(xml);
                XmlReader reader = XmlReader.Create(sreader, new XmlReaderSettings() { XmlResolver = null });
                msgXml.Load(reader);
                reader.Dispose();

                //#if DEBUG
                //                M53 m53 = new M53(msgXml);
                //                StringCollection sc = m53.Process();
                //                TextReader sr = new StringReader(sc[0]);
                //                //TextReader sr = new StringReader(new M53(msgXml).Process()[0]);
                //#else
                TextReader sr = new StringReader(new M53(msgXml).Process()[0]);
                //#endif
                //if (sr.ToString().Substring(1, 2) == "nb")
                //{
                //    throw new Exception("Error");
                //}

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
                throw;
            }
            finally
            {

            }

            return Ok(resultDTO);
        }

        //// PUT: api/TodoItems/5
        //[HttpPost("53/{id}")]
        //public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        //{ 

        //}

        //// POST: api/TodoItems
        //[HttpPost]
        //public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        //{
        //    _context.TodoItems.Add(todoItem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        //}


        public List<Object> GetDTO(XElement xmlTree)
        {
            if (xmlTree?.Name.ToString() == "nb") throw new Exception(resourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture));

            List<Object> lObjDTO = default;
            if ((xmlTree != null) && (xmlTree.Elements().Any()))
            {
                lObjDTO = new List<Object>();
                xmlTree.Elements().ToList().ForEach(o => lObjDTO.Add(new M53.M53DTO()
                {
                    r = o.FirstNode.ToString()
                }));
            }
            return lObjDTO;
        }
    }
}
