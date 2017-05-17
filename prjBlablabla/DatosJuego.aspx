﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DatosJuego.aspx.cs" Inherits="prjBlablabla.DatosJuego" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
   
<div class="container">

    <!-- Modal -->

    <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="TitleModalAsignacion">Empleados</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" id="contAgregar">
                    <form class="form-horizontal" role="form" id="fnGuardar">
                        <input type="hidden" name="idEmpleado" id="idEmpleado" />
                        <input type="hidden" name="frIdEmpresa" id="frIdEmpresa" />

                        <div class="row" id="fnNombre">
                            <div class="form-group col-md-12">
                                <label class="col-md-2 control-label" style="width: 12%;">Nombre:</label>
                                <div class="col-md-10" style="width: 88%;">
                                    <input type="text" class="form-control" id="Nombre" name="Nombre" tabindex="1" maxlength="300">
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="col-xs-6 ">
                                    <div class="col-xs-3"></div>
                                    <div class="col-xs-9 errorMsg"></div>
                                </div>
                            </div>
                        </div>

                        <div class="row" id="fnPuesto">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Puesto:</label>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" id="Puesto" name="Puesto" tabindex="2">
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Jefe Inmediato:</label>
                                <div class="col-md-9">
                                    <select class="form-control" tabindex="3" id="JefeInmediato" name="JefeInmediato">
                                        <option value="0">Sin jefe inmediato</option>
                                        @foreach (var emp in Model.ctEmpleados)
                                        {
                                            <option value="@emp.Id_Empleado">@emp.Nombre_Empleado</option>
                                        }
                                    </select>
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

                        <div class="row" id="fnFecha">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label">Fecha Nacimineto:</label>
                                <div class="col-md-9">
                                    <div class="input-group">
                                        <input type="text" class="form-control" placeholder="dd/mm/yyyy" id="fecha_nacimiento" name="fecha_nacimiento" tabindex="4">
                                        <span class="input-group-addon bg-primary b-0 text-white"><i class="ti-calendar"></i></span>
                                    </div><!-- input-group -->
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label">Fecha Ingreso:</label>
                                <div class="col-md-9">
                                    <div class="input-group">
                                        <input type="text" class="form-control" placeholder="dd/mm/yyyy" id="fecha_ingreso" name="fecha_ingreso" tabindex="5">
                                        <span class="input-group-addon bg-primary b-0 text-white"><i class="ti-calendar"></i></span>
                                    </div><!-- input-group -->
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

                        <div class="row" id="fnEmailSkype">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">E-mail:</label>
                                <div class="col-md-9">
                                    <input type="email" class="form-control" id="Email" name="Email" tabindex="6">
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Skype:</label>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" id="Skype" name="Skype" tabindex="7">
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

                        <div class="row" id="fnTel">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Movil:</label>
                                <div class="col-md-9">
                                    <input type="tel" class="form-control" id="Movil" name="Movil" tabindex="8">
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Casa:</label>
                                <div class="col-md-9">
                                    <input type="tel" class="form-control" id="Casa" name="Casa" tabindex="9">
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

                        <div class="row" id="fnDomicilio">
                            <div class="form-group col-md-12">
                                <label class="col-md-2 control-label" for="example-email">Domicilio:</label>
                                <div class="col-md-10">
                                    <textarea type="text" class="form-control" id="Domicilio" name="Domicilio" tabindex="10"></textarea>
                                </div>
                            </div>
                            <div class="col-xs-12">
                                <div class="col-xs-6 ">
                                    <div class="col-xs-3"></div>
                                    <div class="col-xs-9 errorMsg"></div>
                                </div>
                            </div>
                        </div>

                        <div class="row" id="fnUsuario">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label">Acceso al sistema:</label>
                                <div class="col-md-9">
                                    <div class="contEstado col-md-6  col-centered">
                                        <label class="radio-inline">
                                            <input type="radio" name="IsLogin" tabindex="11" value="1" id="rdlgSI">SI
                                        </label>
                                        <label class="radio-inline">
                                            <input type="radio" checked name="IsLogin" tabindex="12" value="0" id="rdlgNO">NO
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Usuario:</label>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" id="Usuario" name="Usuario" tabindex="13">
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

                        <div class="row" id="fnPassword">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Contraseña:</label>
                                <div class="col-md-9">
                                    <input type="password" class="form-control" id="Password" name="Password" tabindex="14">
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label" for="example-email">Repetir Contraseña:</label>
                                <div class="col-md-9">
                                    <input type="password" class="form-control" id="Password2" name="Password2" tabindex="15">
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

                        <div class="row" id="fnPerfilEstado">
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label">Estado:</label>
                                <div class="col-md-9">
                                    <div class="contEstado col-md-6  col-centered">
                                        <label class="radio-inline">
                                            <input type="radio" name="estado" tabindex="16" value="1" id="rdSI">SI
                                        </label>
                                        <label class="radio-inline">
                                            <input type="radio" checked name="estado" tabindex="17" value="0" id="rdNO">NO
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group col-md-6">
                                <label class="col-md-3 control-label">Perfil:</label>
                                <div class="col-md-9">
                                    <select class="form-control" name="Perfil" id="Perfil" tabindex="18">
                                        <option value="0">Seleccione</option>
                                        @foreach (var emp in Model.ctPerfil)
                                        {
                                            <option value="@emp.Id_Perfil">@emp.Nombre_Perfil</option>
                                        }
                                    </select>
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
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" id="Guardar">Guardar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- ENd Modal-->
    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box table-responsive">

                <h4 class="header-title m-t-0 m-b-30">Empleados</h4>

                <table id="datatable" class="table table-striped dt-responsive nowrap dataTable no-footer dtr-inline" role="grid" aria-describedby="datatable_info">
                    <thead>
                        <tr>
                            <th>IdEmpleado</th>
                            <th>Nombre</th>
                            <th>Puesto</th>
                            <th>Email</th>
                            <th>Móvil</th>
                            <th>Antigüedad</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        </div><!-- end col -->
    </div>
    <!-- end row -->

    <script src="Scripts/Preguntas.js"></script>

</div> <!-- container -->

</asp:Content>
