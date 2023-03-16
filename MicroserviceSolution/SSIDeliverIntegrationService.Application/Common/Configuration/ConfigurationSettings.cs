using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDeliverIntegrationService.Application.Common.Configuration
{
    public interface IConfigurationSettings
    {
        string AzureStorageConnection { get; set; }
        string SSIDeliverQueueName { get; set; }
        string IDeliverProvider { get; set; }
        string SkipIDeliverOrderStatus { get; set; }
        string ActorResurrectionQueueName { get; set; }
        string Token { get; set; }
        string BulkIDeliverOrderUploadBlobName { get; set; }
        string BulkIDeliverOrderUploadQueue { get; set; }
        int WarehouseId { get; set; }
        int ProcessSSIDeliverQueueDelayMilliSeconds { get; set; }
        int BulkIDeliverProcessingDelayInMinutes { get; set; }
        int ProcessDeliveryDeliveredDelayInMinutes { get; set; }
        string SaleAgreementUploadBlobName { get; set; }
        string MarketicUIBaseURL { get; set; }
        string ExternalSourceName { get; set; }
        string EventType { get; set; }
        string PODUploadBlobName { get; set; }
        string CommsQueue { get; set; }
        string SkipOutForDeliveryProviders { get; set; }
        string SaleDeliveredExternalSourceName { get; set; }
        string SaleDeliveredExternalSourceEvent { get; set; }
    }
    /// <summary>
    /// Configuration Settings
    /// </summary>
    public class ConfigurationSettings : IConfigurationSettings
    {
        readonly IConfiguration configuration;


        public string AzureStorageConnection { get { return configuration.GetValue<string>("marketic:ssconnectionstrings:azurestorage"); } set { } }

        public string SSIDeliverQueueName { get { return configuration.GetValue<string>("marketic:ssideliver:ssideliverqueue"); } set { } }

        public string IDeliverProvider { get { return configuration.GetValue<string>("marketic:ssideliver:ssideliverproviders"); } set { } }

        public string SkipIDeliverOrderStatus { get { return configuration.GetValue<string>("marketic:ssideliver:skipideliverorderstatus"); } set { } }
        public string ActorResurrectionQueueName { get { return configuration.GetValue<string>("marketic:ssideliver:actorresurrectionqueue"); } set { } }
        public string Token { get { return configuration.GetValue<string>("marketic:ideliver:accesstoken"); } set { } }

        public string BulkIDeliverOrderUploadBlobName { get { return configuration.GetValue<string>("marketic:ssideliver:ideliverbulkorderuploadblob"); } set { } }
        public string BulkIDeliverOrderUploadQueue { get { return configuration.GetValue<string>("marketic:ssideliver:ideliverbulkorderuploadqueue"); } set { } }

        public int WarehouseId { get { return configuration.GetValue<int>("marketic:ideliver:warehouse"); } set { } }
        public int ProcessSSIDeliverQueueDelayMilliSeconds { get { return configuration.GetValue<int>("marketic:ideliver:processideliverqueuedelayinmilliseconds"); } set { } }
        public int BulkIDeliverProcessingDelayInMinutes { get { return configuration.GetValue<int>("marketic:ideliver:bulkideliverorderprocessingdelayinminutes"); } set { } }
        public int ProcessDeliveryDeliveredDelayInMinutes { get { return configuration.GetValue<int>("marketic:ideliver:processdeliverydelivereddelayinminutes"); } set { } }

        public string SaleAgreementUploadBlobName { get { return configuration.GetValue<string>("marketic:ideliver:ideliversaleagreementuploadblob"); } set { } }
        public string MarketicUIBaseURL { get { return configuration.GetValue<string>("marketicui:baseurl"); } set { } }
        public string ExternalSourceName { get { return configuration.GetValue<string>("marketicui:ssideliver:externalsourcename"); } set { } }
        public string EventType { get { return configuration.GetValue<string>("marketicui:eventtype"); } set { } }
        public string PODUploadBlobName { get { return configuration.GetValue<string>("marketic:ideliver:ideliverpoduploadblob"); } set { } }
        public string CommsQueue { get { return configuration.GetValue<string>("marketic:ss:commsqueue"); } set { } }
        public string SkipOutForDeliveryProviders { get { return configuration.GetValue<string>("marketic:ideliver:skipdodproviders"); } set { } }
        public string SaleDeliveredExternalSourceName { get { return configuration.GetValue<string>("marketic:engaigeintegration:externalsourcename"); } set { } }
        public string SaleDeliveredExternalSourceEvent { get { return configuration.GetValue<string>("marketic:engaigeintegration:saledeliveredevent"); } set { } }

        public ConfigurationSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
