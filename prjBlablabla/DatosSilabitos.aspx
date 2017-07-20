<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DatosSilabitos.aspx.cs" Inherits="prjBlablabla.DatosSilabitos" %>

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
                            <label class="col-md-3 control-label">C 1</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="C1" TabIndex="1"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">C 2</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="C2" TabIndex="2"></asp:TextBox>
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
                    <div class="row" id="fnEnunciados2">
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">C 3</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="C3" TabIndex="3"></asp:TextBox>

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
                            <label class="col-md-3 control-label">Palabra 1</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="P1" TabIndex="4"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Palabra 2</label>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="P2" TabIndex="5"></asp:TextBox>
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
                            <label class="col-md-3 control-label">Orden</label>
                            <div class="col-md-9">
                                <asp:TextBox TextMode="Number" runat="server" CssClass="form-control" ClientIDMode="Static" ID="Orden" TabIndex="6"></asp:TextBox>

                            </div>
                        </div>
                         <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Acomodo</label>
                            <div class="col-md-9">
                                <asp:TextBox TextMode="Number" runat="server" CssClass="form-control" ClientIDMode="Static" ID="Acomodo" TabIndex="6"></asp:TextBox>

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
                     <div class="row" id="fnopciones4">
                        <div class="form-group col-md-6">
                            <label class="col-md-3 control-label">Nivel</label>
                            <div class="col-md-9">
                                <asp:DropDownList runat="server" ID="ddlNivelGd" CssClass="form-control">
                                    <asp:ListItem Text="Nivel 1" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Nivel 2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Nivel 3" Value="3"></asp:ListItem>
                                </asp:DropDownList>
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

        <asp:DropDownList runat="server" ID="ddlNivel" CssClass="col-md-3">
            <asp:ListItem Text="Nivel 1" Value="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Nivel 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Nivel 3" Value="3"></asp:ListItem>
        </asp:DropDownList>

        <div id="frasesSilabitos">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <button type="button" id="agregarFraseSilabito" class="btn btn-primary dropdown-toggle waves-effect waves-light" data-toggle="modal" data-target="#addFrase">Agregar <span class="m-l-5"><i class="fa fa-plus-circle"></i></span></button>
                    </div>
                    <table id="fraseSilabitosTable" class="display" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>C1</th>
                                <th>C2</th>
                                <th>C3</th>
                                <th>Palabra 1</th>
                                <th>Palabra 2</th>
                                <th>Orden</th>
                                <th>Acomodo</th>
                                <th></th>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Literal runat="server" ID="ltFrasesSilabitos"></asp:Literal>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </div>

    <script src="/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="/Scripts/DatosJuego.js"></script>



</asp:Content>
