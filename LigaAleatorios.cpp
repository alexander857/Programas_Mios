#include<iostream>
#include<algorithm>
#include<string>
#include<time.h>
#include<stdlib.h>
#include<vector>
#include<queue>
#include<stack>

using namespace std;

//informacion que tendra cada jugador
struct infoPlayer{
	string name;
	int points, pointsFalse, ID;
};

typedef infoPlayer P;

vector<infoPlayer> jornadas, pairing, extra; //vector para jornadas y vector de eliminatorias
stack<infoPlayer> pila1, pila2, pilaVS1, pilaVS2, pilaVS3, pilaVS4;

//variables globales                            eliminatorias          jornadas
bool playeraddJ = false, playeraddE = false, playOffPairing = false, playOffPairing2 = false;
int Around = 1, Around2 = 1;

//como ordenar el vector segun los puntos de las jornadas
bool ordenando(P a, P b){
	return a.points > b.points;
}

//prototipos de funciones
void AddPlayers(), scoreTable(), playRound(), playoff(), pairingEquipment(), pairingProcess(), Mix(), removePlayer(int), scoreTableE();
void Mix2(), removePlayer2(int n), pairingEquipment2(), pairingProcess2();
int menuCompetition();

int main(){
	P aPlayer;

	bool follow = true;

	do{
		char option = 0;
		cout << "\n\033[36m--------------------JORNADAS Y ELIMINATORIAS FIFA SPORTS--------------------\033[0m\n" << endl;
		cout << "J-Jugar Jornada (" << Around << ")\t\t\tX-Tabla de Posiciones Liga\n";
        cout << "E-Jugar Eliminatoria (" << Around2 << ")\t\tY-Tabla de Posiciones Champions League\n";
		cout << "C-Emparejamientos de Champions\t\tL-Emparejamientos de Liga\n";
        cout << "A-Ingresar Jugadores\t\t\tS-Salir\n";
		cout << "Opcion: "; cin >> option; cin.ignore();

		switch(option){
			case 'J': //funcion de jornadas
            case 'j': playRound(); break; 
            case 'X': //funcion de tablas de posiciones jornadas
			case 'x': scoreTable(); break; 
            case 'L': //emparejamiento de jornadas
            case 'l': pairingEquipment2(); break;
            case 'E': //jugar eliminatorias
            case 'e': playoff(); break;  
            case 'Y'://tabla de eliminatorias
            case 'y': scoreTableE(); break;
            case 'C': //emparejamientos
            case 'c': pairingEquipment(); break;
			case 'A': //ingresar jugadores
            case 'a': AddPlayers(); break;
			case 'S': //salir
            case 's': follow = false; break;
            default : cout << "\nOpcion invalida!" << endl;
		}

	}while(follow);

	return 0;
}

//elegir tipo de competencia para los jugadores
int menuCompetition(){

    int option;

    while(option < 1 || option > 4){
        //se pide el tipo decompetencia
        cout << "\n\033[35m----------TIPO DE COMPETENCIA A JUGAR----------\033[0m\n" << endl;
        cout << "1-Liga de jornadas\t3-Ambas competencias\n2-Eliminatorias\t\t4-Salir\n";
        cout << "\nOpcion: "; cin >> option; cin.ignore();
    }
    return option;
}

void AddPlayers(){
	P aPlayer;
	int k = 0, option = 0, typeCompetition = 0;
    //se resive la opcion en el menu de tipo de competencia
    typeCompetition = menuCompetition();

    switch(typeCompetition){

        case 1: //caso jornadas
            if(playeraddJ == true){
                cout << "\nYa hay una liga iniciada, podra ingresar nuevos jugadores cuando acabe!" << endl;
            }
            else{
                cout << "\nOBLIGATORIAMENTE TIENE QUE SER 20 JUGADORES!\n\n" << endl;
                do{
                    cout << "Ingrese ID del jugador: "; getline(cin, aPlayer.name);
                    aPlayer.points = 0;
                    aPlayer.pointsFalse = 0;
                    aPlayer.ID = k + 1;
                    jornadas.insert(jornadas.end(), aPlayer); //guardando info para jornadas
                    k++;
                }while(k < 20);
                playeraddJ = true; //ya hay una jornada iniciada
            }
        break;
        case 2: //caso eliminatorias 
            if(playeraddE == true){
                cout << "\nYa hay una eliminatoria iniciada, podra ingresar nuevos jugadores cuando acabe!" << endl;
            }
            else{
                cout << "\nOBLIGATORIAMENTE TIENE QUE SER 32 JUGADORES!\n\n" << endl;
                do{
                    cout << "Ingrese ID del jugador: "; getline(cin, aPlayer.name);
                    aPlayer.points = 0;
                    aPlayer.pointsFalse = 0;
                    aPlayer.ID = k + 1; //id del jugador
                    pairing.insert(pairing.end(), aPlayer); //guardando info para eliminatorias
                    extra.insert(extra.end(), aPlayer); //guardando misma info en extra
                    k++;
                }while(k < 32);
                playeraddE = true; //ya hay una eliminatoria iniciada
            }
        break;
        case 3: //ambas competencias
            if(playeraddE == true || playeraddJ == true){
                cout << "\nPUEDE QUE HAYA UNA ELIMINATORIA, UNA JORNADA O AMBAS INICIADA, INTENTELO CUANDO ACABEN!" << endl;
            }
            else{
                cout << "\nINGRESE 32 JUGADORES, 12 DE ELLOS SOLO ESTARAN EN ELIMINATORIAS!\n\n" << endl;
                do{
                    cout << "Ingrese ID del jugador: "; getline(cin, aPlayer.name);
                    aPlayer.points = 0;
                    aPlayer.pointsFalse = 0;
                    aPlayer.ID = k + 1;
                    //para jornadas solo se guardan los primeros 20
                    if(k < 20) jornadas.insert(jornadas.end(), aPlayer); //guardando info para jornadas
                    
                    pairing.insert(pairing.end(), aPlayer); //guardando info para eliminatorias
                    extra.insert(extra.end(), aPlayer); //guardando misma info en extra
                    k++;
                }while(k < 32);

                playeraddE = true; //ya hay una eliminatoria iniciada
                playeraddJ = true; //ya hay una jornada iniciada
            }
    }


}
//tabla de puntuacion de jornadas
void scoreTable(){

	if(playeraddJ == false){
		cout << "\nNO HAY UNA LIGA INICIADA!" << endl;
	}
	else{

		sort(jornadas.begin(), jornadas.end(), ordenando);
        cout << "\nTABLA DE PUNTUACIONES DE LAS JORNADAS\n";
		cout << "\nJugadores			Puntos\n" << endl;
		for(int i = 0; i < jornadas.size(); i++){
            if(i < 3) cout << "\033[34m" << jornadas[i].name << "				" << jornadas[i].points << "\033[0m" << endl;
                
			else if(i < 9) cout << "\033[33m" << jornadas[i].name << "				" << jornadas[i].points << "\033[0m" << endl;
                
            else if(i < 16) cout << "\033[32m" << jornadas[i].name << "				" << jornadas[i].points << "\033[0m" << endl;

            else if(i < 20) cout << "\033[31m" << jornadas[i].name << "				" << jornadas[i].points << "\033[0m" << endl;
		}
        cout << "\033[36m----------------------------------------------------------\033[0m" <<endl;
        cout << "\033[34m * \033[0m   Mejores Equipos de la Competencia" << endl;
        cout << "\033[33m * \033[0m   Casi de los Mejores de la Competencia" << endl;
        cout << "\033[32m * \033[0m   Equipos Regulares de la Competencia" << endl;
        cout << "\033[31m * \033[0m   Equipos en Descenso" << endl;
	}

}
//tabla de puntuaciones de eliminatorias
void scoreTableE(){
	if(playeraddE == false){
		cout << "\nNO HAY UNA ELIMINATORIA INICIADA!" << endl;
	}
    else{
        sort(pairing.begin(), pairing.end(), ordenando);
        cout << "\nTABLA DE PUNTUACIONES DE LAS ELIMINATORIAS\n";
		cout << "\nJugadores			Puntos\n" << endl;
		for(int i = 0; i < pairing.size(); i++){
            if(i < 5) cout << "\033[34m" << pairing[i].name << "				" << pairing[i].points << "\033[0m" << endl;
                
			else if(i < 15) cout << "\033[33m" << pairing[i].name << "				" << pairing[i].points << "\033[0m" << endl;
                
            else if(i < 25) cout << "\033[32m" << pairing[i].name << "				" << pairing[i].points << "\033[0m" << endl;

            else if(i < 33) cout << "\033[31m" << pairing[i].name << "				" << pairing[i].points << "\033[0m" << endl;
		}
        cout << "\033[36m----------------------------------------------------------\033[0m" <<endl;
        cout << "\033[34m * \033[0m   Mejores Equipos de la Competencia" << endl;
        cout << "\033[33m * \033[0m   Casi de los Mejores de la Competencia" << endl;
        cout << "\033[32m * \033[0m   Equipos Regulares de la Competencia" << endl;
        cout << "\033[31m * \033[0m   Equipos en Descenso" << endl;
    }
}

//FUNCION PARA JUGAR UNA JORNADA
void playRound(){
	srand(time(NULL));
	int x = 0, y = 0;
    P aux, aux2;

	    //se verifica si se hizo ya el emparejamiento
    if(playOffPairing2 == false){
        cout << "\nVISITE LA OPCION DE EMPAREJAMIENTO PRIMERO DE LIGA!" << endl;
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

			playeraddJ = false;
			jornadas.clear(); //se vacia el vector para una nueva liga
			Around = 1; //se reinicia el contador de jornadas
		}
		else{
            //proceso de la funcion
            //se juega una jornada
            cout << "\nRESULTADOS DE LA JORNADA DE LIGA " << Around << "\n" << endl;
            while(!pilaVS3.empty() || !pilaVS4.empty()){
                //se sacan unos numeros aleatorios

                x = 1 + rand()% 9;
                y = 1 + rand()% 9;

                //se muestra cada pareja y sus resultados
                cout << pilaVS3.top().name << " \t" << x << " - " << y << "  \t" << pilaVS4.top().name << endl;
                //guardo la info de los participantes
                aux = pilaVS3.top();
                aux2 = pilaVS4.top();

                //se busca jugador 1 en el vector original
                for(auto iter = jornadas.begin(); iter != jornadas.end(); ++iter){
                    if(iter->ID == aux.ID){
                        if(x > y) iter->points += 3;
                        else if(x < y) iter->points += 0;
                        else if(x == y) iter->points += 1;
                        break;
                    }
                }
                //se busca jugador 2 en el vector original
                for(auto iter = jornadas.begin(); iter != jornadas.end(); ++iter){
                    if(iter->ID == aux2.ID){
                        if(x < y) iter->points += 3;
                        else if(x > y) iter->points += 0;
                        else if(x == y) iter->points += 1;
                        break;
                    }
                }

                //se eliminan de la pila los jugadores
                pilaVS3.pop();
                pilaVS4.pop();
            }
            playOffPairing2 = false;
			Around++;
		}
	}
}

//FUNCION PARA JUGAR UNA ELIMINATORIA
void playoff(){
    srand(time(NULL));
    int x = 0, y = 0;
    P aux, aux2;

    //se verifica si se hizo ya el emparejamiento
    if(playOffPairing == false){
        cout << "\nVISITE LA OPCION DE EMPAREJAMIENTO PRIMERO DE CHAMPIONS LEAGUE!" << endl;
    }
    else{
        if(Around2 == 39){
            cout << "\nLAS ELIMINATORIAS TERMINARON, EL GANADOR DE LA TEMPORADA ES:\n" << endl;
            sort(pairing.begin(), pairing.end(), ordenando);

            for(int i = 0; i < pairing.size(); i++){
                cout << pairing[i].name << " con " << pairing[i].points << " puntos" << endl;
                break;
            }
            //se reinicia todo para otras eliminatorias
            playeraddE = false;
            pairing.clear();
            extra.clear();
            Around2 = 1;
            playOffPairing = false;
        }
        else{

            //proceso de la funcion
            //se juega una eliminatoria
            cout << "\nRESULTADOS DE LA ELIMINATORIA " << Around2 << "\n" << endl;
            while(!pilaVS1.empty() || !pilaVS2.empty()){
                //se sacan unos numeros aleatorios

                x = 1 + rand()% 9;
                y = 1 + rand()% 9;

                //se muestra cada pareja y sus resultados
                cout << pilaVS1.top().name << " \t" << x << " - " << y << "  \t" << pilaVS2.top().name << endl;
                //guardo la info de los participantes
                aux = pilaVS1.top();
                aux2 = pilaVS2.top();

                //se busca jugador 1 en el vector original
                for(auto iter = pairing.begin(); iter != pairing.end(); ++iter){
                    if(iter->ID == aux.ID){
                        if(x > y) iter->points += 3;
                        else if(x < y) iter->points += 0;
                        else if(x == y) iter->points += 1;
                        break;
                    }
                }
                //se busca jugador 2 en el vector original
                for(auto iter = pairing.begin(); iter != pairing.end(); ++iter){
                    if(iter->ID == aux2.ID){
                        if(x < y) iter->points += 3;
                        else if(x > y) iter->points += 0;
                        else if(x == y) iter->points += 1;
                        break;
                    }
                }

                //se eliminan de la pila los jugadores
                pilaVS1.pop();
                pilaVS2.pop();
            }

            playOffPairing = false;
            Around2++;

        }

    }
}

//FUNCION DE EMPAREJAMIENTO DE ELIMINATORIAS
void pairingEquipment(){
    P aux, aux2;
    //se verifica si se jugo una ronda de eliminatoria
    if(playOffPairing == true || playeraddE == false){
        cout << "\nINGRESE LOS JUGADORES O JUEGUE UNA ELIMINATORIA ANTES!" << endl;
    }
    else{
        if(Around2 == 39){
            cout << "\nLAS ELIMINATORIAS ACABARON, VEA EL GANADOR EN LA OPCION E, INGRESE MAS JUGADORES" << endl;
            playOffPairing = true;
        }
        else{
            //llamando la funcion que empareja los jugadores
            pairingProcess();
            //mostrando las parejas
            cout << "\nASI QUEDAN LOS PARTIDOS PARA LA ELIMINATORIA " << Around2 << "\n" << endl;
            while(!pila1.empty() || !pila2.empty()){
                //se sacan los dos primeros nombres de los jugadores
                aux.name = pila1.top().name;
                aux2.name = pila2.top().name;
                //se eliminan de las pilas esos nombres
                pila1.pop();
                pila2.pop();
                //se muestran los nombres
                cout << aux.name << "\tVS\t" << aux2.name << endl;
            }

            playOffPairing = true;//se hizo el emparejamiento
        }

    }

}
//proceso de emparejamiento de eliminatoria
void pairingProcess(){
    stack<P> pilaAssistant; //pila auxiliar
    P aux;

    Mix();
    //proceso de "barajear" los jugadores
    for(int i = 0; i < extra.size(); i++){
            aux.name = extra[i].name;
            aux.ID = extra[i].ID;
            aux.points = extra[i].points;
            aux.pointsFalse = extra[i].pointsFalse;
            pilaAssistant.push(aux); //se guarda la info del jugador en la pila auxiliar
     }
    

    //GUARDANDO LOS JUGADORES DE LA PILA AUXILIAR EN OTRAS DOS PILAS
    while(!pilaAssistant.empty()){
        pila1.push(pilaAssistant.top()); //guardamos el primer dato de la pila aux en pila 1
        pilaVS1.push(pilaAssistant.top()); //se guarda la info en la pila para jugar eliminatorias
        pilaAssistant.pop();
        pila2.push(pilaAssistant.top()); //guardamos el otro dato en la pila 2
        pilaVS2.push(pilaAssistant.top()); //se guarda la info en la pila para jugar eliminatorias
        pilaAssistant.pop();
    }

}
//genera numeros aleatorios para buscar ese jugador eliminatorias
void Mix(){
    for(int i=0; i<100; i++) {
            
        int n = rand() % 32 + 1;
    
        removePlayer(n);
    }
}
//se busca el jugador en el vector para eliminarlo y volver a guardarlo en otra posicion
void removePlayer(int n){
    P aux;
    for(auto iter = extra.begin(); iter != extra.end(); ++iter){
        if(iter->ID == n){
            aux.name = iter->name;
            aux.ID = iter->ID;
            aux.points = iter->points;
            aux.pointsFalse = iter->pointsFalse;
            iter = extra.erase(iter);
            break;
        }
    }
    extra.insert(extra.end(), aux); //se guarda de nuevo el jugador
}

//FUNCION DE EMPAREJAMIENTO DE JORNADAS
void pairingEquipment2(){
    P aux, aux2;
    //se verifica si se jugo una ronda de eliminatoria
    if(playOffPairing2 == true || playeraddJ == false){
        cout << "\nINGRESE LOS JUGADORES O JUEGUE UNA JORNADA ANTES!" << endl;
    }
    else{
        if(Around == 39){
            cout << "\nLAS JORNADAS ACABARON, VEA EL GANADOR EN LA OPCION J, INGRESE MAS JUGADORES" << endl;
            playOffPairing2 = true;
        }
        else{
            //llamando la funcion que empareja los jugadores
            pairingProcess2();
            //mostrando las parejas
            cout << "\nASI QUEDAN LOS PARTIDOS PARA LA JORNADA " << Around << "\n" << endl;
            while(!pila1.empty() || !pila2.empty()){
                //se sacan los dos primeros nombres de los jugadores
                aux.name = pila1.top().name;
                aux2.name = pila2.top().name;
                //se eliminan de las pilas esos nombres
                pila1.pop();
                pila2.pop();
                //se muestran los nombres
                cout << aux.name << "\tVS\t" << aux2.name << endl;
            }

            playOffPairing2 = true;//se hizo el emparejamiento
        }

    }

}

//proceso de emparejamiento de jornada
void pairingProcess2(){
    stack<P> pilaAssistant; //pila auxiliar
    P aux;

    Mix();
    //proceso de "barajear" los jugadores
    for(int i = 0; i < jornadas.size(); i++){
            aux.name = jornadas[i].name;
            aux.ID = jornadas[i].ID;
            aux.points = jornadas[i].points;
            aux.pointsFalse = jornadas[i].pointsFalse;
            pilaAssistant.push(aux); //se guarda la info del jugador en la pila auxiliar
     }
    

    //GUARDANDO LOS JUGADORES DE LA PILA AUXILIAR EN OTRAS DOS PILAS
    while(!pilaAssistant.empty()){
        pila1.push(pilaAssistant.top()); //guardamos el primer dato de la pila aux en pila 1
        pilaVS3.push(pilaAssistant.top()); //se guarda la info en la pila para jugar JORNADA
        pilaAssistant.pop();
        pila2.push(pilaAssistant.top()); //guardamos el otro dato en la pila 2
        pilaVS4.push(pilaAssistant.top()); //se guarda la info en la pila para jugar jornada
        pilaAssistant.pop();
    }

}

//aleatorios de las jornadas
void Mix2(){
    for(int i=0; i<100; i++) {
            
        int n = rand() % 20 + 1;
    
        removePlayer2(n);
    }
}

//se busca jugador en el vector de las jornadas
void removePlayer2(int n){
    P aux;
    for(auto iter = jornadas.begin(); iter != jornadas.end(); ++iter){
        if(iter->ID == n){
            aux.name = iter->name;
            aux.ID = iter->ID;
            aux.points = iter->points;
            aux.pointsFalse = iter->pointsFalse;
            iter = jornadas.erase(iter);
            break;
        }
    }
    jornadas.insert(jornadas.end(), aux); //se guarda de nuevo el jugador
}