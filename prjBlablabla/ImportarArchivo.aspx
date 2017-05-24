<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ImportarArchivo.aspx.cs" Inherits="prjBlablabla.ImportarArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

   
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Carga de archivos</h3>
            </div>
            <div class="panel-body">
                <div>
                    <div class="row itemImport">
                        <div class="funkyradio col-sm-12">
                            <div class="funkyradio-primary col-md-3">
                                <asp:RadioButton GroupName="radioFrase" ClientIDMode="Static" ID="rbFrases" Checked="true" runat="server" />
                                <%--<input type="radio" name="radio" id="radio2" checked />--%>
                                <label for="rbFrases">Archivo de frases comunes</label>
                            </div>
                            <div class="funkyradio-primary col-md-3">
                                <asp:RadioButton GroupName="radioFrase" ID="rbFrasesSilabitos" ClientIDMode="Static" runat="server" />
                                <label for="rbFrasesSilabitos">Archivo de Frases de Silabitos</label>
                            </div>

                        </div>
                    </div>
                    <div class="row itemImport">
                        <div class="col-md-12">

                            <h2>Seleccionar el archivo de configuración:</h2>
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
   

    



</asp:Content>
