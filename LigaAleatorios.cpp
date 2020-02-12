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
    int score1, score2;
};

typedef versus V;

struct PlayersPairing{ //registro para el vector de puntos de eliminatorias
    string playname;
    int score;
};

typedef PlayersPairing Play;

vector<infoPlayer> jornadas; //vector para jornadas
vector<infoPlayer> qualifiers; //vector para eliminatorias
vector<PlayersPairing> qualifiersTable; //ordenar las eliminatorias por puntos
queue<versus> games; //cola de partidas de eliminatorias

//variables globales
bool playeradd = false, pairingDone = false, pairingPlayed = false;
int Around = 1, NumRandom[20], first = 0, Around2 = 1;

//como ordenar el vector segun los puntos de las jornadas
bool ordenando(P a, P b){
	return a.points > b.points;
}
//como ordenar el vector de puntos de eliminatorias
bool ordenando2(Play a, Play b){
    return a.score > b.score;
}

//prototipos de funciones
void AddPlayers(), scoreTable(), playRound(), FillingUpArray(), Pairing(), matches(), scoreQualifiers();
bool verifyNUM(int);

int main(){
	P aPlayer;

	bool follow = true;

	do{
		int option = 0;
		cout << "\nLIGA DE ALEATORIOS\n" << endl;
		cout << "1-Jugar Jornada (" << Around << ")\n";
        cout << "2-Jugar Eliminatoria (" << Around2 << ")\n";
		cout << "3-Tabla de posiciones de las Jornadas\n";
        cout << "4-Tabla de puntuaciones de las Eliminatorias\n";
        cout << "5-Emparejamientos de Eliminatorias\n";
		cout << "6-Ingresar jugadores\n";
		cout << "7-Salir\n";
		cout << "Opcion: "; cin >> option; cin.ignore();

		switch(option){
			case 1: playRound(); break;
            case 2: matches(); break; 
			case 3: scoreTable(); break; //funcion de tablas de posiciones
            case 4: scoreQualifiers(); break; //puntuaciones de las qualifiers
            case 5: Pairing(); break;  //emparejamiento de qualifiers
			case 6: AddPlayers(); break;
			case 7: follow = false; break;
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
            qualifiers.insert(qualifiers.end(), aPlayer); //guardando info para qualifiers
			k++;
		}while(k < 20);
		playeradd = true; //ya hay una liga iniciada
	}

}
//tabla de puntuacion de jornadas
void scoreTable(){

	if(playeradd == false){
		cout << "\nNO HAY UNA LIGA INICIADA!" << endl;
	}
	else{

		sort(jornadas.begin(), jornadas.end(), ordenando);
        cout << "\nTABLA DE PUNTUACIONES DE LAS JORNADAS\n";
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
            cout << "\nLOS EQUIPOS QUEDAN DE ESTA MANERA:\n" << endl;
            do{

                cout << qualifiers[NumRandom[aux+aux]].name << " VS " << qualifiers[NumRandom[aux+aux2]].name << endl;
                //guardando los nombre de las parejas
                vs.player1 = qualifiers[NumRandom[aux+aux]].name;
                vs.player2 = qualifiers[NumRandom[aux+aux2]].name;
                //puntuacion inicial de cada jugador
                vs.score1 = 0;
                vs.score2 = 0;
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
            cout << "\nLOS EQUIPOS QUEDAN DE ESTA MANERA:\n" << endl;
            do{

                cout << qualifiers[NumRandom[aux+aux]].name << " VS " << qualifiers[NumRandom[aux2+aux2]].name << endl;
                aux++;
                aux2++;

                cont++;

            }while(cont < 10);
        }

    }

}

//partidos de qualifiers
void matches(){
    srand(time(NULL));
    queue<versus> temporary; //cola temporal
    V aux;
    Play auxP1, auxP2;
    int x = 0, y = 0;

	if(playeradd == false || pairingDone == false){
		cout << "\nNO HAY UNA ELIMINATORIA INICIADA O NO HAY EMPAREJAMIENTOS!" << endl;
	}
    else{
        if(Around2 == 39){
            cout << "\nLAS ELIMINATORIAS ACABARON!\n" << endl;
            cout << "El ganador de las eliminatorias es: ";
            sort(qualifiersTable.begin(), qualifiersTable.end(), ordenando2);
            for(int i = 0; i < qualifiersTable.size(); i++){
                cout << qualifiersTable[i].playname << " con " << qualifiersTable[i].score << " puntos" << endl;
                break;
            }
            Around2 = 1;
            //se reinician los puntos
            for(int i = 0; i < qualifiersTable.size(); i++){
                qualifiersTable[i].score = 0;
            }
            //se reinician los puntos de cada jugador de la cola
            while(!games.empty()){ 
                aux = games.front();
                aux.score1 = 0;
                aux.score2 = 0;
                temporary.push(aux);
                games.pop();
            }
            //se guardan los datos ya reiniciados de nuevo a la cola para otra eliminatoria
            while(!temporary.empty()){
                games.push(temporary.front());
                temporary.pop();
            }
            
        }
        else{
            cout << "\nRESULTADOS DE LAS PARTIDAS DE ELIMINATORIA " << Around2 << "\n" << endl;
            if(!qualifiersTable.empty()){
                    qualifiersTable.clear(); //se vacia el vector de eliminatorias para nuevos datos
            }
            while(!games.empty()){
                aux = games.front(); //sacamos los jugadores de la cola

                x = 1 + rand()% 9;
                y = 1 + rand()% 9;
                cout << aux.player1 << "\t" << x << " - " << y << "\t " << aux.player2 << endl; //se muestran los resultados
                //puntuacion correspondiente para cada jugador
                if(x > y) aux.score1 += 3;
                else if(x < y) aux.score2 += 3;
                else if(x == y){
                    aux.score1 += 1;
                    aux.score2 += 1;
                }
                //tomando los datos de cada jugador individualmente
                auxP1.playname = aux.player1;
                auxP1.score = aux.score1;
                auxP2.playname = aux.player2;
                auxP2.score = aux.score2;

                temporary.push(aux); //guardamos en la cola tamporal los jugadores

                qualifiersTable.insert(qualifiersTable.end(), auxP1); //guardando datos en el vector
                qualifiersTable.insert(qualifiersTable.end(), auxP2); //guardando datos en el vector
                    
                games.pop();
            }
            //llenando nuevamente la cola original con los jugadores
            while(!temporary.empty()){
                games.push(temporary.front());
                temporary.pop();
            }
            Around2++;
            pairingPlayed = true;
        }

    }

}

//tabla de puntuaciones de las qualifiers
void scoreQualifiers(){
    
	if(playeradd == false || pairingPlayed == false){
		cout << "\nNO HAY UNA ELIMINATORIA INICIADA O NO SE HA JUGADO FASE DE ELIMINATORIA!" << endl;
	}
	else{

		sort(qualifiersTable.begin(), qualifiersTable.end(), ordenando2);
        //mostrando la table de puntos de las eliminatorias
        cout << "\nTABLA DE PUNTUACIONES DE LAS ELIMINATORIAS\n";
		cout << "\nJugadores			Puntos\n" << endl;
		for(int i = 0; i < qualifiersTable.size(); i++){
            cout << qualifiersTable[i].playname << "				" << qualifiersTable[i].score << endl;
		}

	}
}