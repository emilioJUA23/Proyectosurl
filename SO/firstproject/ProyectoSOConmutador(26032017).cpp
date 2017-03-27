#include <stdio.h>
#include <dos.h>
#include <conio.h>

#define INTR 0X1C //Direccion de interrupcion de temporizador

#ifdef __cplusplus
	#define __CPPARGS ...
#else
	#define __CPPARGS
#endif

void interrupt (*oldhandler)(__CPPARGS);

//Variables Globales
int count = 0;
int quantum = 0;
int tempo = 0;
int j = 2; //Colores
int m_presionado = 0;
int t_presionado = 0;
int contexto = 0;
int pt_cadena = 0; //Size de cadena
char cadena[80]; //Comandos
int salir = 0;
char squares[6][9][15];
char far *video_mem = (char far*) 0xBB8000000L;

void  pantalla_inicial()
{
	for (int j =0;j<2;j=j+1)
	{

		for(int k=0;k<17*3;k=k+1)
		{
			 printf("*");
		}
		printf("\n");
		for(int l=0;l<9;l=l+1)
		{

			printf("*");
			for(int n=0;n<(17)-2;n=n+1)
			{
				 printf(" ");
			}
			printf("*");
			printf("*");
			for(int o=0;o<(17)-2;o=o+1)
			{
				 printf(" ");
			}
			printf("*");
			printf("*");
			for(int p=0;p<(17)-2;p=p+1)
			{
				 printf(" ");
			}
			printf("*");
			printf("\n");
	    }
	    for(int m=0;m<17*3;m=m+1)
		{
			 printf("*");
		}
		printf("\n");
		
	}
	printf("*");
	for(int q=0;q<(17*3)-2;q=q+1)
	{
		 printf(" ");
	}
	 printf("*");
	printf("\n");
	for(int r=0;r<17*3;r=r+1)
	{
		 printf("*");
	}
	printf("\n");



}

void color_text()
{
	int i;
	for (i=1; i<=3999; i=i+2)
	{
		*(video_mem + i) = j;
		if(j == 8)
		{
			j = 2;
		}
	}
	j++;
}

//----------------PROCESO DEL MOUSE--------------------------
int ResetRaton()
{
	union REGS regin, regout;
	regin.x.ax = 0;
	int86(0x33, &regin, &regout);
	if((int)regout.x.ax == 0)
	{
		printf("No hat un mouse instalado \n");
		return -1;
	}
	else  
	{
		//printf("Raton listo para utilizarse\n");
		regin.x.ax = 1;
		int86(0x33, &regin, &regout);
	}
	return 1;
}

int ClicRaton()
{
	union REGS regin, regout;
	regin.x.ax = 3;
	int86(0x33, &regin, &regout);
	 if(((int)regout.x.bx ==1) && (m_presionado == 0))
	 {
		//Mandar las coordenadas a un metodos que decida a que pantalla corresponde
		int x = ((int)regout.x.cx/8)+1;
		int y = ((int)regout.x.dx/8)+1;
		gotoxy(x,y);
		printf("#");
		m_presionado = 1;
		count++;
		return 1;
	 }
	 if((int)regout.x.bx == 0)
	 {
		m_presionado = 0;
	 }
	 return -1;
}

void limpiar_texto()
{
	gotoxy(2,23);
	for(int q=0;q<(17*3)-2;q=q+1)
	{
		 printf(" ");
	}
}

//---------------------PROCESO DE TECLADO---------------------------
int Teclado(void)
{
	if(kbhit())
	{
		//Verificar si es backspace
		pt_cadena++;
		gotoxy(pt_cadena+1,23);
		char ch = getch();
		printf("%c", ch);
		cadena[pt_cadena] = ch;
		//Metodo de Leslie
	}
	return 1;
}
//---------------------INTERRUPCION TEMPORIZADOR-----------------
void interrupt temporizador(__CPPARGS)
{
	disable();
	if(tempo == quantum)
	{
		//color_text();
		if(contexto == 0)
		{
			contexto = 1;
		}
		else
		{
			contexto = 0;
		}
		tempo =0;
	}
	else
	{
		tempo++;
	}
	enable();
	oldhandler();
}


//---------------------PROCESO KERNEL-------------------------------
int main(void)
{	clrscr();
	//llamamos a la pintada inicial
	pantalla_inicial();
	ResetRaton();
	oldhandler = getvect(INTR);
	setvect(INTR, temporizador);
	gotoxy(2,23);
	while ((count < 15) && (salir == 0))
	{
		switch(contexto)
		{
			case 0:
				ClicRaton();
				break;
			case 1:
				Teclado();
				break;
		}
	}
	setvect(INTR, oldhandler);
	limpiar_texto();
	gotoxy(2,23);
	printf("Presiona enter para salir\n");
	gets(cadena);
	return 0;
}