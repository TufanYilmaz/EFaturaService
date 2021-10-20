using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaService.Classes.EFatura
{
    public class RequestInvoicesObject
    {
        public string baslangic { get; set; }
        public string bitis { get; set; }
        public string hangiTip { get; set; } = "5000/30000";
        public List<object> table { get; set; } = new List<object>();
    }
    public class RequestInvoiceHTMLObject
    {
        public string ettn { get; set; }
        public string onayDurumu { get; set; }
    }
    public class RequestSMSSendObject
    {
        public string CEPTEL { get; set; }
        public bool KTEL { get; set; } = false;
        public string TIP { get; set; } = "";
    }
    public class RequestSMSVerifyObject
    {
        public string SIFRE { get; set; }
        public string OID { get; set; }
    }
    public class SignDrfatInvoiceObject
    {
        public List<InvoiceInfo> imzalanacaklar { get; set; } = new List<InvoiceInfo>();
    }
}
