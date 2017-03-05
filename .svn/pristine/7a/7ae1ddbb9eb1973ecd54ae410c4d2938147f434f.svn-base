using Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLFuniture
{
    public class Products
    {
        #region Member Variables
        private int intNewsID = int.MinValue;
        private int intCategoryID = int.MinValue;
        private int intCountViews = int.MinValue;
        private string strLink = string.Empty;        
        private string strTitle = string.Empty;
        private string strCategoryName = string.Empty;
        private string strProductCode = string.Empty;
        private string strImage = string.Empty;
        private string strDescription = string.Empty;
        private string strDetail = string.Empty;
        private string strImages = string.Empty;
        private bool bIsActived = false;
        private bool bIsMostSale = false;
        private Data objDataAccess = null;
        private DateTime dtDate = DateTime.MinValue;
        #endregion

        #region Properties
        /// <summary>
        /// The name of caching key
        /// </summary>
        public static string CacheKey
        {
            get { return "Product.Product"; }
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

        public int CategoryID
        {
            get { return intCategoryID; }
            set { intCategoryID = value; }
        }

        public int CountViews
        {
            get { return intCountViews; }
            set { intCountViews = value; }
        }

        public string ProductCode
        {
            get { return strProductCode; }
            set { strProductCode = value; }
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
        public string CategoryName
        {
            get { return strCategoryName; }
            set { strCategoryName = value; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        /// <summary>
        /// Detail
        /// </summary>
        public string Detail
        {
            get { return strDetail; }
            set { strDetail = value; }
        }
        public string Image
        {
            get { return strImage; }
            set { strImage = value; }
        }
        /// <summary>
        /// Links
        /// </summary>
        public string Links
        {
            get { return strLink; }
            set { strLink = value; }
        }
        
        public bool IsActived
        {
            get { return bIsActived; }
            set { bIsActived = value; }
        }

        public bool IsMostSale
        {
            get { return bIsMostSale; }
            set { bIsMostSale = value; }
        }
        public DateTime Date
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        #endregion

        #region Constructor
        public Products()
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
                objData.CreateNewStoredProcedure("sproc_Products_GetByNewsID");
                objData.AddParameter("@NewsID", NewsID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["NewsID"])) this.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["CategoryID"])) this.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) this.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Title"])) this.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Description"])) this.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) this.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) this.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) this.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) this.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) this.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) this.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    if (!Convert.IsDBNull(reader["countviews"])) this.CountViews = Convert.ToInt32(reader["countviews"]);
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
                objData.CreateNewStoredProcedure("sproc_Products_SetActived");
                objData.AddParameter("@NewsID", this.NewsID);
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
                objData.CreateNewStoredProcedure("sproc_Products_Add");
                objData.AddParameter("@ProductCode", this.ProductCode);
                objData.AddParameter("@Title", this.Title);
                objData.AddParameter("@CategoryID", this.CategoryID);
                objData.AddParameter("@Link", this.Links);                
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@Detail", this.Detail);
                objData.AddParameter("@Image", this.Image);
                objData.AddParameter("@Date", this.Date);
                objData.AddParameter("@Status", this.IsActived);
                objData.AddParameter("@IsMostSalte", this.IsMostSale);
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
                objData.CreateNewStoredProcedure("sproc_Products_Update");
                objData.AddParameter("@NewsID", this.NewsID);
                objData.AddParameter("@ProductCode", this.ProductCode);
                objData.AddParameter("@Title", this.Title);
                objData.AddParameter("@CategoryID", this.CategoryID);
                objData.AddParameter("@Link", this.Links);                
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@Detail", this.Detail);
                objData.AddParameter("@Image", this.Image);              
                objData.AddParameter("@Status", this.IsActived);
                objData.AddParameter("@IsMostSalte", this.IsMostSale);
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
                objData.CreateNewStoredProcedure("sproc_Products_Delete");
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

        public ProductsCollection GetListByCategoryID( int CategoryID,string textsearch)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Product_GetlistbyCategoryID");
                objData.AddParameter("@TextSearch", textsearch);
                objData.AddParameter("@CategoryID", CategoryID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["CategoryName"])) obj.CategoryName = Convert.ToString(reader["CategoryName"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    if (!Convert.IsDBNull(reader["countviews"])) obj.CountViews = Convert.ToInt32(reader["countviews"]);
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListByCategoryID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        public ProductsCollection GetListRelate(int CategoryID,int ProductID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Product_GetlistRelate");
                objData.AddParameter("@CategoryID", CategoryID);
                objData.AddParameter("@ProductID", ProductID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListRelate() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        public ProductsCollection GetListByParentID(int ParentID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_products_GetlistProductbyPatentID");
                objData.AddParameter("@ParentD", ParentID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["CategoryName"])) obj.CategoryName = Convert.ToString(reader["CategoryName"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListByParentID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        public ProductsCollection GetListTop()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Products_Get_Top");               
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]); 
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);                   
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                   
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListTop() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        public ProductsCollection GetListImagesProduct(int categoryID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_products_GetlistImageProductbyCategoryID");
                objData.AddParameter("@CategoryID", categoryID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListTop() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        public int UpdateCountViews(int ProductID)
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            int result = 0;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Products_UpdateCountViews");
                objData.AddParameter("@ProductID", ProductID);
                 result = Convert.ToInt32(objData.ExecStoreToString());
               
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListByParentID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return result;
        }


        public ProductsCollection GetListTopmost()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Products_most5");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    if (!Convert.IsDBNull(reader["countviews"])) obj.CountViews = Convert.ToInt32(reader["countviews"]);

                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListTop() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }

        public ProductsCollection GetListTopleast()
        {
            Data objData;
            if (objDataAccess == null)
                objData = new Data();
            else
                objData = objDataAccess;
            ProductsCollection col = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("sproc_Products_least5");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    if (col == null) { col = new ProductsCollection(); }
                    Products obj = new Products();

                    if (!Convert.IsDBNull(reader["CategoryID"])) obj.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    if (!Convert.IsDBNull(reader["NewsID"])) obj.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!Convert.IsDBNull(reader["ProductCode"])) obj.ProductCode = Convert.ToString(reader["ProductCode"]);
                    if (!Convert.IsDBNull(reader["Title"])) obj.Title = Convert.ToString(reader["Title"]);
                    if (!Convert.IsDBNull(reader["Description"])) obj.Description = Convert.ToString(reader["Description"]);
                    if (!Convert.IsDBNull(reader["Detail"])) obj.Detail = Convert.ToString(reader["Detail"]);
                    if (!Convert.IsDBNull(reader["Image"])) obj.Image = Convert.ToString(reader["Image"]);
                    if (!Convert.IsDBNull(reader["Link"])) obj.Links = Convert.ToString(reader["Link"]);
                    if (!Convert.IsDBNull(reader["Date"])) obj.Date = Convert.ToDateTime(reader["Date"]);
                    if (!Convert.IsDBNull(reader["Status"])) obj.IsActived = Convert.ToBoolean(reader["Status"]);
                    if (!Convert.IsDBNull(reader["IsMostSalte"])) obj.IsMostSale = Convert.ToBoolean(reader["IsMostSalte"]);
                    if (!Convert.IsDBNull(reader["countviews"])) obj.CountViews = Convert.ToInt32(reader["countviews"]);

                    col.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetListTop() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null) { objData.DeConnect(); }
            }
            return col;
        }
        

        #endregion
    }
    public class ProductsCollection : System.Collections.CollectionBase
    {
        public Products this[int index]
        {
            get
            {
                return ((Products)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }
        public int Add(Products value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Products value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Products value)
        {
            List.Insert(index, value);
        }
        public void Remove(Products value)
        {
            List.Remove(value);
        }
        public bool Contains(Products value)
        {
            return (List.Contains(value));
        }
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(Products))
                throw new ArgumentException("value must be of type DLLschool.category", "value");
        }
    }
}
