using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Settings
    {
        #region Member Variables
        private string strID = string.Empty;
        private string strType = string.Empty;
        private string strValue = string.Empty;
        private Data objDataAccess = null;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "Contents.Types"; }
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
        public string Type
        {
            get { return strType; }
            set { strType = value; }
        }
        /// <summary>
        /// Link
        /// </summary>
        public string Value
        {
            get { return strValue; }
            set { strValue = value; }
        }


        #endregion

        #region Constructor
        public Settings()
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
                objData.CreateNewStoredProcedure("sproc_Settings_GetById");
                objData.AddParameter("@ID", ID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["ID"])) this.ID = Convert.ToString(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Value"])) this.Value = Convert.ToString(reader["Value"]);
                    if (!Convert.IsDBNull(reader["Type"])) this.Type = Convert.ToString(reader["Type"]);
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
                objData.CreateNewStoredProcedure("sproc_Settings_Add");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@Type", this.Type);
                objData.AddParameter("@Value", this.Value);

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
                objData.CreateNewStoredProcedure("sproc_Settings_Update");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@Type", this.Type);
                objData.AddParameter("@Value", this.Value);
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
                objData.CreateNewStoredProcedure("sproc_Settings_Delete");
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
        public SettingsCollection Getlist(string sTextSearch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            SettingsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Settings_Get");
                objData.AddParameter("@TextSearch", sTextSearch);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new SettingsCollection(); }
                    Settings obj = new Settings();

                    if (!Convert.IsDBNull(reader["ID"])) obj.ID = Convert.ToString(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Type"])) obj.Type = Convert.ToString(reader["Type"]);
                    if (!Convert.IsDBNull(reader["Value"])) obj.Value = Convert.ToString(reader["Value"]);
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
    public class SettingsCollection : System.Collections.CollectionBase
    {
        public Settings this[int index]
        {
            get
            {
                return ((Settings)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Settings value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Settings value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Settings value)
        {
            List.Insert(index, value);
        }
        public void Remove(Settings value)
        {
            List.Remove(value);
        }
        public bool Contains(Settings value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Settings))
                throw new ArgumentException("value must be of type DLLFuniture.Types", "value");
        }
    }
}
