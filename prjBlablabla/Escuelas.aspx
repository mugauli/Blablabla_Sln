<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escuelas.aspx.cs" Inherits="prjBlablabla.Escuelas" MasterPageFile="~/Master.Master" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
     
    <link href="/Css/ImportarArchivo.css" rel="stylesheet" />
    <script src="/Scripts/Escuelas.js"></script>
    <script src="https://code.getmdl.io/1.3.0/material.min.js"></script>
    <link rel="stylesheet" href="https://code.getmdl.io/1.3.0/material.indigo-pink.min.css">
    <!-- Material Design icon font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

    <div class="container">

    <!-- Modal -->
    <div class="modal fade" id="addEscuela" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="TitleModalAsignacion">Escuelas</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" id="contAgregar">
                    <div class="progress">
                        <div class="progress-bar" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:98%">
                            <span class="sr-only">70% Complete</span>
                        </div>
                    </div>
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#ServiciosFacturar">Datos Generales</a></li>
                    </ul>
                    <asp:HiddenField ClientIDMode="Static" ID="IdEscuela" runat="server" Value="0" />
                    <div class="tab-content">
                        <div id="ServiciosFacturar" class="tab-pane fade in active">
                            <form class="form-horizontal" role="form" id="fnGuardarProyecto">
                                <input type="hidden" name="idProyecto" id="idProyecto" />
                                <input type="hidden" name="frIdEmpresa" id="frIdEmpresa" />

                                <div class="row" id="fnEscuela">
                                    <div class="form-group col-md-6">
                                        <label class="col-md-4 control-label">Nombre:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="nombre" TabIndex="1" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label class="col-md-4 control-label">Dirección:</label>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="direccion" TabIndex="1" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-xs-12">
                                        <div class="col-xs-6 ">
                                            <div class="col-xs-3"></div>
                                            <div class="col-xs-9 errorMsg"></div>
                                        </div>
                                        <div class="col-xs-6 ">
                                            <div class="col-xs-3"></div>
                                            <div class="col-xs-9 errorMsg2"></div>
                                        </div>
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button CssClass="btn btn-primary" ClientIDMode="Static" runat="server" ID="GuardarEscuela" OnClick="GuardarEscuela_Click" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>

        <div class="modal fade" id="borrarEscuela" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title">Borrar Escuela</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div>
                            <asp:HiddenField ClientIDMode="Static" ID="IdEscuelaBorrar" runat="server" Value="0" />
                        </div>

                        <h3>¿Esta seguro que desea borrar la Escuela?</h3>


                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                        <asp:Button CssClass="btn btn-danger" runat="server" ID="btnBorrarEscuela" OnClick="btnBorrarEscuela_Click" Text="Borrar" />


                    </div>

                </div>
            </div>
        </div>
    <!-- End Modal-->
    <!-- Page Title -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box table-responsive">

                <h4 class="header-title m-t-0 m-b-30">Escuelas</h4>
               
                <table id="escuelasTable" class="display" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Nombre</th>
                                    <th>Dirección</th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Literal runat="server" ID="ltlTableEscuelas"></asp:Literal>
                            </tbody>
                 </table>
                 <button type='button' id="addModalbtn" class="mdl-button mdl-js-button mdl-button--fab mdl-js-ripple-effect mdl-button--primary pull-right">
                    <i class="material-icons">add</i>
                </button>
            </div>
        </div>
    </div>
</div>

</asp:Content>