using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using tbhp.DataAccess;

namespace tbhp.DataAccess
{
	public class News
	{
		#region ***** Fields & Properties ***** 
		private int _NewsID;
		public int NewsID
		{ 
			get 
			{ 
				return _NewsID;
			}
			set 
			{ 
				_NewsID = value;
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
		private string _Description;
		public string Description
		{ 
			get 
			{ 
				return _Description;
			}
			set 
			{ 
				_Description = value;
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
		private string _Image;
		public string Image
		{ 
			get 
			{ 
				return _Image;
			}
			set 
			{ 
				_Image = value;
			}
		}
		private DateTime _Date;
		public DateTime Date
		{ 
			get 
			{ 
				return _Date;
			}
			set 
			{ 
				_Date = value;
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
		#endregion

		#region ***** Init Methods ***** 
		public News()
		{
		}
		public News(int newsid)
		{
			this.NewsID = newsid;
		}
		public News(int newsid, string title, string description, string detail, string image, DateTime date, string link)
		{
			this.NewsID = newsid;
			this.Title = title;
			this.Description = description;
			this.Detail = detail;
			this.Image = image;
			this.Date = date;
			this.Link = link;
		}
		#endregion

		#region ***** Get Methods ***** 
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public News Populate(IDataReader myReader)
		{
			News obj = new News();
			obj.NewsID = (int) myReader["NewsID"];
			obj.Title = (string) myReader["Title"];
			obj.Description = (string) myReader["Description"];
			obj.Detail = (string) myReader["Detail"];
			obj.Image = (string) myReader["Image"];
			obj.Date = (DateTime) myReader["Date"];
			obj.Link = (string) myReader["Link"];
			return obj;
		}

		/// <summary>
		/// Get News by newsid
		/// </summary>
		/// <param name="newsid">NewsID</param>
		/// <returns>News</returns>
		public News GetByNewsID(int newsid)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_News_GetByNewsID", Data.CreateParameter("NewsID", newsid)))			{
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
		/// Get all of News
		/// </summary>
		/// <returns>List<<News>></returns>
		public List<News> GetList()
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_News_Get"))
			{
				List<News> list = new List<News>();
				while (reader.Read())
				{
				list.Add(Populate(reader));
				}
                reader.Close();
                reader.Dispose();
				return list;
			}
		}

        public List<News> GetListTop()
        {
            using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_News_GetlistTop"))
            {
                List<News> list = new List<News>();
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
		/// Get DataSet of News
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet GetDataSet()
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_News_Get");
		}


		/// <summary>
		/// Get all of News paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>List<<News>></returns>
		public List<News> GetListPaged(int recperpage, int pageindex)
		{
			using (IDataReader reader = SqlHelper.ExecuteReader(Data.ConnectionString, CommandType.StoredProcedure, "sproc_News_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex)))
			{
				List<News> list = new List<News>();
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
		/// Get DataSet of News paged
		/// </summary>
		/// <param name="recperpage">record per page</param>
		/// <param name="pageindex">page index</param>
		/// <returns>DataSet</returns>
		public DataSet GetDataSetPaged(int recperpage, int pageindex)
		{
			return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure,"sproc_News_GetPaged"
							,Data.CreateParameter("recperpage", recperpage)
							,Data.CreateParameter("pageindex", pageindex));
		}





		#endregion

		#region ***** Add Update Delete Methods ***** 
		/// <summary>
		/// Add a new News within News database table
		/// </summary>
		/// <param name="obj">News</param>
		/// <returns>key of table</returns>
		public int Add(News obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_News_Add"
							,Data.CreateParameter("Title", obj.Title)
							,Data.CreateParameter("Description", obj.Description)
							,Data.CreateParameter("Detail", obj.Detail)
							,Data.CreateParameter("Image", obj.Image)
							,Data.CreateParameter("Date", obj.Date)
							,Data.CreateParameter("Link", obj.Link)
			);
			return 0;
		}

		/// <summary>
		/// updates the specified News
		/// </summary>
		/// <param name="obj">News</param>
		/// <returns></returns>
		public void Update(News obj)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_News_Update"
							,Data.CreateParameter("NewsID", obj.NewsID)
							,Data.CreateParameter("Title", obj.Title)
							,Data.CreateParameter("Description", obj.Description)
							,Data.CreateParameter("Detail", obj.Detail)
							,Data.CreateParameter("Image", obj.Image)
							,Data.CreateParameter("Link", obj.Link)
			);
		}
		/// <summary>
		/// Delete the specified News
		/// </summary>
		/// <param name="newsid">NewsID</param>
		/// <returns></returns>
		public void Delete(int newsid)
		{
			SqlHelper.ExecuteNonQuery(Data.ConnectionString, CommandType.StoredProcedure,"sproc_News_Delete", Data.CreateParameter("NewsID", newsid));
		}
		#endregion
	}
}
