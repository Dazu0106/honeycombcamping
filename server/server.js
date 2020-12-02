// WebSocketのサーバの生成
//let ws = require('ws')
//var server = new ws.Server({port:5001});
const WebSocketServer = require('ws').Server;
const server = new WebSocketServer({
  port: 8080
});

// 接続時に呼ばれる
server.on('connection', ws => {
    /*
    let order = [0 , 1, 2 ,3] ;
    var random = Math.floor(Math.random() * order.length) ;

    console.log(order[random]) ;
    */

    let turnNumber = 0;
    var order = [-1,-1,-1,-1] ;
    ws.on('message' , message =>
    {
        if(message == "order")
        {
            turnNumber = 0 ;
            var arr = [0,1,2,3] ;
            var len = arr.length;

            while(len)
            {
                var j = Math.floor(Math.random() * len) ;
                var t = arr[--len] ;
                arr[len] = arr[j] ;
                arr[j] = t ;
            }

            
        
            for(let i = 0 ; i < 4 ; i++)
            {
                order[i] = arr[i] ;
            }

            server.clients.forEach(client => 
                {
                    for(let i = 0 ; i < 4 ; i++)
                    {
                        client.send(order[i])
                    }
                });
        }

        if(message == "wildC")
        {
            //ワイルドカードの挙動を書く
            server.clients.forEach(client=>
                {
                    client.send(order[turnNumber] + ",Start") ;
                });
        }


        var pattern = "TurnEnd" ;
        var Destination = 'minus1' ;
        if(!message.indexOf(pattern))
        {
            if(~message.indexOf("Rfront"))
            {
                Destination = "Rfront" ;
            }
            else if(~message.indexOf("Right"))
            {
                Destination = "Right" ;
            }
            else if(~message.indexOf("Rback"))
            {
                Destination = "Rback" ;
            }
            else if(~message.indexOf("Lback"))
            {
                Destination = "Lback" ;
            }
            else if(~message.indexOf("Left"))
            {
                Destination = "Left" ;
            }
            else if(~message.indexOf("Lfront"))
            {
                Destination = "Lfront" ;
            }


            server.clients.forEach(client =>
                {
                    client.send(order[turnNumber] +','+ Destination) ;
                    turnNumber++ ;
                    if(turnNumber < 4)
                    client.send(order[turnNumber] + ",Start") ;
                    else
                    turnNumber = 0 ;
                }) ;
        }
    });


    // クライアントからのデータ受信時に呼ばれる
    /*
    ws.on('message', message => {
        console.log(message);

        // クライアントにデータを返信
        server.clients.forEach(client => {
            client.send(message);
        });
    });
    */

    // 切断時に呼ばれる
    ws.on('close', () => {
        console.log('close');
    });
});






server.clients.forEach(client =>
    {
        client.send(order[turnNumber] + ",End") ;
        turnNumber++ ;
        if(turnNumber < 4)
        client.send(order[turnNumber] + ",Start") ;
        else
        turnNumber = 0 ;
    }) ;