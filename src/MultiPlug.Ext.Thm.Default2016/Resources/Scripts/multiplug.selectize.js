
function PopulateEventsData(mpevent) {

    optgroups = [];

    $.ajax({
        url: 'multiplug/events/',
        type: 'GET',
        error: function () {
            callback();
        },
        success: function (res) {

            $.each(res.extensions, function () {
                var exname = this.name;
                optgroups.push({
                    name: exname
                });
                $.each(this.events, function () {
                    mpeventids.push({
                        name: exname,
                        mpeventid: this,
                    });
                });
            });

            applyselectize(mpevent);
        }
    });
}

function PopulateAppsData(appselect) {

    appsoptgroups = [];

    $.ajax({
        url: 'multiplug/apps/',
        type: 'GET',
        error: function () {
            callback();
        },
        success: function (res) {

            $.each(res.extensions, function () {
                var exname = this.name;
                appsoptgroups.push({
                    name: exname
                });
                $.each(this.apps, function () {
                    mpapps.push({
                        name: exname,
                        mpapp: this,
                        appurl: '/apps/' + exname + '/' + this.toLowerCase().split(' ').join('-') + '/'
                    });
                });
            });

            applyappsselectize(appselect);
        }
    });
}

var mpappselect = $(".js-mpapp-select");

if (mpappselect.length > 0) {
    applyappsselectize(mpappselect);
}

var mpevent = $(".js-mpevent-select");

if (mpevent.length > 0) {
    applyselectize(mpevent);
}

