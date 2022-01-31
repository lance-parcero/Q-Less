const PWD = 2;
const Senior = 3;

$(document).ready(() => {
  var selectedCardType = $('#txtCardType option:first');
  SetData(selectedCardType);

  $("#txtAdditionalID").keydown(function (evt)
  {
    return this.value = this.value.toUpperCase();
  });
});

/*Events*/
$('#txtClassification').on('change', (evt) => {
  $("#txtAdditionalID").val("");
  var classification = $(evt.currentTarget).val();
  if (classification == PWD)  //PWD
    $("#txtAdditionalID").mask('LL-LLLL-LLLL', {
      translation: {
        'L': { pattern: /^[a-zA-Z0-9]*/ }
      }
    }).attr('maxlength', '12');
  else if (classification == Senior)  //Senior
    $("#txtAdditionalID").mask('LLLL-LLLL-LLLL', {
      translation: {
        'L': { pattern: /^[a-zA-Z0-9]*/ }
      }
    }).attr('maxlength', '14');
  else
    $("#txtAdditionalID").unmask().attr('maxlength', '20');
});





$('#txtCardType').on('change', (evt) => {
  var selectedCardType = $("option:selected", evt.currentTarget);
  SetData(selectedCardType);
});

$('#btnEnroll').on('click', () => {
  if (confirm("Are you sure?")) {
    var isValidEmail = ValidateEmail($('#txtEmailAddress').val());
    var isRequiredID = $('#txtClassification').val() == PWD || $('#txtClassification').val() == Senior;
    if (!ValidateInput($('.required')) && isValidEmail && (!isRequiredID || HasAdditionalID($('#txtAdditionalID')))) {
      var enrollmentForm = $('#enrollment').serializeObject();
      $.post('/Home/Save', enrollmentForm, function (ret) {
        alert('id created:' + ret);
      });
    }
  }
});



/*Functions*/

SetData = (obj) => {
  var initialLoad = obj.attr('initial-load');
  var validity = obj.attr('validity');
  $('#txtLoad').val(initialLoad);
  $('#txtValidity').val(validity);
}


HasAdditionalID = (txtAdditionalID) => {
  if (!ValidateInput(txtAdditionalID)) {
    var id = $('#txtClassification').val();
    var addIDLength = $(txtAdditionalID).val().length;
    if (id == PWD) { //12
      addIDLength != 12 ? $(txtAdditionalID).css('border', '1px solid #FF0000') : $(txtAdditionalID).removeAttr("style");
      return addIDLength == 12;
    }
    else if (id == Senior) { //14
      addIDLength != 14 ? $(txtAdditionalID).css('border', '1px solid #FF0000') : $(txtAdditionalID).removeAttr("style");
      return addIDLength == 14;
    }
  }
  return false;
}

