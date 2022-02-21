using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class ProductGroups
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_ProductGroups_SelectAll", parameters, "ProductGroups");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int ProductGroupID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("ProductGroupID",ProductGroupID) 
                };
            return dbo.RunProcedure("sp_ProductGroups_SelectRow", parameters, "ProductGroups");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(string ProductGroupTitle,string ProductGroupImageUrl)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("ProductGroupTitle",ProductGroupTitle),
					new SqlParameter("ProductGroupImageUrl",ProductGroupImageUrl) 
				};
			Result = dbo.RunProcedure("sp_ProductGroups_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int ProductGroupID,string ProductGroupTitle,string ProductGroupImageUrl)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("ProductGroupID",ProductGroupID),
					new SqlParameter("ProductGroupTitle",ProductGroupTitle),
					new SqlParameter("ProductGroupImageUrl",ProductGroupImageUrl) 
				};
			Result = dbo.RunProcedure("sp_ProductGroups_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int ProductGroupID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("ProductGroupID",ProductGroupID) 
				};
			Result = dbo.RunProcedure("sp_ProductGroups_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}