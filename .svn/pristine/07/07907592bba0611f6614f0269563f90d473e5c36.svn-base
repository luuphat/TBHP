using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Footer
    {
        #region Member Variables
        private int intNewsID = int.MinValue;
        private string strTitle = string.Empty;
        private string strImage = string.Empty;
        private string strDescription = string.Empty;
      
        private Data objDataAccess = null;        
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "Footer.Footer"; }
        }
        /// Đối tượng Data truyền từ ngoài vào
        /// </summary>
        public Data DataObject
        {
            get { return objDataAccess; }
            set { objDataAccess = value; }
        }
        /// <summary>
        /// CategoryID
        /// 
        /// </summary>
        public int NewsID
        {
            get { return intNewsID; }
            set { intNewsID = value; }
        }

       
        /// <summary>
        /// Title
        /// 
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
       
        public string Image
        {
            get { return strImage; }
            set { strImage = value; }
        }
       
        #endregion

        #region Constructor
        public Footer()
        {
            //Nothing
        }
        #endregion

        #region Methods
        ///<summary>
        ///Lấy đối tượng theo id
        ///</summary>
        /// <param name="CategoryID">ID của đối tượng </param>
        /// <returns></returns>
        public bool GetByID(int NewsID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            bool bolOK = false;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Footer_GetByNewsID");
                objData.AddParameter("@NewsID", NewsID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["NewsID"])) this.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["Title"])) this.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Description"])) this.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Image"])) this.Image = Convert.ToString(reader["Image"]);
                    bolOK = true;
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetByID() Error: " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return bolOK;
        }
       
        ///<summary>
        /// Thêm mới đối tượng
        /// Có các trường: ParentID, CategoryName
        /// Trả về mã lỗi. Mặc định là 0 - không lỗi
        ///</summary>
        ///<param name="obj">Đối tượng cần thêm</param>
        ///<returns></returns>
        public object Add()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            object objTemp = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Footer_Add");
                objData.AddParameter("@Title", this.Title);
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@Image", this.Image);
                objTemp = objData.ExecStoreToString();
                if (objTemp == "") { objTemp = "1"; }
            }
            catch (Exception objEx)
            {
                throw new Exception("Insert() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return objTemp;
        }
        ///<summary>
        /// Cập nhật đối tượng
        /// Có các trường: CategoryID, ParentID, CategoryName
        /// Trả về mã lỗi. Mặc định là 0 - không lỗi
        ///</summary>
        ///<param name="obj">Đối tượng cần cập nhật</param>
        ///<returns></returns>
        public object Update()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            object objTemp = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Footer_Update");
                objData.AddParameter("@NewsID", this.NewsID);
                objData.AddParameter("@Title", this.Title);
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@Image", this.Image);
                objTemp = objData.ExecStoreToString();
                if (objTemp == "") { objTemp = "1"; }
            }
            catch (Exception objEx)
            {
                throw new Exception("Update() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return objTemp;
        }
        ///<summary>
        /// Xóa đối tượng
        /// Có các trường: CategoryID
        ///</summary>
        ///<param name="CategoryID">ID của đối tượng</param>
        ///<param name="UserDeleted">Người xóa</param>
        ///<returns></returns>
        public bool Delete(int NewsID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            bool bolOK = false;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Footer_Delete");
                objData.AddParameter("@NewsID", NewsID);
                if (objData.ExecStoreToString() != "0") { bolOK = true; }
            }
            catch (Exception objEx)
            {
                throw new Exception("Delete() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return bolOK;
        }
        ///<summary>
        /// Lấy tất cả đối tượng
        ///
        ///</summary>      

        public FooterCollection GetList(string textsearch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            FooterCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Footer_Get");
                objData.AddParameter("@Textsearch", textsearch);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new FooterCollection(); }
                    Footer obj = new Footer();

                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetAll() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        #endregion
    }
    public class FooterCollection : System.Collections.CollectionBase
    {
        public Footer this[int index]
        {
            get
            {
                return ((Footer)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Footer value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Footer value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Footer value)
        {
            List.Insert(index, value);
        }
        public void Remove(Footer value)
        {
            List.Remove(value);
        }
        public bool Contains(Footer value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Footer))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
