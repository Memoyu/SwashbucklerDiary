﻿using Android.OS;
using Android.Views;
using Android.Widget;
using SwashbucklerDiary.IServices;
using Application = Android.App.Application;

namespace SwashbucklerDiary.Platforms.Android
{
    public static class BackButtonPressed
    {
        private static byte BackPressCounter;

        public static bool OnBackButtonPressed(KeyEvent e)
        {
            if (e.KeyCode == Keycode.Back)
            {
                if (e.Action == KeyEventActions.Down)
                {
                    var service = MauiApplication.Current.Services.GetRequiredService<INavigateService>();
                    bool flag = service!.OnBackButtonPressed();
                    if (!flag)
                    {
                        QuitApp();
                    }
                }
                return true;
            }
            return false;
        }

        public static void QuitApp()
        {
            if (BackPressCounter == 1)
            {
                Process.KillProcess(Process.MyPid());
            }
            else if (BackPressCounter == 0)
            {
                BackPressCounter++;
                Toast.MakeText(Application.Context, "再按一次退出", ToastLength.Long)!.Show();
                Task.Run(async () =>
                {
                    await Task.Delay(2000);
                    BackPressCounter = 0;
                });
            }
        }
    }
}
