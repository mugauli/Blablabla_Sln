<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="prjBlablabla.index" %>


<asp:Content ContentPlaceHolderID="Body" runat="server">


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
                        <h3>Gráfica de promedios <small>por semana y mes</small></h3>
                    </div>
                    <div class="col-md-6">
                        <div id="reportrange" class="pull-right" style="background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc">
                            <i class="glyphicon glyphicon-calendar fa fa-calendar"></i>
                            <span>Diciembre 30, 2016 - Enero 28, 2017</span> <b class="caret"></b>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div id="chart_plot_Dash" class="demo-placeholder"></div>
                </div>




                <div class="clearfix"></div>
            </div>
        </div>

    </div>
    <br />
    <script>
        function gdds(year, month, day) {
            return new Date(year, month - 1, day).getTime();
        }


        var arr_data_Dash1 = [
            [gdds(2012, 1, 1), 17],
            [gdds(2012, 1, 2), 74],
            [gdds(2012, 1, 3), 6],
            [gdds(2012, 1, 4), 39],
            [gdds(2012, 1, 5), 20],
            [gdds(2012, 1, 6), 85],
            [gdds(2012, 1, 7), 7]
        ];

        var arr_data_Dash2 = [
            [gdds(2012, 1, 1), 82],
            [gdds(2012, 1, 2), 23],
            [gdds(2012, 1, 3), 66],
            [gdds(2012, 1, 4), 9],
            [gdds(2012, 1, 5), 119],
            [gdds(2012, 1, 6), 6],
            [gdds(2012, 1, 7), 9]
        ];

        var chart_plot_Dash_Setting = {
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
                mode: "date",
                tickSize: [1, "week"],
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



            $.plot($("#chart_plot_Dash"), [arr_data_Dash1, arr_data_Dash2], chart_plot_Dash_Setting);

        }
    </script>

</asp:Content>
