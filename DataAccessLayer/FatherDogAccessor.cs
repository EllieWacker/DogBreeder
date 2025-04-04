using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;
using DataDomain;

namespace DataAccessLayer
{
    public class FatherDogAccessor : IFatherDogAccessor
    {
        public FatherDog SelectFatherDogByFatherDogID(string fatherDogID)
        {
            FatherDog fatherDog = null;

            // connection
            var conn = DBConnection.GetConnection();

            //command
            var cmd = new SqlCommand("sp_select_father_dog_by_fatherDogID", conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //parameters
            cmd.Parameters.Add("@FatherDogID", SqlDbType.NVarChar, 50);

            //values
            cmd.Parameters["@FatherDogID"].Value = fatherDogID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    fatherDog = new FatherDog()
                    {
                        FatherDogID = reader.GetString(0),
                        BreedID = reader.GetString(1),
                        Personality = reader.GetString(2),
                        EnergyLevel = reader.GetString(3),
                        BarkingLevel = reader.GetString(4),
                        Trainability = reader.GetString(5),
                        Image = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Description = reader.GetString(7),
                    };
                }
                else
                {
                    throw new ArgumentException("Father Dog record not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return fatherDog;
        }

    }



}
