using EspacioCadeteria;
using Microsoft.VisualBasic.FileIO;

namespace EspacioArchivos;
public static class Archivos{
    public static bool Existe(string nombre){
        return File.Exists(nombre+".csv");
    }
    public static Cadeteria LeerCadeteria(string nombre){
        using(TextFieldParser ruta = new TextFieldParser(nombre+".csv")){
            ruta.TextFieldType = FieldType.Delimited;
            ruta.SetDelimiters(",",";");
            while(ruta.EndOfData){
                string[] filas = ruta.ReadFields();
                if(filas.Count()==2){
                    var nom = filas[0];
                    int tel; 
                    int.TryParse(filas[1],out tel);
                    var Cdria = new Cadeteria(nom,tel);
                    return Cdria;
                }else{
                    System.Console.WriteLine("no tiene el formato adecuado");
                }
            }
        }
        return null;
    }
    public static void LeerCadetes(string nombre, List<Cadete> Cadts){
        using(TextFieldParser ruta = new TextFieldParser(nombre+".csv")){
            ruta.TextFieldType = FieldType.Delimited;
            ruta.SetDelimiters(",",";");
            while(ruta.EndOfData){
                string[] filas = ruta.ReadFields();
                if(filas.Count()==4){
                    int id, tel; 
                    var nom = filas[1];
                    var dire = filas[2];
                    int.TryParse(filas[0],out id);
                    int.TryParse(filas[3],out tel);
                    var cad = new Cadete(id,nom,dire,tel);
                    Cadts.Add(cad);
                }else{
                    System.Console.WriteLine("no tiene el formato adecuado");
                }
            }
        }
    }
}