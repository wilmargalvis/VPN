<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="wfConsultaUsuarios.aspx.cs" Inherits="VPN.App.wfConsultaUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border border-info" style="margin-top: 40px;">


        <div class="form-group row">
            <div class="col-sm-10 mt-4">
                <!--mt-3 = Margin Top-->
                <h4 style="text-align: center">Buscar Reserva de asistencia a VPN</h4>
                <div style="text-align: center">
                    <asp:LinkButton ID="lblbuscarMiembro" OnClick="linkBuscarMiembro_Click" runat="server">Ir a registro de miembros</asp:LinkButton>
                </div>
            </div>
            <div class="col-sm-2">
                <img src="https://vidaparalasnaciones.com/wp-content/uploads/2020/06/cropped-Logo.jpg" />

            </div>
        </div>
        <br>

        <%--        <div class="text-right p-4" style="color: blue; font-size: 17px">
            <asp:linkbutton id="lblbuscarMiembro" OnClick="linkBuscarMiembro_Click" runat="server">Ir a registro de miembros</asp:linkbutton>
        </div>--%>

        <div class="form-group row">
            <div class="col-sm-3">
                <label for="nombre">Ingrese el nombre<span id="nombrespan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">

                <asp:TextBox runat="server" placeholder="Nombre" ID="txtNombre" class="form-control"></asp:TextBox>

            </div>
            <div class="col-sm-3">
                <label for="nombre">Ingrese la Cédula<span id="cedulaspan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" placeholder="Cédula" ID="txtCedula" type="number"> </asp:TextBox>
            </div>
        </div>

        <div class="p-3" style="text-align: center;">
            <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" CausesValidation="true" />

        </div>
        <asp:GridView ID="gvTablaUno" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" BackColor="#adb5bd" BorderColor="#ffffff">
            <Columns>   
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                <asp:BoundField DataField="Edad" HeaderText="Edad" />
                <asp:BoundField DataField="Celebracion" HeaderText="Celebración Seleccionada" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Registro" />
                <asp:TemplateField HeaderText="Editar" >
                <ItemTemplate>
                  <asp:LinkButton runat="server" ID="btnEditar" CommandArgument='<%# Eval("MiembroID") %>' CommandName=<%# Eval("Nombre") %> OnCommand="btnEditar_Command" Text="Editar" CssClass="btn btn-primary"/>
                
                 </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView><br>

        <div class="form-group row">
            <div class="col-sm-12" style="text-align: center">
                <asp:Label runat="server" ID="lbltemperatura" Text="Temperatura" Visible="false"/>
                <asp:Label runat="server" ID="lblNombre"></asp:Label>
                <asp:HiddenField runat="server" ID="hfMiembroId" Value="0" />
                <asp:TextBox runat="server" ID="txtTemperatura" PlaceHolder="Temperatura" type="number" Visible="false" />
                <asp:Button Text="Actualizar" ID="btnGuardarTemperatura" CssClass=" btn btn-primary" OnClick="btnGuardarTemperatura_Click" runat="server" Visible="false"/>
            </div>
        </div>

    </div>
</asp:Content>
