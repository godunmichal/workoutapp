﻿using DL.Services;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog.Startup))]
namespace Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}