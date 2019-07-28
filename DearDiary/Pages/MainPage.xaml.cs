using System;
using System.Collections.Generic;
using DearDiary.Interfaces;
using Xamarin.Forms;

namespace DearDiary.Pages
{
    public partial class MainPage : ContentPage
    {
        void Handle_Completed(object sender, System.EventArgs e)
        {
            Application.Current.Properties["des"] = editor.Text;
        }

        int lastRating = 5;
        bool favParameter = false;
        public MainPage()
        {
            InitializeComponent();
			double max = 10d, min = 1d, val = 5d;
			slider.Maximum = max;
			slider.Minimum = min;
			slider.Value = val;

            var toastMessage = DependencyService.Get<IToastMessage>();


            if (Application.Current.Properties.ContainsKey(("des")))
                editor.Text = Application.Current.Properties["des"].ToString();

            favImage.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => { /*handle tap*/

                    if (favParameter == false)
                    {
                        favImage.Source = ImageSource.FromResource("DearDiary.Images.RedHeart.png");
                        favParameter = true;
                        toastMessage.ShowToast("Day selected as favourite");
                    }

                    else
                    {
                        favImage.Source = ImageSource.FromResource("DearDiary.Images.Heart.png");
                        favParameter = false;
                        toastMessage.ShowToast("Day selected as usual");
                    }
				}),
			});

        }

		
		void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
		{

			int val = (int)e.NewValue;


			if (lastRating == val)
				return;
			lastRating = val;
			label.Text = val.ToString();
			string ResourceId = "DearDiary.Images." + val.ToString() + ".png";
			image.Source = ImageSource.FromResource(ResourceId);

		}
    }
}
