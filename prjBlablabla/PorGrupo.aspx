<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PorGrupo.aspx.cs" Inherits="prjBlablabla.PorGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
    <link href="/Css/PorGrupo.css" rel="stylesheet" />
    <script src="/Scripts/PorGrupoChart.js"></script>

    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>Concentrado de datos según Grupo escolar</h3>
            </div>


        </div>

        <div class="clearfix"></div>


        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Detalle de datos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>

                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>

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
                <br />

                <div class="x_content">



                    <div class="table-responsive">
                        <table class="table table-striped jambo_table bulk_action" id="tblPorGrupoResults">
                            <thead>
                                <tr class="headings">
                                    <th class="column-title">Grado </th>
                                    <th class="column-title">n </th>
                                    <th class="column-title">Maculino </th>
                                    <th class="column-title">Femenino </th>
                                    <th class="column-title">Semana / mes </th>
                                    <th class="column-title">Juego </th>
                                    <th class="column-title">Nivel </th>
                                    <th class="column-title">Promedio grupal Aciertos </th>
                                    <th class="column-title">Desv. Estándar Aciertos </th>
                                    <th class="column-title">Prom. grupal Errores </th>
                                    <th class="column-title">Desv. Estándar Errores </th>

                                    <th class="bulk-actions" colspan="7">
                                        <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                    </th>
                                </tr>
                            </thead>

                            <tbody>
                            </tbody>
                        </table>
                    </div>


                </div>
            </div>
        </div>
    </div>
    <script>
        function gd1(year, month, day) {
            return new Date(year, month - 1, day).getTime();
        }


        var arr_data_Nino1 = [
            [1, 37],
            [2, 44],
            [3, 36],
            [4, 9],
            [5, 80],
            [6, 5],
            [7, 57],
            [8, 87],
            [9, 34],
            [10, 46],
            [11, 39],
            [12, 70],
            [13, 95],
            [14, 97]
        ];

        var arr_data_Nino2 = [
            [1, 17],
            [2, 74],
            [3, 6],
            [4, 39],
            [5, 20],
            [6, 85],
            [7, 7],
            [8, 17],
            [9, 74],
            [10, 6],
            [11, 39],
            [12, 20],
            [13, 85],
            [14, 7]
        ];

        var chart_plot_Nino_Setting = {
            series: {
                lines: {
                    show: false,
                    fill: true
                },
                splines: {
                    show: true,
                    tension: 0.4,
                    lineWidth: 1,
                    fill: 0.4
                },
                points: {
                    radius: 0,
                    show: true
                },
                shadowSize: 2
            },
            grid: {
                verticalLines: true,
                hoverable: true,
                clickable: true,
                tickColor: "#d5d5d5",
                borderWidth: 1,
                color: '#fff'
            },
            colors: ["rgba(255, 0, 229, 0.38)", "rgba(4,156, 206, 0.38)"],
            xaxis: {
                tickColor: "rgba(51, 51, 51, 0.06)",
                mode: "number",
                tickSize: [1, "day"],
                tickLength: 10,
                axisLabel: "Date",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 10
            },
            yaxis: {
                ticks: 8,
                tickColor: "rgba(51, 51, 51, 0.06)",
            },
            tooltip: false
        }


        function initChart() {



            $.plot($("#chart_plot_Nino"), [arr_data_Nino1, arr_data_Nino2], chart_plot_Nino_Setting);

        }
    </script>


</asp:Content>
