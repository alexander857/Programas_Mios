#include<iostream>
#include<algorithm>
#include<string>
#include<time.h>
#include<stdlib.h>
#include<vector>

using namespace std;

//informacion que tendra cada jugador
struct infoPlayer{
	string name;
	int points, pointsFalse;
};

typedef infoPlayer P;

vector<infoPlayer> player;


//variables globales
bool playeradd = false;
int Around = 1;

//como ordenar el vector segun los puntos
bool ordenando(P a, P b){
	return a.points > b.points;
}

//prototipos de funciones
void AddPlayers(), scoreTable(), playRound();

int main(){
	P aPlayer;

	bool follow = true;

	do{
		int option = 0;
		cout << "\nLIGA DE ALEATORIOS\n" << endl;
		cout << "1-Jugar Jornada (" << Around << ")\n";
		cout << "2-Tabla de posiciones\n";
		cout << "3-Ingresar jugadores\n";
		cout << "4-Salir\n";
		cout << "Opcion: "; cin >> option; cin.ignore();

		switch(option){
			case 1: playRound(); break;
			case 2: scoreTable(); break; //funcion de tablas de posiciones  
			case 3: AddPlayers(); break;
			case 4: follow = false; break;
		}

	}while(follow);

	return 0;
}

void AddPlayers(){
	P aPlayer;
	int k = 0, option = 0;

	if(playeradd == true){
		cout << "\nYa hay una liga iniciada, podra ingresar nuevos jugadores cuando acabe!" << endl;
	}
	else{
		cout << "\nOBLIGATORIAMENTE TIENE QUE SER 20 JUGADORES!\n\n" << endl;
		do{
			cout << "Ingrese ID del jugador: "; getline(cin, aPlayer.name);
			aPlayer.points = 0;
			aPlayer.pointsFalse = 0;
			player.insert(player.end(), aPlayer);
			k++;
		}while(k < 20);
		playeradd = true; //ya hay una liga iniciada
	}

}

void scoreTable(){

	if(playeradd == false){
		cout << "\nNO HAY UNA LIGA INICIADA!" << endl;
	}
	else{

		sort(player.begin(), player.end(), ordenando);

		cout << "\nJugadores			Puntos\n" << endl;
		for(int i = 0; i < player.size(); i++){
			cout << player[i].name << "				" << player[i].points << endl;
		}

	}

}

void playRound(){
	srand(time(NULL));
	int LuckyNumber = 0;

	if(playeradd == false){
		cout << "\nNO HAY UNA LIGA INICIADA!" << endl;
	}
	else{

		if(Around == 39){
			cout << "\nHA TERMINADO LA TEMPORADA!\n" << endl;
			cout << "El ganador de esta liga es: ";
			sort(player.begin(), player.end(), ordenando);
			
			for(int i = 0; i < player.size(); i++){
				cout << player[i].name << " con " << player[i].points << " puntos" << endl;
				break;
			}

			playeradd = false;
			player.clear(); //se vacia el vector para una nueva liga
			Around = 1; //se reinicia el contador de jornadas
		}
		else{
			cout << "\nJORNADA " << Around << endl;

			for(int i = 0; i < player.size(); i++){
				LuckyNumber = 1 + rand()% 100;

				if(LuckyNumber >= 90){
					player[i].points += 10; //los puntos que se van acumulando
					player[i].pointsFalse = 10; //lo que se muestra en los resultados de la jornada jugada
				}
				else if(LuckyNumber >= 70 && LuckyNumber < 90){
					player[i].points += 7;
					player[i].pointsFalse = 7;
				}
				else if(LuckyNumber >= 50 && LuckyNumber < 70){
					player[i].points += 5;
					player[i].pointsFalse = 5;
				}
				else if(LuckyNumber >= 30 && LuckyNumber < 50){
					player[i].points += 3;
					player[i].pointsFalse = 3;
				}
				else if(LuckyNumber >= 10 && LuckyNumber < 30){
					player[i].points += 1;
					player[i].pointsFalse = 1;
				}
				else if(LuckyNumber < 10){
					player[i].points += 0;
					player[i].pointsFalse = 0;
				}

				
			}
			cout << "\nRESULTADOS DE LA JORDANA: \n" << endl;
			cout << "\nJugadores							Puntos\n" << endl;
			for(int i = 0; i < player.size(); i++){
			cout << player[i].name; 
			cout << "\t\t\t\t\t\t\t\t" << player[i].pointsFalse<< endl;
			}
			Around++;
		}
	}
}