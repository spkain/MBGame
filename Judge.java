
public class Judge { 
 
    private GameBoard gameboard;
    private IPlay[] players;
    
    public Judge(GameBoard gameboard, IPlay[] players) {
        this.gameboard = gameboard;
        this.players = players;
        
        for (IPlay p : players) {
            p.info();
        }
    }

    public void judge() {
        if (gameboard.isDraw()) {
            System.out.println("draw game.");
            return;
        }
        
        for (IPlay p : players) {
            if (winjudge(p)) {
                p.winInfo();
            }
        }
    }
    
    public boolean winjudge(IPlay p) {
        return gameboard.isLineOK(p);
    }
}
