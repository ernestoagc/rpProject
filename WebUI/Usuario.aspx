<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestro.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="WebUI.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/css/bootstrap-multiselect.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.15/js/bootstrap-multiselect.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
       $(document).ready(function() {
        $('<%= lbArea.ClientID %>').multiselect({
            includeSelectAllOption: true
        });
    });
    </script>

    <asp:UpdatePanel runat="server" ID="updtUsuario">
        <ContentTemplate>

       
    <div class="row">
         <div style="float: left; width: 100%; display:block;">
                <h1><small> Usuarios</small></h1>
            </div>
        </div>
     <div class="row">
         <form>
          <div class="row">
            <div class="col">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Nombres" ID="txtNombre"></asp:TextBox>
             
            </div>
            <div class="col">
                 <asp:TextBox runat="server" CssClass="form-control" placeholder="Apellido Paterno" ID="txtApellidoPaterno"></asp:TextBox>
            </div>
               <div class="col">
              
             <asp:TextBox runat="server" CssClass="form-control" placeholder="Apellido Materno" ID="txtApellidoMaterno"></asp:TextBox>
            </div>

               <div class="col">
            <asp:ListBox runat="server" SelectionMode="Multiple" ID="lbArea" placeholder="Area" CssClass="custom-select"></asp:ListBox>
            </div>
          </div>
              <div class="col">
                     <asp:Button runat="server" CssClass="btn btn-secondary" Text="Nuevo" ID="btnNuevo" OnClick="btnNuevo_Click"/>
                  </div>
        </form>
       
        </div>
    <br />
              <div class="row">
       
    <table id="tbUsuario" style="font-size: 12px;" cellpadding="0" cellspacing="0" border="0" class="datatableS table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>ID</th>
                                                    <th>NOMBRE</th>
                                                    <th>APELLIDO PATERNO</th>
                                                      <th>APELLIDO MATERNO</th>
                                                     <th>AREAS</th>
                                                </tr>
                                                <tbody>
                                                    <asp:Repeater ID="rpUsuario" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                 <td><%# Eval("ID")%></td>
                                                                <td><%# Eval("NOMBRE")%></td>
                                                                <td><%# Eval("APELLIDO_PATERNO")%></td>
                                                                <td><%# Eval("APELLIDO_MATERNO")%></td>
                                                                  <td><%# Eval("AREAS_NOMBRES")%></td>
                                                              
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </thead>
                                        </table>
                  </div>

             </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNuevo" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
