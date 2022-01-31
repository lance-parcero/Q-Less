$('#btn-deduct').on('click', () => {
  $('#loading').removeClass('d-none');
  var cardNumber = $('#h3-1').attr('card-number');
  debounce($.post('/Transaction/Deduct', { cardNumber }, function (ret) {
    $('#loading').addClass('d-none');
    $('#message').html(ret);
    $.post("/Transaction/GetTransactions", { cardNumber }, function (ret) {
      $('#transaction-container').empty();
      $('#transaction-container').html(ret);
    });
  }), 1000);

 


});