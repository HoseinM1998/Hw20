﻿using AppDomainCore.Entities.Config;

namespace AppEndPointApi.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SiteSetting _siteSettings;

        public ApiKeyMiddleware(RequestDelegate next, SiteSetting siteSettings)
        {
            _next = next;
            _siteSettings = siteSettings;
        }
    }
}
