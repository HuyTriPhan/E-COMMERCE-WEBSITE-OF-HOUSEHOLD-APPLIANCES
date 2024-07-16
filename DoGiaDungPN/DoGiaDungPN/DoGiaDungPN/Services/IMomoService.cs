using DoGiaDungPN.Models.Momo;
using DoGiaDungPN.Models.Orders;


namespace DoGiaDungPN.Services;

public interface IMomoService
{
    Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model);
    MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
}