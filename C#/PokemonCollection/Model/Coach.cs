namespace PokemonCollection
{
    public class Coach
    {
        private int id;
        private string name, password;
        private int pokestars, stars, coins, wins, fails;

        public Coach(string name, string password, int pokestars, int stars, int coins, int wins, int fails)
        {
            this.name = name;
            this.password = password;
            this.pokestars = pokestars;
            this.stars = stars;
            this.coins = coins;
            this.wins = wins;
            this.fails = fails;
        }

        public Coach(){}

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public int Pokestars
        {
            get => pokestars;
            set => pokestars = value;
        }

        public int Stars
        {
            get => stars;
            set => stars = value;
        }

        public int Coins
        {
            get => coins;
            set => coins = value;
        }

        public int Wins
        {
            get => wins;
            set => wins = value;
        }

        public int Fails
        {
            get => fails;
            set => fails = value;
        }
    }
}