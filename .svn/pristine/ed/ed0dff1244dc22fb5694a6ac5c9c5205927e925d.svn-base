using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Img
    {
        #region Member Variables
        private int intImageID = int.MinValue;
        private int intProductID = int.MinValue;
        private string strImages = string.Empty;
        private int intSort = 0;
        private Data objDataAccess = null;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "Img.Img"; }
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
        public int ImageID
        {
            get { return intImageID; }
            set { intImageID = value; }
        }

        public int ProductID
        {
            get { return intProductID; }
            set { intProductID = value; }
        }
        /// <summary>
        /// CategoryName
        /// 
        /// </summary>
        public string Images
        {
            get { return strImages; }
            set { strImages = value; }
        }
       
        public int Sort
        {
            get { return intSort; }
            set { intSort = value; }
        }
        #endregion

        #region Constructor
        public Img()
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
        public bool GetByID(int ImageID)
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
                objData.CreateNewStoredProcedure("sproc_ProductImages_GetByImageID");
                objData.AddParameter("@ImageID", ImageID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {

                    if (!Convert.IsDBNull(reader["ImageID"])) this.ImageID = Convert.ToInt32(reader["ImageID"]);
                    if (!Convert.IsDBNull(reader["ProductID"])) this.ProductID = Convert.ToInt32(reader["ProductID"]);
                    if (!Convert.IsDBNull(reader["Images"])) this.Images = Convert.ToString(reader["Images"]);                
                    if (!Convert.IsDBNull(reader["Sort"])) this.Sort = Convert.ToInt32(reader["Sort"]);                    
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
                objData.CreateNewStoredProcedure("sproc_ProductImages_Add");
                objData.AddParameter("@Image", this.Images);
                objData.AddParameter("@ProductID", this.ProductID);
                objData.AddParameter("@Sort", this.Sort);
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
                objData.CreateNewStoredProcedure("sproc_ProductImages_Update");
                objData.AddParameter("@ImageID", this.ImageID);
                objData.AddParameter("@Image", this.Images);            
                objData.AddParameter("@Sort", this.Sort);
                objData.AddParameter("@ProductID", this.ProductID);             
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
        public bool Delete(int ImageID)
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
                objData.CreateNewStoredProcedure("sproc_ProductImages_Delete");
                objData.AddParameter("@ImageID", ImageID);
                if (objData.ExecStoreToString() != "0") { bolOK = true; }
            }
            catch (Exception objEx)
            {
                throw new Exception("Delete() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objData != null) { objData.DeConnect(); }
            }
            return bolOK;
        }
        ///<summary>
        /// Lấy tất cả đối tượng
        ///
        ///</summary>
        public ImgCollection Getlist(int ProductID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ImgCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_ProductImages_Getlist");
                objData.AddParameter("@ProductID", ProductID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ImgCollection(); }
                    Img obj = new Img();

                    if (!Convert.IsDBNull(reader["ImageID"])) obj.ImageID = Convert.ToInt32(reader["ImageID"]);
                    if (!Convert.IsDBNull(reader["ProductID"])) obj.ProductID = Convert.ToInt32(reader["ProductID"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Images = Convert.ToString(reader["Image"]);                   
                    if (!Convert.IsDBNull(reader["Sort"])) obj.Sort = Convert.ToInt32(reader["Sort"]);                    
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
    public class ImgCollection : System.Collections.CollectionBase
    {
        public Img this[int index]
        {
            get
            {
                return ((Img)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Img value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Img value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Img value)
        {
            List.Insert(index, value);
        }
        public void Remove(Img value)
        {
            List.Remove(value);
        }
        public bool Contains(Img value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Img))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
