$(document).ready(function () {
        
    loadItems();
    
});

function loadItems() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:62785/items/',
        success: function (itemArray) {
            $('#holds-items').empty();
            $.each(itemArray, function (index, item) {
                var barSize;
                if (item.quantity > 10) {
                    barSize = 100
                } else {
                    barSize = item.quantity * 10;
                }
                var row = '<div class="col-md-4 item-box" id="box' + item.id + '"style="cursor: pointer;" onclick=putNumberInBox(' + item.id + ')>';
                row += '<div class="row"><p style= "padding-right:5px">' + item.id + '</p><div class="w3-light-grey"><div class="w3-grey" style="height:18px;width:' + barSize + '%"></div></div></div><br>';
                row += '<p class=' + '"center"' + '>' + item.name + '</p>';
                row += '<p class=' + '"center"' + '>$<span id="' + item.id + 'cost">' + item.price.toFixed(2) + '</span></p>';
                row += '<p class=' + '"center"' + '>Quantity Left ' + item.quantity + '</p>';
                row += '</div>';

                $('#holds-items').append(row);
            });
        },
        error: function () {
        }
    });
}

function addMoney(money) {
    var deposited = parseFloat(document.getElementById("deposited").textContent, 10);
    newAmount = (deposited + money / 100);
    $('#deposited').empty();
    document.getElementById("deposited").innerHTML = newAmount.toFixed(2);
}

function putNumberInBox(itemId) {
    document.getElementById("item-choice").innerHTML = itemId;
}

function nextTransaction() {
    $('#makePurchase').show();
    $('#nextTransaction').hide();
    document.getElementById("change").innerHTML = "";
    document.getElementById("messages").innerHTML = "";
}

function makePurchase() {
    var spanName = document.getElementById("item-choice").textContent + 'cost';
    if (spanName === "cost") {
        document.getElementById("messages").innerHTML = "Please Select Item";
        setTimeout(clearMessages, 3000);        
        return;
    }
    var itemCost = document.getElementById(spanName).textContent;
    var deposited = document.getElementById("deposited").textContent;

    if (itemCost > deposited) {
        document.getElementById("messages").innerHTML = "Please Deposit: " + (itemCost - deposited).toFixed(2);
    } else {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:62785/money/' + document.getElementById("deposited").textContent + '/item/' + document.getElementById("item-choice").textContent,
            success: function (status) {
                document.getElementById("messages").innerHTML = "Thank You!!!";
                if (status.quarters > 0) {
                    if (status.quarters > 1) {
                        document.getElementById("change").append(status.quarters + " Quarters  ");
                    } else {
                        document.getElementById("change").append(status.quarters + " Quarter  ");
                    }
                }
                if (status.dimes > 0) {
                    if (status.dimes > 1) {
                        document.getElementById("change").append(status.dimes + " Dimes  ");
                    } else {
                        document.getElementById("change").append(status.dimes + " Dime  ");
                    }
                }
                if (status.nickels > 0) {
                    document.getElementById("change").append(status.nickels + " Nickel  ");
                }
                if (status.pennies > 0) {
                    if (status.pennies > 1) {
                        document.getElementById("change").append(status.pennies + " Pennies  ");
                    } else {
                        document.getElementById("change").append(status.pennies + " Penny  ");
                    }
                }
                var boxId = "#box"+ String(document.getElementById("item-choice").textContent);
                $(boxId).empty();
                $(boxId).append('<div id="loader"></div>'); 
                setTimeout(emptyAll, 3000);                
            },
            error: function (xhr, status, error) {
                document.getElementById("messages").innerHTML = JSON.parse(xhr.responseText).message;
                setTimeout(clearMessages, 3000);
            }
        });
    }
}

function emptyAll() {     
    document.getElementById('item-choice').innerHTML = "";
    document.getElementById("deposited").innerHTML = 0.00;
    $('#messages').empty();
    $('#change').empty(); 
    loadItems();    
}

function returnChange() {
    var deposited = document.getElementById("deposited").textContent;
    var quarters = Math.floor(deposited / 0.25);
    deposited = (deposited - (0.25 * quarters)).toFixed(2);
    var dimes = Math.floor(deposited / 0.10);
    deposited = (deposited - (0.10 * dimes)).toFixed(2);
    var nickels = Math.floor(deposited / 0.05);
    var pennies = deposited - (0.05 * nickels);
    
    if (quarters > 0) {
        if (quarters > 1) {
            document.getElementById("change").append(quarters + " Quarters  ");
        } else {
            document.getElementById("change").append(quarters + " Quarter  ");
        }
    }
    if (dimes > 0) {
        if (dimes > 1) {
            document.getElementById("change").append(dimes + " Dimes  ");
        } else {
            document.getElementById("change").append(dimes + " Dime  ");
        }
    }
    if (nickels > 0) {
        document.getElementById("change").append(nickels + " Nickel  ");
    }
    if (pennies > 0) {
        if (pennies > 1) {
            document.getElementById("change").append(pennies + " Pennies  ");
        } else {
            document.getElementById("change").append(pennies + " Penny  ");
        }
    }
    document.getElementById("deposited").innerHTML = 0.00;
    setTimeout(clearChange, 3000);
}

function clearChange() {
    $('#change').empty();     
}

function clearMessages() {
    $('#messages').empty();     
    
}

