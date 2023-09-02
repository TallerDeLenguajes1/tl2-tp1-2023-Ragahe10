namespace EspacioCadeteria;

public enum Estado {
    SinEntregar,
    Cancelado,
    Entregado
}

public class Cadeteria {
    private string nombre;
    private int telefono;
    private List<Cadete> cadetes;
    private int numPed;
    // PROPIEDADES
    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
    public int NumPed { get => numPed; set => numPed = value; }

    // CONSTRUCTORES
    public Cadeteria(string nombre, int telefono) {
        Nombre = nombre;
        Telefono = telefono;
        Cadetes = new List<Cadete>();
        NumPed = 0;
    }

    // METODOS
    public void TomarPedido(string nombre, string direccion, int telefono, string datos, string datosRef,  string observacion, int id) {
        NumPed++;
        var cliente = new Cliente(nombre, direccion, telefono,datosRef);
        var pedido = new Pedido(NumPed,observacion,cliente);

    }
    public void CancelarPedido(int numeroPed) {
        foreach (var cad in Cadetes)
        {
            foreach (var p in cad.Pedidos)
            {
                if(p.Numero == numeroPed){
                    p.CambiarEstadoPedido(Estado.Cancelado);
                }
            }
        }
    }
    public void MoverPedido(int numeroPed, int id) {
        Pedido pedido = null;
        foreach (var cad in Cadetes)
        {
            if(cad.Id != id){
                foreach (var p in cad.Pedidos)
                {
                    if(p.Numero == numeroPed){
                        pedido = p;
                        cad.Pedidos.Remove(p);
                    }
                }
            }
        }
        if(pedido != null){
            foreach (var cad in Cadetes)
            {
                if(cad.Id == id){
                    cad.Pedidos.Add(pedido);
                }
            }
        }
    }
}
public class Cadete {
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> pedidos;


    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Pedidos = new List<Pedido>();
    }
    public void TomarPedido(Pedido p) {
        Pedidos.Add(p);
    }
    public void CancelarPedido(Estado estado /*datosdel pedido*/) {
        // buscar pedido y modificar
        // List<Pedido>[xx].CambiarEstadoPedido(estado)
    }
    public void EntregarPedido(Estado estado /*datosdel pedido*/) {
        // buscar pedido y modificar
        // List<Pedido>[xx].CambiarEstadoPedido(estado)
    }
    public void QuitarPedido() {

    }
    public void JornalACobrar() {

    }
}

public class Pedido {
    private int numero;
    private string observacion;
    private Estado estado;
    private Cliente client;


    public int Numero { get => numero; set => numero = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Client { get => client; set => client = value; }

    public Pedido(int numero, string observacion, Cliente cliente){
        Numero = numero;
        Observacion = observacion;
        Estado = Estado.SinEntregar;
        Client = cliente;
    }

    public void CambiarEstadoPedido(Estado estado) {
        Estado = estado;
    }
}

public class Cliente {
    private string nombre;
    private string direccion;
    private int telefono;
    private string datosRefDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string DatosRefDireccion { get => datosRefDireccion; set => datosRefDireccion = value; }
    
    public Cliente (string nombre, string direccion, int telefono, string datosRefDireccion) {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosRefDireccion = datosRefDireccion;
    }
}