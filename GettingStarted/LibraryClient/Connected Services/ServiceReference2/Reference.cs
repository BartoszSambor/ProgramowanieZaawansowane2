﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryClient.ServiceReference2 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/UsersServer")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Librarin", Namespace="http://schemas.datacontract.org/2004/07/UsersServer")]
    [System.SerializableAttribute()]
    public partial class Librarin : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Admin", Namespace="http://schemas.datacontract.org/2004/07/UsersServer")]
    [System.SerializableAttribute()]
    public partial class Admin : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IUserServer")]
    public interface IUserServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/Login", ReplyAction="http://tempuri.org/IUserServer/LoginResponse")]
        bool Login([System.ServiceModel.MessageParameterAttribute(Name="login")] string login1, string password, string permissions);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/Login", ReplyAction="http://tempuri.org/IUserServer/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string login, string password, string permissions);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/CreateUser", ReplyAction="http://tempuri.org/IUserServer/CreateUserResponse")]
        bool CreateUser(string login, string password, string permissions);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/CreateUser", ReplyAction="http://tempuri.org/IUserServer/CreateUserResponse")]
        System.Threading.Tasks.Task<bool> CreateUserAsync(string login, string password, string permissions);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/GetUsers", ReplyAction="http://tempuri.org/IUserServer/GetUsersResponse")]
        LibraryClient.ServiceReference2.User[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/GetUsers", ReplyAction="http://tempuri.org/IUserServer/GetUsersResponse")]
        System.Threading.Tasks.Task<LibraryClient.ServiceReference2.User[]> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/GetLibrarians", ReplyAction="http://tempuri.org/IUserServer/GetLibrariansResponse")]
        LibraryClient.ServiceReference2.Librarin[] GetLibrarians();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/GetLibrarians", ReplyAction="http://tempuri.org/IUserServer/GetLibrariansResponse")]
        System.Threading.Tasks.Task<LibraryClient.ServiceReference2.Librarin[]> GetLibrariansAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/GetAdmins", ReplyAction="http://tempuri.org/IUserServer/GetAdminsResponse")]
        LibraryClient.ServiceReference2.Admin[] GetAdmins();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserServer/GetAdmins", ReplyAction="http://tempuri.org/IUserServer/GetAdminsResponse")]
        System.Threading.Tasks.Task<LibraryClient.ServiceReference2.Admin[]> GetAdminsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServerChannel : LibraryClient.ServiceReference2.IUserServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServerClient : System.ServiceModel.ClientBase<LibraryClient.ServiceReference2.IUserServer>, LibraryClient.ServiceReference2.IUserServer {
        
        public UserServerClient() {
        }
        
        public UserServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(string login1, string password, string permissions) {
            return base.Channel.Login(login1, password, permissions);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string login, string password, string permissions) {
            return base.Channel.LoginAsync(login, password, permissions);
        }
        
        public bool CreateUser(string login, string password, string permissions) {
            return base.Channel.CreateUser(login, password, permissions);
        }
        
        public System.Threading.Tasks.Task<bool> CreateUserAsync(string login, string password, string permissions) {
            return base.Channel.CreateUserAsync(login, password, permissions);
        }
        
        public LibraryClient.ServiceReference2.User[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<LibraryClient.ServiceReference2.User[]> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public LibraryClient.ServiceReference2.Librarin[] GetLibrarians() {
            return base.Channel.GetLibrarians();
        }
        
        public System.Threading.Tasks.Task<LibraryClient.ServiceReference2.Librarin[]> GetLibrariansAsync() {
            return base.Channel.GetLibrariansAsync();
        }
        
        public LibraryClient.ServiceReference2.Admin[] GetAdmins() {
            return base.Channel.GetAdmins();
        }
        
        public System.Threading.Tasks.Task<LibraryClient.ServiceReference2.Admin[]> GetAdminsAsync() {
            return base.Channel.GetAdminsAsync();
        }
    }
}
