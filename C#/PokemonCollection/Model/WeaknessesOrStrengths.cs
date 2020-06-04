using System.Collections.Generic;

namespace PokemonCollection
{
    public static class WeaknessesOrStrengths
    {
        //metodo de buscar a que son fuertes
        public static List<string> Strengths(string name)
        {
            string type = "";
            List<string> list = null;
         
            foreach (var po in PokemonDAO.getPokemons())
            {
                if (po.Name.Equals(name))
                    type = po.Type;
            }
            //se verifica a que puede ser fuerte el pokemon
            switch (type)
            {
                case "Normal": return list = new List<string>() {""}; 
                case "Lucha": return list = new List<string>() {"Normal"};
                case "Volador": return list = new List<string>() {"Lucha","Bicho","Planta"};
                case "Veneno": return list = new List<string>() {"Hada","Planta"};
                case "Tierra": return list = new List<string>() {"Veneno","Roca","Acero","Fuego","Electrico"};
                case "Roca": return list = new List<string>() {"Volador","Bicho","Fuego","Hielo"};
                case "Bicho": return list = new List<string>() {"Psiquico","Siniestro","Planta"};
                case "Fantasma": return list = new List<string>() {"Psiquico"};
                case "Acero": return list = new List<string>() {"Roca","Hielo","Hada"};
                case "Fuego": return list = new List<string>() {"Acero","Bicho","Planta","Hielo"};
                case "Agua": return list = new List<string>() {"Tierra","Roca","Fuego"};
                case "Planta": return list = new List<string>() {"Tierra","Roca","Agua"};
                case "Electrico": return list = new List<string>() {"Volador","Agua"};
                case "Psiquico": return list = new List<string>() {"Lucha","Veneno"};
                case "Hielo": return list = new List<string>() {"Tierra","Volador","Planta","Dragon"};
                case "Dragon": return list = new List<string>() {"Dragon"};
                case "Hada": return list = new List<string>() {"Lucha","Dragon"};
                case "Siniestro": return list = new List<string>() {"Fantasma","Psiquico"};
                default: break;
            }

            return list;
        }
        
        //metodo de buscar a que son debiles
        public static List<string> Weaknesses(string name)
        {
            string type = "";
            List<string> list = null;
            
            foreach (var po in PokemonDAO.getPokemons())
            {
                if (po.Name.Equals(name))
                    type = po.Type;
            }
            
            //se verifica a que puede ser debil el pokemon
            switch (type)
            {
                case "Normal": return list = new List<string>() {"Roca","Fantasma","Acero"}; 
                case "Lucha": return list = new List<string>() {"Veneno","Bicho","Fantasma","Psiquico","Hada"};
                case "Volador": return list = new List<string>() {"Roca","Acero","Electrico"};
                case "Veneno": return list = new List<string>() {"Veneno","Tierra","Roca","Fantasma","Acero"};
                case "Tierra": return list = new List<string>() {"Volador","Bicho","Planta"};
                case "Roca": return list = new List<string>() {"Lucha","Tierra","Acero"};
                case "Bicho": return list = new List<string>() {"Lucha","Volador","Veneno","Fantasma","Acero","Fuego",
                    "Agua"};
                case "Fantasma": return list = new List<string>() {"Normal","Siniestro"};
                case "Acero": return list = new List<string>() {"Acero","Fuego","Agua","Electrico"};
                case "Fuego": return list = new List<string>() {"Roca","Fuego","Tierra","Dragon"};
                case "Agua": return list = new List<string>() {"Agua","Planta","Dragon"};
                case "Planta": return list = new List<string>() {"Volador","Veneno","Bicho","Acero","Fuego","Planta",
                    "Dragon"};
                case "Electrico": return list = new List<string>() {"Planta","Electrico","Dragon"};
                case "Psiquico": return list = new List<string>() {"Acero","Psiquico","Siniestro"};
                case "Hielo": return list = new List<string>() {"Acero","Fuego","Hielo"};
                case "Dragon": return list = new List<string>() {"Acero","Agua"};
                case "Hada": return list = new List<string>() {"Veneno","Acero","Fuego"};
                case "Siniestro": return list = new List<string>() {"Lucha","Hada","Siniestro"};
                default: break;
            }
         
            return list;        
        }
        
        //metodo de buscar a que son resistentes
        public static List<string> Resistance(string name)
        {
            string type = "";
            List<string> list = null;
            
            foreach (var po in PokemonDAO.getPokemons())
            {
                if (po.Name.Equals(name))
                    type = po.Type;
            }
         
            //se verifica a que puede ser resistente el pokemon
            switch (type)
            {
                case "Normal": return list = new List<string>() {""}; 
                case "Lucha": return list = new List<string>() {"Roca","Siniestro"};
                case "Volador": return list = new List<string>() {"Tierra"};
                case "Veneno": return list = new List<string>() {""};
                case "Tierra": return list = new List<string>() {""};
                case "Roca": return list = new List<string>() {"Normal","Veneno"};
                case "Bicho": return list = new List<string>() {"Tierra"};
                case "Fantasma": return list = new List<string>() {"Lucha","Veneno","Bicho"};
                case "Acero": return list = new List<string>() {"Normal", "Volador", "Veneno", "Bicho", "Planta", 
                    "Psiquico", "Dragon"};
                case "Fuego": return list = new List<string>() {""};
                case "Agua": return list = new List<string>() {"Acero","Hielo"};
                case "Planta": return list = new List<string>() {"Electrico"};
                case "Electrico": return list = new List<string>() {"Acero"};
                case "Psiquico": return list = new List<string>() {""};
                case "Hielo": return list = new List<string>() {""};
                case "Dragon": return list = new List<string>() {"Fuego","Planta","Electrico"};
                case "Hada": return list = new List<string>() {"Bicho"};
                case "Siniestro": return list = new List<string>() {""};
                default: break;
            }
            
            return list;        
        }
        
        //metodo de buscar a que son vulnerables
        public static List<string> Vulnerable(string name)
        {
            string type = "";
            List<string> list = null;
            
            foreach (var po in PokemonDAO.getPokemons())
            {
                if (po.Name.Equals(name))
                    type = po.Type;
            }
         
            //se verifica a que puede ser vulnerables el pokemon
            switch (type)
            {
                case "Normal": return list = new List<string>() {"Lucha"}; 
                case "Lucha": return list = new List<string>() {"Volador"};
                case "Volador": return list = new List<string>() {"Hielo"};
                case "Veneno": return list = new List<string>() {"Psiquico"};
                case "Tierra": return list = new List<string>() {"Agua","Hielo"};
                case "Roca": return list = new List<string>() {"Agua","Planta"};
                case "Bicho": return list = new List<string>() {"Roca"};
                case "Fantasma": return list = new List<string>() {"Fantasma"};
                case "Acero": return list = new List<string>() {"Lucha","Tierra"};
                case "Fuego": return list = new List<string>() {"Agua"};
                case "Agua": return list = new List<string>() {"Electrico"};
                case "Planta": return list = new List<string>() {"Hielo"};
                case "Electrico": return list = new List<string>() {"Tierra"};
                case "Psiquico": return list = new List<string>() {"Bicho","Fantasma"};
                case "Hielo": return list = new List<string>() {"Lucha","Roca"};
                case "Dragon": return list = new List<string>() {"Hielo","Hada"};
                case "Hada": return list = new List<string>() {"Siniestro"};
                case "Siniestro": return list = new List<string>() {"Bicho"};
                default: break;
            }
            
            return list;        
        }
        
    }
}