namespace Interfaz;

using System;
using System.Linq;
using EspacioCadeteria;
static class InterfazVisual{
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
    public static void menu(Cadeteria Cadeteria){
        ConsoleKeyInfo key;
        int op = 1, salir=0;
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
                            Pedidos(Cadeteria);
                            break;
                        case 2:
                            salir = 1;
                            break;
                    }
                    break;
            }
        } while (key.Key != ConsoleKey.Escape && salir==0);
    }
    private static void Pedidos(Cadeteria Cadeteria){
        ConsoleKeyInfo key;
        int op = 1, salir=0;
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
                Console.WriteLine(Centrar(">>Cambiar estado<<",30));
            }else{
                Console.WriteLine(Centrar("Cambiar estado",30));
            }
            if(op==3){
                Console.WriteLine(Centrar(">>Reasignar<<",30));
            }else{
                Console.WriteLine(Centrar("Reasignar",30));
            }
            if(op==4){
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
                    if(op<4){
                        op++;
                    }
                    break;
                case ConsoleKey.Enter:
                    switch (op)
                    {   
                        case 1:
                            Alta(pedido);
                            pedido = null;
                            break;
                        case 2:
                            CambiarEstado(Cadeteria);
                            break;
                        case 3:
                            Reasignar(Cadeteria);
                            break;
                        case 4:
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
        if(op.Key== ConsoleKey.S || op.Key== ConsoleKey.Y || op.Key== ConsoleKey.Enter)
        {
            p = Cadeteria.TomarPedido(nombre, direccion, telefono, datosRef, observacion);
            EscribirMensaje("- Pedido creado...");
            Console.ReadKey();
            Console.Clear();
            Asignar(p, Cadeteria);
        }
        else
        {
            EscribirMensaje("- Pedido cancelado...");
        }
    }

    private static void Asignar(Pedido p, Cadeteria Cadeteria)
    {
        int id;
        Console.WriteLine(Centrar(">>>ASIGNAR PEDIDO<<<", 30));
        Console.WriteLine("-> LISTADO DE CADETES:");
        foreach (var c in Cadeteria.Cadetes)
        {
            Console.WriteLine(" ->ID:" + c.Id + ", " + c.Nombre + " Cantidad de pedidos: " + c.Pedidos.Count());
        }
        EscribirMensaje("- Elija el ID del cadete a asignar:");
        int.TryParse(Console.ReadLine(), out id);
        Console.Clear();
        if (id < Cadeteria.Cadetes.Count() && id > 0)
        {
            Cadeteria.AsignarPedido(id, p);
            EscribirMensaje("- Pedido asignado...");
        }
        else
        {
            EscribirMensaje("- ID no valido, se asignará automáticamente...");
            var r = new Random();
            id = r.Next(1, Cadeteria.Cadetes.Count());
            Cadeteria.AsignarPedido(id, p);
        }
    }

    private static void CambiarEstado(Cadeteria Cdria)
    {
        int numPed = 0;
        Console.WriteLine(Centrar(">>>CAMBIAR ESTADO<<<",30));
        EscribirMensaje("- Ingrese número del pedido:");
        int.TryParse(Console.ReadLine(), out numPed);
        Console.Clear();
        if(numPed >0 && numPed <= Cdria.NumPed)
        {
            Pedido pedido = BuscarPedidoPorNum(Cdria, numPed);
            Console.WriteLine(Centrar(">>>CAMBIAR ESTADO<<<", 30));
            Console.WriteLine(Centrar("PEDIDO " + pedido.Numero, 30));
            Console.WriteLine(" ->Estado: " + pedido.Estado.ToString());
            Console.WriteLine(" ->Cliente: " + pedido.Client.Nombre);

            var key = new ConsoleKeyInfo();
            int op = 3, salir = 0;
            do
            {
                Console.WriteLine(Centrar(">>>CAMBIAR ESTADO<<<", 30));
                Console.WriteLine(Centrar("PEDIDO " + pedido.Numero, 30));
                Console.WriteLine(" ->Estado: " + pedido.Estado.ToString());
                Console.WriteLine(" ->Cliente: " + pedido.Client.Nombre);
                switch (pedido.Estado)
                {
                    case Estado.SinEntregar:
                        if (op == 1)
                        {
                            Console.WriteLine(Centrar(">>Cancelar<<", 30));
                        }
                        else
                        {
                            Console.WriteLine(Centrar("Cancelar", 30));
                        }
                        if (op == 2)
                        {
                            Console.WriteLine(Centrar(">>Entregar<<", 30));
                        }
                        else
                        {
                            Console.WriteLine(Centrar("Entregar", 30));
                        }
                        break;
                    case Estado.Entregado:
                        Console.WriteLine("El pedido ya fué entregado.");
                        break;
                    case Estado.Cancelado:
                        Console.WriteLine("El pedido ya fué dado de baja.");
                        break;
                }
                if (op == 3)
                {
                    Console.WriteLine(Centrar(">>Salir<<", 30));
                }
                else
                {
                    Console.WriteLine(Centrar("Salir", 30));
                }
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (op > 1 && pedido.Estado == Estado.SinEntregar)
                        {
                            op--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (op < 3 && pedido.Estado == Estado.SinEntregar)
                        {
                            op++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (op)
                        {
                            case 1:
                                pedido.CancelarPedido();
                                break;
                            case 2:
                                pedido.EntregarPedido();
                                break;
                            case 3:
                                salir = 1;
                                break;
                        }
                        break;
                }
            } while (key.Key != ConsoleKey.Escape && salir == 0);

        }
        else
        {
            EscribirMensaje("- El número no corresponde a un pedido existente...");
        }
    }

    private static Pedido BuscarPedidoPorNum(Cadeteria Cdria, int numPed)
    {
        return Cdria.Cadetes.SelectMany(cad => cad.Pedidos).FirstOrDefault(ped => ped.Numero == numPed);
    }

    private static void Reasignar(Cadeteria Cdria)
    {
        int numPed = 0;
        Console.WriteLine(Centrar(">>>REASIGNAR PEDIDO<<<",30));
        EscribirMensaje("- Ingrese número del pedido:");
        int.TryParse(Console.ReadLine(), out numPed);
        Console.Clear();
        if(numPed>0 && numPed<Cdria.NumPed){
            var ped = BuscarPedidoPorNum(Cdria,numPed);
            if(ped.Estado != Estado.Cancelado && ped.Estado != Estado.Entregado){
                Asignar(ped,Cdria);
            }else{
                if(ped.Estado == Estado.Cancelado){
                    EscribirMensaje("- No se puede reasignar porque ya fué cancelado");
                }else{
                    EscribirMensaje("- No se puede reasignar porque ya fué entregado");
                }
            }
        }
    }
}