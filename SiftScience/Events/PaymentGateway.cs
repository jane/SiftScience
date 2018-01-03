using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SiftScience.Events
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentGateway
    {

        [EnumMember(Value = "$adyen")]
        Adyen,
        [EnumMember(Value = "$affirm")]
        Affirm,
        [EnumMember(Value = "$alipay")]
        Alipay,
        [EnumMember(Value = "$altapay")]
        AltaPay,
        [EnumMember(Value = "$amazon_payments")]
        AmazonPayments,
        [EnumMember(Value = "$authorizenet")]
        Authorizenet,
        [EnumMember(Value = "$balanced")]
        Balanced,
        [EnumMember(Value = "$beanstream")]
        Beanstream,
        [EnumMember(Value = "$bluepay")]
        BluePay,
        [EnumMember(Value = "$boacompra")]
        BoaCompra,
        [EnumMember(Value = "$braintree")]
        Braintree,
        [EnumMember(Value = "$ccavenue")]
        CCAvenue,
        [EnumMember(Value = "$chase_paymentech")]
        ChasePaymentech,
        [EnumMember(Value = "$checkoutcom")]
        Checkoutcom,
        [EnumMember(Value = "$clearsettle")]
        Clearsettle,
        [EnumMember(Value = "$cielo")]
        Cielo,
        [EnumMember(Value = "$cofinoga")]
        Cofinoga,
        [EnumMember(Value = "$coinbase")]
        Coinbase,
        [EnumMember(Value = "$collector")]
        Collector,
        [EnumMember(Value = "$compropago")]
        ComproPago,
        [EnumMember(Value = "$conekta")]
        Conekta,
        [EnumMember(Value = "$cuentadigital")]
        CuentaDigital,
        [EnumMember(Value = "$cybersource")]
        CyberSource,
        [EnumMember(Value = "$datacash")]
        DataCash,
        [EnumMember(Value = "$debitway")]
        DebitWay,
        [EnumMember(Value = "$dibs")]
        DIBS,
        [EnumMember(Value = "$digital_river")]
        DigitalRiver,
        [EnumMember(Value = "$elavon")]
        Elavon,
        [EnumMember(Value = "$epayeu")]
        Epayeu,
        [EnumMember(Value = "$eprocessing_network")]
        EProcessingNetwork,
        [EnumMember(Value = "$eway")]
        EWAY,
        [EnumMember(Value = "$first_atlantic_commerce")]
        FirstAtlanticCommerce,
        [EnumMember(Value = "$first_data")]
        FirstData,
        [EnumMember(Value = "$giropay")]
        Giropay,
        [EnumMember(Value = "$global_payment")]
        GlobalPayment,
        [EnumMember(Value = "$globalcollect")]
        GlobalCollect,
        [EnumMember(Value = "$hdfc_fssnet")]
        HDFCFSSnet,
        [EnumMember(Value = "$ingenico")]
        Ingenico,
        [EnumMember(Value = "$internetsecure")]
        InternetSecure,
        [EnumMember(Value = "$intuit_quickbooks_payments")]
        IntuitQuickbooksPayments,
        [EnumMember(Value = "$iugu")]
        Iugu,
        [EnumMember(Value = "$jabong")]
        Jabong,
        [EnumMember(Value = "$mastercard_payment_gateway")]
        MasterCardPaymentGateway,
        [EnumMember(Value = "$mercadopago")]
        MercadoPago,
        [EnumMember(Value = "$merchant_esolutions")]
        MerchanteSolutions,
        [EnumMember(Value = "$mirjeh")]
        Mirjeh,
        [EnumMember(Value = "$moip")]
        MoIP,
        [EnumMember(Value = "$mollie")]
        Mollie,
        [EnumMember(Value = "$moneris_solutions")]
        MonerisSolutions,
        [EnumMember(Value = "$nmi")]
        NMI,
        [EnumMember(Value = "$ogon")]
        Ogon,
        [EnumMember(Value = "$omise")]
        Omise,
        [EnumMember(Value = "$openpaymx")]
        Openpaymx,
        [EnumMember(Value = "$optimal_payments")]
        OptimalPayments,
        [EnumMember(Value = "$pagseguro")]
        PagSeguro,
        [EnumMember(Value = "$payfast")]
        PayFast,
        [EnumMember(Value = "$paygate")]
        PayGate,
        [EnumMember(Value = "$payment_express")]
        PaymentExpress,
        [EnumMember(Value = "$paymill")]
        PAYMILL,
        [EnumMember(Value = "$payone")]
        PayOne,
        [EnumMember(Value = "$paypal")]
        PayPal,
        [EnumMember(Value = "$paystation")]
        Paystation,
        [EnumMember(Value = "$paytrace")]
        PayTrace,
        [EnumMember(Value = "$paytrail")]
        Paytrail,
        [EnumMember(Value = "$payture")]
        Payture,
        [EnumMember(Value = "$payu")]
        PayU,
        [EnumMember(Value = "$payulatam")]
        PayULatam,
        [EnumMember(Value = "$payza")]
        Payza,
        [EnumMember(Value = "$pinpayments")]
        PinPayments,
        [EnumMember(Value = "$pivotal_payments")]
        PivotalPayments,
        [EnumMember(Value = "$princeton_payment_solutions")]
        PrincetonPaymentSolutions,
        [EnumMember(Value = "$psigate")]
        PsiGate,
        [EnumMember(Value = "$qiwi")]
        QIWI,
        [EnumMember(Value = "$quickpay")]
        QuickPay,
        [EnumMember(Value = "$raberil")]
        Raberil,
        [EnumMember(Value = "$rede")]
        Rede,
        [EnumMember(Value = "$redpagos")]
        Redpagos,
        [EnumMember(Value = "$redsys")]
        Redsys,
        [EnumMember(Value = "$rewardspay")]
        RewardsPay,
        [EnumMember(Value = "$rocketgate")]
        RocketGate,
        [EnumMember(Value = "$sagepay")]
        SagePay,
        [EnumMember(Value = "$sermepa")]
        Sermepa,
        [EnumMember(Value = "$simplify_commerce")]
        SimplifyCommerce,
        [EnumMember(Value = "$skrill")]
        Skrill,
        [EnumMember(Value = "$smartcoin")]
        SmartCoin,
        [EnumMember(Value = "$sofort")]
        Sofort,
        [EnumMember(Value = "$sps_decidir")]
        SPSDecidir,
        [EnumMember(Value = "$stripe")]
        Stripe,
        [EnumMember(Value = "$synapsepay")]
        SynapsePay,
        [EnumMember(Value = "$telerecargas")]
        TeleRecargas,
        [EnumMember(Value = "$towah")]
        Towah,
        [EnumMember(Value = "$tnspay")]
        TNSPay,
        [EnumMember(Value = "$twocheckout")]
        TwoCheckout,
        [EnumMember(Value = "$unionpay")]
        UnionPay,
        [EnumMember(Value = "$usa_epay")]
        USAePay,
        [EnumMember(Value = "$vantiv")]
        Vantiv,
        [EnumMember(Value = "$veritrans")]
        Veritrans,
        [EnumMember(Value = "$venmo")]
        Venmo,
        [EnumMember(Value = "$vindicia")]
        Vindicia,
        [EnumMember(Value = "$virtual_card_services")]
        VirtualCardServices,
        [EnumMember(Value = "$vme")]
        VME,
        [EnumMember(Value = "$webpay_oneclick")]
        WebpayOneclick,
        [EnumMember(Value = "$wirecard")]
        Wirecard,
        [EnumMember(Value = "$worldpay")]
        Worldpay
    }
}