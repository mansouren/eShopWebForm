using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class Orders
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_Orders_SelectAll", parameters, "Orders");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int OrderID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("OrderID",OrderID) 
                };
            return dbo.RunProcedure("sp_Orders_SelectRow", parameters, "Orders");
        }

        public static int SelectSubTotal(int OrderID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("OrderID",OrderID) 
                };
            return
                Convert.ToInt32(
                    dbo.RunProcedure("sp_Orders_SelectSubTotal", parameters, "Orders").Tables["Orders"].Rows[0][
                        "SubTotal"]);

        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int UserID,DateTime OrderDate,bool Finalized)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("UserID",UserID),
					new SqlParameter("OrderDate",OrderDate),
					new SqlParameter("Finalized",Finalized) 
				};
			Result = dbo.RunProcedure("sp_Orders_Insert", parameters, out RowsAffected);
			return Result;
        }

        public static int AddProduct(int UserID, DateTime OrderDate, int ProductID, int ProductCount)
        {
            int RowsAffected = 0;
            int Result = 0;
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("UserID",UserID),
					new SqlParameter("OrderDate",OrderDate),
					new SqlParameter("ProductID",ProductID),
                    new SqlParameter("ProductCount",ProductCount)
				};
            Result = dbo.RunProcedure("sp_Orders_AddProduct", parameters, out RowsAffected);
            return Result;
        }

        public static int Finalize(int OrderID)
        {
            int RowsAffected = 0;
            int Result = 0;
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderID",OrderID)
				};
            Result = dbo.RunProcedure("sp_Orders_Finalize", parameters, out RowsAffected);
            return Result;
        }
		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int OrderID,int UserID,DateTime OrderDate,bool Finalized)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderID",OrderID),
					new SqlParameter("UserID",UserID),
					new SqlParameter("OrderDate",OrderDate),
					new SqlParameter("Finalized",Finalized) 
				};
			Result = dbo.RunProcedure("sp_Orders_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int OrderID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderID",OrderID) 
				};
			Result = dbo.RunProcedure("sp_Orders_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}