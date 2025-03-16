﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancelleryApp.ViewModels
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddTransient<MainWindowViewModel>();
    }
}
