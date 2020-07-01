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
        public static int timePlayer = 0, lifesPlayer = 3, time = 0; 
        public static int speedPlayer = 20, movePlayer = 70, movePlayerSlow = 20;
        //public static int contTimeTruce = 20;
        public static bool playerDown = true;

        //variables del juego propio
        public static bool pause = false, mainMusic = true;
        public static bool Truce = true;

        //variables nombres de pb (img)
        public static string wall = "wall1";
        public static string ball = "Ball";

        //random para la posicion de las plataformas
        public static int PositionPlataform()
        {
            Random r = new Random();
            return r.Next(1, 9);
        }

        //random para las img de la pelota
        public static int ImgBall()
        {
            Random r = new Random();
            return r.Next(1, 4);
        }
    }
}