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



int main()
{
  	pantalla_inicial();
  	//getchar();
  	//system("cls");
  	string line(15,'*');
  	string square[] = {line,line,line,line,line,line,line,line,line};
  	square[3][5]='5';
	for(int i=0;i<9;i=i+1)
	{
	  cout <<square[i]<<endl;	
	} 
	getchar();
	system("cls");
  	return 0;
	
}



