using Parcial1_Ap2_EstebanMena.BLL;
using Parcial1_Ap2_EstebanMena.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_EstebanMena.UI
{
    public partial class RegistroPresupuestos : System.Web.UI.Page
    {
        private Presupuesto presupuesto = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            AlertaValidar.Visible = false;
            AlertaGuardadoExito.Visible = false;
            AlertaError.Visible = false;

            if (!this.IsPostBack)
            {
                Session["ListaRelaciones"] = new List<PresupuestoDetalle>();
                LlenarDataGrid();
            }

        }

        private void Limpiar()
        {
            presupuesto = null;
            PresupuestoIdTextBox.Text = "";
            FechaTextBox.Text = "";
            DescripcionTextBox.Text = "";
            MontoTextBox.Text = "";

            AlertaValidar.Visible = false;
            AlertaGuardadoExito.Visible = false;
            AlertaError.Visible = false;

            Session["ListaRelaciones"] = new List<PresupuestoDetalle>();
            LlenarDataGrid();

            NuevoOModificando();
        }

        private void CargarDatos()
        {
            PresupuestoIdTextBox.Text = presupuesto.PresupuestoId.ToString();
            FechaTextBox.Text = presupuesto.Fecha.GetDateTimeFormats()[80].ToString().Substring(0, 10);
            DescripcionTextBox.Text = presupuesto.Descripcion;
            MontoTextBox.Text = presupuesto.Monto.ToString();
            //Detalle
            Session["ListaRelaciones"] = PresupuestoDetalleBLL.GetList(R => R.PresupuestoId == presupuesto.PresupuestoId);
            List<PresupuestoDetalle> listaRelaciones = (List<PresupuestoDetalle>)Session["ListaRelaciones"];
            LlenarDataGrid();
        }

        private void LlenarDataGrid()
        {
            List<PresupuestoDetalle> Lista = (List<PresupuestoDetalle>)Session["ListaRelaciones"];
            DetalleGridView.DataSource = Lista;
            DetalleGridView.DataBind();
        }

        private void NuevoOModificando()
        {
            if (PresupuestoIdTextBox.Text == "")
            {
                NuevoOModificandoLabel.Text = "Nuevo presupuesto";
            }
            else
            {
                NuevoOModificandoLabel.Text = "Modificando el presupuesto " + PresupuestoIdTextBox.Text;
            }
        }

        private bool Validar()
        {
            bool flag = true;
            if (string.IsNullOrWhiteSpace(FechaTextBox.Text))
            {
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                flag = false;
            }
            return flag;
        }

        private void LlenarCamposInstancia()
        {
            int id = 0;
            if (PresupuestoIdTextBox.Text != "")
            {
                id = Utilidad.ToInt(PresupuestoIdTextBox.Text);
            }
            presupuesto = new Presupuesto(id, DateTime.Parse(FechaTextBox.Text), DescripcionTextBox.Text, Utilidad.ToDouble(MontoTextBox.Text));
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                LlenarCamposInstancia();
                List<PresupuestoDetalle> listaRelaciones = (List<PresupuestoDetalle>)Session["ListaRelaciones"];
                if (PresupuestoBLL.Guardar(presupuesto, listaRelaciones))
                {
                    PresupuestoIdTextBox.Text = presupuesto.PresupuestoId.ToString();
                    MensajeAlertaGuardadoExito.Text = "¡Guardado con éxito con el ID " + presupuesto.PresupuestoId + "!";
                    AlertaGuardadoExito.Visible = true;
                    NuevoOModificando();
                }
                else
                {
                    AlertaError.Visible = true;
                }
            }
            else
            {
                AlertaValidar.Visible = true;
            }
        }
        
        

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PresupuestoIdTextBox.Text))
            {
                int id = Utilidad.ToInt(PresupuestoIdTextBox.Text);
                presupuesto = PresupuestoBLL.Buscar(P => P.PresupuestoId == id);
                if (presupuesto != null)
                {
                    CargarDatos();
                    NuevoOModificando();
                }
                else
                {
                    MensajeAlertaError.Text = "No encontrado";
                    AlertaError.Visible = true;
                }
            }
        }

        protected void AnadirButton_Click(object sender, EventArgs e)
        {
            List<PresupuestoDetalle> listaRelaciones = (List<PresupuestoDetalle>)Session["ListaRelaciones"];
            listaRelaciones.Add(new PresupuestoDetalle(0, 0, DetalleDescripcionTextBox.Text, Utilidad.ToDouble(MetaTextBox.Text), LogradoDropDownList.Text));
            LlenarDataGrid();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PresupuestoIdTextBox.Text))
            {
                int id = Utilidad.ToInt(PresupuestoIdTextBox.Text);
                presupuesto = PresupuestoBLL.Buscar(P => P.PresupuestoId == id);
                PresupuestoBLL.Eliminar(presupuesto);
                Limpiar();
            }
        }
    }
}