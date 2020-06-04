using System;
using System.Collections.Generic;
using System.Data;

namespace PokemonCollection
{
    public static class PokebolaDAO
    {
        public static List<Pokebola> getPokebolas()
        {
            string sql = "SELECT * FROM POKEBOLA";
            
            DataTable dt = ConnectionBDD.ExecuteQuery(sql);
            
            List<Pokebola> pokebolas = new List<Pokebola>();

            foreach (DataRow row in dt.Rows)
            {
                Pokebola p = new Pokebola();

                p.IdPokebola = Convert.ToInt32(row[0].ToString());
                p.IdType = Convert.ToInt32(row[1].ToString());
                p.ValueS = Convert.ToInt32(row[2].ToString());
                p.ValueM = Convert.ToInt32(row[3].ToString());
                p.CantPokemon = Convert.ToInt32(row[4].ToString());
                
                pokebolas.Add(p);
            }

            return pokebolas;
        }
        
        //metodo de mensajes de informacion de cada pokebola
        public static string messagePokebola(int a)
        {
            switch (a)
            {
                case 1:
                    return "Esta pokebola puede contener algun pokemon de los tipos: Normal, Roca.";
                case 2:
                    return "Esta pokebola puede contener algun pokemon de los tipos: Bicho, Planta, Agua, Volador.";
                case 3:
                    return "Esta pokebola puede contener algun pokemon de los tipos: Veneno, Fantasma, Psiquico, " +
                           "Siniestro.";
                case 4:
                    return "Esta pokebola puede contener algun pokemon de los tipos: Hada, Acero, Fuego, Dragon, " +
                           "Electrico, Hielo.";
                case 5:
                    return "Esta pokebola puede contener algun pokemon de los tipos: Lucha, Tierra.";
            }

            return "";
        }
    }
}