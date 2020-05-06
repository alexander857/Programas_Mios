#include<iostream>
#include<string>
using namespace std;

int pedirEdad(int Tuedad);

int main(){

    int edad = 0;

    edad = pedirEdad(edad);

    cout << "Tu edad es: " << edad << endl;
    return 0;
}

int pedirEdad(int Tuedad){
    cout << "Ingresa tu edad: "; cin >> Tuedad;
    return Tuedad;
}