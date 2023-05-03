using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoupGaroup.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Accueil : ContentPage
	{
		public Accueil ()
		{
			InitializeComponent ();
			int userId = (int)Application.Current.Properties["UserId"];
			mail.Text = userId.ToString();

        }
	}
}