<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroPresupuestos.aspx.cs" Inherits="Parcial1_Ap2_EstebanMena.UI.RegistroPresupuestos" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta lang="es-ES" />
    <title>Registro de presupuestos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>

</head>
<body>
    <header>
        <div class="jumbotron bg-success">
            <h1 class="display-3" style="color: white;">Presupuestos</h1>
        </div>
    </header>

    <br />
    <br />

    <div class="fluid-container">
        <div class="col-xs-12 col-sm-4">

            <!--Alertas-->
            <div class="col-xs-12">
                <asp:Panel ID="AlertaGuardadoExito" class="alert alert-success text-center" role="alert" runat="server">
                    <asp:Label ID="MensajeAlertaGuardadoExito" runat="server">¡Guardado con éxito!</asp:Label>
                </asp:Panel>
                <asp:Panel ID="AlertaError" class="alert alert-danger text-center" role="alert" runat="server">
                    <asp:Label ID="MensajeAlertaError" runat="server">¡Algo salió mal!</asp:Label>
                </asp:Panel>
                <asp:Panel ID="AlertaValidar" class="alert alert-info text-center" role="alert" runat="server">
                    <asp:Label ID="MensajeAlertaValidar" runat="server">Por favor llene todos los campos correctamente...</asp:Label>
                </asp:Panel>
            </div>
            <br />

            <%-- Formulario --%>
            <form id="form" runat="server">
                <div class="text-center">
                    <h4>
                        <asp:Label CssClass="text-center" ID="NuevoOModificandoLabel" runat="server" Text="Nuevo presupuesto"></asp:Label></h4>
                </div>
                <asp:Button CssClass="btn btn-success float-right" ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <br />
                <br />

                <div class="text-center float-right">
                    <asp:Button CssClass="btn btn-danger" ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                </div>
                <div class="text-center float-right">
                    <asp:Button CssClass="btn btn-info" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                </div>
                

                <div class="form-group">
                    <label for="PresupuestoTextBox">Presupuesto Id</label>
                    <asp:TextBox Type="number" CssClass="form-control" ID="PresupuestoIdTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="FechaTextBox">Fecha</label>
                    <asp:TextBox Type="date" CssClass="form-control" ID="FechaTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="DescripcionTextBox">Descripción</label>
                    <asp:TextBox CssClass="form-control" ID="DescripcionTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="MontoTextBox">Monto</label>
                    <asp:TextBox CssClass="form-control" ID="MontoTextBox" runat="server"></asp:TextBox>
                </div>

                <%-- Detalle --%>
                <div class="form-row">
                    <div class="form-group col-5">
                        <label for="CategoriaIdDropDownList">Descripción</label>
                        <asp:TextBox CssClass="form-control" ID="DetalleDescripcionTextBox" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-3">
                        <label for="MontoTextBox">Meta</label>
                        <asp:TextBox CssClass="form-control" ID="MetaTextBox" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-4">
                        <label for="LogradoDropDownList">Estado</label>
                        <asp:DropDownList CssClass="form-control" ID="LogradoDropDownList" runat="server">
                            <asp:ListItem>Logrado</asp:ListItem>
                            <asp:ListItem>No logrado</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:Button CssClass="btn btn-secundary" ID="AnadirButton" runat="server" Text="Añadir" OnClick="AnadirButton_Click" />
                    </div>
                </div>

                <asp:GridView ID="DetalleGridView" runat="server">
                    <HeaderStyle CssClass="bg-success" />
                </asp:GridView>

                <br />
                <div class="text-center">
                    <asp:Button CssClass="btn btn-success" ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                </div>
            </form>
        </div>
    </div>

    <br />
    <br />

    <footer class="bg-success">
        <p class="text-center" style="color: white;">Esteban Mena - 2014-0563 - Segundo parcial</p>
    </footer>

</body>
</html>
