using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Category
    {
        #region Member Variables
        private int intCategoryID = int.MinValue;
        private int intParentID = int.MinValue;
        private int intRandID = int.MinValue;
        private int intNewsID = int.MinValue;
        private string strCategoryName = string.Empty;
        private string strImages = string.Empty;
        private string strParentCategoryName = string.Empty;
        private string strLinks = string.Empty;
        private DateTime dtmInputTime = DateTime.MinValue;
        private bool bIsActived = false;
        private bool bIsDeleted = false;
        private string strUserCreated = string.Empty;
        private Data objDataAccess = null;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "News.Category"; }
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
        public int CategoryID
        {
            get { return intCategoryID; }
            set { intCategoryID = value; }
        }
        /// <summary>
        /// ParentID
        /// 
        /// </summary>
        public int ParentID
        {
            get { return intParentID; }
            set { intParentID = value; }
        }
        /// <summary>
        /// ParentID
        /// 
        /// </summary>
        public int RandID
        {
            get { return intRandID; }
            set { intRandID = value; }
        }
        public int NewsID
        {
            get { return intNewsID; }
            set { intNewsID = value; }
        }
        /// <summary>
        /// CategoryName
        /// 
        /// </summary>
        public string CategoryName
        {
            get { return strCategoryName; }
            set { strCategoryName = value; }
        }
        /// <summary>
        /// Links
        /// </summary>
        public string Links
        {
            get { return strLinks; }
            set { strLinks = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Images
        {
            get { return strImages; }
            set { strImages = value; }
        }

        /// <summary>
        /// CategoryName
        /// 
        /// </summary>
        public string ParentCategoryName
        {
            get { return strParentCategoryName; }
            set { strParentCategoryName = value; }
        }
        /// <summary>
        /// InputTime
        /// 
        /// </summary>
        public DateTime InputTime
        {
            get { return dtmInputTime; }
            set { dtmInputTime = value; }
        }
        public bool IsActived
        {
            get { return bIsActived; }
            set { bIsActived = value; }
        }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted
        {
            get { return bIsDeleted; }
            set { bIsDeleted = value; }
        }
        
        #endregion

        #region Constructor
        public Category()
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
        public bool GetByID(int CategoryID)
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
                objData.CreateNewStoredProcedure("Category_GetByID");
                objData.AddParameter("@CategoryID", CategoryID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {

                    if (!Convert.IsDBNull(reader["CategoryID"])) this.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["ParentID"])) this.ParentID = Convert.ToInt32(reader["ParentID"]);
                    if (!Convert.IsDBNull(reader["CategoryName"])) this.CategoryName = Convert.ToString(reader["CategoryName"]);
                    if (!Convert.IsDBNull(reader["Links"])) this.Links = Convert.ToString(reader["Links"]);
                    if (!Convert.IsDBNull(reader["Images"])) this.Images = Convert.ToString(reader["Images"]);
                    if (Convert.ToString(reader["ParentCategoryName"]) == null)
                    {
                        this.ParentCategoryName = Convert.ToString(reader["CategoryName"]); 
                    }
                    else
                    {
                        this.ParentCategoryName = Convert.ToString(reader["ParentCategoryName"]);
                    }
                    if (!Convert.IsDBNull(reader["IsActived"])) this.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!Convert.IsDBNull(reader["IsDeleted"])) this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!Convert.IsDBNull(reader["InputTime"])) this.InputTime = Convert.ToDateTime(reader["InputTime"]);
                    if (!Convert.IsDBNull(reader["RandID"])) this.RandID = Convert.ToInt32(reader["RandID"]);
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
        /// <summary>
        /// SetActived
        /// </summary>
        /// <returns></returns>
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
                objData.CreateNewStoredProcedure("Category_SetActived");
                objData.AddParameter("@CategoryID", this.CategoryID);
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
                objData.CreateNewStoredProcedure("Category_Insert");
                objData.AddParameter("@CategoryName", this.CategoryName);
                objData.AddParameter("@ParentID", this.ParentID);
                objData.AddParameter("@Links", this.Links);
                objData.AddParameter("@Images", this.Images);
                objData.AddParameter("@IsActived", this.IsActived);
                objData.AddParameter("@IsDeleted", this.IsDeleted);
                objData.AddParameter("@RandID", this.RandID);
                objTemp = objData.ExecStoreToString();
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
                objData.CreateNewStoredProcedure("Category_Update");
                objData.AddParameter("@CategoryID", this.CategoryID);
                objData.AddParameter("@CategoryName", this.CategoryName);
                objData.AddParameter("@Links", this.Links);
                objData.AddParameter("@Images", this.Images);
                objData.AddParameter("@ParentID", this.ParentID);
                objData.AddParameter("@IsActived", this.IsActived);
                objData.AddParameter("@RandID", this.RandID);
                objTemp = objData.ExecStoreToString();
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
        public bool Delete(int CategoryID)
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
                objData.CreateNewStoredProcedure("Category_Delete");
                objData.AddParameter("@CategoryID", CategoryID);
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
        public CategoryCollection GetAll(string sTextSearch, int CategoryID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            CategoryCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("Category_SelectAll");
                objData.AddParameter("@TextSearch", sTextSearch);
                objData.AddParameter("@CategoryID", CategoryID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new CategoryCollection(); }
                    Category obj = new Category();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["ParentID"])) obj.ParentID = Convert.ToInt32(reader["ParentID"]);
                    if (!Convert.IsDBNull(reader["CategoryName"])) obj.CategoryName = Convert.ToString(reader["CategoryName"]);
                    if (!Convert.IsDBNull(reader["ParentCategoryName"])) obj.ParentCategoryName = Convert.ToString(reader["ParentCategoryName"]);
                    if (!Convert.IsDBNull(reader["Links"])) obj.Links = Convert.ToString(reader["Links"]);
                    if (!Convert.IsDBNull(reader["Images"])) obj.Images = Convert.ToString(reader["Images"]);
                    if (!Convert.IsDBNull(reader["RandID"])) obj.RandID = Convert.ToInt32(reader["RandID"]);
                    if (!Convert.IsDBNull(reader["IsActived"])) obj.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!Convert.IsDBNull(reader["IsDeleted"])) obj.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
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

        public CategoryCollection GetlistParent()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            CategoryCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("Category_GetlistParent");

                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new CategoryCollection(); }
                    Category obj = new Category();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["ParentID"])) obj.ParentID = Convert.ToInt32(reader["ParentID"]);
                    if (!Convert.IsDBNull(reader["CategoryName"])) obj.CategoryName = Convert.ToString(reader["CategoryName"]);
                    if (!Convert.IsDBNull(reader["Links"])) obj.Links = Convert.ToString(reader["Links"]);
                    if (!Convert.IsDBNull(reader["Images"])) obj.Images = Convert.ToString(reader["Images"]);
                    if (!Convert.IsDBNull(reader["IsActived"])) obj.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!Convert.IsDBNull(reader["IsDeleted"])) obj.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!Convert.IsDBNull(reader["RandID"])) obj.RandID = Convert.ToInt32(reader["RandID"]);
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

        ///<summary>
        /// Lấy tất cả đối tượng
        ///
        ///</summary>
        public CategoryCollection Getlist(int parentid)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            CategoryCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("Category_Getsubmenu");
                objData.AddParameter("@ParentID", parentid);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new CategoryCollection(); }
                    Category obj = new Category();


                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["ParentID"])) obj.ParentID = Convert.ToInt32(reader["ParentID"]);
                    if (!Convert.IsDBNull(reader["CategoryName"])) obj.CategoryName = Convert.ToString(reader["CategoryName"]);
                    if (!Convert.IsDBNull(reader["Links"])) obj.Links = Convert.ToString(reader["Links"]);
                    if (!Convert.IsDBNull(reader["Images"])) obj.Images = Convert.ToString(reader["Images"]);
                    if (!Convert.IsDBNull(reader["RandID"])) obj.RandID = Convert.ToInt32(reader["RandID"]);
                    if (!Convert.IsDBNull(reader["IsActived"])) obj.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!Convert.IsDBNull(reader["IsDeleted"])) obj.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
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
    public class CategoryCollection : System.Collections.CollectionBase
    {
        public Category this[int index]
        {
            get
            {
                return ((Category)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Category value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Category value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Category value)
        {
            List.Insert(index, value);
        }
        public void Remove(Category value)
        {
            List.Remove(value);
        }
        public bool Contains(Category value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Category))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
