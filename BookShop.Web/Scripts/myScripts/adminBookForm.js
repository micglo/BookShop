//JS używany w widokach /Areas/Admin/Views/Books/Create i /Areas/Admin/Views/Books/Create/Edit


$(function () {
    //Zmiana informacji o błędzie dla input type number
    jQuery.extend(jQuery.validator.messages, {
        number: "Podaj wartość liczbowa."
    });


    //tworzy slider dla wartości 0 - 1, aby obsłużyć pole bestseller(tak/nie)
    var handle = $("#custom-handle");
    $("#slider").slider({
        create: function () {
            handle.text($(this).slider("value"));
        },
        slide: function (event, ui) {
            handle.text(ui.value);
        },
        min: 0,
        max: 1,
        value: setBestsellerValue(),
        change: function (event, ui) {
            if (ui.value === 0)
                $('#bestseller').val('false');
            else
                $('#bestseller').val('true');
        }
    });


    //ustawia wartość dla slidera
    function setBestsellerValue() {
        var val = $('#bestseller').val();
        if (val === 'True')
            return 1;
        return 0;
    }


    //tworzy obiekt datepicker 
    $('#publishDate').datepicker({
        dateFormat: 'dd/mm/yy',
        regional: ["pl"],
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        showAnim: "slideDown"
    });


    //click na ikone, aby rozwinąć wybór daty
    $('#publishDateButton').click(function () {
        $('#publishDate').datepicker("show");
    });


    //select2 na pole wyboru języka
    $('#languagesSelectList')
        .select2({
            language: 'pl',
            minimumResultsForSearch: Infinity
        }).on('change', function () {
            $('#languagesSelectList').valid();
        });


    //select2 na pole wyboru rodzaju okładki
    $('#coversSelectList')
        .select2({
            language: 'pl',
            minimumResultsForSearch: Infinity
        });


    //select2 na pole wyboru wydawnictwa
    $('#publishingSelectList')
        .select2({
            language: 'pl',
            ajax: {
                url: function (params) {
                    return '/Admin/Publishings/GetPublishingsForSelect?searchString=' + params.term;
                },
                processResults: function (data) {
                    var preparedData = [];
                    $.each(data,
                        function (index, element) {
                            preparedData.push({
                                id: element.Id,
                                text: element.Text
                            });
                        });

                    return {
                        results: preparedData
                    };
                }
            }
        }).on('change', function () {
            $('#publishingSelectList').valid();
        });


    //select2 na pole wyboru autorów
    $('#authorSelectList')
        .select2({
            language: 'pl',
            multiple: true,
            placeholder: '*** Wybierz autora ***',
            ajax: {
                url: function (params) {
                    return '/Admin/Authors/GetAuthorsForSelect?searchString=' + params.term;
                },
                processResults: function (data) {
                    var preparedData = [];
                    $.each(data,
                        function (index, element) {
                            preparedData.push({
                                id: element.Id,
                                text: element.Text
                            });
                        });

                    return {
                        results: preparedData
                    };
                }
            }
        }).on('change', function () {
            $('#authorSelectList').valid();
        });


    //select2 na pole wyboru subkategorii
    $('#subMainCategorySelectList')
        .select2({
            language: 'pl',
            multiple: true,
            placeholder: '*** Wybierz kategorie ***'
        }).on('change', function () {
            var subMainCategoryValues = $(this).val();

            var url = '/Admin/Books/GetBookCategories?subMainCategoryIdList=' + subMainCategoryValues;

            $.get(url,
                function (data) {
                    var preparedData = new Array();
                    $.each(data,
                        function (index, element) {
                            preparedData.push({
                                text: element.Text,
                                children: getElementChildren(element.Children)
                            });
                        });

                    var oldBookCategoryValues = $("#bookCategorySelectList").val();
                    $("#bookCategorySelectList").select2().empty();

                    $("#bookCategorySelectList")
                        .select2(
                        {
                            language: 'pl',
                            multiple: true,
                            data: preparedData,
                            placeholder: '*** Wybierz kategorie ***'
                        });

                    $("#bookCategorySelectList").val(oldBookCategoryValues).trigger('change');

                    function getElementChildren(children) {
                        var childrenArr = new Array();
                        $.each(children,
                            function (index, child) {
                                childrenArr.push({
                                    id: child.Id,
                                    text: child.Text
                                });
                            });
                        return childrenArr;
                    }
                });

            $('#subMainCategorySelectList').valid();
        });


    //select2 na pole wyboru kategorii
    $('#bookCategorySelectList')
        .select2({
            language: 'pl',
            multiple: true,
            placeholder: '*** Wybierz kategorie ***'
        });
});