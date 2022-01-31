
formatMMddyyyyUTC = (date) => {
  var d = date.split('/');
  var year = d[2];
  var month = d[0];
  var day = d[1];
  return d[2] + '-' + d[0] + '-' + d[1];
}

// toObject = (formArray) => {
//  serialize data function
//  var returnArray = {};
//  for (var i = 0; i < formArray.length; i++) {
//    returnArray[formArray[i]['name']] = formArray[i]['value'];
//  }
//  return returnArray;
//}


ValidateInput = (arrayControls) => {
  var errorCount = 0;
  $(arrayControls).each(function () {
    if ($(this).val() === '') {
      errorCount++;
      $(this).css('border', '1px solid #FF0000');
    }
    else {
      $(this).removeAttr("style");
    }
  });
  return errorCount > 0 ? true : false;
}

ValidateEmail = (email) => {
  var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
  return regex.test(email);
}



function CreateGuid() {
  function _p8(s) {
    var p = (Math.random().toString(16) + "000000000").substr(2, 8);
    return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
  }
  return _p8() + _p8(true) + _p8(true) + _p8();
}


var today = new Date();
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
var yyyy = today.getFullYear();


var defaultSelectedYear = yyyy - 18;
today = mm + '/' + dd + '/' + yyyy;
//today = yyyy + '-' + mm + '-' + dd;
var firstDay = mm + '/' + '01' + '/' + defaultSelectedYear;

//$(".date-readonly").removeAttr("readonly");

$(document).ready(function () {
  (function ($) {
    $.fn.inputFilter = function (inputFilter) {
      return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
        if (inputFilter(this.value)) {
          this.oldValue = this.value;
          this.oldSelectionStart = this.selectionStart;
          this.oldSelectionEnd = this.selectionEnd;
        } else if (this.hasOwnProperty("oldValue")) {
          this.value = this.oldValue;
          this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
        } else {
          this.value = "";
        }
      });
    };
  }(jQuery));

  // 1-9
  $(".numeric").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
  });
  //A-Z
  $(".alphabet").inputFilter(function (value) {
    return /^[a-z ]*$/i.test(value);
  });
  //1-9 A-Z
  $(".alphanumeric").inputFilter(function (value) {
    return /^[a-zA-Z0-9 ]*$/i.test(value);
  });

  //1-0 A-Z _@./#&+-]*$ with special characters
  $(".alphanumericspecial").inputFilter(function (value) {
    return /^[a-zA-Z0-9`~!@#$%^&*()-_+=:;"'<,>.?/ ]*$/i.test(value);
  });

  //Integer >= 0
  $("#uintTextBox").inputFilter(function (value) {
    return /^\d*$/.test(value);
  });
  //Integer with limits 0 >= and <=500
  $("#intLimitTextBox").inputFilter(function (value) {
    return /^\d*$/.test(value) && (value === "" || parseInt(value) <= 500);
  });
  //Float
  $("#floatTextBox").inputFilter(function (value) {
    return /^-?\d*[.,]?\d*$/.test(value);
  });
  //Currency 2 Decimal
  $("#currencyTextBox").inputFilter(function (value) {
    return /^-?\d*[.,]?\d{0,2}$/.test(value);
  });
  //Hexadecimal
  $("#hexTextBox").inputFilter(function (value) {
    return /^[0-9a-f]*$/i.test(value);
  });
});


//function encrypt(key) {
//  return CryptoJS.AES.encrypt(JSON.stringify(key), "rMs5KTR0iXGqMATbvH6gS9qgWFz5xogp");
//}

//function decrypt(key) {
//  return (CryptoJS.AES.decrypt(key, "rMs5KTR0iXGqMATbvH6gS9qgWFz5xogp")).toString(CryptoJS.enc.Utf8);
//}

String.prototype.thousandSeparator = function () {
  return this.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}



debounce = (func, wait, immediate) => {
  var timeout;
  return function () {
    var context = this, args = arguments;
    var later = function () {
      timeout = null;
      if (!immediate) func.apply(context, args);
    };
    var callNow = immediate && !timeout;
    clearTimeout(timeout);
    timeout = setTimeout(later, wait);
    if (callNow) func.apply(context, args);
  };
};

String.prototype.allTrim = String.prototype.allTrim ||
  function () {
    var test = this.trim();
    return test.replace(/\s+/g, ' ')
      .replace(/^\s+|\s+$/, '');
  };