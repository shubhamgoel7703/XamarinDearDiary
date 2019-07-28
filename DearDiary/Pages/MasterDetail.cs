using System;

using Xamarin.Forms;

namespace DearDiary.Pages
{
    MasterPageCS masterPage;

    public class MasterDetail : ContentPage
    {
        public MasterDetail()
        {
            masterPage = new MasterPageCS();
            Master = masterPage;
            Detail = new NavigationPage(new ContactsPageCS());
        }
    }
}

