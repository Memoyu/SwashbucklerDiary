﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NoDecentDiary.IServices;

namespace NoDecentDiary.Components
{
    public class PageComponentBase : MyComponentBase
    {
        [Inject]
        protected ISettingsService SettingsService { get; set; } = default!;
        [Inject]
        protected IJSRuntime JS { get; set; } = default!;
        [Inject]
        protected ISystemService SystemService { get; set; } = default!;

        protected void NavigateToBack()
        {
            NavigateService.NavigateToBack();
        }
    }
}
