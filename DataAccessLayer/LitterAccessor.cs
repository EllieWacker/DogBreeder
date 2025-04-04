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
    public class LitterAccessor : ILitterAccessor
    {
        public Litter SelectLitterByLitterID(string litterID)
        {
            Litter litter = null;

            // connection
            var conn = DBConnection.GetConnection();

            //command
            var cmd = new SqlCommand("sp_select_litter_by_litterID", conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //parameters
            cmd.Parameters.Add("@LitterID", SqlDbType.NVarChar, 50);

            //values
            cmd.Parameters["@LitterID"].Value = litterID;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    litter = new Litter()
                    {
                        LitterID = reader.GetString(0),
                        FatherDogID = reader.GetString(1),
                        MotherDogID = reader.GetString(2),
                        Image = reader.IsDBNull(2) ? null : reader.GetString(3),
                        DateOfBirth = reader.GetDateTime(4),
                        GoHomeDate = reader.GetDateTime(5),
                        NumberPuppies = reader.GetInt32(6)
                    };
                }
                else
                {
                    throw new ArgumentException("Litter record not found");
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

            return litter;
        }

        public List<Litter> SelectAllLitters()
        {
            List<Litter> litters = new List<Litter>();

            // connection
            var conn = DBConnection.GetConnection();

            //command
            var cmd = new SqlCommand("sp_select_all_litters", conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var litter = new Litter()
                        {
                            LitterID = reader.GetString(0),
                            FatherDogID = reader.GetString(1),
                            MotherDogID = reader.GetString(2),
                            Image = reader.IsDBNull(2) ? null : reader.GetString(3),
                            DateOfBirth = reader.GetDateTime(4),
                            GoHomeDate = reader.GetDateTime(5),
                            NumberPuppies = reader.GetInt32(6)
                        };
                        litters.Add(litter);
                    }
                }
                else
                {
                    throw new ArgumentException("Litter record not found");
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

            return litters;
        }

    }
}
