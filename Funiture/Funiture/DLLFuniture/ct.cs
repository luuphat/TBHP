using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class ct
    {
        #region Member Variables
        private string strID = string.Empty;
        private string strTitle = string.Empty;
        private string strDetail = string.Empty;
        private Data objDataAccess = null;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "ct.Types"; }
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
        public string ID
        {
            get { return strID; }
            set { strID = value; }
        }

        /// <summary>
        /// TypeName
        /// 
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }
        /// <summary>
        /// Link
        /// </summary>
        public string Detail
        {
            get { return strDetail; }
            set { strDetail = value; }
        }
       

        #endregion

        #region Constructor
        public ct()
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
        public bool GetByID(string ID)
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
                objData.CreateNewStoredProcedure("sproc_Contents_GetByID");
                objData.AddParameter("@ID", ID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["ID"])) this.ID = Convert.ToString(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Title"])) this.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Detail"])) this.Detail = Convert.ToString(reader["Detail"]);                              
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
        public int Add()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            int objTemp = 0;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Contents_Add");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@Title", this.Title);
                objData.AddParameter("@Detail", this.Detail);
             
                objTemp = Convert.ToInt32(objData.ExecStoreToString());
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
                objData.CreateNewStoredProcedure("sproc_Contents_Update");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@Title", this.Title);
                objData.AddParameter("@Detail", this.Detail);              
                objTemp = objData.ExecStoreToString();
                if (objTemp == "") { objTemp = 1; }
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
        public bool Delete(string ID)
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
                objData.CreateNewStoredProcedure("sproc_Contents_Delete");
                objData.AddParameter("@ID", ID);
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

        /// Lấy tất cả đối tượng
        ///
        ///</summary>
        public ctCollection Getlist(string sTextSearch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ctCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Contents_Get");
                objData.AddParameter("@TextSearch", sTextSearch);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ctCollection(); }
                    ct obj = new ct();

                    if (!Convert.IsDBNull(reader["ID"])) obj.ID = Convert.ToString(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);                 
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("Getlist() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        #endregion
    }
    public class ctCollection : System.Collections.CollectionBase
    {
        public ct this[int index]
        {
            get
            {
                return ((ct)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(ct value)
        {
            return (List.Add(value));
        }
        public int IndexOf(ct value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, ct value)
        {
            List.Insert(index, value);
        }
        public void Remove(ct value)
        {
            List.Remove(value);
        }
        public bool Contains(ct value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(ct))
                throw new ArgumentException("value must be of type DLLFuniture.Types", "value");
        }
    }
}
