using System;
using System.Collections.Generic;
using System.Data;

namespace PokemonCollection
{
    public static class TypePokemonDAO
    {
        public static List<TypePokemon> getTypePokemons()
        {
            string sql = "SELECT * FROM TIPO_POKEMON";

            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<TypePokemon> typesP = new List<TypePokemon>();

            foreach (DataRow row in dt.Rows)
            {
                TypePokemon tP = new TypePokemon();

                tP.IdT = Convert.ToInt32(row[0].ToString());
                tP.TipoP = row[1].ToString();
                
                typesP.Add(tP);
            }

            return typesP;
        }
    }
}