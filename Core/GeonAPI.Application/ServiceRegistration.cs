﻿using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GeonAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
        }
    }
}