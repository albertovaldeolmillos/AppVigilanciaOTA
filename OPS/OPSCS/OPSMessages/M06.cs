using System;
using System.Collections.Specialized;
using System.Xml;
using System.Globalization;
using OPS.Components.Data;
using OPS.Comm;
using OPS.FineLib;
using System.Collections;
using CS_OPS_TesM1;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;



namespace OPS.Comm.Becs.Messages
{
	/// <summary>
	/// Class to handle de m6 message.
	/// </summary>
	public sealed class Msg06 : MsgReceived, IRecvMessage
	{
		#region DefinedRootTag (m6)
		#region Static stuff

		/// <summary>
		/// Init the static variables reading the configuration file
		/// </summary>
		static Msg06()
		{
		}

		#endregion

		/// <summary>
		/// Returns the root tag that each type of message must have.
		/// That method MUST be defined on each class, althought is not defined in any interface or base class
		/// </summary>
		public static string DefinedRootTag { get { return "m6"; } }
		#endregion

		#region Static stuff

		private static int CCT_TRANS_PENDING = 10;
		private static int CCT_TRANS_CONFIRMED = 20;
		private static int CCT_TRANS_CANCELLED = 30;

		#endregion

		#region Variables, creation and parsing

		private int			_unit;
		private DateTime	_date;
		private int _MessageNumber;
		private int _MessageType;
		private string _Message	= "";

		/// <summary>
		/// Constructs a new msg06 with the data of the message.
		/// </summary>
		/// <param name="msgXml">XML Document with the message</param>
		public Msg06(XmlDocument msgXml) : base(msgXml) {}

		protected override void DoParseMessage()
		{
			CultureInfo culture = new CultureInfo("", false);

			foreach (XmlNode n in _root.ChildNodes)
			{
				switch (n.Name)
				{
					case "u": _unit = Convert.ToInt32(n.InnerText); break;
					case "d": _date = OPS.Comm.Dtx.StringToDtx(n.InnerText); break;
					case "n": _MessageNumber = Convert.ToInt32(n.InnerText); break;
					case "t": _MessageType = Convert.ToInt32(n.InnerText); break;
					case "m":	_Message		= n.InnerText;									
						break;


				}
			}
		}

		#endregion

		#region IRecvMessage Members

		/// <summary>
		/// Inserts a new register in the OPERATIONS table, and if everything is succesful sends an ACK_PROCESSED
		/// </summary>
		/// <returns>Message to send back to the sender</returns>
		public System.Collections.Specialized.StringCollection Process()
		{
			StringCollection res=null;
			OracleConnection oraDBConn=null;
			OracleCommand oraCmd=null;
			ILogger logger = null;


			try
			{
				Database d = OPS.Components.Data.DatabaseFactory.GetDatabase ();
				logger = DatabaseFactory.Logger;
				System.Data.IDbConnection DBCon=d.GetNewConnection();
				oraDBConn = (OracleConnection)DBCon;
				oraDBConn.Open();

				if (oraDBConn.State == System.Data.ConnectionState.Open)
				{

					if(logger != null)
						logger.AddLog(string.Format("[Msg6:Process]: insert into MSGS_TEXT  "+
							"(MSTE_DATE, MSTE_UNIT, MSTE_NUMBER, MSTE_TYPE, MSTE_TEXT) values "+
							"(TO_DATE('{0}','HH24MISSDDMMYY'),{1},{2},{3},'{4}')",
							OPS.Comm.Dtx.DtxToString(_date),
							_unit,
							_MessageNumber,
							_MessageType,
							_Message),				
							LoggerSeverities.Debug);

					oraCmd= new OracleCommand();
					oraCmd.Connection=(OracleConnection)oraDBConn;
					oraCmd.CommandText=string.Format("insert into MSGS_TEXT  "+
						"(MSTE_DATE, MSTE_UNIT, MSTE_NUMBER, MSTE_TYPE, MSTE_TEXT) values "+
						"(TO_DATE('{0}','HH24MISSDDMMYY'),{1},{2},{3},'{4}')",
						OPS.Comm.Dtx.DtxToString(_date),
						_unit,
						_MessageNumber,
						_MessageType,
						_Message);
				

					oraCmd.ExecuteNonQuery();

					res = ReturnAck(AckMessage.AckTypes.ACK_PROCESSED);

				}

				// Special processing for EMV credit cards
				if (_Message.IndexOf("ti:") >= 0)
				{
					string strTransId = "";
					string strTransRef = "";
					string strTransDate = "";
					string strTransTime = "";
					string strTransTerm = "";
					string strCompanyId = "";
					string strCenterId = "";

					string[] strTagList = _Message.Split(new char[] { ';' });
					foreach (string strTag in strTagList)
					{
						string[] strTagDataList = strTag.Split(new char[] { ':' });

						switch (strTagDataList[0])
						{
							case "ti":
								strTransTerm = strTagDataList[1];
								break;
							case "td":
								strTransDate = strTagDataList[1];
								break;
							case "tt":
								strTransTime = strTagDataList[1];
								break;
							case "tr":
								strTransRef = strTagDataList[1];
								break;
							case "tri":
								strTransId = strTagDataList[1];
								break;
							case "tc":
								strCompanyId = strTagDataList[1];
								break;
							case "tce":
								strCenterId = strTagDataList[1];
								break;
						}
					}

					if (strTransId.Length > 0 && strTransRef.Length > 0)
					{
						if (oraDBConn.State == System.Data.ConnectionState.Open)
						{
							// First check to see if M2 already arrived
							CmpCreditCardsTransactionsDB cmpCreditCardsTransactionsDB = new CmpCreditCardsTransactionsDB();
							int iCCTId = cmpCreditCardsTransactionsDB.ExistTransaction(strTransId, strTransRef, _unit);

							// Existing transaction is found
							if (iCCTId > 0)
							{
								if (logger != null)
									logger.AddLog(string.Format("[Msg6:Process]: update CREDIT_CARDS_TRANSACTIONS set " +
										"CCT_REFERENCE = '{0}', CCT_DATE = '{1}', CCT_TIME = '{2}', CCT_TERMINAL = '{3}', CCT_COMPANY = '{4}', CCT_CENTER = '{5}' " +
										"WHERE CCT_ID = {6}",
										strTransRef,
										strTransDate,
										strTransTime,
										strTransTerm,
										strCompanyId,
										strCenterId,
										iCCTId),
										LoggerSeverities.Debug);

								oraCmd = new OracleCommand();
								oraCmd.Connection = (OracleConnection)oraDBConn;
								oraCmd.CommandText = string.Format("update CREDIT_CARDS_TRANSACTIONS set " +
									"CCT_REFERENCE = '{0}', CCT_DATE = '{1}', CCT_TIME = '{2}', CCT_TERMINAL = '{3}', CCT_COMPANY = '{4}', CCT_CENTER = '{5}' " +
									"WHERE CCT_ID = {6}",
									strTransRef,
									strTransDate,
									strTransTime,
									strTransTerm,
									strCompanyId,
									strCenterId,
									iCCTId);

								oraCmd.ExecuteNonQuery();

								res = ReturnAck(AckMessage.AckTypes.ACK_PROCESSED);
							}
							else
							{
								if (logger != null)
									logger.AddLog(string.Format("[Msg6:Process]: insert into CREDIT_CARDS_TRANSACTIONS " +
										"(CCT_TRANS_ID, CCT_REFERENCE, CCT_DATE, CCT_TIME, CCT_TERMINAL, CCT_STATE, CCT_UNI_ID, CCT_COMPANY, CCT_CENTER) values " +
										"{0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}')",
										strTransId,
										strTransRef,
										strTransDate,
										strTransTime,
										strTransTerm,
										CCT_TRANS_PENDING,
										_unit,
										strCompanyId,
										strCenterId),
										LoggerSeverities.Debug);

								oraCmd = new OracleCommand();
								oraCmd.Connection = (OracleConnection)oraDBConn;
								oraCmd.CommandText = string.Format("insert into CREDIT_CARDS_TRANSACTIONS " +
									"(CCT_TRANS_ID, CCT_REFERENCE, CCT_DATE, CCT_TIME, CCT_TERMINAL, CCT_STATE, CCT_UNI_ID, CCT_COMPANY, CCT_CENTER, CCT_INS_DATE, CCT_STATE_DATE) values " +
									"('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',(TO_DATE('{9}','HH24MISSDDMMYY')),(TO_DATE('{10}','HH24MISSDDMMYY')))",
									strTransId,
									strTransRef,
									strTransDate,
									strTransTime,
									strTransTerm,
									CCT_TRANS_PENDING,
									_unit,
									strCompanyId,
									strCenterId,
									OPS.Comm.Dtx.DtxToString(_date),
									OPS.Comm.Dtx.DtxToString(_date));

								oraCmd.ExecuteNonQuery();

								res = ReturnAck(AckMessage.AckTypes.ACK_PROCESSED);
							}
						}

					}
				}
			}
			catch(Exception e)
			{
				if(logger != null)
					logger.AddLog("[Msg6:Process]: Error: "+e.Message,LoggerSeverities.Error);
				res = ReturnNack(NackMessage.NackTypes.NACK_ERROR_BECS);
			}
			finally
			{

				if (oraCmd!=null)
				{
					oraCmd.Dispose();
					oraCmd = null;
				}


				if (oraDBConn!=null)
				{
					oraDBConn.Close();
					oraDBConn.Dispose();
					oraDBConn = null;
				}

			}

			return res;
		}


		#endregion
	}
}
