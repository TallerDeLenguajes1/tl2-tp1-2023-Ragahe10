using EspacioCadeteria;
using Interfaz;

var Cadeteria = new Cadeteria("YaPedidos",4265192);
var cadete1 = new Cadete(1,"Ramiro Herrea","BdRS",9);
var cadete2 = new Cadete(2,"José Boggio","YB",13);
var cadete3 = new Cadete(3,"Miguel Veliz","SMdT",4);

Cadeteria.Cadetes.Add(cadete1);
Cadeteria.Cadetes.Add(cadete2);
Cadeteria.Cadetes.Add(cadete3);

InterfazVisual.menu(Cadeteria);
