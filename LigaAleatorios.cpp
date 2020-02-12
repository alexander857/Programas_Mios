#include<iostream>
#include<algorithm>
#include<string>
#include<time.h>
#include<stdlib.h>
#include<vector>
#include<queue>

using namespace std;

//informacion que tendra cada jugador
struct infoPlayer{
	string name;
	int points, pointsFalse;
};

typedef infoPlayer P;

struct versus{
    string player1, player2;
};

typedef versus V;

vector<infoPlayer> jornadas; //vector para jornadas
vector<infoPlayer> eliminatorias; //vector para eliminatorias
queue<versus> games; //cola de partidas de eliminatorias

//variables globales
bool playeradd = false, pairingDone = false;
int Around = 1, NumRandom[20], first = 0;

//como ordenar el vector segun los puntos
bool ordenando(P a, P b){
	return a.points > b.points;
}

//prototipos de funciones
void AddPlayers(), scoreTable(), playRound(), FillingUpArray(), Pairing(), matches();
bool verifyNUM(int);

int main(){
	P aPlayer;

	bool follow = true;

	do{
		int option = 0;
		cout << "\nLIGA DE ALEATORIOS\n" << endl;
		cout << "1-Jugar Jornada (" << Around << ")\n";
        cout << "2-Jugar Eliminatoria\n";
		cout << "3-Tabla de posiciones de las Jornadas\n";
        cout << "4-Emparejamientos de Eliminatorias\n";
		cout << "5-Ingresar jugadores\n";
		cout << "6-Salir\n";
		cout << "Opcion: "; cin >> option; cin.ignore();

		switch(option){
			case 1: playRound(); break;
            case 2: matches(); break; 
			case 3: scoreTable(); break; //funcion de tablas de posiciones
            case 4: Pairing(); break;  //emparejamiento de eliminatorias
			case 5: AddPlayers(); break;
			case 6: follow = false; break;
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
			jornadas.insert(jornadas.end(), aPlayer); //guardando info para jornadas
            eliminatorias.insert(eliminatorias.end(), aPlayer); //guardando info para eliminatorias
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

		sort(jornadas.begin(), jornadas.end(), ordenando);

		cout << "\nJugadores			Puntos\n" << endl;
		for(int i = 0; i < jornadas.size(); i++){
			cout << jornadas[i].name << "				" << jornadas[i].points << endl;
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
			sort(jornadas.begin(), jornadas.end(), ordenando);
			
			for(int i = 0; i < jornadas.size(); i++){
				cout << jornadas[i].name << " con " << jornadas[i].points << " puntos" << endl;
				break;
			}

			playeradd = false;
			jornadas.clear(); //se vacia el vector para una nueva liga
			Around = 1; //se reinicia el contador de jornadas
		}
		else{
			cout << "\nJORNADA " << Around << endl;

			for(int i = 0; i < jornadas.size(); i++){
				LuckyNumber = 1 + rand()% 100;

				if(LuckyNumber >= 90){
					jornadas[i].points += 10; //los puntos que se van acumulando
					jornadas[i].pointsFalse = 10; //lo que se muestra en los resultados de la jornada jugada
				}
				else if(LuckyNumber >= 70 && LuckyNumber < 90){
					jornadas[i].points += 7;
					jornadas[i].pointsFalse = 7;
				}
				else if(LuckyNumber >= 50 && LuckyNumber < 70){
					jornadas[i].points += 5;
					jornadas[i].pointsFalse = 5;
				}
				else if(LuckyNumber >= 30 && LuckyNumber < 50){
					jornadas[i].points += 3;
					jornadas[i].pointsFalse = 3;
				}
				else if(LuckyNumber >= 10 && LuckyNumber < 30){
					jornadas[i].points += 1;
					jornadas[i].pointsFalse = 1;
				}
				else if(LuckyNumber < 10){
					jornadas[i].points += 0;
					jornadas[i].pointsFalse = 0;
				}

				
			}
			cout << "\nRESULTADOS DE LA JORDANA: \n" << endl;
			cout << "\nJugadores							Puntos\n" << endl;
			for(int i = 0; i < jornadas.size(); i++){
			cout << jornadas[i].name; 
			cout << "\t\t\t\t\t\t\t\t" << jornadas[i].pointsFalse<< endl;
			}
			Around++;
		}
	}
}

//llenando arreglo de aleatorios
void FillingUpArray(){
    srand(time(NULL));
    int num = 0, k = 0;
    NumRandom[0] = 0; //comienza el arreglo con 0

    num = 1 + rand()% 20;

    for(int i = 1; i < 20; i++){
  
        while(!verifyNUM(num)){ //verificando si el numero se repite en el arreglo
            num = 1 + rand()% 20;
   
        } 

        NumRandom[i] = num;   
    }
}

//verificar si un numero esta o no en el arreglo
bool verifyNUM(int n){
    for(int i = 0; i < 20; i++){
        if(n == NumRandom[i] || n == 20) return false;
    }
    return true;
}

//emparejando los equipos
void Pairing(){
    int cont = 0, aux = 0, aux2 = 1;
    V vs;

    if(playeradd == false){
        cout << "\nINGRESE LOS EQUIPOS PRIMERO!" << endl;
    }
    else{
        if(first == 0){
            FillingUpArray();
            cout << "\nLOS QUIPOS QUEDAN DE ESTA MANERA:\n" << endl;
            do{

                cout << eliminatorias[NumRandom[aux+aux]].name << " VS " << eliminatorias[NumRandom[aux+aux2]].name << endl;
                //guardando los nombre de las parejas
                vs.player1 = eliminatorias[NumRandom[aux+aux]].name;
                vs.player2 = eliminatorias[NumRandom[aux+aux2]].name;
                //metiendolos a una cola
                games.push(vs);

                aux++;
                aux2++;

                cont++;

            }while(cont < 10);
            first = 1;
            pairingDone = true;
        }
        else{
            cout << "\nLOS QUIPOS QUEDAN DE ESTA MANERA:\n" << endl;
            do{

                cout << eliminatorias[NumRandom[aux+aux]].name << " VS " << eliminatorias[NumRandom[aux2+aux2]].name << endl;
                aux++;
                aux2++;

                cont++;

            }while(cont < 10);
        }

    }

}

//partidos de eliminatorias
void matches(){
    srand(time(NULL));
    queue<versus> temporary; //cola temporal
    V aux;
    int x = 0, y = 0;

	if(playeradd == false && pairingDone == false){
		cout << "\nNO HAY UNA ELIMINATORIA INICIADA O NO HAY EMPAREJAMIENTOS!" << endl;
	}
    else{
        cout << "\nRESULTADOS DE LAS PARTIDAS DE ELIMINATORIA\n" << endl;
        while(!games.empty()){
            aux = games.front(); //sacamos los jugadores de la cola
            temporary.push(games.front()); //guardamos en la cola tamporal los jugadores
            x = 1 + rand()% 9;
            y = 1 + rand()% 9;
            cout << aux.player1 << "\t" << x << " - " << y << "\t " << aux.player2 << endl; //se muestran los resultados
            games.pop();
        }

    }

}