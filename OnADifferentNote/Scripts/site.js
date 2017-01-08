$(document).ready(function () {
    
    //Check if a cookie with zip code or new user already exists
    var docCookies = document.cookie.split(";");
    var cookieZip;
    for (var i = 0; i <docCookies.length; i++) {
        var thisCookie = docCookies[i].split("=");
        var cookieName = thisCookie[0];
        var cookieValue = thisCookie[1];
        if ((cookieName === "Zip Code Cookie" || cookieName === " Zip Code Cookie") && cookieValue != null) {
            var zipObj = { zipCode: cookieValue };
            var cookieZip = thisCookie;
            zipUpdate(zipObj);
        }
        else if (cookieName === "Username" || cookieName === " Username") {
            revealWelcomeMessage(cookieValue);
        }
        if (cookieZip === null) {
            $(".regular-price").removeClass("slash-through italics");
        }
    }

    //Get all the buttons
    var zipButton = document.getElementById("zipCodeButton");
    var signUpButton = document.getElementById("signUpButton");
    var addToCartButton = document.getElementById("addToCart");
    var removeFromCartButton = document.getElementById("removeFromCart");

    function zipUpdate(data) {
        //Might not need to make this a json obj, but rather keep is as a string and then remove the .stringify down a few lines
        //only do ajax request if zipCode field does in fact have value
        $.ajax(
            {
                url: "/Home/UpdateZip",
                data: JSON.stringify(data),
                type: "POST",
                //This could be changed to dataType: "json"
                contentType: "application/json; charset=utf-8",
                success: function (responseJSON) {
                    var salePrice = responseJSON.promoSalePrice;
                    if (salePrice != 0)
                    {
                        $(".regular-price").addClass("slash-through italics");
                        $(".sale-price").addClass("special attention");
                        $(".sale-price").text("$" + salePrice);
                    }
                    else {
                        $(".regular-price").removeClass("slash-through italics");
                        $(".sale-price").removeClass("special attention");
                        $(".sale-price").text("");
                    }
                    displayZip(data.zipCode);
                    //Every js function has automatic arguments
                    //var response = data;
                    //$(".results").text("Zipcode upated to: " + $("#zipCode").val());
                    //way done in class was to get the responseJson.promoSalePrice
                    //check if it is not null
                    //if so, add classes that will display strikethrough
                    //else, remove the strikethrough class
                    //I would need some class results in html, which would then display results
                },
                error: function () {
                    alert("Error");
                }
            })
    }

    function createUser(data) {
        $.ajax({
                url: "/Home/NewUserSignUp",
                data: JSON.stringify(data),
                type: "POST",
                contentType: "application/json charset=utf-8",
                success: function (responseJSON) {
                    var username = responseJSON.user;
                    revealWelcomeMessage(username);
                },
                error: function () {
                    alert("Oh no, looks like something went wrong.")
                }
            })
    }

    function addToCart(cartdata) {
        $.ajax({
            url: "/Cart/AddToCart",
            data: JSON.stringify(cartdata),
            type: "POST",
            contentType: "application/json charset=utf-8",
            success: function (responseJSON) {
                alert("cartId: " + responseJSON.cartId)
            },
            error: function () {
                alert("Oh no, looks like something went wrong.")
            }
        })
    }

    function removeFromCart(cartdata) {
        $.ajax({
            url: "/Cart/RemoveFromCart",
            data: JSON.stringify(cartdata),
            type: "POST",
            contentType: "application/json charset=utf-8",
            success: function (responseJSON) {
            },
            error: function () {
                alert("Oh no, looks like something went wrong.")
            }
        })
    }

    function revealWelcomeMessage(username) {
        $("#welcome-message").css("visibility", "visible");
        $("#welcome-message").text("Welcome, " + username);
    }
    
    function displayZip(zipcode) {
        $("#current-zipcode").css("visibility", "visible");
        $("#current-zipcode").text("Current Zip Code: " + zipcode);
    }

    if (zipButton != null) { 
        zipButton.addEventListener("click", function () 
        { zipUpdate({ zipCode: $("#zipCode").val() }); },
        false); 
    }

   
    signUpButton.addEventListener("click", function () {
        createUser({
            email: $("#emailInput").val(),
            username: $("#usernameInput").val(),
            password: $("#passwordInput").val()
        });
    }, false);
    if (addToCartButton != null) { 
        addToCartButton.addEventListener("click", function () 
        { addToCart({ productId: $("#productId").text() }) }, false); 
    }
    if (removeFromCartButton != null) {
        removeFromCartButton.addEventListener("click", function ()
        {removeFromCart({productId: $("#productId").text()})}, false);
    }
});



   