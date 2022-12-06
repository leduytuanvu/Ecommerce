using Ecommerce.Application.Common.Interfaces.Services.Authentication;
using Ecommerce.Application.Common.Interfaces.Services.Category;
using Ecommerce.Application.Common.Interfaces.Services.Image;
using Ecommerce.Application.Common.Interfaces.Services.Order;
using Ecommerce.Application.Common.Interfaces.Services.OrderDetail;
using Ecommerce.Application.Common.Interfaces.Services.Payment;
using Ecommerce.Application.Common.Interfaces.Services.Product;
using Ecommerce.Application.Common.Interfaces.Services.Shipper;
using Ecommerce.Application.Common.Interfaces.Services.Supplier;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            services.AddFluentValidation(x => x.ImplicitlyValidateChildProperties = true);
#pragma warning restore CS0618 // Type or member is obsolete
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ISupplierService, SupplierService>();
            services.AddSingleton<IShipperService, ShipperService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IPaymentService, PaymentService>();
            services.AddSingleton<IOrderDetailService, OrderDetailService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IImageService, ImageService>();
            return services;
        }
    }
}
