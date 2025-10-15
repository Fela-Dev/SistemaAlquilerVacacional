using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
namespace Presentacion.PaginasPublicas
{
    public partial class FormPrincipal : System.Web.UI.Page
    {
        private string cadenaConexion = "Data Source=.;Initial Catalog=SistemaAlquilerVacacional;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSitiosDisponibles();
            }
        }

        private void CargarSitiosDisponibles(
     DateTime? fechaInicio = null,
     DateTime? fechaFin = null,
     int? idTipoSitio = null,
     string provincia = null,
     string canton = null,
     int? personasMinimas = null,
     decimal? precioMinimo = null,
     decimal? precioMaximo = null,
     bool? permiteMascotas = null,
     string facilidadesRequeridas = null
 )
        {
            // Crear lista de parámetros
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        new SqlParameter("@FechaInicio", (object)fechaInicio ?? DBNull.Value),
        new SqlParameter("@FechaFin", (object)fechaFin ?? DBNull.Value),
        new SqlParameter("@IdTipoSitio", (object)idTipoSitio ?? DBNull.Value),
        new SqlParameter("@Provincia", (object)provincia ?? DBNull.Value),
        new SqlParameter("@Canton", (object)canton ?? DBNull.Value),
        new SqlParameter("@PersonasMinimas", (object)personasMinimas ?? DBNull.Value),
        new SqlParameter("@PrecioMinimo", (object)precioMinimo ?? DBNull.Value),
        new SqlParameter("@PrecioMaximo", (object)precioMaximo ?? DBNull.Value),
        new SqlParameter("@PermiteMascotas", (object)permiteMascotas ?? DBNull.Value),
        new SqlParameter("@FacilidadesRequeridas", (object)facilidadesRequeridas ?? DBNull.Value)
    };

            // Ejecutar SP
            DataTable dt = Datos.ConexionSQL.EjecutarConRetorno("sp_BuscarSitiosDisponibles", parametros.ToArray());

            // Asignar al repeater
            repeaterSitios.DataSource = dt;
            repeaterSitios.DataBind();
        }


        // Convierte IdTipoSitio a texto
        protected string GetTipoSitioText(object idTipo)
        {
            switch (Convert.ToInt32(idTipo))
            {
                case 1: return "Playa";
                case 2: return "Montaña";
                case 3: return "Citadino";
                default: return "Desconocido";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Leer fechas
            DateTime? fechaInicio = string.IsNullOrWhiteSpace(txtFechaInicio.Text)
                ? (DateTime?)null
                : Convert.ToDateTime(txtFechaInicio.Text);

            DateTime? fechaFin = string.IsNullOrWhiteSpace(txtFechaFin.Text)
                ? (DateTime?)null
                : Convert.ToDateTime(txtFechaFin.Text);

            // Tipo de sitio (DropDownList)
            int? idTipoSitio = string.IsNullOrWhiteSpace(ddlTipoSitio.SelectedValue)
                ? (int?)null
                : Convert.ToInt32(ddlTipoSitio.SelectedValue);

            // Texto libre
            string provincia = string.IsNullOrWhiteSpace(txtProvincia.Text) ? null : txtProvincia.Text;
            string canton = string.IsNullOrWhiteSpace(txtCanton.Text) ? null : txtCanton.Text;

            // Número de personas
            int? personasMinimas = string.IsNullOrWhiteSpace(txtPersonas.Text)
                ? (int?)null
                : Convert.ToInt32(txtPersonas.Text);

            // Precio
            decimal? precioMin = string.IsNullOrWhiteSpace(txtPrecioMin.Text)
                ? (decimal?)null
                : Convert.ToDecimal(txtPrecioMin.Text);

            decimal? precioMax = string.IsNullOrWhiteSpace(txtPrecioMax.Text)
                ? (decimal?)null
                : Convert.ToDecimal(txtPrecioMax.Text);

            // Mascotas (CheckBox)
            bool? permiteMascotas = chkMascotas.Checked ? true : (bool?)null;

            // Facilidades (Texto separado por comas)
            string facilidades = string.IsNullOrWhiteSpace(txtFacilidades.Text) ? null : txtFacilidades.Text;

            // Llamar al método que carga el repeater con los parámetros
            CargarSitiosDisponibles(
                fechaInicio, fechaFin, idTipoSitio, provincia, canton,
                personasMinimas, precioMin, precioMax, permiteMascotas, facilidades
            );
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar todos los controles
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            ddlTipoSitio.SelectedIndex = 0; // O el índice que represente "Todos"
            txtProvincia.Text = "";
            txtCanton.Text = "";
            txtPersonas.Text = "";
            txtPrecioMin.Text = "";
            txtPrecioMax.Text = "";
            chkMascotas.Checked = false;
            txtFacilidades.Text = "";

            // Recargar sitios sin filtros
            CargarSitiosDisponibles();

        }
    }
}