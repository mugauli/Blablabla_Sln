<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DatosJuego.aspx.cs" Inherits="prjBlablabla.DatosJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

    <link href="/Css/DatosJuego.css" rel="stylesheet" />
    <link href="/vendors/datatables.net-bs/css/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- Modal -->

    <div class="modal fade" id="addFrase" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">Frases Comunes</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" id="contAgregar">

                    <asp:HiddenField ClientIDMode="Static" ID="IdFrase" runat="server" Value="0" />

                    <div class="row" id="fnEnunci"></div>
                    <div class="row" id="fnEnunciados">
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Enunciado 1</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="enun1" TabIndex="1" ></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Enunciado 2</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="enun2" TabIndex="2" ></asp:TextBox>
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
                    <div class="row" id="fnOpciones">
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Opción 1</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="opcion1" TabIndex="3" ></asp:TextBox>
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
                    <div class="row" id="fnOpciones2">
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Opción 2</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="opcion2" TabIndex="4" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Correcta</label>
                            <div class="col-md-9">
                                <asp:TextBox TextMode="Number" runat="server" CssClass="form-control" ClientIDMode="Static" ID="correcta" TabIndex="5" ></asp:TextBox>

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
                    <div class="row" id="fnopciones3">
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Opción 3</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="opcion3" TabIndex="6" ></asp:TextBox>
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
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                    <asp:Button CssClass="btn btn-primary" ClientIDMode="Static" runat="server" ID="GuardarFrase" OnClick="GuardarFrase_Click" Text="Aceptar" />

                </div>

            </div>
        </div>
    </div>

    <div class="modal fade" id="borrarFrase" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">Borrar Frase</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div>
                        <asp:HiddenField ClientIDMode="Static" ID="IdFraseBorrar" runat="server" Value="0" />
                    </div>
                    <div>
                        <asp:HiddenField ClientIDMode="Static" ID="TipoFraseBorrar" runat="server" Value="0" />
                    </div>

                    <h3>¿Esta seguro que desea borrar la frase?</h3>


                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                    <asp:Button CssClass="btn btn-danger" runat="server" ID="btnBorrarFrase" OnClick="BorrarFrase_Click" Text="Borrar" />
                    

                </div>

            </div>
        </div>
    </div>

    <div class="container">

        <ul class="nav nav-tabs">
            <li class="active"><a href="#frasesComunes">Frase Comunes</a></li>
            <li><a href="#frasesSilabitos">Frases silabitos</a></li>
        </ul>

        <div class="tab-content">
            <div id="frasesComunes" class="tab-pane fade in active">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <button type="button" id="agregarAsg" class="btn btn-primary dropdown-toggle waves-effect waves-light" data-toggle="modal" data-target="#addFrase">Agregar <span class="m-l-5"><i class="fa fa-plus-circle"></i></span></button>
                        </div>
                        <table id="fraseComunesTable" class="display" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Enunciado 1</th>
                                    <th>Enunciado 2</th>
                                    <th>Correcta</th>
                                    <th>Opción 1</th>
                                    <th>Opción 2</th>
                                    <th>Opción 3</th>
                                    <th></th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Literal runat="server" ID="ltlTableFrases"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div id="frasesSilabitos" class="tab-pane fade">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="/Scripts/DatosJuego.js"></script>



</asp:Content>
