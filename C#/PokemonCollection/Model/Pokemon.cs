namespace PokemonCollection
{
    public class Pokemon
    {
        private int pokedex;
        private string name;
        private int life, max, min, value;
        private string type;

        public Pokemon(string name, int life, int max, int min, int value, string type)
        {
            this.name = name;
            this.life = life;
            this.max = max;
            this.min = min;
            this.value = value;
            this.type = type;
        }

        public Pokemon(){}

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

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }
    }
}