using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<ErrorOr<entities.Payment?>> Create(entities.Payment payment)
        {
            var createResponse = await _paymentRepository.Create(payment);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<entities.Payment?>> Delete(Guid id)
        {
            var deleteResponse = await _paymentRepository.Delete(id);
            return deleteResponse;
        }

        public async Task<ErrorOr<List<entities.Payment>?>> GetAll()
        {
            var getAllResponse = await _paymentRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Payment?>> GetById(Guid id)
        {
            var getByIdResponse = await _paymentRepository.GetById(id);
            return getByIdResponse;
        }

        public async Task<ErrorOr<entities.Payment?>> Update(Guid id, entities.Payment payment)
        {
            var updateResponse = await _paymentRepository.Update(id, payment);
            return updateResponse;
        }
    }
}
