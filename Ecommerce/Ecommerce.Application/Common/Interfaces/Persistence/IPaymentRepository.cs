using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IPaymentRepository
    {
        Task<List<Payment>?> GetAll();

        Task<Payment?> GetById(Guid id);

        Task<Payment?> Create(Payment payment);

        Task<Payment?> Update(Guid id, Payment payment);

        Task<Payment?> Delete(Guid id);
    }
}
