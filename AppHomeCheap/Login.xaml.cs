using AppHomeCheap.Model;
using AppHomeCheap.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHomeCheap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _con;

        public Login()
        {
            InitializeComponent();
            _con = DependencyService.Get<Database>().GetConnection();
        }


        public static IEnumerable<Usuario> SELECT_WHERE(SQLiteConnection db, string celular, string contrasena)
        {

            return db.Query<Usuario>("SELECT * FROM Usuario WHERE Celular = ? and Contrasena= ?", celular, contrasena);
        }


        private void btnLogin_Clicked(object sender, EventArgs e)
        {
			try
			{

				var documentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "homecheap.db3");
				var db = new SQLiteConnection(documentPath);
				db.CreateTable<Usuario>();
				db.CreateTable<Arriendos>();

				IEnumerable<Usuario> resultado = SELECT_WHERE(db, txtUsuario.Text, txtClave.Text);

				txtUsuario.Text = "";
				txtClave.Text = "";

				if (resultado.Count() > 0)
				{
					
					Navigation.PushAsync(new Opciones());

				}
				else
				{
					DisplayAlert("Alerta", "Usuario no registrado", "OK");
				}
			}
			catch (Exception)
			{

				throw;
			}

			
        }

		private async void btnRegistroUser_Clicked(object sender, EventArgs e)
		{

			
			await Navigation.PushAsync(new Registro());

		}

		private async void btnBuscar_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ConsultaRegistroA());
		}
	}
}