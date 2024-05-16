using ECommerceAPI.Endpoints.PaymentInfo.RequestResponse;

namespace ECommerceAPI.Endpoints.PaymentInfo
{
    public class PaymentInfoService
    {

        public PaymentInfoService() { }


        public PaymentInfoResponse GetPaymentInfo(int id)
        {
            //TODO query database
            return new PaymentInfoResponse();
        }
    }
    
}
