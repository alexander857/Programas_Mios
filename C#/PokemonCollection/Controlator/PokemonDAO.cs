using System;
using System.Collections.Generic;
using System.Data;

namespace PokemonCollection
{
    public static class PokemonDAO
    {
        public static List<Pokemon> getPokemons()
        {
            string sql = "select po.pokedex, po.nombre, po.vida, po.danio_max, po.danio_min, po.valor, ti.tipo " +
            "from pokemon po, tipo_pokemon ti\nwhere po.id_tipo = ti.id_tipo";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (DataRow row in dt.Rows)
            {
                Pokemon p = new Pokemon();

                p.Pokedex = Convert.ToInt32(row[0].ToString());
                p.Name = row[1].ToString();
                p.Life = Convert.ToInt32(row[2].ToString());
                p.Max = Convert.ToInt32(row[3].ToString());
                p.Min = Convert.ToInt32(row[4].ToString());
                p.Value = Convert.ToInt32(row[5].ToString());
                p.Type = row[6].ToString();
                
                pokemons.Add(p);
            }

            return pokemons;
        }
        
        //metodo para consultar los pokemon por tipo
        public static List<Pokemon> getPokemonsByType(string type)
        {
            string sql = "select po.pokedex, po.nombre, po.vida, po.danio_max, po.danio_min, po.valor, ti.tipo " +
                         $"from pokemon po, tipo_pokemon ti\nwhere po.id_tipo = ti.id_tipo and ti.tipo = '{type}'";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (DataRow row in dt.Rows)
            {
                Pokemon p = new Pokemon();

                p.Pokedex = Convert.ToInt32(row[0].ToString());
                p.Name = row[1].ToString();
                p.Life = Convert.ToInt32(row[2].ToString());
                p.Max = Convert.ToInt32(row[3].ToString());
                p.Min = Convert.ToInt32(row[4].ToString());
                p.Value = Convert.ToInt32(row[5].ToString());
                p.Type = row[6].ToString();
                
                pokemons.Add(p);
            }
            return pokemons;
        }
        
        //se consultan los pokemons por el tipo para las pokebolas
        public static List<Pokemon> getPokemonsToPokebolas(int type)
        {
            string sql = "select po.pokedex, po.nombre, po.vida, po.danio_max, po.danio_min, po.valor, ti.tipo " +
                         $"from pokemon po, tipo_pokemon ti\nwhere po.id_tipo = ti.id_tipo and ti.id_tipo = '{type}'";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (DataRow row in dt.Rows)
            {
                Pokemon p = new Pokemon();

                p.Pokedex = Convert.ToInt32(row[0].ToString());
                p.Name = row[1].ToString();
                p.Life = Convert.ToInt32(row[2].ToString());
                p.Max = Convert.ToInt32(row[3].ToString());
                p.Min = Convert.ToInt32(row[4].ToString());
                p.Value = Convert.ToInt32(row[5].ToString());
                p.Type = row[6].ToString();
                
                pokemons.Add(p);
            }
            return pokemons;
        }
        
    }
}