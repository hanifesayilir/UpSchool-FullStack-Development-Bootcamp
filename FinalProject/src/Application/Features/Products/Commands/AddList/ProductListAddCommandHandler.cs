using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Commands.AddList
{
    public class ProductListAddCommandHandler : IRequestHandler<ProductListAddCommand, Response<Guid>>
    {

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IEmailService _emailService;
       
        private readonly INotificationApplicationHubService _notificationApplicationHubService;

        public ProductListAddCommandHandler(IApplicationDbContext applicationDbContext, IEmailService emailService, INotificationApplicationHubService notificationApplicationHubService)
        {
            _applicationDbContext = applicationDbContext;
            _emailService = emailService;
            _notificationApplicationHubService = notificationApplicationHubService;
         

        }
            public async Task<Response<Guid>> Handle(ProductListAddCommand request, CancellationToken cancellationToken)
            {
            try
            {
                List<Product> productList = new List<Product>();


                foreach (var product in request.Products)
                {
                    if (product == null) continue;
                    else
                    {
                        Product productNew = new Product()
                        {
                            OrderId = product.OrderId,
                            Name = product.Name,
                            IsOnSale = product.IsOnSale,
                            Picture = product.Picture,
                            Price = product.Price,
                            SalePrice = product.SalePrice,
                            CreatedOn = DateTimeOffset.Now,
                            CreatedByUserId = null,
                            IsDeleted = false,
                        };

                        productList.Add(productNew);
                    }
                }

                await _applicationDbContext.Products.AddRangeAsync(productList, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);


                var notificationSetting = await _applicationDbContext.NotificationSettings.FirstOrDefaultAsync();



                // send an email

            /*    if (notificationSetting != null && notificationSetting.IsEmailEnabled)
                {
                    _emailService.SendEmailNotification(new SendEmailNotificationDto()
                    {
                        Email = notificationSetting.EmailAddress,
                        Name = notificationSetting.UserName,

                    });

                }*/

                // send application message to wasm notificationpage
                if (notificationSetting != null && notificationSetting.IsApplicationEnabled)
                {
                    await _notificationApplicationHubService.SendApplication($"{productList.Count} products are added successfully in your order.", cancellationToken);
                
                }

                return new Response<Guid>($"{productList.Count} products were added successfully");
            } catch(Exception ex)
            {
                Console.WriteLine("ExceptionMessage: " +ex.Message);
                return null;
            }
                

            }
        }
    }

