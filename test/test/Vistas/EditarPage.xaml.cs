using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;

namespace test.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarPage : PopupPage
	{
		public EditarPage ()
		{
			InitializeComponent ();
		}
	}
}