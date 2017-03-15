#include <string>
#include <iostream>
using namespace std;

void  pantalla_inicial()
{
	string line1(17,'*'),	line2(17,' ');
	string line3(17*3,' ');
	line3[0]='*';
	line3[(17*3)-1]='*';
	line2[0]='*';
	line2[16]='*';
	
	cout <<line1<<line1<<line1<<endl;
	for	(int i=0;i<9;i=i+1)
	{
	  cout <<line2<<line2<<line2<<endl;
	}
	cout <<line1<<line1<<line1<<endl;
	for	(int i=0;i<9;i=i+1)
	{
	  cout <<line2<<line2<<line2<<endl;
	}
	cout <<line1<<line1<<line1<<endl;
	
	cout <<line3<<endl;
	cout <<line1<<line1<<line1<<endl;

}



string squares[6][9];	
void llenar_matriz()
{
	for(int i=0;i<6;i=i+1)
	{
	  for(int j=0;j<9;j=j+1)
		{
		  squares[i][j]=string(15,' ');	
		} 	
	}
}
int main()
{
  	//pantalla_inicial();
  	//getchar();
  	//system("cls");
  	//printf("\033[%d;%dH", row, col);
  	
  	//string line(15,' ');
  	//string square[] = {line,line,line,line,line,line,line,line,line};
	llenar_matriz();
	squares[1][2][4]='*';
	squares[1][3][4]='?';
	squares[1][2][5]='0';
	squares[2][2][4]='*';
	for(int i=0;i<6;i=i+1)
	{
	  for(int j=0;j<9;j=j+1)
		{
		  	cout <<squares[i][j]<<endl;
		} 	
		cout <<endl;
		cout <<endl;
	}

	getchar();
	system("cls");
  	return 0;
	
}



