using EFaturaService.Classes.EFatura;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaService
{
    class Program
    {
        static void Main(string[] args)
        {
            EFaturaClient client = new EFaturaClient();
            client.Mod = MODE.Debug;
            client.GetTestUser();
            client.GetToken();
            //var res=client.GetInvoicesByDateRange(DateTime.Now.AddDays(-18), DateTime.Now);
            //client.CreateDraftInvoice();
            //client.GetInvoiceHTML(res[0].ettn, false);
            //client.GetDownloadURL(res[1].ettn, false);
            //client.GetUserData();
            //client.SendSignSMSCode("5322524599");

            var inv = new Invoice()
            {
                belgeNumarasi = "",
                faturaTarihi = "19/01/2020",
                saat = DateTime.Now.TimeOfDay.ToString(),
                paraBirimi = CurrencyType.TURK_LIRASI,
                dovzTLkur = "0",
                faturaTipi = InvoiceType.SATIS,
                vknTckn = "11111111111",
                aliciUnvan = "Mehmet UZUNÖZ",
                aliciAdi = "Mehmet",
                aliciSoyadi = "UZUNÖZ",
                binaAdi = "",
                binaNo = "",
                kapiNo = "",
                kasabaKoy = "",
                vergiDairesi = "MALTEPE",
                ulke = Country.TURKIYE,
                bulvarcaddesokak = "DENEME SK. DENEME MAH.",
                mahalleSemtIlce = "",
                sehir = " ",
                postaKodu = "",
                tel = "",
                fax = "",
                eposta = "",
                websitesi = "",
                ozelMatrahTutari = "0",
                ozelMatrahOrani = 0,
                ozelMatrahVergiTutari = "0",
                vergiCesidi = " ",
                tip = "İskonto",
                matrah = 100,
                malhizmetToplamTutari = 100,
                toplamIskonto = "0",
                hesaplanankdv = 18,
                vergilerToplami = 18,
                vergilerDahilToplamTutar = 118,
                odenecekTutar = 118,
                not = "xxx",
                siparisNumarasi = "",
                siparisTarihi = "",
                irsaliyeNumarasi = "",
                irsaliyeTarihi = "",
                fisNo = "",
                fisTarihi = "",
                fisSaati = " ",
                fisTipi = " ",
                zRaporNo = "",
                okcSeriNo = ""
            };
            inv.malHizmetTable.Add(new MalHizmet
            {
                malHizmet = "Yazılım Geliştirme",
                miktar = 10,
                birim = UnitType.GUN,
                birimFiyat = "10",
                fiyat = "100",
                malHizmetTutari = "100",
                kdvOrani = 18,
                kdvTutari = "18",
                vergininKdvTutari = "0"
            });
            client.CreateDraftInvoice(inv);
            var draftInv=client.FindInvoice(inv);
            client.DownloadInvoice(draftInv.ettn, false);
            //client.SignDraftInvoice(draftInv);
            var invs=client.GetInvoicesByDateRange(DateTime.Now.AddDays(-4), DateTime.Now.AddDays(1));

        }
    }
}
