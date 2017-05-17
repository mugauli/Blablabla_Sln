<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ImportarArchivo.aspx.cs" Inherits="prjBlablabla.ImportarArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label AssociatedControlID="fileUploader1" runat="server" Text="Seleccionar una imagen:" />
                <asp:FileUpload ID="fileUploader1" runat="server" />
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </p>
            <asp:Button ID="cargarImagen" runat="server" Text="Cargar imágenes" OnClick="cargarImagen_Click" />
        </div>
    </form>

</asp:Content>
