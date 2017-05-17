<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubirArchivo.ascx.cs" Inherits="prjBlablabla.UserControls.SubirArchivo" %>

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
