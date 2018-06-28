using Model;
using System.Linq;
using Xamarin.Forms;

namespace CrossApp
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = this;

            System.Console.WriteLine(Manager);

            FirstAccount = Manager.db.Accounts.FirstOrDefault();
		}

        public Manager Manager { get { return ((App)App.Current).Manager; } }

        public Account FirstAccount { get; set; }
	}
}
