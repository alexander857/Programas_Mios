namespace PokemonCollection
{
    public class PokemonUnlocked
    {
        private int pokedex;
        private string name;
        private int life, max, min;
        private string type;

        public PokemonUnlocked(){}

        public int Pokedex
        {
            get => pokedex;
            set => pokedex = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Life
        {
            get => life;
            set => life = value;
        }

        public int Max
        {
            get => max;
            set => max = value;
        }

        public int Min
        {
            get => min;
            set => min = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }
    }
}