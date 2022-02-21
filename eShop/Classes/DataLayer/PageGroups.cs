using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class PageGroups
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_PageGroups_SelectAll", parameters, "PageGroups");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int PageGroupID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("PageGroupID",PageGroupID) 
                };
            return dbo.RunProcedure("sp_PageGroups_SelectRow", parameters, "PageGroups");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(string PageGroupTitle)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PageGroupTitle",PageGroupTitle) 
				};
			Result = dbo.RunProcedure("sp_PageGroups_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int PageGroupID,string PageGroupTitle)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PageGroupID",PageGroupID),
					new SqlParameter("PageGroupTitle",PageGroupTitle) 
				};
			Result = dbo.RunProcedure("sp_PageGroups_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int PageGroupID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("PageGroupID",PageGroupID) 
				};
			Result = dbo.RunProcedure("sp_PageGroups_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}