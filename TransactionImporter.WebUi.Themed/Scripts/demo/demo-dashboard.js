// Dashboard demo code
// -----------------------------------

(function(window, document, $, undefined) {

    $(function() {

        // Dashboard v1/v3 pie chart

        var dashv13_pieOptions = {
            animate: {
                duration: 800,
                enabled: true
            },
            barColor:  APP_COLORS['info'],
            trackColor: 'rgba(200,200,200,0.4)',
            scaleColor: false,
            lineWidth: 10,
            lineCap: 'round',
            size: 145
        };

        $('#dashv13_easypie1').easyPieChart(dashv13_pieOptions);

        // Dashboard v2 pie chart

        var dashv2_pieOptions1 = {
            animate: {
                duration: 800,
                enabled: true
            },
            barColor: APP_COLORS['info'],
            trackColor: '#edf2f6',
            scaleColor: false,
            lineWidth: 2,
            lineCap: 'round',
            size: 130
        };
        $('#dashv2-piechart1').easyPieChart(dashv2_pieOptions1);
        var dashv2_pieOptions2 = {
            animate: {
                duration: 800,
                enabled: true
            },
            barColor: APP_COLORS['pink'],
            trackColor: '#edf2f6',
            scaleColor: false,
            lineWidth: 2,
            lineCap: 'round',
            size: 130
        };
        $('#dashv2-piechart2').easyPieChart(dashv2_pieOptions2);
        var dashv2_pieOptions3 = {
            animate: {
                duration: 800,
                enabled: true
            },
            barColor: APP_COLORS['purple'],
            trackColor: '#edf2f6',
            scaleColor: false,
            lineWidth: 2,
            lineCap: 'round',
            size: 130
        };
        $('#dashv2-piechart3').easyPieChart(dashv2_pieOptions3);
        var dashv2_pieOptions4 = {
            animate: {
                duration: 800,
                enabled: true
            },
            barColor: APP_COLORS['warning'],
            trackColor: '#edf2f6',
            scaleColor: false,
            lineWidth: 2,
            lineCap: 'round',
            size: 130
        };
        $('#dashv2-piechart4').easyPieChart(dashv2_pieOptions4);

    });

})(window, document, window.jQuery);