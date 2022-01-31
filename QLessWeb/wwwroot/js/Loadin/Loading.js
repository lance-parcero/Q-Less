$('#btn-load').on('click', () => {
  
  if (!ValidateInput([$('#txtMoney'), $('#txtLoad')])) {
    var money = $('#txtMoney').val();
    var load = $('#txtLoad').val();
    var currentLoad = $('#lblCurrentLoad').text();
    var cardNumber = $('#h3-1').attr('card-number');
    if (+money >= +load) {
      if (+load + +currentLoad <= 1000) {
        $.post("/Loading/Load", { cardNumber, load }, function (ret) {
          var change = +money - +load;
          $('.card').removeClass('d-none');
          $("#lblAmountLoaded").text(load);
          $("#lblCustomerMoney").text(money);
          $("#lblChange").text(change);
          $("#lblNewBalance").text(ret);
          $('#lblCurrentLoad').text(ret);
        });
        $("#message").text("Load Complete").css('color', 'black');
      }
      else {
        $('.card').addClass('d-none');
        $("#message").text('Maximum Load Limit Reached').css('color','red');
      }
    }
    else {
      $('.card').addClass('d-none');
      $("#message").text('Not enough money').css('color', 'red');
    }

  }

})