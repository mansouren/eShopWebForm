using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class PaymentUniqueNumbers
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_PaymentUniqueNumbers_SelectAll", parameters, "PaymentUniqueNumbers");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int PaymentUniqueNumberID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("PaymentUniqueNumberID",PaymentUniqueNumberID) 
                };
            return dbo.RunProcedure("sp_PaymentUniqueNumbers_SelectRow", parameters, "PaymentUniqueNumbers");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int OrderID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderID",OrderID) 
				};
			Result = dbo.RunProcedure("sp_PaymentUniqueNumbers_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int PaymentUniqueNumberID,int OrderID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PaymentUniqueNumberID",PaymentUniqueNumberID),
					new SqlParameter("OrderID",OrderID) 
				};
			Result = dbo.RunProcedure("sp_PaymentUniqueNumbers_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int PaymentUniqueNumberID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PaymentUniqueNumberID",PaymentUniqueNumberID) 
				};
			Result = dbo.RunProcedure("sp_PaymentUniqueNumbers_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}