﻿using Microsoft.Extensions.DependencyInjection;
using socialNet.Repositories.UnitOfWork;
using socialNet.Repsitories.Interfaces.IUnitOfWork;
using socialNet.Services;
using socialNet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.ConfigurationServices
{
    public static class DIConfigure
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<IFriendshipService, FriendshipService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
   
    }
}
