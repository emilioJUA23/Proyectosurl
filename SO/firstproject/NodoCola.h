#include <iostream>
#include <string>
#include "pcb.h"

using namespace std;

class NodoCola {

    public:
    PCB *Dato = nullptr;	
    NodoCola *Siguiente = nullptr;	
    NodoCola(PCB *dato,NodoCola *siguiente)	
    {	
        Dato = dato;	
        Siguiente = siguiente;	
    }	
    PCB *ObtenerDato();	
    NodoCola *ObtenerSiguiente();	
    void ModificarSiguiente(NodoCola *siguiente);	
  
};


