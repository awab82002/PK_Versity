using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassLibraryEntities;

namespace ClassLibraryDAL
{
    public class DALStudentInfo
    {


        public static string? Excep { get; set; }


        public static void SaveStudentInfo(EntStudentInfo ee)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveStudentInfo", con);
                cmd.Parameters.AddWithValue("@SID", ee.SID);
                cmd.Parameters.AddWithValue("@FirstName", ee.FirstName);
                cmd.Parameters.AddWithValue("@FatherName", ee.FatherName);
                cmd.Parameters.AddWithValue("@Gender", ee.Gender);
                cmd.Parameters.AddWithValue("@CNIC", ee.CNIC);
                cmd.Parameters.AddWithValue("@DateOfBirth", ee.DateOfBirth);
                cmd.Parameters.AddWithValue("@City", ee.City);
                cmd.Parameters.AddWithValue("@Address", ee.Address);
                cmd.Parameters.AddWithValue("@StudentMobileNo", ee.StudentMobileNo);
                cmd.Parameters.AddWithValue("@Email", ee.Email);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DalFilter.GetError(Excep);
            }
        }

        



    


    }



}

