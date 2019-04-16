// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function(){

    $(document).on("click", "#submitUsername", function(){
        $.get( "/Home/GetUserPosts", { username: "simplemove17" } )
        .done(function( data ) {
        alert( "Data Loaded: " + data );
    });
    
    });
});