﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace carimagery.CarImagery {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://carimagery.com/", ConfigurationName="CarImagery.apiSoap")]
    public interface apiSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://carimagery.com/GetImageUrl", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetImageUrl(string searchTerm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://carimagery.com/GetImageUrl", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetImageUrlAsync(string searchTerm);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface apiSoapChannel : carimagery.CarImagery.apiSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class apiSoapClient : System.ServiceModel.ClientBase<carimagery.CarImagery.apiSoap>, carimagery.CarImagery.apiSoap {
        
        public apiSoapClient() {
        }
        
        public apiSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public apiSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public apiSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public apiSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetImageUrl(string searchTerm) {
            return base.Channel.GetImageUrl(searchTerm);
        }
        
        public System.Threading.Tasks.Task<string> GetImageUrlAsync(string searchTerm) {
            return base.Channel.GetImageUrlAsync(searchTerm);
        }
    }
}
