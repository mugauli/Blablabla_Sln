<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ImportarDatos.aspx.cs" Inherits="prjBlablabla.ImportarDatos"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">   
     
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Carga de archivos</h3>
            </div>
            <div class="panel-body">
                <div>
                    <p>
                        <asp:Label AssociatedControlID="fileUploader1" runat="server" Text="Seleccionar el archivo de datos:" />
                        <asp:FileUpload class="btn btn-info" ID="fileUploader1" runat="server" />
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </p>
                    <asp:Button class="btn btn-primary" ID="cargarImagen" runat="server" Text="Cargar archivo" OnClick="cargarImagen_Click" />
                </div>
            </div>
        </div>
   
</asp:Content>
