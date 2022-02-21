using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using NovinMedia.Data;

namespace DataLayer
{
    [DataObject(true)]
    public class Roles
    {
		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectAll()
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
 
                };
            return dbo.RunProcedure("sp_Roles_SelectAll", parameters, "Roles");
        }

		[DataObjectMethod(DataObjectMethodType.Fill)]
		public static DataSet SelectRow(int RoleID)
        {
            DbObject dbo = new DbObject();
            SqlParameter[] parameters = new SqlParameter[]
                {
					new SqlParameter("RoleID",RoleID) 
                };
            return dbo.RunProcedure("sp_Roles_SelectRow", parameters, "Roles");
        }

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertRow(int RoleID,string RoleTitle,string RoleName)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("RoleID",RoleID),
					new SqlParameter("RoleTitle",RoleTitle),
					new SqlParameter("RoleName",RoleName) 
				};
			Result = dbo.RunProcedure("sp_Roles_Insert", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Update)]
		public static int UpdateRow(int RoleID,string RoleTitle,string RoleName)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("RoleID",RoleID),
					new SqlParameter("RoleTitle",RoleTitle),
					new SqlParameter("RoleName",RoleName) 
				};
			Result = dbo.RunProcedure("sp_Roles_Update", parameters, out RowsAffected);
			return Result;
        }

		[DataObjectMethod(DataObjectMethodType.Delete)]
		public static int DeleteRow(int RoleID)
		{
			int RowsAffected = 0;
			int Result = 0;
			DbObject dbo = new DbObject();
			SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("RoleID",RoleID) 
				};
			Result = dbo.RunProcedure("sp_Roles_DeleteRow", parameters, out RowsAffected);
			return Result;
        }
    }
}