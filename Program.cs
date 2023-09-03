using EspacioCadeteria;
using EspacioArchivos;
using Interfaz;

var Cadet = Archivos.LeerCadeteria("Cadeteria");
Archivos.LeerCadetes("Cadetes", Cadet.Cadetes);


InterfazVisual.menu(Cadet);
