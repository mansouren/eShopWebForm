using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class Products
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_Products_SelectAll", parameters, "Products");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int ProductID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("ProductID",ProductID) 
                };
            return dbo.RunProcedure("sp_Products_SelectRow", parameters, "Products");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int ProductGroupID,string ProductTitle,int ProductPrice,string ProductImageUrl,string ProductDescription)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("ProductGroupID",ProductGroupID),
					new SqlParameter("ProductTitle",ProductTitle),
					new SqlParameter("ProductPrice",ProductPrice),
					new SqlParameter("ProductImageUrl",ProductImageUrl),
					new SqlParameter("ProductDescription",ProductDescription) 
				};
			Result = dbo.RunProcedure("sp_Products_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int ProductID,int ProductGroupID,string ProductTitle,int ProductPrice,string ProductImageUrl,string ProductDescription)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("ProductID",ProductID),
					new SqlParameter("ProductGroupID",ProductGroupID),
					new SqlParameter("ProductTitle",ProductTitle),
					new SqlParameter("ProductPrice",ProductPrice),
					new SqlParameter("ProductImageUrl",ProductImageUrl),
					new SqlParameter("ProductDescription",ProductDescription) 
				};
			Result = dbo.RunProcedure("sp_Products_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int ProductID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("ProductID",ProductID) 
				};
			Result = dbo.RunProcedure("sp_Products_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}