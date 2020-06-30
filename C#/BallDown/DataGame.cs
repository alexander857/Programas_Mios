using System;

namespace BallDown
{
    public static class DataGame
    {
        //variables usadas para las plataformas
        public static int speedPlataform = 10, distancePlataform = 100;
        public static int contPlataform = 0;
        public static int contPlataformLife = 0;

        //variables usadas para el jugador
        public static int timePlayer = 0, speedPlayer = 20, movePlayer = 70;
        public static int time = 0, movePlayerSlow = 20, lifesPlayer = 3;
        public static bool playerDown = true;

        //variables del juego propio
        public static bool pause = false, mainMusic = true;

        //random para la posicion de las plataformas
        public static int PositionPlataform()
        {
            Random r = new Random();
            return r.Next(1, 9);
        }
    }
}