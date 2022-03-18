using OPS.Components.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Routing;

namespace API_Vigilancia
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        log4net.ILog log = log4net.LogManager.GetLogger("root.API_Vigilancia");

        //private System.Resources.ResourceManager resourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));
        //public System.Resources.ResourceManager ResourceManagerAPIVigilancia { get; set; }

        //protected void Application_Start()
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //DatabaseFactory.Logger = new OPS.Comm.Logger(log4net.LogManager.GetLogger("root.API_Vigilancia"));
            DatabaseFactory.Logger = new OPS.Comm.Logger(log);
            log4net.Config.XmlConfigurator.Configure();

            

        //ResourceManagerAPIVigilancia = new ResourceManager(typeof(Resources));
        //    //string s = rm.GetString("Error_OPSNET", new System.Globalization.CultureInfo("es-es"));
        //    string s = ResourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture);

            //Console.WriteLine(s);
            //#if DEBUG
            //try {int Num = Int16.Parse("A");} catch (Exception e) { DatabaseFactory.Logger.AddLog(e); }
            //log4net.Config.XmlConfigurator.Configure(); //Inicio del Logger.
            //log.Info("KAIXO-2");

            //IHttpActionResult result = SimularPeticion();
            //DatabaseFactory.Logger.AddLog(result.ToString(), OPS.Comm.LoggerSeverities.Debug);
            //#endif
        }

        //#if DEBUG
        //        public Boolean Conexion()
        //        {
        //            try
        //            {
        //                //OPSMessages.
        //                //string Data_Source = "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = host.docker.internal)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl.docker.internal)))";
        //                //string oradb2 = $"User ID=opsiurreta;Password=opsiurreta; Persist Security Info=True; Data Source={Data_Source};";
        //                //oradb2 = "User Id=opsiurreta;Password=opsiurreta; Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = host.docker.internal)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl.docker.internal)))";

        //                string strConnString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
        //                OracleConnection conn = new OracleConnection(strConnString);
        //                conn.Open();

        //                string sql = "select * FROM alarms_def"; // C#
        //                OracleCommand cmd = new OracleCommand(sql, conn);

        //                OracleDataReader dr = cmd.ExecuteReader(); // C#
        //                dr.Read();
        //                return true;
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine($"{e}{Environment.NewLine}{e.StackTrace}");
        //                return false;
        //            }
        //        }

        //        //public IHttpActionResult SimularPeticion()
        //        //{
        //        //    API_Vigilancia.Controllers.M52Controller m52 = new API_Vigilancia.Controllers.M52Controller();

        //        //    IHttpActionResult result = m52.GetAll();

        //        //    return result;
        //        //}
        //#endif
    }

    //public class ApiResponse: WebApiApplication
    //{
    //      bool SiNo()
    //    {
    //        System.Resources.ResourceManager ResourceManagerAPIVigilancia2 = ResourceManagerAPIVigilancia;

    //        string s = ResourceManagerAPIVigilancia.GetString("Error_OPSNET", System.Threading.Thread.CurrentThread.CurrentCulture);
    //        return true;
    //    }
        
    //}
}