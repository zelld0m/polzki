 //Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
 //for details on configuring this project to bundle and minify static web assets.

 //Write your JavaScript code.
$(function(){
    console.log("Page is ready");
    $("#findAttendeeBtn").click(function () {
        event.preventDefault();
        console.log("Find Attendee Button is clicked");
        $.ajax({
            type: "GET",
            url: 'SingleAttendee/Id',
            data: $("form").serialize(),
            success: function (data) {
                console.log(data);
                $("attendeeInformationArea").html(data);
            }
        });
    });
});