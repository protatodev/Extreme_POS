


var menuDisplay = function() {
    $(".menu button").click(function() {
        var target = $(this).attr("id");
        $(".display").hide();
        $("#" + target + "-display").show();
    });

    $("#tables").click();
}

var menuNav = function() {
    $(".menu button").click(function() {
        $(this).parent().siblings().removeClass("nav-selected");
        $(this).parent().addClass("nav-selected");
    });
    $(".permissions button").click(function() {
        $(this).parent().siblings().removeClass("nav-selected");
        $(this).parent().addClass("nav-selected");
    });
}



var foodFlood = function() { // populates the food tab buttons
      $.ajax({
        type: 'GET',
        url: '/food-get',
        success: function (result) {
          $('#food-display').html(result);
        }
      });
}


var foodAdd = function(name, id, ticket) { // hopefully tosses said buttons into ticket
    $.ajax({
        type: 'post',
        data: { name: name, id: id, ticket: ticket},
        url: '/food-add',
        success: function (result) {
          $('.food-orders tbody').append(result);
        }
      });
}

var drinksFlood = function() {
      $.ajax({
        type: 'GET',
        url: '/drinks-get',
        success: function (result) {
          $('#drinks-display').html(result);
        }
      });
}

var drinkAdd = function(id, ticket) {
    $.ajax({
        type: 'post',
        data: { id: id, ticket: ticket},
        url: '/drinks-add',
        success: function (result) {
          $('.drink-orders tbody').append(result);
        }
      });
}

$(function() {
    menuNav();
    menuDisplay();
    foodFlood();
    drinksFlood();

    var total = 1;

    $(document).on("click", ".food-item", function () {
        var foodName = $(this).children().first().html();
        var foodId = $(this).children().first().siblings().html();
        var ticketId = $("#ticket-id").text();
        var items = [];

        $('.price').each(function(i, obj) {

        foodAdd(foodName, foodId);
    });
                total++;
        });     


        console.log(total);

        foodAdd(foodName, foodId, ticketId);
    });

    $(document).on("click", ".drinks-item", function () {
        var drinkId = $(this).children().first().siblings().html();
        var ticketId = $("#ticket-id").text();
        drinkAdd(drinkId, ticketId);
    });





    $(".wide-table, .bar .seat").click(function() {
        var tableId = $(this).children().children().children().text();
        console.log(tableId);
        var url = $(this).children().first().attr('href');
        $.ajax({
        type: 'post',
        data: {table_id: tableId},
        url: url,
        success: function (result) {
          $('.ticket-number').html(result);
        }
      });
    });

});
