<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestro.Master" AutoEventWireup="true" CodeBehind="Area.aspx.cs" Inherits="WebUI.Area" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">

          function DeleteRecord(id) { 
            document.getElementById("<%= hdnId.ClientID %>").value = id;
            $('#deleteModal').modal("show");
        }
            $(document).ready(function () {
           
            });


    </script>
   
    <asp:UpdatePanel runat="server" ID="updtArea">
        <ContentTemplate>

       
    <div class="row">
         <div style="float: left; width: 100%; display:block;">
                <h1><small> Areas</small></h1>
            </div>
        </div>
         <form>
          <div class="row">
            <div class="col">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Nombres" ID="txtNombre"></asp:TextBox>
             
            </div>
            <div class="col">
               <asp:DropDownList runat="server" ID="ddlInmueble" CssClass="custom-select"></asp:DropDownList>
            </div>
			
              <div class="col">
                     <asp:Button runat="server" CssClass="btn btn-secondary" Text="Nuevo" ID="btnNuevo" OnClick="btnNuevo_Click"/>
                  </div>
        </form>
       
        </div>
    <br />
              <div class="row">
       <asp:HiddenField ID="hdnId" runat="server" />
    <table  style="width:100%" id="tbArea" style="font-size: 12px;" cellpadding="0" cellspacing="0" border="0" class="datatable table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                         <th>ID</th>
                                                    <th>NOMBRE</th>

                                                    <th>INMUEBLE</th>
                                                 
                                                     <th>ACCCION</th>
                                                </tr>
                                                <tbody>
                                                    <asp:Repeater ID="rpArea" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                  <td><%# Eval("ID")%></td>
                                                                <td><%# Eval("NOMBRE")%></td>

                                                                <td>   <%# this.GetInmueble(((String)Eval("INMUEBLE_CODIGO")))%></td>
				
                                                                <td><button type="button" class="btn btn-danger" onclick='javascript:DeleteRecord("<%# Eval("ID") %>")'>Eliminar</button> </td>
                                                          
														  
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </thead>
                                        </table>
                  </div>

				  
				     <%--Delete--%>
    <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H1">Confirmación</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal" role="form">
                        ¿Seguro de Eliminar?                                                              
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnDelete" UseSubmitBehavior="false" runat="server" class="btn btn-danger" CausesValidation="false" ValidationGroup="ninguno" OnClick="btnDelete_Click" Text="Eliminar" />
                </div>
            </div>
        </div>
    </div>
				  
				  
             </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNuevo" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
	

	
</asp:Content>
