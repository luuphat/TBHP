﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using tbhp.DataAccess;

namespace tbhp.DataAccess
{
	public class Contents
	{
		#region ***** Fields & Properties ***** 
		private string _ID;
		public string ID
		{ 
			get 
			{ 
				return _ID;
			}
			set 
			{ 
				_ID = value;
			}
		}
		private string _Title;
		public string Title
		{ 
			get 
			{ 
				return _Title;
			}
			set 
			{ 
				_Title = value;
			}
		}
		private string _Detail;
		public string Detail
		{ 
			get 
			{ 
				return _Detail;
			}
			set 
			{ 
				_Detail = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public Contents()
		{
		}
		public Contents(string id)
		{
			this.ID = id;
		}
		public Contents(string id, string title, string detail)
		{
			this.ID = id;
			this.Title = title;
			this.Detail = detail;
		}
		#endregion

		#region ***** Get Methods ***** 
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Contents Populate(IDataReader myReader)
		{
			Contents obj = new Contents();
			obj.ID = (string) myReader["ID"];
			obj.Title = (string) myReader["Title"];
			obj.Detail = (string) myReader["Detail"];
			return obj;
		}

		/// <summary>
		/// Get Contents by id
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>Contents</returns>
		public Contents GetByID(string id)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Contents_GetByID", Data.CreateParameter("ID", id)))			{
				if (reader.Read())
				{
					return Populate(reader);
				}
                reader.Close();
                reader.Dispose();
				return null;
			}
		}

		/// <summary>
		/// Get all of Contents
		/// </summary>
		/// <returns>List<<Contents>></returns>
		public List<Contents> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Contents_Get"))
			{
				List<Contents> list = new List<Contents>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
                reader.Close();
                reader.Dispose();
				return list;
			}
		}

		/// <summary>
		/// Get DataSet of Contents
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetDataSet()
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Contents_Get");
		}


		/// <summary>
		/// Get all of Contents paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>List<<Contents>></returns>
		public List<Contents> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Contents_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Contents> list = new List<Contents>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
                reader.Close();
                reader.Dispose();
				return list;
			}
		}

		/// <summary>
		/// Get DataSet of Contents paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>DataSet</returns>
		public DataSet GetDataSetPaged(int recperpage, int pageindex)
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Contents_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex));
		}





		#endregion

		#region ***** Add Update Delete Methods ***** 
		/// <summary>
		/// Add a new Contents within Contents database table
		/// </summary>
		/// <param name="obj">Contents</param>
		/// <returns>key of table</returns>
		public int Add(Contents obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Contents_Add"
                            , Data.CreateParameter("ID", obj.ID)
							,Data.CreateParameter("Title", obj.Title)
							,Data.CreateParameter("Detail", obj.Detail)
			);
			return 0;
		}

		/// <summary>
		/// updates the specified Contents
		/// </summary>
		/// <param name="obj">Contents</param>
		/// <returns></returns>
		public void Update(Contents obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Contents_Update"
							,Data.CreateParameter("ID", obj.ID)
							,Data.CreateParameter("Title", obj.Title)
							,Data.CreateParameter("Detail", obj.Detail)
			);
		}

		/// <summary>
		/// Delete the specified Contents
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns></returns>
		public void Delete(string id)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Contents_Delete", Data.CreateParameter("ID", id));
		}
		#endregion
	}
}
