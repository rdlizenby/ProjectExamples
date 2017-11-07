$(document).ready(function () {
    "use strict";
    loadDvds();
  
    $('#create-button').click(function (event) {
        $('#errorMessages').empty();
        if (($('#create-dvd-title').val() === '') || (($('#create-release-year').val() < 1000) || ($('#create-release-year').val() > 9999))) {
            if ($('#create-dvd-title').val() === '') {
                $('#errorMessages')
                    .append($('<li>')
                         .attr({class: 'list-group-item list-group-item-danger'})
                              .text('Please enter a title for the DVD.'));
            }
            if (($('#create-release-year').val() < 1000) || ($('#create-release-year').val() > 9999)) {
                $('#errorMessages')                
                    .append($('<li>')
                         .attr({class: 'list-group-item list-group-item-danger'})
                              .text('Please enter a 4 digit year'));
            }
        } else {
            $.ajax({
                type: 'POST',
                url: 'http://localhost:61515/dvd',
                data: JSON.stringify({
                    title: $('#create-dvd-title').val(),
                    releaseYear: $('#create-release-year').val(),
                    director: $('#create-director').val(),
                    rating: $('#create-rating').val(),
                    notes: $('#create-notes').val()
                }),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                'dataType': 'json',
                success: function () {
                    backToHome();
                },
                error: function () {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({class: 'list-group-item list-group-item-danger'})
                                .text('Error calling web service. Please try again later.'));
                }
            })
        }
    });
    
    $('#edit-button').click(function (event) {
        $('#errorMessages').empty();
        if (($('#edit-dvd-title').val() === '') || (($('#edit-release-year').val() < 1000) || ($('#edit-release-year').val() > 9999))) {
            if ($('#edit-dvd-title').val() === '') {
                $('#errorMessages')
                    .append($('<li>')
                         .attr({class: 'list-group-item list-group-item-danger'})
                              .text('Please enter a title for the DVD.'));
            }
            if (($('#edit-release-year').val() < 1000) || ($('#edit-release-year').val() > 9999)) {
                $('#errorMessages')
                    .append($('<li>')
                         .attr({class: 'list-group-item list-group-item-danger'})
                              .text('Please enter a 4 digit year'));
            }
        } else {
            $.ajax({
                type: 'PUT',
                url: 'http://localhost:61515/dvd/' + $('#edit-dvd-id').val(),
                data: JSON.stringify({
                    dvdId: $('#edit-dvd-id').val(),
                    title: $('#edit-dvd-title').val(),
                    releaseYear: $('#edit-release-year').val(),
                    director: $('#edit-director').val(),
                    rating: $('#edit-rating').val(),
                    notes: $('#edit-notes').val()
                }),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                'dataType': 'json',
                success: function () {
                    $('#errorMessages').empty();
                    $('#edit-first-name').val('');
                    $('#edit-last-name').val('');
                    $('#edit-company').val('');
                    $('#edit-phone').val('');
                    $('#edit-email').val('');
                    $('#edit-dvd-id').val('');

                    backToHome();
                },
                error: function () {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({class: 'list-group-item list-group-item-danger'})
                                .text('Error calling web service. Please try again later.'));
                }
            })
        }
    });
});
                  
function loadDvds() {
    "use strict";
    var contentRows = $('#contentRows');
    
    $.ajax({
        type: 'GET',
        url: 'http://localhost:61515/dvds',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                
                var row = '<tr>';
                row += '<td><a onclick="showDvdDetails(' + dvd.dvdId + ')">' + dvd.title + '</a></td>';
                row += '<td>' + dvd.releaseYear + '</td>';
                row += '<td>' + dvd.director + '</td>';
                row += '<td>' + dvd.rating + '</td>';

                row += '<td><a onclick="showEditForm(' + dvd.dvdId + ')">Edit </a>';
                row += '| <a onclick="deleteDvd(' + dvd.dvdId + ')">Delete</a></td>';
                row += '<tr>';
                
                contentRows.append(row);
            });
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service. Please try again later.'));
        }
    });
}

function showDvdDetails(dvdId) {
    "use strict";
    $('#display-dvd-div').show();
    $('#displayHeader').hide();
    $('#dvdTableDiv').hide();
    
    $.ajax({
        type: 'GET',
        url: 'http://localhost:61515/dvd/' + dvdId,
        success: function (dvd) {
            $('#dvd-title').append(dvd.title);
            $('#dvd-release-year').append(dvd.releaseYear);
            $('#dvd-director').append(dvd.director);
            $('#dvd-rating').append(dvd.rating);
            $('#dvd-notes').append(dvd.notes);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service. Please try again later.'));
        }
    });
}

function backToHome() {
    "use strict";
    $('#errorMessages').empty();
    $('#create-dvd-title').val('');
    $('#create-release-year').val('');
    $('#create-director').val('');
    $('#create-rating').val('');
    $('#create-notes').val('');
    $('#dvd-title').empty();
    $('#dvd-release-year').empty();
    $('#dvd-director').empty();
    $('#dvd-rating').empty();
    $('#dvd-notes').empty();
    $('#display-dvd-div').hide();
    $('#create-dvd-div').hide();
    $('#edit-dvd-div').hide();
    $('#dvdTableDiv').show();
    $('#displayHeader').show();
    $('#contentRows').empty();
    loadDvds();
}

function createDvd() {
    $('#displayHeader').hide();
    $('#dvdTableDiv').hide();
    $('#create-dvd-div').show();
}

function deleteDvd(dvdId) {
    $(function () {
        $("#dialog-confirm").dialog({
            resizable: false,
            height: "auto",
            width: 400,
            modal: true,
            buttons: {
                "Delete DVD": function () {
                    $(this).dialog("close");
                    $.ajax({
                        type: 'DELETE',
                        url: 'http://localhost:61515/dvd/' + dvdId,
                        success: function () {
                            backToHome();
                        }
                    });
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        });
    });
}

function showEditForm(dvdId) {
    $('#create-dvd-div').hide();
    $('#edit-dvd-div').show();
    $('#dvdTableDiv').hide();
    $('#displayHeader').hide();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:61515/dvd/' + dvdId,
        success: function (dvd) {
            $('#edit-dvd-title').val(dvd.title);
            $('#edit-release-year').val(dvd.releaseYear);
            $('#edit-director').val(dvd.director);
            $('#edit-rating').val(dvd.rating);
            $('#edit-notes').val(dvd.notes);
            $('#edit-dvd-id').val(dvd.dvdId);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                        .text('Error calling web service. Please try again later.'));
        }
    });
}

function search() {
    var searchCategory = $('#search-category');
    var searchTerm = $('#search-term');
    if ((searchCategory.val() === "Search Category") || (searchTerm.val() === "")) {
        $('#errorMessages')
            .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Both Search Category and Search Term are required.'));
    } else {
        $('#errorMessages').empty();
        $.ajax({
            type: 'GET',
            url: 'http://localhost:61515/dvds/' + searchCategory.val().toLowerCase() + '/' + searchTerm.val(),
            success: function (dvdArray) {
                $('#contentRows').empty();
                $.each(dvdArray, function (index, dvd) {

                    var row = '<tr>';
                    row += '<td><a onclick="showDvdDetails(' + dvd.dvdId + ')">' + dvd.title + '</a></td>';
                    row += '<td>' + dvd.releaseYear + '</td>';
                    row += '<td>' + dvd.director + '</td>';
                    row += '<td>' + dvd.rating + '</td>';

                    row += '<td><a onclick="showEditForm(' + dvd.dvdId + ')">Edit </a>';
                    row += '| <a onclick="deleteDvd(' + dvd.dvdId + ')">Delete</a></td>';
                    row += '<tr>';

                    $('#contentRows').append(row);
                    });
                },
                error: function() {
                    $('#errorMessages')
                        .append($('<li>')
                            .attr({class: 'list-group-item list-group-item-danger'})
                                .text('Error calling web service. Please try again later.'));
                }
            });  
        }
}
