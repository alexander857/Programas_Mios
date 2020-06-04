using System;
using System.Collections.Generic;
using System.Data;

namespace PokemonCollection
{
    public static class TypePokebolaDAO
    {
        public static List<TypePokebola> getTypePokebolas()
        {
            string sql = "SELECT * FROM TIPO_POKEBOLA";
            
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<TypePokebola> type = new List<TypePokebola>();

            foreach (DataRow row in dt.Rows)
            {
                TypePokebola tP = new TypePokebola();

                tP.Id = Convert.ToInt32(row[0].ToString());
                tP.TipoP = row[1].ToString();
                
                type.Add(tP);
            }

            return type;
        }
    }
}