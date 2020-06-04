using System;
using System.Collections.Generic;
using System.Data;

namespace PokemonCollection
{
    public static class PokemonUnlokedDAO
    {
        public static List<PokemonUnlocked> getPokeUnlocked(int idJ)
        {
            string sql = "select po.pokedex, po.nombre, po.vida, po.danio_max, po.danio_min, ti.tipo " +
                         "from pokemon po, desbloqueados des, tipo_pokemon ti " +
                         $"where po.pokedex = des.pokedex and des.id_entrenador = {idJ} and " +
                         "po.id_tipo = ti.id_tipo";
            
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<PokemonUnlocked> unlockeds = new List<PokemonUnlocked>();
            
            foreach (DataRow row in dt.Rows)
            {
                PokemonUnlocked pU = new PokemonUnlocked();

                pU.Pokedex = Convert.ToInt32(row[0].ToString());
                pU.Name = row[1].ToString();
                pU.Life = Convert.ToInt32(row[2].ToString());
                pU.Max = Convert.ToInt32(row[3].ToString());
                pU.Min = Convert.ToInt32(row[4].ToString());
                pU.Type = row[5].ToString();
                
                unlockeds.Add(pU);
            }

            return unlockeds;
        }
        public static void AddPokemonUnlocked(int idP, int idJ)
        {
            string sql = String.Format(
                "INSERT INTO DESBLOQUEADOS(pokedex,id_entrenador) " + 
                $"VALUES({idP},{idJ})"
                );
            
            ConnectionBDD.ExecuteNonQuery(sql);
        }
    }
}