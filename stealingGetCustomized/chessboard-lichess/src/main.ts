import { Chessground } from 'chessground';

const palco = document.createElement("div")
palco.classList.add("blue")
palco.classList.add("merida")


fetch("http://localhost:5280/lichess").then(e => e.json()).then( data =>{
    console.log(data)
    const board = document.createElement("div")

    palco.classList.add("palco")

    const blackPlayer = document.createElement("div")
    blackPlayer.classList.add("blackPlayer")
    blackPlayer.innerHTML = data.study.chapter.tags[4][1]

    palco.appendChild(blackPlayer)
    palco.append(board)

    const whitePlayer = document.createElement("div")
    whitePlayer.classList.add("whitePlayer")
    whitePlayer.innerHTML = data.study.chapter.tags[0][1]

    palco.appendChild(whitePlayer)
    document.body.append(palco);

    const actualFen = data.study.chapters.find(e => e.id == data.study.chapter.id).fen

    Chessground(board, {
        fen: actualFen,
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

