using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Units
    {
        #region Member Variables

        private int intID = int.MinValue;
        private string strValue = string.Empty;    
        private Data objDataAccess = null;
        private DateTime dtDate = DateTime.MinValue;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "Unit.Unit"; }
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
        public DateTime Date
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        public string Value
        {
            get { return strValue; }
            set { strValue = value; }
        }
       

        #endregion

        #region Constructor
        public Units()
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
                objData.CreateNewStoredProcedure("Unit_GetbyID");
                objData.AddParameter("@ID", ID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["ID"])) this.ID = Convert.ToInt32(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Value"])) this.Value = Convert.ToString(reader["Value"]);                  
                    if (!Convert.IsDBNull(reader["InputTime"])) this.Date = Convert.ToDateTime(reader["InputTime"]);
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
                objData.CreateNewStoredProcedure("Unit_Insert");
                objData.AddParameter("@Value", this.Value);              
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
                objData.CreateNewStoredProcedure("Unit_update");
                objData.AddParameter("@ID", this.ID);
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
                objData.CreateNewStoredProcedure("Unit_Delete");
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
        public UnitsCollection Getlist(string textsearch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            UnitsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("Unit_Getlist");
                objData.AddParameter("@TextSearch",textsearch);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new UnitsCollection(); }
                    Units obj = new Units();
                    if (!Convert.IsDBNull(reader["ID"])) obj.ID = Convert.ToInt32(reader["ID"]);
                    if (!Convert.IsDBNull(reader["Value"])) obj.Value = Convert.ToString(reader["Value"]);
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
    public class UnitsCollection : System.Collections.CollectionBase
    {
        public Units this[int index]
        {
            get
            {
                return ((Units)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Units value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Units value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Units value)
        {
            List.Insert(index, value);
        }
        public void Remove(Units value)
        {
            List.Remove(value);
        }
        public bool Contains(Units value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Units))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
