namespace Interfaz;

using System.Runtime.InteropServices;
using EspacioCadeteria;
static class Interfaz{
    public static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(10); // Retardo de 10 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    public static string Centrar(string palabra, int espacios){
        int Blanco = (espacios - palabra.Length)/2;
        string palabraCentrada = palabra.PadLeft(palabra.Length + Blanco);
        palabraCentrada = palabraCentrada.PadRight(espacios);
        return palabraCentrada;
    }
    static void menu(){
        ConsoleKeyInfo key;
        int op = 1, salir=0;
        var Cadeteria = new Cadeteria("YaPedidos",4265192);
        do{
            Console.WriteLine(Centrar("++   "+Cadeteria.Nombre+"   ++",30));
            Console.WriteLine(Centrar("  +Tel:"+Cadeteria.Telefono+"+", 30));
            if(op==1){
                Console.WriteLine(Centrar(">>Pedidos<<",30));
            }else{
                Console.WriteLine(Centrar("Pedidos",30));
            }
            if(op==2){
                Console.WriteLine(Centrar(">>Finalizar Día<<",30));
            }else{
                Console.WriteLine(Centrar("Finalizar Día",30));
            }
            key = Console.ReadKey();
            Console.Clear();
            switch (key.Key)
            {   
                case ConsoleKey.UpArrow:
                    if(op>1){
                        op--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(op<2){
                        op++;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch (op)
                    {   
                        case 1:
                            Pedidos();
                            break;
                        case 2:
                            salir = 1;
                            break;
                    }
                    break;
            }
        } while (key.Key != ConsoleKey.Escape && salir==0);
    }
    static void Pedidos(){

    }
}