﻿using Microsoft.AspNetCore.Components;
using NoDecentDiary.Components;
using NoDecentDiary.Shared;

namespace NoDecentDiary.Pages
{
    public partial class UserAgreementPage : PageComponentBase
    {
        private string? Content { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadingData();
            await base.OnInitializedAsync();
        }

        private async Task LoadingData()
        {
            var uri = I18n.T("FilePath.UserAgreement");
            Content = await SystemService.ReadMarkdown(uri);
        }
    }
}
