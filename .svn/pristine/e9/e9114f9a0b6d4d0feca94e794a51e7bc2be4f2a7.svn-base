using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Types
    {
        #region Member Variables
        private int intTypeID = int.MinValue;
        private string strTypeName = string.Empty;
        //private DateTime dtmInputTime = DateTime.MinValue;
        private bool bIsActived = false;
        private string strSort = string.Empty;
        private string strLink = string.Empty;
        private Data objDataAccess = null;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "Finiture.Types"; }
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
        public int TypeID
        {
            get { return intTypeID; }
            set { intTypeID = value; }
        }

        /// <summary>
        /// TypeName
        /// 
        /// </summary>
        public string TypeName
        {
            get { return strTypeName; }
            set { strTypeName = value; }
        }
        /// <summary>
        /// Link
        /// </summary>
        public string Link
        {
            get { return strLink; }
            set { strLink = value; }
        }
        /// <summary>
        /// IsActived
        /// </summary>
        public bool IsActived
        {
            get { return bIsActived; }
            set { bIsActived = value; }
        }
        /// <summary>
        /// Sort
        /// </summary>
        public string Sort
        {
            get { return strSort; }
            set { strSort = value; }
        }
        /// <summary>
        /// InputTime
        /// 
        /// </summary>
        //public DateTime InputTime
        //{
        //    get { return dtmInputTime; }
        //    set { dtmInputTime = value; }
        //}
      
        #endregion

        #region Constructor
        public Types()
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
        public bool GetByID(int TypeID)
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
                objData.CreateNewStoredProcedure("sproc_Types_GetByTypeID");
                objData.AddParameter("@TypeID", TypeID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["TypeID"])) this.TypeID = Convert.ToInt32(reader["TypeID"]);
                    if (!Convert.IsDBNull(reader["TypeName"])) this.TypeName = Convert.ToString(reader["TypeName"]);
                    if (!Convert.IsDBNull(reader["Sort"])) this.Sort = Convert.ToString(reader["Sort"]);
                    if (!Convert.IsDBNull(reader["Link"])) this.Link = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Status"])) this.IsActived = Convert.ToBoolean(reader["Status"]);
                    //if (!Convert.IsDBNull(reader["InputTime"])) this.InputTime = Convert.ToDateTime(reader["InputTime"]);                   
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
                objData.CreateNewStoredProcedure("sproc_Types_Add");            
                objData.AddParameter("@TypeName", this.TypeName);
                objData.AddParameter("@Link", this.Link);
                objData.AddParameter("@Sort", this.Sort);
                objData.AddParameter("@Status", this.IsActived);
                objTemp =Convert.ToInt32(objData.ExecStoreToString());
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
                objData.CreateNewStoredProcedure("sproc_Types_Update");
                objData.AddParameter("@TypeID", this.TypeID);
                objData.AddParameter("@TypeName", this.TypeName);
                objData.AddParameter("@Link", this.Link);
                objData.AddParameter("@Sort", this.Sort);
                objData.AddParameter("@Status", this.IsActived);

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
        public bool Delete(int TypeID)
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
                objData.CreateNewStoredProcedure("sproc_Types_Delete");
                objData.AddParameter("@TypeID", TypeID);
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

        public bool SetActived()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            bool bolOK = true;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Types_SetActived");
                objData.AddParameter("@TypeID", this.TypeID);
                objData.AddParameter("@IsActived", this.IsActived);
                if (objData.ExecStoreToString() == "0") { bolOK = false; }
            }
            catch (Exception objEx)
            {
                throw new Exception("SetActived() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return bolOK;
        }
        ///<summary>
        /// Lấy tất cả đối tượng
        ///
        ///</summary>
        public TypesCollection GetAll()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            TypesCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Types_Get");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new TypesCollection(); }
                    Types obj = new Types();

                    if (!Convert.IsDBNull(reader["TypeID"])) obj.TypeID = Convert.ToInt32(reader["TypeID"]);
                    if (!Convert.IsDBNull(reader["TypeName"])) obj.TypeName = Convert.ToString(reader["TypeName"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Link = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Sort"])) obj.Sort = Convert.ToString(reader["Sort"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
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

        ///<summary>
        /// Lấy tất cả đối tượng
        ///
        ///</summary>
        public TypesCollection Getlist(string sTextSearch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            TypesCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Types_Getlist");
                objData.AddParameter("@TextSearch", sTextSearch);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new TypesCollection(); }
                    Types obj = new Types();

                    if (!Convert.IsDBNull(reader["TypeID"])) obj.TypeID = Convert.ToInt32(reader["TypeID"]);
                    if (!Convert.IsDBNull(reader["TypeName"])) obj.TypeName = Convert.ToString(reader["TypeName"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Link = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Sort"])) obj.Sort = Convert.ToString(reader["Sort"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);

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
    public class TypesCollection : System.Collections.CollectionBase
    {
        public Types this[int index]
        {
            get
            {
                return ((Types)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Types value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Types value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Types value)
        {
            List.Insert(index, value);
        }
        public void Remove(Types value)
        {
            List.Remove(value);
        }
        public bool Contains(Types value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Types))
                throw new ArgumentException("value must be of type DLLFuniture.Types", "value");
        }
    }
}
