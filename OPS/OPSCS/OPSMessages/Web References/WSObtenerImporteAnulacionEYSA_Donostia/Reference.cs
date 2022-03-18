﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace OPSMessages.WSObtenerImporteAnulacionEYSA_Donostia {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AnulacionesSoap", Namespace="http://tempuri.org/")]
    public partial class Anulaciones : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private ConsolaSoapHeader consolaSoapHeaderValueField;
        
        private System.Threading.SendOrPostCallback UploadOperationCompleted;
        
        private System.Threading.SendOrPostCallback EsExpedienteAnulableOperationCompleted;
        
        private System.Threading.SendOrPostCallback EsExpedienteAnulableConCuantiaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Anulaciones() {
            this.Url = global::OPSMessages.Properties.Settings.Default.OPS_Messages_1_2_1_1_WSObtenerImporteAnulacionEYSA_Donostia_Anulaciones;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public ConsolaSoapHeader ConsolaSoapHeaderValue {
            get {
                return this.consolaSoapHeaderValueField;
            }
            set {
                this.consolaSoapHeaderValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event UploadCompletedEventHandler UploadCompleted;
        
        /// <remarks/>
        public event EsExpedienteAnulableCompletedEventHandler EsExpedienteAnulableCompleted;
        
        /// <remarks/>
        public event EsExpedienteAnulableConCuantiaCompletedEventHandler EsExpedienteAnulableConCuantiaCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("ConsolaSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Upload", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Upload(string deviceCode, string parkCode, System.DateTime pndDate, string plateNumber, short fineStatus, string numTicket) {
            object[] results = this.Invoke("Upload", new object[] {
                        deviceCode,
                        parkCode,
                        pndDate,
                        plateNumber,
                        fineStatus,
                        numTicket});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpload(string deviceCode, string parkCode, System.DateTime pndDate, string plateNumber, short fineStatus, string numTicket, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Upload", new object[] {
                        deviceCode,
                        parkCode,
                        pndDate,
                        plateNumber,
                        fineStatus,
                        numTicket}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndUpload(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UploadAsync(string deviceCode, string parkCode, System.DateTime pndDate, string plateNumber, short fineStatus, string numTicket) {
            this.UploadAsync(deviceCode, parkCode, pndDate, plateNumber, fineStatus, numTicket, null);
        }
        
        /// <remarks/>
        public void UploadAsync(string deviceCode, string parkCode, System.DateTime pndDate, string plateNumber, short fineStatus, string numTicket, object userState) {
            if ((this.UploadOperationCompleted == null)) {
                this.UploadOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadOperationCompleted);
            }
            this.InvokeAsync("Upload", new object[] {
                        deviceCode,
                        parkCode,
                        pndDate,
                        plateNumber,
                        fineStatus,
                        numTicket}, this.UploadOperationCompleted, userState);
        }
        
        private void OnUploadOperationCompleted(object arg) {
            if ((this.UploadCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadCompleted(this, new UploadCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("ConsolaSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EsExpedienteAnulable", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int EsExpedienteAnulable(string expediente, System.DateTime fechaParquimetro) {
            object[] results = this.Invoke("EsExpedienteAnulable", new object[] {
                        expediente,
                        fechaParquimetro});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginEsExpedienteAnulable(string expediente, System.DateTime fechaParquimetro, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("EsExpedienteAnulable", new object[] {
                        expediente,
                        fechaParquimetro}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndEsExpedienteAnulable(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void EsExpedienteAnulableAsync(string expediente, System.DateTime fechaParquimetro) {
            this.EsExpedienteAnulableAsync(expediente, fechaParquimetro, null);
        }
        
        /// <remarks/>
        public void EsExpedienteAnulableAsync(string expediente, System.DateTime fechaParquimetro, object userState) {
            if ((this.EsExpedienteAnulableOperationCompleted == null)) {
                this.EsExpedienteAnulableOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEsExpedienteAnulableOperationCompleted);
            }
            this.InvokeAsync("EsExpedienteAnulable", new object[] {
                        expediente,
                        fechaParquimetro}, this.EsExpedienteAnulableOperationCompleted, userState);
        }
        
        private void OnEsExpedienteAnulableOperationCompleted(object arg) {
            if ((this.EsExpedienteAnulableCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EsExpedienteAnulableCompleted(this, new EsExpedienteAnulableCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("ConsolaSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EsExpedienteAnulableConCuantia", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string EsExpedienteAnulableConCuantia(string expediente, System.DateTime fechaParquimetro) {
            object[] results = this.Invoke("EsExpedienteAnulableConCuantia", new object[] {
                        expediente,
                        fechaParquimetro});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginEsExpedienteAnulableConCuantia(string expediente, System.DateTime fechaParquimetro, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("EsExpedienteAnulableConCuantia", new object[] {
                        expediente,
                        fechaParquimetro}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndEsExpedienteAnulableConCuantia(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void EsExpedienteAnulableConCuantiaAsync(string expediente, System.DateTime fechaParquimetro) {
            this.EsExpedienteAnulableConCuantiaAsync(expediente, fechaParquimetro, null);
        }
        
        /// <remarks/>
        public void EsExpedienteAnulableConCuantiaAsync(string expediente, System.DateTime fechaParquimetro, object userState) {
            if ((this.EsExpedienteAnulableConCuantiaOperationCompleted == null)) {
                this.EsExpedienteAnulableConCuantiaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEsExpedienteAnulableConCuantiaOperationCompleted);
            }
            this.InvokeAsync("EsExpedienteAnulableConCuantia", new object[] {
                        expediente,
                        fechaParquimetro}, this.EsExpedienteAnulableConCuantiaOperationCompleted, userState);
        }
        
        private void OnEsExpedienteAnulableConCuantiaOperationCompleted(object arg) {
            if ((this.EsExpedienteAnulableConCuantiaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EsExpedienteAnulableConCuantiaCompleted(this, new EsExpedienteAnulableConCuantiaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class ConsolaSoapHeader : System.Web.Services.Protocols.SoapHeader {
        
        private int idContrataField;
        
        private System.DateTime localTimeField;
        
        private string nomUsuarioField;
        
        private string numSerieField;
        
        private string idUsuarioField;
        
        private string passwordField;
        
        /// <comentarios/>
        public int IdContrata {
            get {
                return this.idContrataField;
            }
            set {
                this.idContrataField = value;
            }
        }
        
        /// <comentarios/>
        public System.DateTime LocalTime {
            get {
                return this.localTimeField;
            }
            set {
                this.localTimeField = value;
            }
        }
        
        /// <comentarios/>
        public string NomUsuario {
            get {
                return this.nomUsuarioField;
            }
            set {
                this.nomUsuarioField = value;
            }
        }
        
        /// <comentarios/>
        public string NumSerie {
            get {
                return this.numSerieField;
            }
            set {
                this.numSerieField = value;
            }
        }
        
        /// <comentarios/>
        public string IdUsuario {
            get {
                return this.idUsuarioField;
            }
            set {
                this.idUsuarioField = value;
            }
        }
        
        /// <comentarios/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void UploadCompletedEventHandler(object sender, UploadCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UploadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UploadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void EsExpedienteAnulableCompletedEventHandler(object sender, EsExpedienteAnulableCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EsExpedienteAnulableCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EsExpedienteAnulableCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void EsExpedienteAnulableConCuantiaCompletedEventHandler(object sender, EsExpedienteAnulableConCuantiaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EsExpedienteAnulableConCuantiaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EsExpedienteAnulableConCuantiaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591