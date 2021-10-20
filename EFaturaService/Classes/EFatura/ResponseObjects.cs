using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaService.Classes.EFatura
{
    class ResponseObjects
    {
    }
    public class EfaturaUser
    {
        public string userid { get; set; }
        public string password { get; set; } = "1";

    }
    public class TokenResponse
    {
        public string token { get; set; }
        public string chgpwd { get; set; }
        public string redirectUrl { get; set; }
    }
    public class Invoices
    {
        public List<InvoiceInfo> data { get; set; }
    }
    public class InvoiceInfo
    {
        public string belgeNumarasi { get; set; }
        public string aliciVknTckn { get; set; }
        public string aliciUnvanAdSoyad { get; set; }
        public string belgeTarihi { get; set; }
        public string belgeTuru { get; set; }
        public string onayDurumu { get; set; }
        public string ettn { get; set; }
    }
    public class UserData
    {
        public string vknTckn { get; set; }
        public string unvan { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string cadde { get; set; }
        public string apartmanAdi { get; set; }
        public string apartmanNo { get; set; }
        public string kapiNo { get; set; }
        public string kasaba { get; set; }
        public string ilce { get; set; }
        public string il { get; set; }
        public string postaKodu { get; set; }
        public string ulke { get; set; }
        public string telNo { get; set; }
        public string faksNo { get; set; }
        public string ePostaAdresi { get; set; }
        public string webSitesiAdresi { get; set; }
        public string vergiDairesi { get; set; }
        public string sicilNo { get; set; }
        public string isMerkezi { get; set; }
        public string mersisNo { get; set; }

    }
}
