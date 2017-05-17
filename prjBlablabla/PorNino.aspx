﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PorNino.aspx.cs" Inherits="prjBlablabla.PorNino" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">

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
            <div class="dashboard_graph">

                <div class="row x_title">
                    <div class="col-md-6">
                        <h3>Gráfica de aciertos <small>por niño</small></h3>
                    </div>
                    <div class="col-md-6">
                        <div id="reportrange" class="pull-right" style="background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc">
                            <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                            <span>Diciembre 30, 2016 - Enero 28, 2017</span> <b class="caret"></b>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div id="chart_plot_Nino" class="demo-placeholder"></div>
                </div>


                <div class="clearfix"></div>
            </div>
        </div>

    </div>
    <br />
    <div class="table-responsive">
        <table class="table table-striped jambo_table bulk_action">
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
                <tr class="even pointer">

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
                <tr class="odd pointer">

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

                <tr class="even pointer">

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
                <tr class="odd pointer">

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
