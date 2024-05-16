using ECommerce.Api.Endpoints.PaymentInfo.RequestResponse;

namespace ECommerceAPI.Endpoints.Product
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
