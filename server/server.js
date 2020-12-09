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
    var resultNum = 0 ;
    var GameJudge = false ;
    var order = [-1,-1,-1,-1] ;
    var rdy = [0,0,0,0] ;
    var wildCard = false;
    var CanMove = [1 , 1 , 1 , 1] ;
    ws.on('message' , message =>
    {
        console.log(message) ;
        if(message == "ready")
        {
            var rdygo = 0;
            rdy[rdygo] = 1 ;
            if(rdy[3]==1)
            {
                server.clients.forEach(server =>
                    {
                        client.send("readygo") ;
                        //readygoをもらった一人のプレイヤーがorderを投げる



                    });
                rdy = [0,0,0,0] ;
            }
            else
            rdygo++ ;
        }

        if(message == "GameSet")
        {
            server.clients.forEach(client =>
                {
                    client.send(resultNum + "resultcheck") ;
                });
        }

        if(~message.indexOf("result"))
        {
            var result = "" ;
            result = message.substr(6) //result35

            server.clients.forEach(client =>
                {
                    client.send(resultNum + result) ;
                    resultNum++ ;
                    client.send("resultcheck" + resultNum);
                });
        }

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
                    client.send("order"+order[0]+order[1]+order[2]+order[3]) ;
                    while(CanMove[order[turnNumber]] == -1)
                    {
                        turnNumber++ ;
                        if(turnNumber > 4) 
                        {
                            GameJudge = true ;
                            client.send("GameSet") ;
                            break ;
                        }
                    }
                    if(GameJudge != true)
                    client.send("Start," + order[turnNumber] ) ;
                    
                });
        }

        if(message == "wildC")
        {
            //ワイルドカードの挙動を書く
            wildCard = true ;
        }

        if(message == "cantMove")
        {
            CanMove[order[turnNumber]] = -1 ;
            turnNumber++ ;

            server.clients.forEach(client =>
                {
                    if(turnNumber < 4 )
                    {
                        client.send("Start," + order[turnNumber]) ;
                    }
                    else
                    {
                        client.send("turnAround") ;
                        turnNumber = 0 ;
                    }
                })
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
            else if(~message.indexOf("timeover"))
            {
                Destination = "None" ;
            }

            if(~message.indexOf("Stop"))
            {
                CanMove[order[turnNumber]] = -1 ;
            }

            server.clients.forEach(client =>
                {
                    if(wildCard)
                    {
                        client.send(  Destination +','+ order[turnNumber]) ;
                        wildCard = false ;
                    }
                    else
                    {
                        client.send( Destination + "," + order[turnNumber]) ;
                        turnNumber++ ;
                    }
                    if(turnNumber < 4)
                        client.send("Start," + order[turnNumber]) ;
                    else
                    {
                        client.send("turnAround") ;
                        turnNumber = 0 ;

                    }
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

