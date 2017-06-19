<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ImportarArchivo.aspx.cs" Inherits="prjBlablabla.ImportarArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
     
    <link href="/Css/ImportarArchivo.css" rel="stylesheet" />
   

        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Carga de archivos</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="row itemImport">
                        <div class="funkyradio col-sm-12">
                            <div class="funkyradio-primary col-md-3">
                                <asp:RadioButton GroupName="radioFrase" ClientIDMode="Static" ID="rbFrases" Checked="true" runat="server"/>
                                <%--<input type="radio" name="radio" id="radio2" checked />--%>
                                <label for="rbFrases">Archivo de frases comunes</label>
                            </div>
                            <div class="funkyradio-primary col-md-3">
                                <asp:RadioButton GroupName="radioFrase" ID="rbFrasesSilabitos" ClientIDMode="Static" runat="server" />
                                <label for="rbFrasesSilabitos">Archivo de Frases de Silabitos</label>
                            </div>

                        </div>
                    </div>
                    <%--DropDown de Juegos--%>
                    <div class="row">
                        <div class="input-group" id="gameSelectContainer">  
                            <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="gameId" PlaceHolder="Selecciona un Juego"></asp:TextBox>
                            <div class="input-group-btn">
                                <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><span class="caret"></span><span class="sr-only">Toggle Dropdown</span> </button>
                                <ul class="dropdown-menu" id="gamesList">
                                    <li><a href="#">Juego 1</a></li>
                                    <li><a href="#">Juego 2</a></li>
                                    <li><a href="#">Juego 3</a></li>
                                    <li><a href="#">Juego 4</a></li>
                                    <li><a href="#">Juego 5</a></li>
                                </ul>
                            </div>
                        </div>

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

                    <div class="row itemImport">
                        <div class="col-md-12">

                            <h2>Seleccionar el archivo de configuración para:</h2><h2 id="gameLevel"></h2>
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
