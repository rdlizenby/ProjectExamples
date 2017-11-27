using DVDLibrary.Data.InterfaceAndFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DVDLibrary.Data
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Delete(int dvd)
        {
                using (var cn = new SqlConnection(Settings.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("DvdDelete", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DvdId", dvd);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            
        }

        public IEnumerable<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId= (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public Dvd GetById(int DvdId)
        {
            Dvd dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", DvdId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId= (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            dvd.Notes = dr["Notes"].ToString();
                    }
                }
            }
            return dvd;
        }

        public IEnumerable<Dvd> GetBySearch(string category, string searchTerm)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSearchResults", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();

                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.ReleaseYear = (int)dr["ReleaseYear"];
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            row.Notes = dr["Notes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public void Insert(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId= (int)param.Value;
            }
        }

        public void Update(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
