using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class Pages
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_Pages_SelectAll", parameters, "Pages");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int PageID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("PageID",PageID) 
                };
            return dbo.RunProcedure("sp_Pages_SelectRow", parameters, "Pages");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int PageGroupID,string PageTitle,string PageText,DateTime PageDate)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PageGroupID",PageGroupID),
					new SqlParameter("PageTitle",PageTitle),
					new SqlParameter("PageText",PageText),
					new SqlParameter("PageDate",PageDate) 
				};
			Result = dbo.RunProcedure("sp_Pages_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int PageID,int PageGroupID,string PageTitle,string PageText,DateTime PageDate)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PageID",PageID),
					new SqlParameter("PageGroupID",PageGroupID),
					new SqlParameter("PageTitle",PageTitle),
					new SqlParameter("PageText",PageText),
					new SqlParameter("PageDate",PageDate) 
				};
			Result = dbo.RunProcedure("sp_Pages_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int PageID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PageID",PageID) 
				};
			Result = dbo.RunProcedure("sp_Pages_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}