namespace Interfaz;

using System;
using System.Runtime.InteropServices;
using EspacioCadeteria;
static class Interfaz{
    private static void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(10); // Retardo de 10 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    private static string Centrar(string palabra, int espacios){
        int Blanco = (espacios - palabra.Length)/2;
        string palabraCentrada = palabra.PadLeft(palabra.Length + Blanco);
        palabraCentrada = palabraCentrada.PadRight(espacios);
        return palabraCentrada;
    }
    public static void menu(){
        ConsoleKeyInfo key;
        int op = 1, salir=0;
        var Cadeteria = new Cadeteria("YaPedidos",4265192);
        do{
            Console.WriteLine(Centrar("++   "+Cadeteria.Nombre+"   ++",30));
            Console.WriteLine(Centrar("+Tel:"+Cadeteria.Telefono+"+", 30));
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
    private static void Pedidos(){
        ConsoleKeyInfo key;
        int op = 1, salir=0;
        var Cadeteria = new Cadeteria("YaPedidos",4265192);
        Pedido pedido = null;
        do{
            Console.WriteLine(Centrar("++   "+Cadeteria.Nombre+"   ++",30));
            Console.WriteLine(Centrar("+Tel:"+Cadeteria.Telefono+"+", 30));
            Console.WriteLine(Centrar(">>>> PEDIDOS <<<<", 30));
            if(op==1){
                Console.WriteLine(Centrar(">>Dar de alta<<",30));
            }else{
                Console.WriteLine(Centrar("Dar de alta",30));
            }
            if(op==2){
                Console.WriteLine(Centrar(">>Dar de alta<<",30));
            }else{
                Console.WriteLine(Centrar("Dar de alta",30));
            }
            if(op==3){
                Console.WriteLine(Centrar(">>Cambiar estado<<",30));
            }else{
                Console.WriteLine(Centrar("Cambiar estado",30));
            }
            if(op==4){
                Console.WriteLine(Centrar(">>Reasignar<<",30));
            }else{
                Console.WriteLine(Centrar("Reasignar",30));
            }
            if(op==5){
                Console.WriteLine(Centrar(">>Salir<<",30));
            }else{
                Console.WriteLine(Centrar("Salir",30));
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
                    if(op<5){
                        op++;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch (op)
                    {   
                        case 1:
                            Alta(pedido);
                            break;
                        case 2:
                            Asignar(pedido);
                            break;
                        case 3:
                            CambiarEstado();
                            break;
                        case 4:
                            Reasignar();
                            break;
                        case 5:
                            salir = 1;
                            break;
                    }
                    break;
            }
        } while (key.Key != ConsoleKey.Escape && salir==0);
    }


    private static void Alta(Pedido p)
    {
        var Cadeteria = new Cadeteria("YaPedidos",4265192);

        Console.WriteLine(Centrar(">>>ALTA PEDIDO<<<",30));
        EscribirMensaje("- Ingrese los siguientes datos:");
        Console.ReadKey();

        string nombre, direccion, datosRef, observacion;
        int telefono;
        EscribirMensaje("- Nombre de la persona que hace el pedido:");
        nombre = Console.ReadLine();
        EscribirMensaje("- Dirección:");
        direccion = Console.ReadLine();
        EscribirMensaje("- Referencias sobre la dirección:");
        datosRef = Console.ReadLine();
        EscribirMensaje("- Teléfono:");
        int.TryParse(Console.ReadLine(),out telefono);
        EscribirMensaje("- Observación del pedido:");
        observacion = Console.ReadLine();
        
        Console.Clear();
        Console.WriteLine(Centrar(">>>ALTA PEDIDO<<<",30));
        Console.WriteLine("<> PEDIDO Nº "+Cadeteria.NumPed);
        Console.WriteLine("  ->Observación: "+observacion);
        Console.WriteLine("  ->Datos del Cliente:");
        Console.WriteLine("     ->Nombre: "+nombre);
        Console.WriteLine("     ->Direccion: "+direccion);
        Console.WriteLine("     ->Referencias: "+datosRef);
        Console.WriteLine("     ->Teléfono: "+telefono);

        EscribirMensaje("- Confirma el pedido???(presione enter, s o y, para confirmar)");
        ConsoleKeyInfo op = Console.ReadKey();
        if(op.Key== ConsoleKey.S || op.Key== ConsoleKey.Y || op.Key== ConsoleKey.Enter){
            p = Cadeteria.TomarPedido(nombre,direccion, telefono, datosRef,observacion);
            EscribirMensaje("- Pedido creado...");
        }else{
            EscribirMensaje("- Pedido cancelado...");
        }
    }
    private static void Asignar(Pedido pedido)
    {
        throw new NotImplementedException();
    }
    private static void CambiarEstado()
    {
        throw new NotImplementedException();
    }
    private static void Reasignar()
    {
        throw new NotImplementedException();
    }

}