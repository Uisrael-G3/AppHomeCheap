using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using AppHomeCheap.iOS;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteIOS))]
namespace AppHomeCheap.iOS
{
	class ClienteIOS : Database
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentPath, "homecheap.db3");

			return new SQLiteAsyncConnection(path);

		}

	}
}