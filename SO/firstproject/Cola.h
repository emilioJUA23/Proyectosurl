#include "NodoCola.h"	

class Cola	
  
{	
private:	
  int Tamanio =	 0;	
  NodoCola *Cima = nullptr;	
  
public:	
  Cola()  
  { 
    Tamanio = 0;  
    Cima = nullptr;  
  } 	
  void Meter(PCB *dato);	
  PCB *Sacar();	
  bool EsNulo();	
  int ObtenerTamanio();	
  
};	