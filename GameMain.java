
public class GameMain {

    public static void main(String[] args) {
        new GameMain().mainloop();
    }
    
    public void mainloop() {
        GameBoard gameboard = new GameBoard();
        Player mainPlayer = new Player(Player.Kind.ONE);
        Player cpuPlayer = new Player(Player.Kind.CPU);
       
        IPlay[] players = { mainPlayer, cpuPlayer };
        Judge judgeman = new Judge(gameboard, players);

        gameboard.startgame();
        boolean sente = true; 
        while (gameboard.isDraw() == false && 
               gameboard.hasAlreadyWin(players)  == false) {

               if (sente) {
                   mainPlayer.play(gameboard);
               } else {
                   cpuPlayer.play(gameboard);
               }
               sente = !sente;
               
        }
        judgeman.judge();
        gameboard.endgame();
    }
}
