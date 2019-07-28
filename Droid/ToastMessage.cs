using System;
using Android.Widget;
using DearDiary.Interfaces;
using Xamarin.Forms;

[assembly : Dependency(typeof(DearDiary.Droid.ToastMessage))]
namespace DearDiary.Droid
{
    public class ToastMessage : Interfaces.IToastMessage
    {
        public ToastMessage()
        {
        }


        void IToastMessage.ShowToast(string content)
        {
            Toast.MakeText(Forms.Context, content, ToastLength.Short).Show();
        }
    }
}
