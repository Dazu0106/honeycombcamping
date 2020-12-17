// WebSocketのサーバの生成
//let ws = require('ws')
//var server = new ws.Server({port:5001});
const WebSocketServer = require('ws').Server;
const server = new WebSocketServer({
  port: 8080
});


let turnNumber = 0;
var resultNum = 0 ;
var GameJudge = false ;
var order = [-1,-2,-3,-4] ;
var rdy = [0,0,0,0] ;
var wildCard = false;
var CanMove = [1 , 1 , 1 , 1] ;
var rdygo = 0;


// 接続時に呼ばれる
server.on('connection', ws => {
    /*
    let order = [0 , 1, 2 ,3] ;
    var random = Math.floor(Math.random() * order.length) ;

    console.log(order[random]) ;
    */


    ws.on('message' , message =>
    {
        console.log(message) ;
        //4人の準備完了を待機
        if(message == "ready")
        {
            rdy[rdygo] = 1 ;


            if(rdy[3]==1)
            {
                server.clients.forEach(client =>
                    {
                        client.send("readygo") ;
                        //readygoをもらった一人のプレイヤーがorderを投げる



                    });
                //rdy = [0,0,0,0] ;
                //rdygo = 0 ;
            }
            else
            rdygo++ ;
        }

        //ゲームセットを送り返してもらってゲーム終了のメッセージ
        //プレイヤー0のリザルトチェック

        if(message == "GameSet")
        {
            server.clients.forEach(client =>
                {
                    client.send("GameSet") ;
                });
        }
        /*
        {
        
            server.clients.forEach(client =>
                {
                    client.send("resultcheck" + resultNum ) ;
                });
        }

        if(~message.indexOf("result"))
        {
            var result = "" ;
            result = message.substr(6) //result35


            if(resultNum < 4)
            {
            server.clients.forEach(client =>
                {
                    client.send(resultNum + result) ;
                });
                    resultNum++ ;
            server.clients.forEach(client =>{
                    client.send("resultcheck" + resultNum);
                });
            }
        }
        */

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
                });
                    while(CanMove[order[turnNumber]] == -1)
                    {
                        turnNumber++ ;
                        if(turnNumber == 4) 
                        {
                            GameJudge = true ;
                            server.clients.forEach(client =>{
                                client.send("GameSet") ;
                            }) ;
                            break ;
                        }
                    }
                    if(GameJudge != true)
                    server.clients.forEach(client =>{
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
                    if(turnNumber < 4 )
                    {
                        server.clients.forEach(client =>{
                            client.send("Start," + order[turnNumber]) ;
                        });
                    }
                    else
                    {
                        server.clients.forEach(client =>{
                            client.send("turnAround") ;
                        });
                        turnNumber = 0 ;
                    }
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
                    if(wildCard == true)
                    {
                        server.clients.forEach(client =>{
                            client.send(  Destination +','+ order[turnNumber]) ;
                        });
                        wildCard = false ;
                    }
                    else
                    {
                        server.clients.forEach(client =>{
                            client.send( Destination + "," + order[turnNumber]) ;
                        }) ;
                        turnNumber++ ;
                    }
                    if(turnNumber < 4)
                        server.clients.forEach(client =>{
                            client.send("Start," + order[turnNumber]) ;
                        });
                    else
                    {
                        server.clients.forEach(client =>{
                            client.send("turnAround") ;
                        });
                        turnNumber = 0 ;

                    }
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

