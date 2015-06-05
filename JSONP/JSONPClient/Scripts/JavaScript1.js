jQuery(function ($)
{
    //$('#dvOutput').text('HELLO WORLD!');

    $("#btGetJson").click(function ()
    {
        $.ajax({
            type: 'GET',
            url: "http://localhost:57140/JSONP/GetJSON",
            dataType: 'jsonp',
            success: callbackFunc
        })
    });

    function callbackFunc(json)
    {
        alert(json);
    }
});