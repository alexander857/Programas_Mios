namespace PokemonCollection
{
    public class Pokebola
    {
        private int idPokebola, idType, valueS, valueM, cantPokemon;

        public Pokebola(){}

        public int IdPokebola
        {
            get => idPokebola;
            set => idPokebola = value;
        }

        public int IdType
        {
            get => idType;
            set => idType = value;
        }

        public int ValueS
        {
            get => valueS;
            set => valueS = value;
        }

        public int ValueM
        {
            get => valueM;
            set => valueM = value;
        }

        public int CantPokemon
        {
            get => cantPokemon;
            set => cantPokemon = value;
        }
    }
}