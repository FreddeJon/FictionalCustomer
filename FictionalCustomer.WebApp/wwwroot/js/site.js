﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//SelectPicker 
$(function () {
    $('select').selectpicker();
});

$(function () {
    var table = $('#user-employee-datatables').DataTable({
        processing: true,
        ordering: true,
        paging: true,
        searching: true,
        order: [[1, "asc"]],
        ajax: {
            "url": "/api/data/employees",
            "type": "GET",
            "datatype": "json"
        },
        "language": {
            "lengthMenu": "Display _MENU_ records per page",
            "zeroRecords": "Nothing found - sorry",
            "info": "Showing page _PAGE_ of _PAGES_",
            "infoEmpty": "No records available",
            "infoFiltered": "(filtered from _MAX_ total records)"
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [4],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [5],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [6],
                "visible": true,
                "searchable": false,
                "orderable": false
            }
        ],

        columns: [
            { "data": "id" },
            { "data": "name" },
            { "data": "stackType" },
            { "data": "email" },
            { "data": "phoneNumber" },
            { "data": "employeeStatus" },
            {
                "render": function (data, type, full, meta) {
                    return '<div style="display:flex;justify-content: center;"> <a class="" href="/Admin/Employees/Details?id=' + full.id + '"><i class="bi bi-info-circle"></i></a>'
                        ;
                }
            }
        ]

    });
});



// Admin EMPLOYE TABLE
$(function () {
    var table = $('#admin-employee-datatables').DataTable({
        processing: true,
        ordering: true,
        paging: true,
        searching: true,
        order: [[1, "asc"]],
        ajax: {
            "url": "/api/data/employees",
            "type": "GET",
            "datatype": "json"
        },
        "language": {
            "lengthMenu": "Display _MENU_ records per page",
            "zeroRecords": "Nothing found - sorry",
            "info": "Showing page _PAGE_ of _PAGES_",
            "infoEmpty": "No records available",
            "infoFiltered": "(filtered from _MAX_ total records)"
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [4],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [5],
                "visible": true,
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [6],
                "visible": true,
                "searchable": false,
                "orderable": false,
            }
        ],

        columns: [
            { "data": "id" },
            { "data": "name" },
            { "data": "stackType" },
            { "data": "email" },
            { "data": "phoneNumber" },
            { "data": "employeeStatus" },
            {
                "render": function (data, type, full, meta) {
                    return '<div class="buttons-actions"> <a class="" href="/Admin/Employees/Details?id=' + full.id + '"><i class="bi bi-info-circle"></i></a>' +
                        '<a href="/Admin/Employees/Edit?id=' + full.id + '" ><i class="bi bi-pen"></i></a>' +
                        '<a href="/Admin/Employees/Delete?id=' + full.id + '" ><i class="bi bi-trash"></i></a></div>'
                        ;
                }
            }
        ]
    });
});

// Admin Projects Table
$(function () {
    var table = $('#admin-projects-datatables').DataTable({
        processing: true,
        ordering: true,
        paging: true,
        searching: true,
        order: [[1, "asc"]],
        ajax: {
            "url": "/api/data/projects",
            "type": "GET",
            "datatype": "json"
        },
        "language": {
            "lengthMenu": "Display _MENU_ records per page",
            "zeroRecords": "Nothing found - sorry",
            "info": "Showing page _PAGE_ of _PAGES_",
            "infoEmpty": "No records available",
            "infoFiltered": "(filtered from _MAX_ total records)"
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [4],
                "visible": true,
                "searchable": false,
                "orderable": true
            },
            {
                "targets": [5],
                "visible": true,
                "searchable": false,
                "orderable": true
            },
            {
                "targets": [6],
                "visible": true,
                "searchable": false,
                "orderable": false,
            }
        ],

        columns: [
            { "data": "id" },
            { "data": "company" },
            { "data": "projectName" },
            { "data": "projectBudget" },
            { "data": "startDate" },
            { "data": "endDate" },
            { "data": "projectStatus" },
            {
                "render": function (data, type, full, meta) {
                    return '<div class="buttons-actions"> <a class="" href="/Admin/Projects/Details?id=' + full.id + '"><i class="bi bi-info-circle"></i></a>' +
                        '<a href="/Admin/Projects/Edit?id=' + full.id + '" ><i class="bi bi-pen"></i></a>' +
                        '<a href="/Admin/Projects/Delete?id=' + full.id + '" ><i class="bi bi-trash"></i></a></div>'
                        ;
                }
            }
        ]
    });
});




$(document).ready(function () {
    $(document).on('change', '#heyo', function () {
        var note = $(this).find('option').first(),// the '--Select--' option
            selected = $(this).find('option:selected'),
            rest = $(this).find('option:not(:first-of-type):not(:selected)');

        var sorter = (a, b) => {
            let aName = a.innerText.toLowerCase(),
                bName = b.innerText.toLowerCase();
            return ((aName < bName) ? -1 : ((aName > bName) ? 1 : 0));
        };

        $(this)
            // adding '--Select--' 
            .html(note)
            // appending selected options sorted in alphabetical order
            .append(selected.sort(sorter))
            // adding the rest of the options sorted too
            .append(rest.sort(sorter));
    });
});
