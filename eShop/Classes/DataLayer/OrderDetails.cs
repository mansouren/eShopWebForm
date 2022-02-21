using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class OrderDetails
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_OrderDetails_SelectAll", parameters, "OrderDetails");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int OrderDetailID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("OrderDetailID",OrderDetailID) 
                };
            return dbo.RunProcedure("sp_OrderDetails_SelectRow", parameters, "OrderDetails");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int OrderID,int ProductID,int ProductCount)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderID",OrderID),
					new SqlParameter("ProductID",ProductID),
					new SqlParameter("ProductCount",ProductCount) 
				};
			Result = dbo.RunProcedure("sp_OrderDetails_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int OrderDetailID,int OrderID,int ProductID,int ProductCount)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderDetailID",OrderDetailID),
					new SqlParameter("OrderID",OrderID),
					new SqlParameter("ProductID",ProductID),
					new SqlParameter("ProductCount",ProductCount) 
				};
			Result = dbo.RunProcedure("sp_OrderDetails_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int OrderDetailID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderDetailID",OrderDetailID) 
				};
			Result = dbo.RunProcedure("sp_OrderDetails_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}