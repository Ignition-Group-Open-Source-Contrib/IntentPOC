using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDeliverIntegrationService.Application.Common.Helper
{
    public static class Constants
    {
        public const int Quantity = 1;
        public static readonly List<string> DeliveryDescription = new List<string> { "Delivered", "Proof Of Delivery" };
        public static readonly List<string> DeliveryRTS = new List<string> { "Return to sender", "Returned To Sender" };
        public const string SaleAgreement = "SaleAgreement";
        public const string POD = "POD";
        public const string PDFContentType = "application";
        public const string ImageContentType = "image";
        public const string TiffType = "tiff";
        public const string PdfType = "pdf";
        public const string DeliveryStatus = "Delivery Delivered";
    }
}
