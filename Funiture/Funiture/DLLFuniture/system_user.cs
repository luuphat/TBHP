using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class system_user
    {
        #region Member Variables

        private int intID = int.MinValue;
        private string strUserName = string.Empty;
        private string strPasswords = string.Empty;
        private Data objDataAccess = null;
        private DateTime dtDate = DateTime.MinValue;
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

        public string UserName
        {
            get { return strUserName; }
            set { strUserName = value; }
        }
        /// <summary>
        /// Passwords
        /// </summary>
        public string Passwords
        {
            get { return strPasswords; }
            set { strPasswords = value; }
        }

        public DateTime InputTime
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        #endregion

        #region Constructor
        public system_user()
        {
            //Nothing
        }
        #endregion

        #region Method
        ///<summary>
        ///Lấy đối tượng theo id
        ///</summary>
        /// <param name="CategoryID">ID của đối tượng </param>
        /// <returns></returns>
        /// 

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
                objData.CreateNewStoredProcedure("sproc_sys_Users_GetByID");
                objData.AddParameter("@ID", ID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["ID"])) this.ID = Convert.ToInt32(reader["ID"]);            
                    if (!Convert.IsDBNull(reader["UserName"])) this.UserName = Convert.ToString(reader["UserName"]);                
                    if (!Convert.IsDBNull(reader["Passwords"])) this.Passwords = Convert.ToString(reader["Passwords"]);               
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
       
        public string ChangePass(string username,string oldpassword, string newpassword)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            string  objTemp = "0";
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_sys_User_ChangePassword");
                objData.AddParameter("@Username", username);
                objData.AddParameter("@Passwords", oldpassword);
                objData.AddParameter("@PasswordNew", newpassword);
                objTemp = objData.ExecStoreToString();
               
            }
            catch (Exception objEx)
            {
                throw new Exception("ChangePass() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return objTemp;
        }

        public string ForgotPass(string username, string password)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            string objtemp = "0";
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_sys_user_Forgotpass");
                objData.AddParameter("@UserName", username);
                objData.AddParameter("@Passwords", password);
                objtemp = objData.ExecStoreToString();
                if (objtemp == "") { objtemp = "1"; }
            }
            catch (Exception objEx)
            {
                throw new Exception("ForgotPass() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return objtemp;
        }


        public bool Login(string username, string password)
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
                objData.CreateNewStoredProcedure("sproc_sys_user_LoginNew");
                objData.AddParameter("@UserName", username);
                objData.AddParameter("@Passwords", password);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {                  
                    if (!Convert.IsDBNull(reader["UserName"])) this.UserName = Convert.ToString(reader["UserName"]);
                    if (!Convert.IsDBNull(reader["Passwords"])) this.Passwords = Convert.ToString(reader["Passwords"]);                    
                    bolOK = true;
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("Login() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
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
                objData.CreateNewStoredProcedure("sproc_sys_Users_Add");
                objData.AddParameter("@UserName", this.UserName);
                objData.AddParameter("@Passwords", this.Passwords);               
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
                objData.CreateNewStoredProcedure("sproc_sys_Users_Update");
                objData.AddParameter("@ID", this.ID);
                objData.AddParameter("@UserName", this.UserName);
                objData.AddParameter("@Passwords", this.Passwords);              
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
                objData.CreateNewStoredProcedure("sproc_sys_Users_Deleted");
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
        public system_UsersCollection GetAll()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            system_UsersCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("Users_SelectAll");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new system_UsersCollection(); }
                    system_user obj = new system_user();
                    if (!Convert.IsDBNull(reader["ID"])) obj.ID = Convert.ToInt32(reader["ID"]);
                    if (!Convert.IsDBNull(reader["UserName"])) obj.UserName = Convert.ToString(reader["UserName"]);
                    if (!Convert.IsDBNull(reader["Passwords"])) obj.Passwords = Convert.ToString(reader["Passwords"]);
                    if (!Convert.IsDBNull(reader["InputTime"])) obj.InputTime = Convert.ToDateTime(reader["InputTime"]);
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

        public system_UsersCollection Getlist(string stextsarch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            system_UsersCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_sys_User_Getlist");
                objData.AddParameter("@TextSearch", stextsarch);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new system_UsersCollection(); }
                    system_user obj = new system_user();
                    if (!Convert.IsDBNull(reader["ID"])) obj.ID = Convert.ToInt32(reader["ID"]);
                    if (!Convert.IsDBNull(reader["UserName"])) obj.UserName = Convert.ToString(reader["UserName"]);
                    if (!Convert.IsDBNull(reader["Passwords"])) obj.Passwords = Convert.ToString(reader["Passwords"]);
                    if (!Convert.IsDBNull(reader["InputTime"])) obj.InputTime = Convert.ToDateTime(reader["InputTime"]);
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
    public class system_UsersCollection : System.Collections.CollectionBase
    {
        public system_user this[int index]
        {
            get
            {
                return ((system_user)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(system_user value)
        {
            return (List.Add(value));
        }
        public int IndexOf(system_user value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, system_user value)
        {
            List.Insert(index, value);
        }
        public void Remove(system_user value)
        {
            List.Remove(value);
        }
        public bool Contains(system_user value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(system_user))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
