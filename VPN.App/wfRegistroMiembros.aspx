<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="wfRegistroMiembros.aspx.cs" Inherits="VPN.wfRegistroMiembros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container border border-info" style="margin-top: 40px;">

        <div class="form-group row">
            <div class="col-sm-4 text-right">
                <br>
                <h3 style="align-self: auto;" for="titulo-registro">Registro Iglesia VPN</h3>
            </div>

<%--            <div class="col-sm-0 spinner-border text-danger spinner-border m-4" role="status" id="cargando">
                <span class="sr-only">Loading...</span>
            </div>--%>

            <div class="col-sm-2 text-right p-3">
                <asp:HyperLink NavigateUrl="~/wfConsultaUsuarios.aspx" runat="server" Text="Buscar miembros registrados"/>
            </div>

            <div class="col-sm-4 text-right p-1">
                <img src="https://vidaparalasnaciones.com/wp-content/uploads/2020/06/cropped-Logo.jpg" />
                <!---->
            </div>

        </div>


        <div class="form-group row">
            <div class="col-sm-3">
                <label for="celebracion">Elija el servicio al que asistirá<span id="celebracionspan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">
                <asp:DropDownList runat="server" ID="ddlCelebracion" CssClass="form-control" OnSelectedIndexChanged="ddlCelebracion_Change" AutoPostBack="True"   >
                   
                </asp:DropDownList>

                <asp:RequiredFieldValidator runat="server" ID="rqvCelebracion" ControlToValidate="ddlCelebracion" InitialValue="0" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6">
                <span id="disponibilidadspan" style="color: red; font-size: 14px">Puestos Disponibles: </span>
               
                <asp:Label ID="lblDisponible" runat="server"></asp:Label>
               
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-3">
                <label for="cedula">Cédula o Identificación <span id="cedulaspan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">

                <asp:TextBox runat="server" placeholder="Cédula" ID="txtCedula"  type="number" class="form-control" required ></asp:TextBox>

            </div>
            <div class="col-sm-3">
                <label for="nombre">Nombre<span id="nombrespan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" placeholder="Nombre" ID="txtNombre" required />
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-3">
                <label for="edad">Edad<span id="edadspan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox runat="server" type="number" class="form-control" placeholder="Edad" ID="txtEdad" required />
            </div>
            <div class="col-sm-3">
                <label for="temp">Celular o fijo<span id="celularspan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" placeholder="Celular o Fijo" ID="txtCelular" required />
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-3">
                <label for="temp">Correo Electrónico<span id="correospan" style="color: red; font-size: 14px"> *</span></label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox runat="server" class="form-control" placeholder="Correo" ID="txtCorreo" />
            </div>

            <div class="col-sm-3">
                <label for="celebracion">Es primera vez que asiste a VPN?<span id="tipoMiembrospan" style="color: red; font-size: 14px"> *</span></label>
                <asp:RadioButtonList ID="rbTipoMiembro" runat="server" required="required" aria-required="true" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>
                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ClientValidationFunction="ValidaterbTipoMiembro"></asp:CustomValidator>
            </div>

        </div>

        <div class="form-group row" style="text-align: center;">
            <div class="col-sm-12 border">
                <div>
                    <label for="temp" style="font-weight: bolder">Declaro no tener, ni haber tenido síntomas asociados al COVID-19 y no haber estado en contacto con personas con síntomas asociados COVID-19 en los últimos 15 días. </label>

                    <asp:RadioButtonList ID="rbSintomasCovid" runat="server" required="required" aria-required="true" RepeatDirection="Horizontal" >
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ClientValidationFunction="ValidaterbSintomasCovid"></asp:CustomValidator>
                    <%--<asp:RadioButton  runat="server" name="embarazada" id="r15" value="sí" required="required" aria-required="true" Text="Si"/>
                        <asp:RadioButton  runat="server" name="embarazada" id="r16" value="no" required="required" aria-required="true" Text="No"/>
                        <asp:RadioButton  runat="server" name="embarazada" id="r17" value="no aplica" Text="no aplica"/>--%>
                </div>
            </div>
        </div>

        <div class="form-group form-check" style="text-align: center;">

            <div style="text-align: center">
                <asp:CheckBox runat="server" class="form-check-input" ID="chkConsentimiento" required="required" aria-required="true" />
                <asp:Label runat="server" class="form-check-label" for="chkConsentimiento">Doy consentimiento para que VIDA PARA LAS NACIONES almacene mis datos y se ponga en contacto conmigo </asp:Label>
                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="chkConsentimiento" InitialValue="0" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*Requerido" ForeColor="Red" ClientValidationFunction="ValidateCheckBox"></asp:CustomValidator>
            </div>

        </div>

        <div style="text-align: center;">
            <asp:Button runat="server" ID="btnRegistrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" Text="Registrar" CausesValidation="true" />
        </div>
        
    </div>

        <script>
            function ValidateCheckBox(sender, args) {
                if (document.getElementById("<%=chkConsentimiento.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }

            function ValidaterbSintomasCovid(sender, args) {
                if (document.getElementById("<%=chkConsentimiento.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }

            function ValidaterbTipoMiembro(sender, args) {
                if (document.getElementById("<%=chkConsentimiento.ClientID %>").checked == true) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
        </script>


</asp:Content>
