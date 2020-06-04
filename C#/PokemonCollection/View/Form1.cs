using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonCollection
{
    public partial class Form1 : Form
    {
        private Coach unCoach, info;
        private Pokebola pokeSelected;
        private bool viewComplete = true, battleStart = false;
        private List<Pokemon> pokemons;
        private int lifeJ, lifeR;
        private string AboutRival, AboutPlayer;
        public Form1(Coach c)
        {
            lifeJ = lifeR = 0;
            AboutPlayer = AboutRival = "";
            InitializeComponent();
            unCoach = c;
            pokemons = PokemonDAO.getPokemons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataCoach();
            FillTypePokebolas();
            FillComboPokemon();
            FillComboTypePokemon();
            FillCMBUnlockedPokemon();
            FillPokeStarsCoinsCombo();
            picPokeUnloked.Image = Image.FromFile(@"Pokemon\Silueta.png");
            picPokemonPlayer.Image = Image.FromFile(@"Pokemon\Silueta.png");
        }
        
        //se llenan los combobox de las pokestrellas y monedas de la tienda de intercambio
        public void FillPokeStarsCoinsCombo()
        {
            cmbCantStar.DataSource = new List<int>(){2,5,10,20,40};
            cmbCantCoins.DataSource = new List<int>(){100,200,400,600,1000};
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      
        //En el timer salen recompensas de monedas, estrellas y pokestrellas aleatoriamente segun la hora
        private void timer1_Tick(object sender, EventArgs e)
        {
            string hora = "";
            hora = DateTime.Now.ToString("h:mm:ss tt");
            
            Random r = new Random();
            int booty = r.Next(1, 1000);

            if (booty == 777)
            {
                timer1.Enabled = false;
                lblStarBotin.Text = Convert.ToString(CoachDAO.getStars());
                lblPokStarBotin.Text = Convert.ToString(CoachDAO.getPokestars());
                lblCoinBotin.Text = Convert.ToString(CoachDAO.getCoins());
                btnCollectBotin.Enabled = true;
            }
            
        }

        //se llena el comboBox de pokemon deslbloqueados del jugador
        public void FillCMBUnlockedPokemon()
        {
            cmbUnlokedPokemon.DataSource = null;
            cmbUnlokedPokemon.ValueMember = "pokedex";
            cmbUnlokedPokemon.DisplayMember = "name";
            cmbUnlokedPokemon.DataSource = PokemonUnlokedDAO.getPokeUnlocked(unCoach.Id);
        }
        
        //se actualizan los datos del entrenador
        public void FillDataCoach()
        {
            //se manda a consultar la info del usuario en sesion a la base para tener acualizados los datos en
            //los labels
            info = CoachDAO.InfoCoach(unCoach.Id);
            
            lblPokeName.Text = info.Name;
            lblPokeStars.Text = Convert.ToString(info.Pokestars);
            lblStars.Text = Convert.ToString(info.Stars);
            lblCoins.Text = Convert.ToString(info.Coins);
            lblWins.Text = Convert.ToString(info.Wins);
            lblFails.Text = Convert.ToString(info.Fails); 
            lblStarsActual.Text = Convert.ToString(info.Stars);
            lblPokStarActual.Text = Convert.ToString(info.Pokestars);
            lblCoinActual.Text = Convert.ToString(info.Coins);
            lblCoinsBattle.Text = "Monedas de batalla: " + Convert.ToString(info.Coins);
        }
        
        //llenando el combo de tipos de pokebolas
        public void FillTypePokebolas()
        {
            cmbBolaStore.DataSource = null;
            cmbBolaStore.ValueMember = "id";
            cmbBolaStore.DisplayMember = "tipoP";
            cmbBolaStore.DataSource = TypePokebolaDAO.getTypePokebolas();
        }

        //timer donde se visualizan las pokebolas
        private void timerPokebolas_Tick(object sender, EventArgs e)
        {
            try
            {
                int idType = Convert.ToInt32(cmbBolaStore.SelectedValue);
                List<Pokebola> pokebolas = PokebolaDAO.getPokebolas(); //se obtiene la lista de pokebolas

                foreach (var p in pokebolas)
                {
                    if (idType == p.IdType)
                    {
                        lblStarBola.Text = Convert.ToString(p.ValueS);
                        lblCoinBola.Text = Convert.ToString(p.ValueM);
                        picPokebola.Image =
                            (Bitmap) Properties.Resources.ResourceManager.GetObject("Pokebola" + p.IdPokebola);
                        picPokebola.SizeMode = PictureBoxSizeMode.StretchImage;

                        pokeSelected = p;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
            
        }

        //boton que muestra informacion sobre la pokebola
        private void btnInfoBola_Click(object sender, EventArgs e)
        {

            if (pokeSelected == null)
            {
                MessageBox.Show("No se ha seleccionado ninguna Pokebola!","Aviso",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                switch (pokeSelected.IdType)
                {
                    case 1:
                        MessageBox.Show(PokebolaDAO.messagePokebola(1), "Informacion", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        MessageBox.Show(PokebolaDAO.messagePokebola(2), "Informacion", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 3:
                        MessageBox.Show(PokebolaDAO.messagePokebola(3), "Informacion", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 4:
                        MessageBox.Show(PokebolaDAO.messagePokebola(4), "Informacion", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 5:
                        MessageBox.Show(PokebolaDAO.messagePokebola(5), "Informacion", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
        
        //METODOS DE LOS POKEMON
        //se llena el comboBox con todos los pokemon registrados
        public void FillComboPokemon()
        {
            cmbPokeStoreN.DataSource = null;
            cmbPokeStoreN.ValueMember = "pokedex";
            cmbPokeStoreN.DisplayMember = "name";
            cmbPokeStoreN.DataSource = PokemonDAO.getPokemons();
        }
        
        //se llena el combobox de pokemos por tipo seleccionado en el combobox de tipo
        public void FillComboPokemonByType(string type)
        {
            cmbPokeStoreN.DataSource = null;
            cmbPokeStoreN.ValueMember = "pokedex";
            cmbPokeStoreN.DisplayMember = "name";
            cmbPokeStoreN.DataSource = PokemonDAO.getPokemonsByType(type);
        }
        
        //se llena el combobox de los tipos de pokemon
        public void FillComboTypePokemon()
        {
            cmbPokeStoreT.DataSource = null;
            cmbPokeStoreT.ValueMember = "idT";
            cmbPokeStoreT.DisplayMember = "tipoP";
            cmbPokeStoreT.DataSource = TypePokemonDAO.getTypePokemons();
        }
        
        //timer de ver pokemon en la tienda
        private void timerPokemonStore_Tick(object sender, EventArgs e)
        {
            try
            {
                int idPokedex = Convert.ToInt32(cmbPokeStoreN.SelectedValue);
                string nameImage = "Pokemon" + idPokedex; //nombre de la imagen a cargar
            
                foreach (var p in pokemons)
                {
                    if (idPokedex == p.Pokedex)
                    {
                        lblPokeStore.Text = p.Name;
                        lblLifeStore.Text = Convert.ToString(p.Life);
                        lblTypeStore.Text = p.Type;
                        lblMaxStore.Text = Convert.ToString(p.Max);
                        lblMinStore.Text = Convert.ToString(p.Min);
                        lvlValueStore.Text = Convert.ToString(p.Value);
                        //se muestra la imagen del pokemon
                        picPokeStore.Image = Image.FromFile($@"Pokemon\{nameImage}.png");
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
            
        }
        
        //evento cuando se cambia de iten en el combobox de tipos de pokemon
        private void cmbPokeStoreT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = Convert.ToString(cmbPokeStoreT.Text);
            FillComboPokemonByType(type);
        }

        //boton que vuelve a llenar el combobox de nombres de pokemon con todos los pokemon registrados
        private void btnViewPoke_Click(object sender, EventArgs e)
        {
            FillComboPokemon();
        }
        
        //METODOS DE BUSCAR RIVAL EN UNA BATALLA

        //actualizar los controles de batalla
        public void UpdateControlsBattle()
        {
            picPokemonRival.Image = Image.FromFile(@"Pokemon\Silueta2.png");
            //controles del rival
            lblRival.Text = "POKEMON";
            lblTypeRival.Text = "TIPO";
            lblLifeRival.Text = 0000 + "/" + 0000;
            //botones desactivados
            btnAttack.Visible = false;
            btnStartBattle.Enabled = false;
        }
        //boton de buscar un rival
        private void btnBattle_Click(object sender, EventArgs e)
        {
            try
            {
                if (info.Coins < 100)
                {
                    MessageBox.Show("No tienes suficientes monedas de batalla!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!lblPokePlayer.Text.Equals("POKEMON"))
                {
                    Random idRandom = new Random();
                    int id = idRandom.Next(1, 261);
                
                    string nameImage = "Pokemon" + id; //nombre de la imagen a cargar
                
                    foreach (var p in pokemons)
                    {
                        //para el pokemon rival
                        if (id == p.Pokedex)
                        {
                            lblRival.Text = p.Name;
                            lblTypeRival.Text = p.Type;
                            lifeR = p.Life;
                            lblLifeRival.Text = lifeR + "/" + p.Life;
                            //se muestra la imagen del pokemon
                            picPokemonRival.Image = Image.FromFile($@"Pokemon\{nameImage}.png");
                        }
                        //para el pokemon del jugador
                        if (lblPokePlayer.Text.Equals(p.Name))
                        {
                            lblTypePlayer.Text = p.Type;
                            lifeJ = p.Life;
                            lblLifePlayer.Text = lifeJ + "/" + p.Life;
                        }
                    }

                    btnStartBattle.Enabled = true; //se activa el boton de empezar batalla
                
                    //se disminuyen las monedas el jugador y se actualiza la base
                    int newCant = info.Coins - 100;
                    CoachDAO.UpdateCoins(newCant,unCoach.Id);
                    FillDataCoach();
                }
                else
                {
                    MessageBox.Show("Equipa un Pokemon para buscar batalla!", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
        }

        //boton de empezar la batalla
        
        private void btnStartBattle_Click(object sender, EventArgs e)
        {
            battleStart = true;
            btnStartBattle.Enabled = false;
            btnBattle.Enabled = false;
            string pokemon = lblRival.Text;
            string pokemonJ = lblPokePlayer.Text;
            MessageBox.Show(pokemon + " vs " + pokemonJ);
            btnAttack.Visible = true;

            //listas de debilidades, fortalecas etc. Del rival
            List<string> listF = WeaknessesOrStrengths.Strengths(lblRival.Text);
            List<string> listD = WeaknessesOrStrengths.Weaknesses(lblRival.Text);
            List<string> listR = WeaknessesOrStrengths.Resistance(lblRival.Text);
            List<string> listV = WeaknessesOrStrengths.Vulnerable(lblRival.Text);

            //listas de debilidades, fortalecas etc. Del jugador 
            List<string> listF1 = WeaknessesOrStrengths.Strengths(lblPokePlayer.Text);
            List<string> listD1 = WeaknessesOrStrengths.Weaknesses(lblPokePlayer.Text);
            List<string> listR1 = WeaknessesOrStrengths.Resistance(lblPokePlayer.Text);
            List<string> listV1 = WeaknessesOrStrengths.Vulnerable(lblPokePlayer.Text);
            
            AboutRival = VerifyPokemonTypesR(listF, listD, listR, listV);
            AboutPlayer = VerifyPokemonTypesJ(listF1, listD1, listR1, listV1);

            MessageToPlayer();
        }

        //mensaje para el jugador de como es con respecto a su rival
        public void MessageToPlayer()
        {
            switch (AboutPlayer)
            {
                case "F": MessageBox.Show("Eres fuerte contra " + lblRival.Text + ", ganale!"); break;
                case "D": MessageBox.Show("Eres debil contra " + lblRival.Text + ", ten cuidado!"); break;
                case "R": MessageBox.Show("Eres resistente contra " + lblRival.Text + ", trata de vencerlo!"); 
                    break;
                case "V": MessageBox.Show("Eres vulnerable contra " + lblRival.Text + ", suerte!"); break;
                case "N": MessageBox.Show("Tendras una pelea reñida con " + lblRival.Text + ", se el mejor!"); 
                    break;
            }
        }
        //metodo que verifica como es las capacidad del rival con respecto al jugador
        public string VerifyPokemonTypesR(List<string> F,List<string> D, List<string> R, List<string> V)
        {
            foreach (var v in F)
            {
                if(v.Equals(lblTypePlayer.Text))
                    return "F";
            }
            foreach (var v in D)
            {
                if(v.Equals(lblTypePlayer.Text))
                    return "D";
            }
            foreach (var v in R)
            {
                if(v.Equals(lblTypePlayer.Text))
                    return "R";
            }
            foreach (var v in V)
            {
                if(v.Equals(lblTypePlayer.Text))
                    return "V";
            }

            return "N";
        }
        
        //metodo que verifica como es las capacidad del jugador con respecto al rival
        public string VerifyPokemonTypesJ(List<string> F,List<string> D, List<string> R, List<string> V)
        {
            foreach (var v in F)
            {
                if(v.Equals(lblTypeRival.Text))
                    return "F";
            }
            foreach (var v in D)
            {
                if(v.Equals(lblTypeRival.Text))
                    return "D";
            }
            foreach (var v in R)
            {
                if(v.Equals(lblTypeRival.Text))
                    return "R";
            }
            foreach (var v in V)
            {
                if(v.Equals(lblTypeRival.Text))
                    return "V";
            }

            return "N";
        }
        
        //boton de atacar al rival
        private void btnAttack_Click(object sender, EventArgs e)
        {
            string pokemon = lblRival.Text;
            string pokemonJ = lblPokePlayer.Text;
            
            //daño de cada pokemon
            Random r = new Random();
            int danioRival = r.Next(100, 501);
            int danioPlayer = r.Next(100, 501);

            //se va a verificar cuanto daño hara cada pokemon
            lifeR -= VerifyHurtPlayer(danioPlayer);
            lifeJ -= VerifyHurtRival(danioRival);

            foreach (var p in pokemons)
            {
                if (pokemon.Equals(p.Name)) //nombre del pokemon rival
                {
                    if (lifeR <= 0)
                    {
                        lblLifeRival.Text = 0 + "/" + p.Life;
                        MessageBox.Show("Has ganado");
                        RewardBattle(1); //metodo de premio
                        //se actualizan las victorias
                        int newWin = info.Wins + 1;
                        CoachDAO.UpdateWins(newWin,unCoach.Id);
                        FillDataCoach();
                        battleStart = false;
                        btnBattle.Enabled = true;
                        btnAttack.Visible = false;
                        return;
                    }
                    else 
                        lblLifeRival.Text = lifeR + "/" + p.Life;
                }

                if (pokemonJ.Equals(p.Name)) //nombre del pokemon jugador
                {
                    if (lifeJ <= 0)
                    {
                        lblLifePlayer.Text = 0 + "/" + p.Life;
                        MessageBox.Show("Has perdido");
                        RewardBattle(0); //metodo de premio
                        //se actualizan las derrotas
                        int newFail = info.Fails + 1;
                        CoachDAO.UpdateFails(newFail,unCoach.Id);
                        FillDataCoach();
                        battleStart = false;
                        btnBattle.Enabled = true;
                        btnAttack.Visible = false;
                        return;
                    }
                    else 
                        lblLifePlayer.Text = lifeJ + "/" + p.Life;
                }
            }
            
        }
        
        //verificar cuanto daño hara el jugador al rival
        public int VerifyHurtPlayer(int h)
        {
            int danioTotal = 0;

            switch (AboutPlayer)
            {
                case "D": return danioTotal = (h - Convert.ToInt32((h * 40) / 100));
                case "R": return danioTotal = (h - Convert.ToInt32((h * 20) / 100));
                case "V": return danioTotal = (h - Convert.ToInt32((h * 60) / 100));
                case "N": return danioTotal = (h - Convert.ToInt32((h * 10) / 100));
                default: return h;
            }
        }
        
        //verificar cuanto daño hara el rival al jugador
        public int VerifyHurtRival(int h)
        {
            int danioTotal = 0;

            switch (AboutRival)
            {
                case "D": return danioTotal = (h - Convert.ToInt32((h * 40) / 100));
                case "R": return danioTotal = (h - Convert.ToInt32((h * 20) / 100));
                case "V": return danioTotal = (h - Convert.ToInt32((h * 60) / 100));
                case "N": return danioTotal = (h - Convert.ToInt32((h * 10) / 100));
                default: return h;
            }
        }

        //evento de cambiar de pestaña en el tabControl
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("tabBattle"))
            {
                if(!battleStart)
                    UpdateControlsBattle();
            }
            else
            {
                if(battleStart)
                {
                    MessageBox.Show("Debes terminar la batalla!", "Atencion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                }
            }
        }
        
        //metodos de conseguir o gastar pokestrellas, estrellas o monedas

        //comprar un pokemon
        private void btnBuyPokemon_Click(object sender, EventArgs e)
        {
            Pokemon p = (Pokemon) cmbPokeStoreN.SelectedItem;
            bool exist = false;

            if (MessageBox.Show("Seguro que desea comprar a " + p.Name + "?", "Aviso", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.Value > info.Pokestars)
                {
                    MessageBox.Show("No tienes suficientes Pokestrellas!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {    //se busca el pokemon a comprar en la lista del jugador para que no compre el mismo 2 veces
                        foreach (var pok in PokemonUnlokedDAO.getPokeUnlocked(unCoach.Id))
                        {
                            if (pok.Pokedex == p.Pokedex)
                                exist = true;
                        }

                        if (!exist) //si no lo tiene se compra
                        {
                            int newCant = info.Pokestars - p.Value;
                            CoachDAO.UpdatePokestrellas(newCant,unCoach.Id);
                            //se añade pokemon a lista del jugador
                            PokemonUnlokedDAO.AddPokemonUnlocked(p.Pokedex,unCoach.Id); 
                            FillDataCoach();
                            MessageBox.Show("Ha comprado a " + p.Name + " con exito!", "Exito", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillCMBUnlockedPokemon();
                        }
                        else //si lo tiene no se compra
                        {
                            MessageBox.Show("Ya tienes a " + p.Name + " en tu coleccion!", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error!");
                    }
                }
            }
        }

        //boton que recoge el botin y actualiza la base de datos
        private void btnCollectBotin_Click(object sender, EventArgs e)
        {
            int stars = 0, pokestars = 0, coins = 0;
            int newStars = 0, newPokStars = 0, newCoins = 0;

            try
            {
                //se guardan las cantidades de los labels del botin
                stars = Convert.ToInt32(lblStarBotin.Text);
                pokestars = Convert.ToInt32(lblPokStarBotin.Text);
                coins = Convert.ToInt32(lblCoinBotin.Text);
                //se hace el calculo de las nuevas cantidades que tendra el jugador
                newStars = info.Stars + stars;
                newPokStars = info.Pokestars + pokestars;
                newCoins = info.Coins + coins;
                //se actualiza la base
                CoachDAO.UpdateStars(newStars,unCoach.Id);
                CoachDAO.UpdatePokestrellas(newPokStars,unCoach.Id);
                CoachDAO.UpdateCoins(newCoins,unCoach.Id);
                FillDataCoach();

                MessageBox.Show("Ha recogido todo el botin!", "Exito", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                btnCollectBotin.Enabled = false;
                timer1.Enabled = true;

                lblStarBotin.Text = "0";
                lblPokStarBotin.Text = "0";
                lblCoinBotin.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
        }
        
        //TIMER DE POKEMON DESBLOQUEADOS DEL JUGADOR
        private void tmrPokeUnlocked_Tick(object sender, EventArgs e)
        {
            try
            {
                int idPokedex = Convert.ToInt32(cmbUnlokedPokemon.SelectedValue);
                string nameImage = "Pokemon" + idPokedex; //nombre de la imagen a cargar
            
                foreach (var p in pokemons)
                {
                    if (idPokedex == p.Pokedex)
                    {
                        lblNamePokemon.Text = p.Name;
                        lblLife.Text = Convert.ToString(p.Life);
                        lblType.Text = p.Type;
                        lblMaxHurt.Text = Convert.ToString(p.Max);
                        lblMinHurt.Text = Convert.ToString(p.Min);
                        //se muestra la imagen del pokemon
                        picPokeUnloked.Image = Image.FromFile($@"Pokemon\{nameImage}.png");
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
        }

        //boton de equipar un pokemon para usarlo en la batalla
        private void btnEquipPokemon_Click(object sender, EventArgs e)
        {
            PokemonUnlocked equip = (PokemonUnlocked) cmbUnlokedPokemon.SelectedItem;
            string nameImage = "Pokemon" + equip.Pokedex;
            
            lblEquipPokemon.Text = equip.Name;
            lblPokePlayer.Text = equip.Name;
            lblTypePlayer.Text = equip.Type;
            lblLifePlayer.Text = equip.Life + "/" + equip.Life;
            picPokemonPlayer.Image = Image.FromFile($@"Pokemon\{nameImage}.png");

            MessageBox.Show(equip.Name + " equipado para la batalla!", "Equipado", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        
        //metodo de recompensa segun las batallas, si pierde o gana
        public void RewardBattle(int n)
        {
            int newCoins = 0, newPokestars = 0, newStars = 0;

            if (n == 1)
            {
                //se hace el calculo de las nuevas cantidades que tendra el jugador
                newStars = info.Stars + 5;
                newPokestars = info.Pokestars + 1;
                newCoins = info.Coins + 200;
                //se actualiza la base
                CoachDAO.UpdateStars(newStars,unCoach.Id);
                CoachDAO.UpdatePokestrellas(newPokestars,unCoach.Id);
                CoachDAO.UpdateCoins(newCoins,unCoach.Id);
                FillDataCoach();
            
                MessageBox.Show("Tu premio: 5 Estrellas, 1 Pokestrellas y 200 monedas", "Exito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                newStars = info.Stars + 3;
                //se actualiza la base
                CoachDAO.UpdateStars(newStars,unCoach.Id);
                FillDataCoach();
            
                MessageBox.Show("Premio de batalla: 3 Estrellas", "Exito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        //METODOS DE INTERCAMBIO DE MONEDAS Y POKESTRELLAS POR ESTRELLAS

        //boton de cambio de estrellas por pokestrellas
        private void btnBuyStar_Click(object sender, EventArgs e)
        {
            int price = 0; //2,5,10,20,40
            int pStars = Convert.ToInt32(cmbCantStar.Text);

            switch (cmbCantStar.SelectedItem)
            {
                case 2: price = 5; break;
                case 5: price = 10; break;
                case 10: price = 15; break;
                case 20: price = 25; break;
                case 40: price = 45; break;
                default: break;
            }

            if (info.Stars < price)
            {
                MessageBox.Show("Necesitas almenos " + price + " estrellas para completar el cambio!", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               int newStars = info.Stars - price;
               int newPokestars = info.Pokestars + pStars;
               
               //se actualizan los datos de la base
               CoachDAO.UpdateStars(newStars,unCoach.Id);
               CoachDAO.UpdatePokestrellas(newPokestars,unCoach.Id);
               FillDataCoach();
               MessageBox.Show("Cambio realizado con exito!", "Exito", 
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //boton de intercambio de estrellas por monedas de batalla
        private void btnBuyCoins_Click(object sender, EventArgs e)
        {
            int price = 0; //100,200,400,600,1000
            int pCoins = Convert.ToInt32(cmbCantCoins.Text);

            switch (cmbCantCoins.SelectedItem)
            {
                case 100: price = 5; break;
                case 200: price = 10; break;
                case 400: price = 15; break;
                case 600: price = 25; break;
                case 1000: price = 45; break;
                default: break;
            }

            if (info.Stars < price)
            {
                MessageBox.Show("Necesitas almenos " + price + " estrellas para completar el cambio!", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int newStars = info.Stars - price;
                int newCoins = info.Coins + pCoins;
               
                //se actualizan los datos de la base
                CoachDAO.UpdateStars(newStars,unCoach.Id);
                CoachDAO.UpdateCoins(newCoins,unCoach.Id);
                FillDataCoach();
                MessageBox.Show("Cambio realizado con exito!", "Exito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}