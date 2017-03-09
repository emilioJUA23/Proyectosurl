/*class for pcb
  un PCB tiene 
  id
  estado de proceso 
  instruction pointer
  valor de registros
  espacio de direcciones de memoria
  lista de recursos asignados 
*/ 
#include <iostream>
#include <string>

using namespace std;

class PCB
{
  public:	
    int ProcessID;
    string estado; //bloqueado ejecucion suspendido terminado 
    /*aqui van no solo registros generales sino todos los re-
    gistros de asm*/
    int AX,BX,CX,DX;
    int IP; //instrucion pointer
    int quantum;
    //punteros a la memoria del proceso
    //std::string rett();
    PCB(int process, int ip);
};
