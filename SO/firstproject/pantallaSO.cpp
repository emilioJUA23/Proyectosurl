#include <stdio.h>
#include <conio.h>
#include <dos.h>

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


}



char squares[6][9][15];	
void llenar_matriz()
{
	for(int i=0;i<6;i=i+1)
	{
	  for(int j=0;j<9;j=j+1)
		{
			for(int k=0;k<15;k=k+1)
			{
				
			  squares[i][j][k]='=';	
			}	
		} 	
	}
}
int main()
{
  	pantalla_inicial();
  	//getchar();
  	//system("cls");
  	//printf("\033[%d;%dH", row, col);
  	
  	//string line(15,' ');
  	//string square[] = {line,line,line,line,line,line,line,line,line};
	/*llenar_matriz();
	squares[1][2][4]='*';
	squares[1][3][4]='?';
	squares[1][2][5]='0';
	squares[2][2][4]='*';
	//gotoxy(4,5);
	for(int i=0;i<6;i=i+1)
	{
	  for(int j=0;j<9;j=j+1)
		{
				for(int k=0;k<15;k=k+1)
			{
				
			  printf(""+squares[i][j][k]);	
			}	
		  	printf("\n");
		} 	
		printf("\n");
		printf("\n");
	}
*/
	getchar();
  	return 0;
	
}



