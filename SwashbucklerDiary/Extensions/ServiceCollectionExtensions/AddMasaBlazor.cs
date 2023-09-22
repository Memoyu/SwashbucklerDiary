﻿using BlazorComponent;
using Masa.Blazor;
using Masa.Blazor.Presets;

namespace SwashbucklerDiary.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMasaBlazorConfig(this IServiceCollection services)
        {
            services.AddMasaBlazor(options =>
            {
                options.Defaults = new Dictionary<string, IDictionary<string, object?>?>()
                {
                    {
                        PopupComponents.SNACKBAR, new Dictionary<string, object?>()
                        {
                            { nameof(PEnqueuedSnackbars.Closeable), true },
                            { nameof(PEnqueuedSnackbars.Text), true },
                            { nameof(PEnqueuedSnackbars.Elevation), new StringNumber(2) },
                            { nameof(PEnqueuedSnackbars.Position), SnackPosition.BottomCenter }
                        }
                    }
                };
            }).AddI18nForMauiBlazor("wwwroot/i18n");
            return services;
        }
    }
}
