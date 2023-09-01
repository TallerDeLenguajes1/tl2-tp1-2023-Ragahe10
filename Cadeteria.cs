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
    // PROPIEDADES
    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

    // CONSTRUCTORES
    public Cadeteria(string nombre, int telefono) {
        Nombre = nombre;
        Telefono = telefono;
        Cadetes = new List<Cadete>();
    }

    // METODOS
    public void AsignarPedido(string nombre, string direccion, int telefono, string datos, string observacion) {

    }
    public void CancelarPedido(string nombre, string direccion, int telefono, string datos, string observacion) {

    }
    public void MoverPedido(string nombre, string direccion, int telefono, string datos, string observacion) {

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
    public void TomarPedido(string nombre, string direccion, int telefono, string datos, string observacion) {
        var p = new Pedido()
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