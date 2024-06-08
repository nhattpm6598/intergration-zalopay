namespace BE.Eco.Infrastructure.ZaloPay.Common.Enums
{
    public enum Status
    {
        SUCCESS,
        PROCESSING,
        FAILED
    }

    public enum StatusMessage
    {
        PAYMENT_CAN_BE_MADE,
        PAYMENT_CANT_BE_MADE,
        PAYMENT_CANT_BE_MADE_ZP_CHANNEL,
        ORDER_CANT_CREATE,
        REQUERI_PAYMENT_NOT_SUCCESS,
        GET_STATUS_ORDER
    }
}
