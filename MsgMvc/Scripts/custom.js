var Msg = {
    clock: function () {
        var date = new Date();
        $('#time').html(date.toLocaleString());
    },
    init: function () {
        setInterval(this.clock, 1000);
        $('[data-toggle="tooltip"]').tooltip();
    }
};