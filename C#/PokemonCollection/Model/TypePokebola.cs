namespace PokemonCollection
{
    public class TypePokebola
    {
        private int id;
        private string tipoP;

        public TypePokebola(){}

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string TipoP
        {
            get => tipoP;
            set => tipoP = value;
        }
    }
}