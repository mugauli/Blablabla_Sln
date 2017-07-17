<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PorNino.aspx.cs" Inherits="prjBlablabla.PorNino" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

    <script src="/Scripts/PorNinoCharts.js"></script>

    <!-- top tiles -->
    <div class="row tile_count">
        <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
            <span class="count_top"><i></i>República de Chipre</span>
            <div class="count">Escuela</div>

        </div>
        <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
            <span class="count_top"><i class="fa fa-clock-o"></i>Grupo</span>
            <div class="count">4 "A"</div>

        </div>
        <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
            <span class="count_top"><i class="fa fa-user"></i>Semana / Mes</span>
            <div class="count green">2 / 4</div>

        </div>
        <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
            <span class="count_top"><i class="fa fa-user"></i>Juego</span>
            <div class="count">LG</div>

        </div>
        <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
            <span class="count_top"><i class="fa fa-user"></i>Promedio grupal</span>
            <div class="count">60%</div>

        </div>
        <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
            <span class="count_top"><i class="fa fa-user"></i>Desv. estándar</span>
            <div class="count">12</div>

        </div>
    </div>
    <!-- /top tiles -->
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
             <h3>Gráfica de promedios <small>por semana y mes</small></h3>
            <div class="dashboard_graph">
                <%--Filtros--%>
                <div class="row">
                                <form class="form-inline" role="form">
                                     <!-- form group [Escuela] -->
                                    <div class="form-group col-md-3">
                                        <label class="filter-col" style="margin-right: 0;" for="pref-perpage">Escuela:</label>
                                        <asp:DropDownList  ID="ddListEscuelas" runat="server" ClientIDMode="Static" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <!-- form group [Grupo] -->
                                    <div class="form-group col-md-2">
                                        <label class="filter-col" style="margin-right: 0;" for="pref-perpage">Grupo:</label>
                                        <select id="group" class="form-control">
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option selected="selected" value="5">5</option>
                                        </select>
                                    </div>
                                    <!-- form group [juego] -->
                                    <div class="form-group col-md-2">
                                        <label class="filter-col" style="margin-right: 0;" for="pref-search">Juego:</label>
                                        <select id="game" class="form-control">
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option selected="selected" value="5">5</option>
                                        </select> 
                                    </div>
                                    <!-- form group [nivel] -->
                                    <div class="form-group col-md-2">
                                        <label class="filter-col" style="margin-right: 0;" for="pref-search">Nivel:</label>
                                        <select id="level" class="form-control">
                                            <option selected="selected" value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                        </select> 
                                    </div>
                                     <!-- form group [fecha] -->
                                    <div class="form-group col-md-3">
                                        <label class="filter-col" style="margin-right: 0;" for="pref-search">Fecha:</label>
                                        <div id="reportrange">
                                            <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                                            <span>Diciembre 30, 2016 - Enero 28, 2017</span> <b class="caret"></b>
                                        </div>
                                    </div>
                                </form>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <button type="button" id="filterAply"class="btn btn-info filter-col">Aplicar</button>
                    </div>
                </div>
                <%--End Filtros--%>

                <div class="col-md-12 col-sm-12 col-xs-12">
                   
                        <canvas id="canvas"></canvas>

                </div>
                <div class="clearfix"></div>
            </div>
        </div>

    </div>
    <br />
    <div class="table-responsive">
        <table class="table table-striped jambo_table bulk_action" id="tblPorNinoResults">
            <thead>
                <tr class="headings">
                    <th class="column-title">Grado </th>
                    <th class="column-title">Edad </th>
                    <th class="column-title">Sexo</th>
                    <th class="column-title">Semana / mes </th>
                    <th class="column-title">Juego </th>
                    <th class="column-title">Nivel </th>
                    <th class="column-title">Total de ensayos </th>
                    <th class="column-title">% Aciertos</th>
                    <th class="column-title">% Errores</th>
                    <th class="column-title">Tiempo de reaccion aciertos</th>
                    <th class="column-title">Total de puntos</th>
                    <th class="column-title">Tasa de efectividad</th>
                </tr>
            </thead>

            <tbody>
                <tr class="even pointer result">

                    <td class=" ">3</td>
                    <td class=" ">8</td>
                    <td class=" ">F</td>
                    <td class=" ">2/5</td>
                    <td class=" ">LG</td>
                    <td class=" ">3</td>
                    <td class=" ">48</td>
                    <td class=" ">85</td>
                    <td class=" ">15</td>
                    <td class=" ">2.17</td>
                    <td class=" ">23000</td>
                    <td class=" ">1.3</td>

                </tr>
                <tr class="odd pointer result">

                    <td class=" ">3</td>
                    <td class=" ">8</td>
                    <td class=" ">F</td>
                    <td class=" ">2/5</td>
                    <td class=" ">LG</td>
                    <td class=" ">3</td>
                    <td class=" ">48</td>
                    <td class=" ">85</td>
                    <td class=" ">15</td>
                    <td class=" ">2.17</td>
                    <td class=" ">23000</td>
                    <td class=" ">1.3</td>

                </tr>

                <tr class="even pointer result">

                    <td class=" ">3</td>
                    <td class=" ">8</td>
                    <td class=" ">F</td>
                    <td class=" ">2/5</td>
                    <td class=" ">LG</td>
                    <td class=" ">3</td>
                    <td class=" ">48</td>
                    <td class=" ">85</td>
                    <td class=" ">15</td>
                    <td class=" ">2.17</td>
                    <td class=" ">23000</td>
                    <td class=" ">1.3</td>

                </tr>
                <tr class="odd pointer result">

                    <td class=" ">3</td>
                    <td class=" ">8</td>
                    <td class=" ">F</td>
                    <td class=" ">2/5</td>
                    <td class=" ">LG</td>
                    <td class=" ">3</td>
                    <td class=" ">48</td>
                    <td class=" ">85</td>
                    <td class=" ">15</td>
                    <td class=" ">2.17</td>
                    <td class=" ">23000</td>
                    <td class=" ">1.3</td>

                </tr>

            </tbody>
        </table>
    </div>



</asp:Content>
