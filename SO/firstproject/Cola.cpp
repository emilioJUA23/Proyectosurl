#include "Cola.h"  
  
bool Cola::EsNulo()  
{ 
  return (Tamanio == 0);
} 

void Cola::Meter(PCB *dato)  
  
{ 
  NodoCola *nodo = nullptr;
  NodoCola *corredor = nullptr;  
  nodo = new NodoCola(dato, nullptr);  
  corredor = Cima;
  
  if(EsNulo())
  {
      Cima=nodo;
  }
  else
  {
     while(corredor->ObtenerSiguiente()!=nullptr)
     {
      corredor = corredor->ObtenerSiguiente();
     }
     corredor->ModificarSiguiente(nodo);
  }
  
  Tamanio++;
} 
  
  
  
PCB  *Cola::Sacar()  
  
{ 
    
  NodoCola *nodo = nullptr;  
  PCB  *dato = nullptr;  
  nodo = Cima; 
  Cima = nodo->ObtenerSiguiente(); 
  dato = nodo->ObtenerDato();  
  delete nodo; 
  Tamanio --;  
  return dato; 
} 
  
int Cola::ObtenerTamanio()  
{ 
  return Tamanio;  
} 
  


