<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubirResultados.aspx.cs" Inherits="prjBlablabla.SubirResultados" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

    <link href="/Css/ImportarArchivo.css" rel="stylesheet" />
    <script src="/Scripts/Preguntas.js"></script>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Carga de archivos</h3>
        </div>
        <div class="panel-body">
            <div>
                <%--DropDown de Escuelas--%>
                <div class="row">
                    <div class="input-group" id="gameSelectContainer">
                        <label>Selecciona una Escuela</label>
                            <asp:DropDownList  AutoPostBack="true" ID="ddListEscuelas" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="ddListEscuelas_SelectedIndexChanged">
                            </asp:DropDownList>
                    </div>
                </div>

                <div class="row itemImport">
                    <div class="col-md-12">

                        <h2>Seleccionar el archivo de Resultados </h2>
                        <asp:FileUpload ID="fileUploader1" runat="server" AllowMultiple="true" CssClass="btn btn-info col-md-4"/>
                        <div class="col-md-3">
                            <asp:Button ID="cargarResultado" runat="server" Text="Cargar archivo" OnClick="cargarResultado_Click" CssClass="btn btn-primary" />
                        </div>

                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </div>
                </div>
                <div class="row itemImport">
                </div>
            </div>
            <asp:Label runat="server" ID="lblMes"></asp:Label>
        </div>
    </div>
</asp:Content>
