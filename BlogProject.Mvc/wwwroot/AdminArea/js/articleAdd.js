$(document).ready(function () {

    //Trumbowyg
    $('#text-editor').trumbowyg({

        btns: [
            ['viewHTML'],
            ['undo', 'redo'], // Only supported in Blink browsers
            ['formatting'],
            ['strong', 'em', 'del'],
            ['superscript', 'subscript'],
            ['link'],
            ['insertImage'],
            ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
            ['removeformat'],
            ['fullscreen'],
            ['foreColor', 'backColor'],
            ['fontsize'],
            ['fontfamily']


        ],
        plugins: {
            fontsize: {
                sizeList: [
                    '12px',
                    '14px',
                    '16px'
                ]
            }
        },
        plugins: {
            fontfamily: {
                fontList: [
                    { name: 'Arial', family: 'Arial, Helvetica, sans-serif' },
                    { name: 'Comic Sans', family: '\'Comic Sans MS\', Textile, cursive, sans-serif' },
                    { name: 'Open Sans', family: '\'Open Sans\', sans-serif' }
                ]
            }
        }
    });
    //  //Trumbowyg

    //Select2

    $('#categoryList').select2({
        theme: 'bootstrap4',
        placeholder: "Bir Kategori Seçiniz",
        allowClear: true
    });
    //Select2


    //JQueryUI-DatePicker

    $(function () {
        $("#datepicker").datepicker({

            closeText: "kapat",
            prevText: "&#x3C;geri",
            nextText: "ileri&#x3e",
            currentText: "bugün",
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
                "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
            dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
            dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            weekHeader: "Hf",
            dateFormat: "dd.mm.yy",
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: "",
            duration: 1000,
            showAnim: "drop",
            showOptions:{direction:"down"},
            minDate: -3,
            maxDate: +3,

        });
    });
    //JQueryUI-DatePicker

})