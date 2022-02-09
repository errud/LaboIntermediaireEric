using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_MovieManager.Models
{
    public class FilmCollection
    {
        public int IdFilm { get; set; }
        public int IdUser { get; set; }
        public byte Favori { get; set; }
        public byte Corbeille { get; set; }      

        public static FilmCollection Converter3(SqlDataReader reader)
        {
            return new FilmCollection
            {
                IdFilm = (int)reader["Id_Film"],
                IdUser = (int)reader["Id_User"],
                Favori = (byte)reader["Favori"],
                Corbeille = (byte)reader["Corbeille"]               
            };
        }

       
    }
}
