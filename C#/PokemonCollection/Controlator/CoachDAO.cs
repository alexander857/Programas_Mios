using System;
using System.Collections.Generic;
using System.Data;

namespace PokemonCollection
{
    public static class CoachDAO
    {
        public static List<Coach> getCoaches()
        {
            string sql = "SELECT * FROM ENTRENADOR";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<Coach> coaches = new List<Coach>();

            foreach (DataRow row in dt.Rows)
            {
                Coach c = new Coach();

                c.Id = Convert.ToInt32(row[0].ToString());
                c.Name = row[1].ToString();
                c.Password = row[2].ToString();
                c.Pokestars = Convert.ToInt32(row[3].ToString());
                c.Stars = Convert.ToInt32(row[4].ToString());
                c.Coins = Convert.ToInt32(row[5].ToString());
                c.Wins = Convert.ToInt32(row[6].ToString());
                c.Fails = Convert.ToInt32(row[7].ToString());
                
                coaches.Add(c);
            }

            return coaches;
        }
        
        //se consultal los datos del entrenador que esta en sesion
        public static Coach InfoCoach(int id)
        {
            string sql = $"SELECT * FROM ENTRENADOR WHERE id_Entrenador = {id}";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);

            Coach infoCoach = null;
            
            foreach (DataRow row in dt.Rows)
            {
                Coach c = new Coach();

                c.Id = Convert.ToInt32(row[0].ToString());
                c.Name = row[1].ToString();
                c.Password = row[2].ToString();
                c.Pokestars = Convert.ToInt32(row[3].ToString());
                c.Stars = Convert.ToInt32(row[4].ToString());
                c.Coins = Convert.ToInt32(row[5].ToString());
                c.Wins = Convert.ToInt32(row[6].ToString());
                c.Fails = Convert.ToInt32(row[7].ToString());
                
                infoCoach = new Coach(c.Name,c.Password,c.Pokestars,c.Stars,c.Coins,c.Wins,c.Fails);
            }

            return infoCoach;
        }

        //ingresar entrenador
        public static void AddCoach(Coach c)
        {
            string sql = String.Format(
                "INSERT INTO ENTRENADOR(nombre,contrasenia,pokestrellas,estrellas,monedas,victorias,derrotas) " +
                $"VALUES('{c.Name}','{c.Password}',{c.Pokestars},{c.Stars},{c.Coins},{c.Wins},{c.Fails})");
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
        
        //metodos de recompensas de los entrenadores
        public static int getPokestars() //pokestrellas
        {
            Random r = new Random();
            return r.Next(1, 3);
        }
        
        public static int getStars() //estrellas normales
        {
            Random ra = new Random();
            return ra.Next(1, 5);
        }
        
        public static int getCoins() //monedas de batalla
        {
            Random random = new Random();
            return random.Next(50, 201);
        }
        
        //metodos de modificar monedas, estrellas y pokestrellas del jugador
        public static void UpdatePokestrellas(int newCant, int idJ)
        {
            string sql = String.Format(
                $"UPDATE ENTRENADOR SET pokestrellas ={newCant} WHERE id_entrenador={idJ}"
                );
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
        
        public static void UpdateStars(int newCant, int idJ)
        {
            string sql = String.Format(
                $"UPDATE ENTRENADOR SET estrellas ={newCant} WHERE id_entrenador={idJ}"
            );
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
        
        public static void UpdateCoins(int newCant, int idJ)
        {
            string sql = String.Format(
                $"UPDATE ENTRENADOR SET monedas ={newCant} WHERE id_entrenador={idJ}"
            );
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
        
        //actualizar las victorias y derrotas
        public static void UpdateWins(int newWins, int idJ)
        {
            string sql = String.Format(
                $"UPDATE ENTRENADOR SET victorias ={newWins} WHERE id_entrenador={idJ}"
            );
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
        
        public static void UpdateFails(int newFail, int idJ)
        {
            string sql = String.Format(
                $"UPDATE ENTRENADOR SET derrotas ={newFail} WHERE id_entrenador={idJ}"
            );
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
    }
}