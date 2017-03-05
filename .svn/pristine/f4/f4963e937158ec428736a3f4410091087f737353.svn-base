using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using tbhp.DataAccess;

namespace tbhp.DataAccess
{
	public class Settings
	{
		#region ***** Fields & Properties ***** 
		private string _Id;
		public string Id
		{ 
			get 
			{ 
				return _Id;
			}
			set 
			{ 
				_Id = value;
			}
		}
		private string _Type;
		public string Type
		{ 
			get 
			{ 
				return _Type;
			}
			set 
			{ 
				_Type = value;
			}
		}
		private string _Value;
		public string Value
		{ 
			get 
			{ 
				return _Value;
			}
			set 
			{ 
				_Value = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public Settings()
		{
		}
		public Settings(string id)
		{
			this.Id = id;
		}
		public Settings(string id, string type, string value)
		{
			this.Id = id;
			this.Type = type;
			this.Value = value;
		}
		#endregion

		#region ***** Get Methods ***** 
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Settings Populate(IDataReader myReader)
		{
			Settings obj = new Settings();
			obj.Id = (string) myReader["Id"];
			obj.Type = (string) myReader["Type"];
			obj.Value = (string) myReader["Value"];
			return obj;
		}

		/// <summary>
		/// Get Settings by id
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns>Settings</returns>
		public Settings GetById(string id)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Settings_GetById", Data.CreateParameter("Id", id)))			{
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
		/// Get all of Settings
		/// </summary>
		/// <returns>List<<Settings>></returns>
		public List<Settings> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Settings_Get"))
			{
				List<Settings> list = new List<Settings>();
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
		/// Get DataSet of Settings
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetDataSet()
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Settings_Get");
		}


		/// <summary>
		/// Get all of Settings paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>List<<Settings>></returns>
		public List<Settings> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Settings_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Settings> list = new List<Settings>();
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
		/// Get DataSet of Settings paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>DataSet</returns>
		public DataSet GetDataSetPaged(int recperpage, int pageindex)
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Settings_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex));
		}





		#endregion

		#region ***** Add Update Delete Methods ***** 
		/// <summary>
		/// Add a new Settings within Settings database table
		/// </summary>
		/// <param name="obj">Settings</param>
		/// <returns>key of table</returns>
		public int Add(Settings obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("Id", obj.Id);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Settings_Add"
							,parameterItemID
							,Data.CreateParameter("Type", obj.Type)
							,Data.CreateParameter("Value", obj.Value)
			);
			return 0;
		}

		/// <summary>
		/// updates the specified Settings
		/// </summary>
		/// <param name="obj">Settings</param>
		/// <returns></returns>
		public void Update(Settings obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Settings_Update"
							,Data.CreateParameter("Id", obj.Id)
							,Data.CreateParameter("Type", obj.Type)
							,Data.CreateParameter("Value", obj.Value)
			);
		}

		/// <summary>
		/// Delete the specified Settings
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		public void Delete(string id)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Settings_Delete", Data.CreateParameter("Id", id));
		}
		#endregion
	}
}
