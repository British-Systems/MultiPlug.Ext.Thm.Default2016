var CoreLogDisplayed = true;
var Selected = null;

function scrollLogToBottom(loggingTextArea) {
    var textarea = document.getElementById(loggingTextArea);
    textarea.scrollTop = textarea.scrollHeight;
}

function pageUp() {
    var CurrentPage = Number($('#page').val())
    CurrentPage++;
    $('#page').val(CurrentPage);
    GetFile();
}

function pageDown() {
    var CurrentPage = Number($('#page').val())
    if (CurrentPage != 1) {
        CurrentPage--;
        $('#page').val(CurrentPage);
        GetFile();
    }
}

function GetFile() {
    if (Selected == null) {
        return;
    }

    var Lines = "21";

    if ($('#page').val() == '1') {
        Lines = "20"; // Add a blank Line at the end for new Live log lines
    }

    var APIUrl = $(Selected).attr("data-multiplugapi") + '?page=' + $('#page').val() + "&lines=" + Lines;
    $('#Logging').val('Loading File');

    $.get(APIUrl, function (data) {

    })
    .done(function (data) {
        if (data.length == 0) {
            $('#Logging').val('End of File or File Empty');
            return;
        }

        var builder = [data.length];

        var filterInfo = $('#filterInfo').hasClass('active');
        var filterWarn = $('#filterWarn').hasClass('active');
        var filterError = $('#filterError').hasClass('active');
        var filterSuccess = $('#filterSuccess').hasClass('active');
        var filterFailure = $('#filterFailure').hasClass('active');
        var filterUnknown = $('#filterUnknown').hasClass('active');

        var anyFilterFound = false;

        for (let i = 0; i < data.length; i++) {
            var DateEnd = data[i].indexOf(' ');
            var TimeEnd = data[i].indexOf(' ', DateEnd + 1);
            var CodeEnd = data[i].indexOf(' ', TimeEnd + 1);

            if (data[i].startsWith('I', CodeEnd + 1) && filterInfo ||
                data[i].startsWith('W', CodeEnd + 1) && filterWarn ||
                data[i].startsWith('E', CodeEnd + 1) && filterError ||
                data[i].startsWith('S', CodeEnd + 1) && filterSuccess ||
                data[i].startsWith('F', CodeEnd + 1) && filterFailure ||
                data[i].startsWith('?', CodeEnd + 1) && filterUnknown) {
                anyFilterFound = true;
                if (i == (data.length - 1)) {
                    builder[i] = data[i] + ($('#page').val() == '1' ? "\n" : ""); // Add a blank Line at the end for new Live log lines
                }
                else {
                    builder[i] = data[i] + "\n";
                }
            }
            else {
                if (i == (data.length - 1)) {
                    builder[i] = ($('#page').val() == '1' ? "\n" : ""); // Add a blank Line at the end for new Live log lines
                }
                else {
                    builder[i] = "\n";
                }
            }
        }

        if (anyFilterFound == false) {
            $('#Logging').val('No Records Found with applied filters on this page.');
        }
        else {
            $('#Logging').val(builder.join(''));
            scrollLogToBottom('Logging');
        }
    })
    .fail(function (xhr, status, error) {
        if (xhr.status == 401) {
            $('#Logging').val('Action requires User Log On');
        }
        if (xhr.status == 403) {
            $('#Logging').val('Insufficient user rights');
        }
    });
}

$.connection.wS.on("Send", function (id, Group) {
    if (id == TraceLogId && CoreLogDisplayed && $('#page').val() == '1') {
        var loggingTextArea = $('#Logging');
        loggingTextArea.val(loggingTextArea.val() + Group.Subjects[1].Value + '\n');
        scrollLogToBottom('Logging');
    }
    else if (id == NotificationId) {
        $("#notificationslist").prepend(CreateNewNotification(Group.Subjects[0].Value, Group.Subjects[1].Value, Group.Subjects[2].Value, Group.Subjects[3].Value, Group.Subjects[4].Value, Group.Subjects[5].Value, false, false));
        ApplyDeleteNotification();
        ApplyMuteNotification();
        jQuery("time.timeago").timeago();
    }
});

$('.tab-focus').click(function (e) {
    e.preventDefault();
    $(this).tab('show');
})

$(".btn-loadlog").click(function (event) {
    event.preventDefault();
    $(this).tab('show');

    $('#ComponentHeading').text("Trace Log of " + $(this).text())

    $('#page').val('1');

    CoreLogDisplayed = ($(this).attr("data-logtype") == "core");

    Selected = $(this);

    GetFile();
});

$("#btn-viewup").click(function (event) {
    event.preventDefault();
    pageUp();
});


$("#btn-viewdown").click(function (event) {
    event.preventDefault();
    pageDown();
});

document.getElementById("Logging").addEventListener("wheel", event => {
    if (Selected == null) {
        return;
    }

    if (event.deltaY > 0) {
        pageDown();
    }
    else {
        pageUp();
    }
});

function ignoreWindowScroll(e) {
    e.preventDefault();
}

$("#Logging").hover(
    function () {
        window.addEventListener("wheel", ignoreWindowScroll, { passive: false });
    }, function () {
        window.removeEventListener("wheel", ignoreWindowScroll, { passive: true });
    }
);

$(".toggleActive").click(function (event) {
    event.preventDefault();
    $(this).parent().toggleClass("active");
    GetFile();
});

scrollLogToBottom('Logging');
Selected = $("#selectedOnLoad");

// Notifications --------------------------------
var notificationPage = 1;

function ShowMore() {
    return '<div id="div-showmore" class="widget-actions">\
                    <a id="btn-showmore" href="' + PathsCurrent + '" class="btn btn-mini" title="">Show more</a>\
                </div>'
}

function CreateNewNotification(theId, theSource, theType, theTime, theMessage, theHref, theSourceMuted, theTypeMuted) {
    if (theHref == null || theHref == "") {
        if (theSource.toLowerCase().startsWith("multiplug.ext")) {
            theHref = PathsSettings + theSource + '/';
        }
        else {
            theHref = PathsSystem;
        }
    }

    var date = new Date(theTime);

    var friendlyDate = date.getHours() + ':' + date.getMinutes().toString().padStart(2, '0') + ':' + date.getSeconds().toString().padStart(2, '0') + ' ' + date.getDate() + '/' + (date.getMonth() + 1).toString().padStart(2, '0') + '/' + date.getFullYear();

    return ' <div class="comment">\
                    <i class="icon-bell icon-2x pull-left icon-border"></i>\
                    <div class="content">\
                        <span class="commented-by">\
                            <a href="' + theHref + '" title="">' + theSource + '</a> <time class="timeago" datetime="' + theTime + '">' + theTime + '</time>\
                        </span>' + theMessage +
                    '<span class="actions">&nbsp;\
                            <a href="' + PathsCurrent + '" class="btn-mute-notification ' + (theSourceMuted ? "muted" : "") + '" data-notiSource="' + theSource + '"> <i class="icon-volume-down"></i>' + (theSourceMuted ? "Unmute" : "Mute") + ' Source</a>' +
(theType == "" ? '' : '<a href="' + PathsCurrent + '" class="btn-mute-notification ' + (theTypeMuted ? "muted" : "") + '" data-notiSource="' + theSource + '" data-notiType="' + theType + '"><i class="icon-volume-down"></i>' + (theTypeMuted ? "Unmute" : "Mute") + ' Type ' + theType + '</a>') +
                        '<a href="' + PathsCurrent + '" class="comment-remove btn-delete-notification" data-notiid="' + theId + '"><i class="icon-trash"></i>Delete</a>\
                            <span class="pull-right">' + friendlyDate + '</span>\
                        </span>\
                    </div>\
                </div>';
}

function OnError(xhr) {
    if (xhr.status == 401) {
        alert('Action requires User Log On');
    }
    if (xhr.status == 403) {
        alert('Insufficient user rights');
    }
}

function ApplyDeleteNotification() {
    $(".btn-delete-notification").click(function (event) {
        event.preventDefault();

        var thisObject = $(this);

        $.post(PathsMultiPlug + "notifications/delete?id=" + $(this).data("notiid"), function (data) {

        })
        .done(function (data) {
            thisObject.closest('.comment').remove();
            $("#notification-count").text(data.count);
        })
        .fail(function (xhr, status, error) {
            OnError(xhr);
        });
    });
}

function handleMuteResponse(isMuted, type, source, This) {
    if (isMuted) {
        if (type != null) {
            $(This).html(' <i class="icon-volume-down"></i>Mute Type ' + type);
        }
        else {
            $(This).html(' <i class="icon-volume-down"></i>Mute Source');
        }

        $(This).removeClass("muted");
    }
    else {
        if (type != null) {
            alert("Notifications from " + source + " of type " + type + " will be muted during the current runtime");
            $(This).html(' <i class="icon-volume-down"></i>Unmute Type ' + type);
        }
        else {
            alert("All Notifications from " + source + " will be muted during the current runtime");
            $(This).html(' <i class="icon-volume-down"></i>Unmute Source');
        }

        $(This).addClass("muted");
    }
}

function ApplyMuteNotification() {
    $(".btn-mute-notification").click(function (event) {
        event.preventDefault();

        var type = $(this).attr("data-notiType");
        var source = $(this).attr("data-notiSource");
        var url = "";

        var This = $(this)
        var isMuted = This.hasClass("muted");

        if (type != null) {
            url = PathsMultiPlug + "notifications/" + (isMuted ? "unmute" : "mute") + "?source=" + source + "&type=" + type;
        }
        else {
            url = PathsMultiPlug + "notifications/" + (isMuted ? "unmute" : "mute") + "?source=" + source;
        }

        $.post(url, function (data) {
        })
        .done(function (data) {
            handleMuteResponse(isMuted, type, source, This);
        })
        .fail(function (xhr, status, error) {
            if (xhr.status == 400) { // State update already set
                handleMuteResponse(isMuted, type, source, This);
            }
            else
            {
                OnError(xhr);
            }
        });
    });
}

function ApplyShowMore() {
    $("#btn-showmore").click(function (event) {
        event.preventDefault();
        notificationPage++;
        GetNotifications();
    });
}

function OnLoadError(xhr, theSelection) {
    if (xhr.status == 401) {
        $(theSelection).empty();
        $(theSelection).append('<span class="label label-red">REQUIRES USER LOG ON</span>');
    }
    else if (xhr.status == 403) {
        $(theSelection).empty();
        $(theSelection).append('<span class="label label-red">INSUFFICIENT USER RIGHTS</span>');
    }
}

function GetNotifications() {
    $.ajax({
        url: PathsMultiPlug + "notifications/list?count=7&page=" + notificationPage,
        type: "get",
        success: function (data) {
            $("#div-showmore").remove();

            var note = $("#notificationslist");

            for (let i in data.notifications) {
                note.append(CreateNewNotification(data.notifications[i].id, data.notifications[i].source, data.notifications[i].type, data.notifications[i].time, data.notifications[i].message, data.notifications[i].href, data.notifications[i].sourceMuted, data.notifications[i].typeMuted)); //CreateNewNotification(theId, theSource, theType, theTime, theMessage, theHref )
            }

            if (data.notifications.length > 0) {
                note.append(ShowMore());
                ApplyShowMore();
            }

            ApplyDeleteNotification();
            ApplyMuteNotification();

            jQuery("time.timeago").timeago();
        },
        error: function (data) {
            OnLoadError(data, $('#notificationslist'));
        }
    });
}

GetNotifications();