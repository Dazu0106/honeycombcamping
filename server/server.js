// WebSocketのサーバの生成
//let ws = require('ws')
//var server = new ws.Server({port:8080});
const WebSocketServer = require('ws').Server;
const server = new WebSocketServer({
  port: 8080
});

//サーバーが持ってる変数の初期値
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

//メッセージ受信時に呼ばれる
    ws.on('message' , message =>
    {
        console.log(message) ;
        //4人の準備完了を待機

        if(message == "GameRestart")
        {
            turnNumber = 0 ;
            rdygo =  0 ;
            order = [-1,-2,-3,-4] ;
            CanMove = [1 , 1 , 1 , 1] ;
            rdy = [0 , 0 , 0, 0] ;
            wildCard = false;
            GameJudge = false ;
            resultNum = 0 ;

            server.clients.forEach(client =>
                {
                    client.send("GameRestart") ;
                });

            /*
            server.clients.forEach(client =>
                {
                    client.send("readygo") ;
                    //readygoをもらった一人のプレイヤーがorderを投げる
                });
            */

        }

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
        //プレイヤー1~3までのリザルトチェック
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

        //ゲーム開始時の順番決め
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

        //ワイルドカード使用
        if(message == "wildC")
        {
            //ワイルドカードの挙動を書く
            wildCard = true ;
        }

        //ターンの始めの移動不可判定
        if(message == "cantMove")
        {
            CanMove[order[turnNumber]] = -1 ;
            turnNumber++ ;

            for(var i = 0 ; i < 4 ; i++)
            {
                console.log(CanMove[i]) ;
            }

            while(CanMove[order[turnNumber]] == -1)
            {
                turnNumber++ ;
            }
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

                    //ここでturnAroundしてるのはorderの中にゲームセット判定があるから
        }


        //プレイヤーの移動先のメッセージ
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
                Destination = "None" ;  //時間切れ(移動なし)
            }


            //移動した後の移動不可判定
            if(~message.indexOf("Stop"))
            {
                CanMove[order[turnNumber]] = -1 ;
            }
                    if(wildCard == true)    //ワイルドカード使ってたらもう一回
                    {
                        server.clients.forEach(client =>{
                            client.send(  Destination +','+ order[turnNumber]) ;    //移動先+プレイヤーの番号
                        });
                        wildCard = false ;
                    }
                    else    //使ってないなら次の人
                    {
                        server.clients.forEach(client =>{
                            client.send( Destination + "," + order[turnNumber]) ;
                        }) ;
                        turnNumber++ ;
                    }

                    while(CanMove[order[turnNumber]] == -1)
                    {
                        turnNumber++ ;
                    }


                    if(turnNumber < 4)  //ターンが一周してないとき

                        server.clients.forEach(client =>{
                            client.send("Start," + order[turnNumber]) ;
                        });
                    else    //ターンが一周したらturnAroundでorderを送ってもらう
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

