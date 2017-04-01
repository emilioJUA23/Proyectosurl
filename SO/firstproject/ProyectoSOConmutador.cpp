#include <stdio.h>
#include <dos.h>
#include <conio.h>
#include <string.h>

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
int m_presionado = 0;
int contexto = 0;
int pt_cadena = 0; //Size de cadena
char cadena[80]; //Comandos
int salir = 0;
char squares[6][9][15];//squares[pantalla][posicion y][posicion x]
int  habilitados [6];
char far *video_mem = (char far*) 0xBB8000000L;


void limpiar_texto()
{
	gotoxy(2,23);
	for(int q=0;q<(17*3)-2;q=q+1)
	{
		 printf(" ");
	}
}
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
int posx(int pantallax)
{	//metooo que devuelve posicion x inicial de la pantalla
	if (pantallax==1||pantallax==4)	{return 2;}
	else if (pantallax==2||pantallax==5){return 2+17;}
	else if (pantallax==3||pantallax==6){return 2+(17*2);}
	else{return 0;}
}

int posy(int pantallay)
{	//metodo que devuelve la posicion y inicial de la pantalla
    if (pantallay==1||pantallay==2||pantallay==3)	{return 2;}
	else if (pantallay==4||pantallay==5||pantallay==6){return 2+11;}
	else{return 0;}
}

void imprimir_pantalla(int pa)
{
   for (int i = 0; i < 9; ++i)
   {
   		for (int j = 0; j < 15; ++j)
   		{
   			gotoxy(posx(pa)+j,posy(pa)+i);
   			printf("%c", squares[pa-1][i][j]);
   		}
   }

}

int tell_me_a_screen(int x,int y)
{
	//pantalla 1
	if (x>1&&x<17&&y>1&&y<11){return 1;}
	//pantalla 2 
	else if (x>18&&x<34&&y>1&&y<11){return 2;}
	//pantalla 3 
	else if (x>35&&x<51&&y>1&&y<11){return 3;}
	//pantalla 4 
	else if (x>1&&x<17&&y>12&&y<22){return 4;}
	//pantalla 5
	else if (x>18&&x<34&&y>12&&y<22){return 5;}
	//pantalla 6
	else if (x>35&&x<51&&y>12&&y<22){return 6;}
  	else {return 0;}

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
		int pantalla = tell_me_a_screen(x,y);
		if (pantalla==0)
		{
			count--;
		}
		else
		{ 
			
			if (habilitados[pantalla-1]==1)
			{
			   gotoxy(x,y);
			   printf("#");
			   squares[pantalla-1][y-posy(pantalla)][x-posx(pantalla)]='#';
			}
			
	      //  imprimir_pantalla(pantalla);
		}
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



//---------------------PROCESO DE TECLADO---------------------------
void comando()
{
	char *add = "add", *pause = "pause", *play = "play", *clear ="clear", *quantum = "quantum", *stats = "stats", *erase = "erase";
	int cmp;
	char *ptr, *tmp;
	char space = ' ';

	ptr = strchr(cadena,space);
	ptr++;

	gotoxy(2,25);
	cmp = strncmp(cadena,add,3);
	if (cmp == 0)
	{
		/* codigo add */
	}
	else
	{
	    cmp = strncmp(cadena,pause,5);
	    if (cmp == 0)
	    {
		/* codigo pause */
	    }
	    else
	    {
		cmp = strncmp(cadena,play,4);
		if (cmp == 0)
		{
		     /* codigo play */
		}
		else
		{
		    cmp = strncmp(cadena,clear,5);
		    if (cmp == 0)
		    {
			/* codigo clear */
		    }
		    else
		    {
			cmp = strncmp(cadena,quantum,7);
			if (cmp == 0)
			{
			    tmp=strrchr(cadena,space);
			    tmp++;
			    /* codigo quantum */
			}
			else
			{
			    cmp = strncmp(cadena,stats,5);
			    if (cmp == 0)
			    {
				/* codigo stats */
			    }
			    else
			    {
				cmp = strncmp(cadena,erase,5);
				if (cmp == 0)
				{
				    /* codigo erase */
				}
				else
				{
				    printf("Comando invalido\n");
				}
			    }
			}
		    }
		}
	    }
	}
}
int Teclado(void)
{
	if(kbhit())
	{
		pt_cadena++;
		gotoxy(pt_cadena+1,23);
		char ch = getch();
		if(ch == 8) //Backspace
		{
		   if(pt_cadena > 1)
		   {
			pt_cadena--;
			gotoxy(pt_cadena+1,23);
			printf(" ");
			pt_cadena--;
			cadena[pt_cadena] = ch;
			gotoxy(pt_cadena+1,23);
		   }
		   else if (pt_cadena == 1)
		   {
			pt_cadena--;
			gotoxy(2,23);
			printf(" ");
			gotoxy(2,23);
			pt_cadena = 0;
		   }
		}
		else if (ch == 13)
		{
		   limpiar_texto();
		   pt_cadena = 0;
		   //Metodo de Leslie
		   comando();
		}
		else if (pt_cadena >= 79)
		{
		   pt_cadena--;
		}
		else
		{
		   printf("%c", ch);
		   cadena[pt_cadena - 1] = ch;
		}

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
		else if (contexto==1)
		{
			contexto=2;
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
{
	int zahl=1;	
	for (int j = 0; j < 6; ++j)
	{
		habilitados[j]=1;
	}
	
	clrscr();
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
			case 2:
				 if (habilitados[zahl-1]==1)
				 {
				 	imprimir_pantalla(zahl);
				 }
			     zahl++;
			     if (zahl==7)
			     {
			     	zahl=1;
			     }
			break;
		}
	}
	setvect(INTR, oldhandler);
	limpiar_texto();
	gotoxy(2,23);
	printf("Presiona enter para salir");
	gets(cadena);
	return 0;
}