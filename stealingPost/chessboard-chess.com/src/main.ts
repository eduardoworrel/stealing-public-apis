import { Chessground } from 'chessground';

const palco = document.createElement("div")
palco.classList.add("blue")
palco.classList.add("merida")


fetch("https://www.chess.com/events/v1/api/game/2024-gct-superbet-poland-rapid-blitz/17/Wei_Yi-Praggnanandhaa_R").then(e => e.json()).then( data =>{
    
    const board = document.createElement("div")

    palco.classList.add("palco")

    const blackPlayer = document.createElement("div")
    blackPlayer.classList.add("blackPlayer")
    blackPlayer.innerHTML = data.game.black.preferredName

    palco.appendChild(blackPlayer)
    palco.append(board)

    const whitePlayer = document.createElement("div")
    whitePlayer.classList.add("whitePlayer")
    whitePlayer.innerHTML = data.game.white.preferredName

    palco.appendChild(whitePlayer)

    document.body.append(palco);

    Chessground(board, {
        fen: data.game.currentFEN,
        viewOnly: true,
        animation: {
            duration: 1000
        },
        movable: {
            free: false,
        },
        drawable: {
            visible: false,
        }
    });
        
})        

