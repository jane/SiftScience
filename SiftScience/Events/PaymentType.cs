using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentType
    {
        [EnumMember(Value = "$credit_card")]
        CreditCard,
        [EnumMember(Value = "$electronic_fund_transfer")]
        ElectronicFundTransfer,
        [EnumMember(Value = "$store_credit")]
        StoreCredit,
        [EnumMember(Value = "$gift_card")]
        GiftCard,
        [EnumMember(Value = "$points")]
        Points,
        [EnumMember(Value = "$financing")]
        Financing,
        [EnumMember(Value = "$third_party_processor")]
        ThirdPartyProcessor,
        [EnumMember(Value = "$cash")]
        Cash,
        [EnumMember(Value = "$check")]
        Check,
        [EnumMember(Value = "$crypto_currency")]
        CryptoCurrency,
        [EnumMember(Value = "$interac")]
        Interac,
        [EnumMember(Value = "$invoice")]
        Invoice,
        [EnumMember(Value = "$money_order")]
        MoneyOrder,
        [EnumMember(Value = "$masterpass")]
        Masterpass,
        [EnumMember(Value = "$voucher")]
        Voucher
    }
}