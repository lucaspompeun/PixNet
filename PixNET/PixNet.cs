using PixNet.src;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PixNet
{
    public static class PixNet
    {
        public static string Payload(string json)
        {
            var data = (JObject)JsonConvert.DeserializeObject(json);

            // IDs do Payload do Pix
            const string IdPayloadFormatIndicator = "00";
            const string IdMerchantAccountInformation = "26";
            const string IdMerchantAccountInformationGui = "00";
            const string IdMerchantAccountInformationKey = "01";
            const string IdMerchantAccountInformationDescription = "02";
            const string IdMerchantCategoryCode = "52";
            const string IdTransactionCurrency = "53";
            const string IdTransactionAmount = "54";
            const string IdCountryCode = "58";
            const string IdMerchantName = "59";
            const string IdMerchantCity = "60";
            const string IdAdditionalDataFieldTemplate = "62";
            const string IdAdditionalDataFieldTemplateTxid = "05";
            const string IdCrc16 = "63";

            // Fazer verificação dos inputs do pix

            // Inputs do Pix
            string pixKey = data["Key"].Value<string>();
            string description = data["Description"].Value<string>();
            string merchantName = data["Name"].Value<string>();
            string merchantCity = data["City"].Value<string>();
            string txId = data["TransactionID"].Value<string>();
            double amount = data["Amount"].Value<double>();

            // Payload
            string payload;
            payload = Merchant.GetValue(IdPayloadFormatIndicator, "01");

            payload += Merchant.GetMerchantAccountInformation(IdMerchantAccountInformationGui, IdMerchantAccountInformationKey, pixKey, IdMerchantAccountInformationDescription, description, IdMerchantAccountInformation);

            payload += Merchant.GetValue(IdMerchantCategoryCode, "0000");

            payload += Merchant.GetValue(IdTransactionCurrency, "986");

            payload += Merchant.GetValue(IdTransactionAmount, String.Format("{0:0.00}", amount));

            payload += Merchant.GetValue(IdCountryCode, "BR");

            payload += Merchant.GetValue(IdMerchantName, merchantName);

            payload += Merchant.GetValue(IdMerchantCity, merchantCity);

            payload += Merchant.GetAdditionalDataFieldTemplate(IdAdditionalDataFieldTemplateTxid, txId, IdAdditionalDataFieldTemplate);

            payload += $"{IdCrc16}04";


            return "";
        }

    }
}


