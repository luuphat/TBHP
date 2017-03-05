using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class size
    {
        #region Member Variables

        private int intID = int.MinValue;
        private string strwidth = string.Empty;
        private string strheight = string.Empty;
        private Data objDataAccess = null;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "News.Users"; }
        }
        /// Đối tượng Data truyền từ ngoài vào
        /// </summary>
        public Data DataObject
        {
            get { return objDataAccess; }
            set { objDataAccess = value; }
        }
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }
        public string Width
        {
            get { return strwidth; }
            set { strwidth = value; }
        }
        /// <summary>
        /// Passwords
        /// </summary>
        public string Height
        {
            get { return strheight; }
            set { strheight = value; }
        }

        #endregion

        #region Constructor
        public size()
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
        public bool GetByID(int ID)
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
                objData.CreateNewStoredProcedure("size_GetbyID");
                objData.AddParameter("@ID", ID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["Width"])) this.Width = Convert.ToString(reader["Width"]);
                    if (!Convert.IsDBNull(reader["Height"])) this.Height = Convert.ToString(reader["Height"]);
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
                objData.CreateNewStoredProcedure("size_Insert");
                objData.AddParameter("@Width", this.Width);
                objData.AddParameter("@Height", this.Height);
                objTemp = objData.ExecStoreToString();
                if (objTemp == "") { objTemp = 1; }
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
                objData.CreateNewStoredProcedure("size_update");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@Width", this.Width);
                objData.AddParameter("@Height", this.Height);
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
        public bool Delete(int ID)
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
                objData.CreateNewStoredProcedure("size_deleted");
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
        ///<summary>
        /// Lấy tất cả đối tượng
        ///
        ///</summary>
        public sizeCollection GetAll()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            sizeCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("size_Getlist");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new sizeCollection(); }
                    size obj = new size();
                    if (!Convert.IsDBNull(reader["ID"])) obj.ID = Convert.ToInt32(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Width"])) obj.Width = Convert.ToString(reader["Width"]);
                    if (!Convert.IsDBNull(reader["Height"])) obj.Height = Convert.ToString(reader["Height"]);
               
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
    public class sizeCollection : System.Collections.CollectionBase
    {
        public size this[int index]
        {
            get
            {
                return ((size)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(size value)
        {
            return (List.Add(value));
        }
        public int IndexOf(size value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, size value)
        {
            List.Insert(index, value);
        }
        public void Remove(size value)
        {
            List.Remove(value);
        }
        public bool Contains(size value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(size))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
