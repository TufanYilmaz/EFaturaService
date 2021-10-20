namespace EFaturaService.Classes.EFatura
{
    public static class COMMANDS
    {
        public static MyCommand createDraftInvoice = new MyCommand() { Command = "EARSIV_PORTAL_FATURA_OLUSTUR", PageName = "RG_BASITFATURA" };
        public static MyCommand getAllInvoicesByDateRange = new MyCommand() { Command = "EARSIV_PORTAL_TASLAKLARI_GETIR", PageName = "RG_BASITTASLAKLAR" };
        public static MyCommand signDraftInvoice = new MyCommand() { Command = "EARSIV_PORTAL_FATURA_HSM_CIHAZI_ILE_IMZALA", PageName = "RG_BASITTASLAKLAR" };
        public static MyCommand getInvoiceHTML = new MyCommand() { Command = "EARSIV_PORTAL_FATURA_GOSTER", PageName = "RG_BASITTASLAKLAR" };
        public static MyCommand cancelDraftInvoice = new MyCommand() { Command = "EARSIV_PORTAL_FATURA_SIL", PageName = "RG_BASITTASLAKLAR" };
        public static MyCommand getRecipientDataByTaxIDOrTRID = new MyCommand() { Command = "SICIL_VEYA_MERNISTEN_BILGILERI_GETIR", PageName = "RG_BASITFATURA" };
        public static MyCommand sendSignSMSCode = new MyCommand() { Command = "EARSIV_PORTAL_SMSSIFRE_GONDER", PageName = "RG_SMSONAY" };
        public static MyCommand verifySMSCode = new MyCommand() { Command = "EARSIV_PORTAL_SMSSIFRE_DOGRULA", PageName = "RG_SMSONAY" };
        public static MyCommand getUserData = new MyCommand() { Command = "EARSIV_PORTAL_KULLANICI_BILGILERI_GETIR", PageName = "RG_KULLANICI" };
        public static MyCommand updateUserData = new MyCommand() { Command = "EARSIV_PORTAL_KULLANICI_BILGILERI_KAYDET", PageName = "RG_KULLANICI" };
    }
    public class MyCommand
    {
        public string Command { get; set; }
        public string PageName { get; set; }
    }
}
