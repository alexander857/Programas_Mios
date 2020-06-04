namespace PokemonCollection
{
    public class TypePokemon
    {
        private int idT;
        private string tipoP;

        public TypePokemon(){}

        public int IdT
        {
            get => idT;
            set => idT = value;
        }

        public string TipoP
        {
            get => tipoP;
            set => tipoP = value;
        }
    }
}