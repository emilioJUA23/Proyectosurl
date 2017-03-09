
#include "NodoCola.h"

	
  
	
  
PCB *NodoCola::ObtenerDato()	
{	
  return Dato;	
}	
  
	
  
NodoCola *NodoCola::ObtenerSiguiente()	
{	
  return Siguiente;	
}	
  
	
  
void NodoCola::ModificarSiguiente(NodoCola *siguiente)	
{	
  Siguiente = siguiente;	
}
