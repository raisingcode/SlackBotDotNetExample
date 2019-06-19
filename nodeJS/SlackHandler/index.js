
module.exports = async function (context, req) {
   const request = require('request');


    context.log('JavaScript HTTP trigger function processed a request.');

    if (req.body && req.body.event)
    {
        var event = req.body.event;
        var usr = "<@" + event.user + ">";
        var chan = event.channel || 'CGHUBADE2';
        var txt = "OK Data";
	var bearToken = ''; //note you must provide a valid token your bot won't be able to reply to messages

        if(event.type && event.type === "app_mention")
         {
            var message = {
                        channel: chan,
                        text: txt
                        };
            var url = "https://slack.com/api/chat.postMessage";
                    
            request(
                {
                    uri: 'https://slack.com/api/chat.postMessage',
                    method: 'POST',
                    headers: {'Authorization': 'Bearer ' + bearToken},
                    json: true,
                    body: message            

                    },
                    function(error, response, body)
                    {            
                        if (error || response.statusCode !== 200) {
                        var output = (error || {statusCode: response.statusCode});
                        context.log(output);
                        }
            
                });
         }
    }
    else if (req.body && request.body.challenge) 
    {
        var message = req.body.challenge;
        context.log(message);

        context.res = {
                 body: message
        };
    }
    
    else 
    {
           context.res = {
                            status: 400,
                            body: "Please pass a Challenge on the query string or in the request Challenge"
                         };
    }
};