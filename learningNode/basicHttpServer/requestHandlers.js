var querystring = require("querystring");

function start(response) {
    console.log("Request handler 'start' was called");
    var body = '<html><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8" /></head>'+
    '<body><form action="/upload" method="post">'+
    '<textarea name="text" rows="20" cols="60"></textarea>' +
    '<input type="submit" value="Submit text" />' +
    '</form></body></html>';

    response.writeHead(200, {"Content-Type": "text/html"});
    response.write(body);
    response.end();
}

function upload(response, postData) {
    console.log("Request handler 'upload' was called");
    response.writeHead(200, {"Content-Type": "text/plain"});
    response.write("You sent: " + querystring.parse(postData).text);
    response.end();
}

//Not sure how I got postData here... want params

function days(response, postData) {
    console.log("Request for 'days' was made");
    response.writeHead(200, {"Content-Type": "application/json"});

    console.log(querystring.parse(postData).text);
    var blah =  {
        "userId": 1,
        "id": 1,
        "title": "delectus aut autem",
        "completed": false
      };
    response.write(JSON.stringify(blah));
       
    response.end();
}

exports.start = start;
exports.upload = upload;
exports.days = days;