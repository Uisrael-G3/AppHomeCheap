using AppHomeCheap.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace AppHomeCheap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaRegistroA : ContentPage
	{

		private SQLiteAsyncConnection _conn;
		private ObservableCollection<Arriendos> tablaArriendos;



		public ConsultaRegistroA()
		{
		
			InitializeComponent();
			_conn = DependencyService.Get<Database>().GetConnection();
		}


		protected async override void OnAppearing()
		{
			var resultado = await _conn.Table<Arriendos>().ToListAsync();
			tablaArriendos = new ObservableCollection<Arriendos>(resultado);

			ListaArriendos.ItemsSource = tablaArriendos;
			base.OnAppearing();

		}

		public void OnSelection(object sender, SelectedItemChangedEventArgs e) 
		{

			var Obj = (Arriendos)e.SelectedItem;
			var item = Obj.Id.ToString();
			int ID = Convert.ToInt32(item);

			var tit = Obj.Titulo;
			var dir = Obj.Direccion;
			var pre = Obj.Precio;
			var tel = Obj.Telefonos;
			var det = Obj.Detallle;

			try
			{
				Navigation.PushAsync(new Elemento(ID, tit, dir, pre, tel, det));
			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}