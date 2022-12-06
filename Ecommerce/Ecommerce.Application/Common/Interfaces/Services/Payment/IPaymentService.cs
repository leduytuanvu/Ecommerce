using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Payment
{
    public interface IPaymentService
    {
        Task<ErrorOr<List<entities.Payment>?>> GetAll();

        Task<ErrorOr<entities.Payment?>> GetById(Guid id);

        Task<ErrorOr<entities.Payment?>> Create(entities.Payment Payment);

        Task<ErrorOr<entities.Payment?>> Update(Guid id, entities.Payment Payment);

        Task<ErrorOr<entities.Payment?>> Delete(Guid id);
    }
}
