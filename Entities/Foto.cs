using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entities
{
    public class Foto
    {

        public string Operacion { get; set; } // "INSERT", "UPDATE", "DELETE"
        public int IdFoto { get; set; }
        public int IdSitio { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public bool EsPrincipal { get; set; }
        public string Descripcion { get; set; }

        // Crear la lista de parámetros para el SP
        private SqlParameter[] listaAtributos()
        {
            SqlParameter[] lista = new SqlParameter[]
            {
            new SqlParameter("@Operacion", Operacion),
            new SqlParameter("@IdFoto", IdFoto),
            new SqlParameter("@IdSitio", IdSitio),
            new SqlParameter("@NombreArchivo", (object)NombreArchivo ?? DBNull.Value),
            new SqlParameter("@RutaArchivo", (object)RutaArchivo ?? DBNull.Value),
            new SqlParameter("@EsPrincipal", EsPrincipal),
            new SqlParameter("@Descripcion", (object)Descripcion ?? DBNull.Value)
            };
            return lista;
        }

        // Ejecutar el SP y devolver un DataTable
        public DataTable ejecutarConsultaMantenimiento()
        {
            SqlParameter[] lista = listaAtributos();
            return Datos.ConexionSQL.EjecutarConRetorno("sp_MantenimientoFotos", lista);
        }
        public void MoverYRenombrarImagen()
        {
            try
            {
                if (string.IsNullOrEmpty(RutaArchivo) || !File.Exists(RutaArchivo))
                    throw new FileNotFoundException("No se encontró el archivo especificado en RutaArchivo: " + RutaArchivo);

                // Obtener la extensión original
                string extension = Path.GetExtension(RutaArchivo);

                // Generar número aleatorio 0-1000
                Random rnd = new Random();
                int random = rnd.Next(0, 1001);

                // Nuevo nombre de archivo
                string nuevoNombre = $"imagen{IdSitio}_{random}{extension}";

                // Carpeta destino dentro del proyecto
                string carpetaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "ImagenesSitios");

                // Crear carpeta si no existe
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                // Ruta física completa del archivo destino
                string rutaDestinoFisica = Path.Combine(carpetaDestino, nuevoNombre);

                // Copiar o sobrescribir el archivo
                File.Copy(RutaArchivo, rutaDestinoFisica, true);

                // Actualizar propiedades para la web
                RutaArchivo = "/Imagenes/ImagenesSitios/" + nuevoNombre; // Ruta relativa
                NombreArchivo = nuevoNombre;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mover y renombrar la imagen: " + ex.Message);
            }
        }
        public void RenombrarImagenExistente()
        {
            try
            {
                if (string.IsNullOrEmpty(RutaArchivo) || !File.Exists(RutaArchivo))
                    throw new FileNotFoundException("No se encontró el archivo en el servidor: " + RutaArchivo);

                // Obtener extensión original
                string extension = Path.GetExtension(RutaArchivo);

                // Generar número aleatorio 0-1000
                Random rnd = new Random();
                int random = rnd.Next(0, 1001);

                // Nuevo nombre de archivo
                string nuevoNombre = $"imagen{IdSitio}_{random}{extension}";

                // Carpeta donde ya está la imagen
                string carpetaDestino = Path.GetDirectoryName(RutaArchivo);

                // Ruta completa del nuevo nombre
                string nuevaRutaFisica = Path.Combine(carpetaDestino, nuevoNombre);

                // Renombrar el archivo en el servidor
                File.Move(RutaArchivo, nuevaRutaFisica);

                // Actualizar propiedades para la web
                RutaArchivo = "/Imagenes/ImagenesSitios/" + nuevoNombre;
                NombreArchivo = nuevoNombre;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al renombrar la imagen: " + ex.Message);
            }
        }




    }

}
