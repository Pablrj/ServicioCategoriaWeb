using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface CategoriaIService
{

    [OperationContract]
    int NuevaCategoria(miCategoria categoria);

    [OperationContract]
    int EditarCategoria(miCategoria categoria);
    [OperationContract]
    int EliminarCategoria(int idCategoria);
    [OperationContract]
    miCategoria buscarContrato(int idCategoria);
    [OperationContract]
    List<miCategoria> listaCategoria();
}

[DataContract]
public class miCategoria
{
    [DataMember]
    public int CategoriaID { get; set; }
    [DataMember]
    public string CategoriaNombre { get; set; }
    [DataMember]
    public string Descripcion { get; set; }

}



