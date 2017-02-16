//ustawienia dla dataTables
$.extend($.fn.dataTable.defaults, {
    "dom": '<"toolbar">lfrtip',
    "language": {
        "decimal": ",",
        "thousands": ".",
        "lengthMenu": "Pokaż _MENU_ rekordów na stronę",
        "zeroRecords": "Brak danych",
        "info": "Strona _PAGE_ z _PAGES_",
        "infoEmpty": "Brak danych",
        "emptyTable": "Brak danych",
        "infoFiltered": "(znalezionych z _MAX_ wszystkich rekordów)",
        "search": "Szukaj",
        "paginate": {
            "previous": "Poprzednia",
            "next": "Następna"
        }
    }
});