using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EFaturaService.Classes.EFatura
{
    public class Invoice
    {
        public string faturaUuid { get; set; } = Guid.NewGuid().ToString();
        public string belgeNumarasi { get; set; } = "";
        public string faturaTarihi { get; set; }
        public string saat { get; set; }
        public string paraBirimi { get; set; } = "";
        public string dovzTLkur { get; set; } = "0";
        public string faturaTipi { get; set; } = InvoiceType.SATIS;
        public string hangiTip { get; set; } = "5000/30000";
        public string siparisNumarasi { get; set; } = "";
        public string siparisTarihi { get; set; } = "";
        public string irsaliyeNumarasi { get; set; } = "";
        public string irsaliyeTarihi { get; set; } = "";
        public string fisNo { get; set; } = "";
        public string fisTarihi { get; set; } = "";
        public string fisSaati { get; set; } = " ";
        public string fisTipi { get; set; } = " ";
        public string zRaporNo { get; set; } = "";
        public string okcSeriNo { get; set; } = "";

        public string vknTckn { get; set; } = "11111111111";
        public string aliciUnvan { get; set; } = "";
        public string aliciAdi { get; set; } = "";
        public string aliciSoyadi { get; set; } = "";
        public string bulvarcaddesokak { get; set; } = "";
        public string binaAdi { get; set; } = "";
        public string binaNo { get; set; } = "";
        public string kapiNo { get; set; } = "";
        public string kasabaKoy { get; set; } = "";
        public string mahalleSemtIlce { get; set; } = "";
        public string sehir { get; set; } = " ";
        public string ulke { get; set; } = Country.TURKIYE;
        public string postaKodu { get; set; } = "";
        public string tel { get; set; } = "";
        public string fax { get; set; } = "";
        public string eposta { get; set; } = "";
        public string websitesi { get; set; } = "";
        public string vergiDairesi { get; set; } = "";


        //public double komisyonOrani { get; set; }
        //public double navlunOrani { get; set; }
        //public double hammaliyeOrani { get; set; }
        //public double nakliyeOrani { get; set; }
        //public string komisyonTutari { get; set; }
        //public string navlunTutari { get; set; }
        //public string hammaliyeTutari { get; set; }
        //public string nakliyeTutari { get; set; }
        //public double komisyonKDVOrani { get; set; }
        //public double navlunKDVOrani { get; set; }
        //public double hammaliyeKDVOrani { get; set; }
        //public double nakliyeKDVOrani { get; set; }
        //public string komisyonKDVTutari { get; set; }
        //public string navlunKDVTutari { get; set; }
        //public string hammaliyeKDVTutari { get; set; }
        //public string nakliyeKDVTutari { get; set; }
        //public double gelirVergisiOrani { get; set; }
        //public double bagkurTevkifatiOrani { get; set; }
        //public string gelirVergisiTevkifatiTutari { get; set; }
        //public string bagkurTevkifatiTutari { get; set; }
        //public double halRusumuOrani { get; set; }
        //public double ticaretBorsasiOrani { get; set; }
        //public double milliSavunmaFonuOrani { get; set; }
        //public double digerOrani { get; set; }
        //public string halRusumuTutari { get; set; }
        //public string ticaretBorsasiTutari { get; set; }
        //public string milliSavunmaFonuTutari { get; set; }
        //public string digerTutari { get; set; }
        //public double halRusumuKDVOrani { get; set; }
        //public double ticaretBorsasiKDVOrani { get; set; }
        //public double milliSavunmaFonuKDVOrani { get; set; }
        //public string digerKDVOrani { get; set; }
        //public string halRusumuKDVTutari { get; set; }
        //public string ticaretBorsasiKDVTutari { get; set; }
        //public string milliSavunmaFonuKDVTutari { get; set; }
        //public string digerKDVTutari { get; set; }
        public List<object> iadeTable { get; set; } = new List<object>();
        public string ozelMatrahTutari { get; set; } = "";
        public double ozelMatrahOrani { get; set; } = 0;
        public string ozelMatrahVergiTutari { get; set; } = "";
        public string vergiCesidi { get; set; } = " ";
        public List<MalHizmet> malHizmetTable { get; set; } = new List<MalHizmet>();
        public string tip { get; set; } = "";
        public double matrah { get; set; } 
        public double malhizmetToplamTutari { get; set; }
        public string toplamIskonto { get; set; } = "";
        public double hesaplanankdv { get; set; }
        public double vergilerToplami { get; set; } 
        public double vergilerDahilToplamTutar { get; set; }
        public double odenecekTutar { get; set; } 
        public string not { get; set; } = "";

        //public string toplamMasraflar { get; set; }
    }
    public class MalHizmet
    {
        public string iskontoArttm { get; set; } = "";
        public string malHizmet { get; set; }
        public int miktar { get; set; }
        public string birim { get; set; }
        public string birimFiyat { get; set; }
        public string fiyat { get; set; }
        public double iskontoOrani { get; set; } = 0;
        public string iskontoTutari { get; set; } = "0";
        public string iskontoNedeni { get; set; } = "";
        public string malHizmetTutari { get; set; }
        public double kdvOrani { get; set; }
        public double vergiOrani { get; set; }
        public string kdvTutari { get; set; }
        public string vergininKdvTutari { get; set; }

        public int V0021Orani { get; set; }
        public int V0061Orani { get; set; }
        public int V0071Orani { get; set; }
        public int V0073Orani { get; set; }
        public int V0074Orani { get; set; }
        public int V0075Orani { get; set; }
        public int V0076Orani { get; set; }
        public int V0077Orani { get; set; }
        public int V1047Orani { get; set; }
        public int V1048Orani { get; set; }
        public int V4080Orani { get; set; }
        public int V4081Orani { get; set; }
        public int V9015Orani { get; set; }
        public int V9021Orani { get; set; }
        public int V9077Orani { get; set; }
        public int V8001Orani { get; set; }
        public int V8002Orani { get; set; }
        public int V4071Orani { get; set; }
        public int V8004Orani { get; set; }
        public int V8005Orani { get; set; }
        public int V8006Orani { get; set; }
        public int V8007Orani { get; set; }
        public int V8008Orani { get; set; }
        public int V0003Orani { get; set; }
        public int V0011Orani { get; set; }
        public int V9040Orani { get; set; }
        public int V4171Orani { get; set; }
        public int V9944Orani { get; set; }
        public int V0059Orani { get; set; }
        public int V0021Tutari { get; set; }
        public int V0061Tutari { get; set; }
        public int V0061KdvTutari { get; set; }
        public int V0071Tutari { get; set; }
        public int V0071KdvTutari { get; set; }
        public int V0073Tutari { get; set; }
        public int V0073KdvTutari { get; set; }
        public int V0074Tutari { get; set; }
        public int V0074KdvTutari { get; set; }
        public int V0075Tutari { get; set; }
        public int V0075KdvTutari { get; set; }
        public int V0076Tutari { get; set; }
        public int V0076KdvTutari { get; set; }
        public int V0077Tutari { get; set; }
        public int V0077KdvTutari { get; set; }
        public int V1047Tutari { get; set; }
        public int V1047KdvTutari { get; set; }
        public int V1048Tutari { get; set; }
        public int V4080Tutari { get; set; }
        public int V4081Tutari { get; set; }
        [JsonProperty(PropertyName = "V9015Tutari")]
        public double KDVTevkifatTutari { get; set; }
        public int V9021Tutari { get; set; }
        public int V9077Tutari { get; set; }
        public int V9077KdvTutari { get; set; }
        public int V8001Tutari { get; set; }
        public int V8002Tutari { get; set; }
        public int V8002KdvTutari { get; set; }
        public int V4071Tutari { get; set; }
        public int V4071KdvTutari { get; set; }
        public int V8004Tutari { get; set; }
        public int V8004KdvTutari { get; set; }
        public int V8005Tutari { get; set; }
        public int V8005KdvTutari { get; set; }
        public int V8006Tutari { get; set; }
        public int V8007Tutari { get; set; }
        public int V8008Tutari { get; set; }
        public int V0003Tutari { get; set; }
        public int V0011Tutari { get; set; }
        public int V9040Tutari { get; set; }
        public int V4171Tutari { get; set; }
        public int V9944Tutari { get; set; }
        public int V9944KdvTutari { get; set; }
        public int V0059Tutari { get; set; }
        public int hesaplananotvtevkifatakatkisi2 { get; set; }

    }
}
