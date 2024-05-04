$(document).ready(function () {
 

    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn');
      allPreviousBtn = $('.backBtn');

    allWells.hide();
    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-success').addClass('btn-default');
            $item.addClass('btn-success');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid) nextStepWizard.removeAttr('disabled').trigger('click');
    });
    allPreviousBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().prev().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid) nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-success').trigger('click');
});
var currentTab = 0;
$(function () {
    $("#tabs").tabs({
        select: function (e, i) {
            currentTab = i.index;
        }
    });
});
$("#btnNext").live("click", function () {
    var tabs = $('#tabs').tabs();
    var c = $('#tabs').tabs("length");
    currentTab = currentTab == (c - 1) ? currentTab : (currentTab + 1);
    tabs.tabs('select', currentTab);
    $("#btnPrevious").show();
    if (currentTab == (c - 1)) {
        $("#btnNext").hide();
    } else {
        $("#btnNext").show();
    }
});
$("#btnPrevious").live("click", function () {
    var tabs = $('#tabs').tabs();
    var c = $('#tabs').tabs("length");
    currentTab = currentTab == 0 ? currentTab : (currentTab - 1);
    tabs.tabs('select', currentTab);
    if (currentTab == 0) {
        $("#btnNext").show();
        $("#btnPrevious").hide();
    }
    if (currentTab < (c - 1)) {
        $("#btnNext").show();
    }
});