﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppHomeCheap
{
	public interface Database
	{
		SQLiteAsyncConnection GetConnection();
	}
}
