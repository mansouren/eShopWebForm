using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class PaymentLogs
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_PaymentLogs_SelectAll", parameters, "PaymentLogs");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int PaymentLogID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("PaymentLogID",PaymentLogID) 
                };
            return dbo.RunProcedure("sp_PaymentLogs_SelectRow", parameters, "PaymentLogs");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int OrderID,string TrackingCode,string ResponseCode,string ResponseMessage,bool IsSuccessful,DateTime PaymentDate)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("OrderID",OrderID),
					new SqlParameter("TrackingCode",TrackingCode),
					new SqlParameter("ResponseCode",ResponseCode),
					new SqlParameter("ResponseMessage",ResponseMessage),
					new SqlParameter("IsSuccessful",IsSuccessful),
					new SqlParameter("PaymentDate",PaymentDate) 
				};
			Result = dbo.RunProcedure("sp_PaymentLogs_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int PaymentLogID,int OrderID,string TrackingCode,string ResponseCode,string ResponseMessage,bool IsSuccessful,DateTime PaymentDate)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PaymentLogID",PaymentLogID),
					new SqlParameter("OrderID",OrderID),
					new SqlParameter("TrackingCode",TrackingCode),
					new SqlParameter("ResponseCode",ResponseCode),
					new SqlParameter("ResponseMessage",ResponseMessage),
					new SqlParameter("IsSuccessful",IsSuccessful),
					new SqlParameter("PaymentDate",PaymentDate) 
				};
			Result = dbo.RunProcedure("sp_PaymentLogs_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int PaymentLogID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PaymentLogID",PaymentLogID) 
				};
			Result = dbo.RunProcedure("sp_PaymentLogs_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}