﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using tbhp.DataAccess;

namespace tbhp.DataAccess
{
	public class Types
	{
		#region ***** Fields & Properties ***** 
		private int _TypeID;
		public int TypeID
		{ 
			get 
			{ 
				return _TypeID;
			}
			set 
			{ 
				_TypeID = value;
			}
		}
		private string _TypeName;
		public string TypeName
		{ 
			get 
			{ 
				return _TypeName;
			}
			set 
			{ 
				_TypeName = value;
			}
		}
		private string _Link;
		public string Link
		{ 
			get 
			{ 
				return _Link;
			}
			set 
			{ 
				_Link = value;
			}
		}
		private bool _Status;
		public bool Status
		{ 
			get 
			{ 
				return _Status;
			}
			set 
			{ 
				_Status = value;
			}
		}
		private int _Sort;
		public int Sort
		{ 
			get 
			{ 
				return _Sort;
			}
			set 
			{ 
				_Sort = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public Types()
		{
		}
		public Types(int typeid)
		{
			this.TypeID = typeid;
		}
		public Types(int typeid, string typename, string link, bool status, int sort)
		{
			this.TypeID = typeid;
			this.TypeName = typename;
			this.Link = link;
			this.Status = status;
			this.Sort = sort;
		}
		#endregion

		#region ***** Get Methods ***** 
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Types Populate(IDataReader myReader)
		{
			Types obj = new Types();
			obj.TypeID = (int) myReader["TypeID"];
			obj.TypeName = (string) myReader["TypeName"];
			obj.Link = (string) myReader["Link"];
			obj.Status = (bool) myReader["Status"];
			obj.Sort = (int) myReader["Sort"];
			return obj;
		}

		/// <summary>
		/// Get Types by typeid
		/// </summary>
		/// <param name="typeid">TypeID</param>
		/// <returns>Types</returns>
		public Types GetByTypeID(int typeid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Types_GetByTypeID", Data.CreateParameter("TypeID", typeid)))			{
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
		/// Get all of Types
		/// </summary>
		/// <returns>List<<Types>></returns>
		public List<Types> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Types_Get"))
			{
				List<Types> list = new List<Types>();
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
		/// Get DataSet of Types
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetDataSet()
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Types_Get");
		}


		/// <summary>
		/// Get all of Types paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>List<<Types>></returns>
		public List<Types> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_Types_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<Types> list = new List<Types>();
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
		/// Get DataSet of Types paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>DataSet</returns>
		public DataSet GetDataSetPaged(int recperpage, int pageindex)
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Types_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex));
		}





		#endregion

		#region ***** Add Update Delete Methods ***** 
		/// <summary>
		/// Add a new Types within Types database table
		/// </summary>
		/// <param name="obj">Types</param>
		/// <returns>key of table</returns>
		public int Add(Types obj)
		{
			DbParameter parameterItemID = Data.CreateParameter("TypeID", obj.TypeID);
			parameterItemID.Direction = ParameterDirection.Output;
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Types_Add"
							,parameterItemID
							,Data.CreateParameter("TypeName", obj.TypeName)
							,Data.CreateParameter("Link", obj.Link)
							,Data.CreateParameter("Status", obj.Status)
							,Data.CreateParameter("Sort", obj.Sort)
			);
			return (int)parameterItemID.Value;
		}

		/// <summary>
		/// updates the specified Types
		/// </summary>
		/// <param name="obj">Types</param>
		/// <returns></returns>
		public void Update(Types obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Types_Update"
							,Data.CreateParameter("TypeID", obj.TypeID)
							,Data.CreateParameter("TypeName", obj.TypeName)
							,Data.CreateParameter("Link", obj.Link)
							,Data.CreateParameter("Status", obj.Status)
							,Data.CreateParameter("Sort", obj.Sort)
			);
		}

		/// <summary>
		/// Delete the specified Types
		/// </summary>
		/// <param name="typeid">TypeID</param>
		/// <returns></returns>
		public void Delete(int typeid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_Types_Delete", Data.CreateParameter("TypeID", typeid));
		}
		#endregion
	}
}
