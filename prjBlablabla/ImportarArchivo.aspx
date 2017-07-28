<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ImportarArchivo.aspx.cs" Inherits="prjBlablabla.ImportarArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

    <link href="/Css/ImportarArchivo.css" rel="stylesheet" />


    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Carga de archivos</h3>
        </div>
        <div class="panel-body">
            <div>

                <%--DropDown de Juegos--%>
                <div class="row">
                    <div class="col-md-3">
                        <div class="input-group" id="gameSelectContainer">
                            <asp:HiddenField runat="server" Value="0" ID="hddGame" ClientIDMode="Static"/>
                            <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="gameId" PlaceHolder="Selecciona un Juego"></asp:TextBox>
                            <div class="input-group-btn">
                                <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><span class="caret"></span><span class="sr-only">Toggle Dropdown</span> </button>
                                <ul class="dropdown-menu" id="gamesList">
                                    <li data-id="1"><a href="#">La torre del tesoro</a></li>
                                    <li data-id="2"><a href="#">El pueblo de los silabitos</a></li>
                                    <li data-id="3"><a href="#">El bosque sin color</a></li>
                                    <li data-id="4"><a href="#">El castillo del mal olor</a></li>
                                    <li data-id="5"><a href="#">El lago de la grama</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--DropDown de Niveles--%>
                        <div class="input-group" id="levelSelectContainer">
                            <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="levelId" PlaceHolder="Selecciona un Nivel"></asp:TextBox>
                            <div class="input-group-btn">
                                <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><span class="caret"></span><span class="sr-only">Toggle Dropdown</span> </button>
                                <ul class="dropdown-menu" id="levelList">
                                    <li><a href="#">Nivel 1</a></li>
                                    <li><a href="#">Nivel 2</a></li>
                                    <li><a href="#">Nivel 3</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row itemImport">
                    <div class="col-md-12">

                        <h2>Seleccionar el archivo de configuración para:</h2>
                        <h2 id="gameLevel"></h2>
                        <asp:FileUpload ID="fileUploader1" runat="server" CssClass="btn btn-info col-md-4" />
                        <div class="col-md-3">
                            <asp:Button ID="cargarImagen" runat="server" Text="Cargar archivo" OnClick="cargarImagen_Click" CssClass="btn btn-primary" />
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




    <script src="/Scripts/Preguntas.js"></script>

</asp:Content>
