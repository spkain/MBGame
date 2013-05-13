
public class GameBoard {
    
    private int[][] field = { 
        {0, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };
    
    public boolean isLineOK(IPlay p) {
       
        // | 
        for (int x = 0; x < 3; ++x) {
            if (field[0][x] == p.getHand() &&
                field[1][x] == p.getHand() &&
                field[2][x] == p.getHand() ){
                return true;
            }
        } 

        // -
        for (int y = 0; y < 3; ++y) {
            if (field[y][0] == p.getHand() &&
                field[y][1] == p.getHand() &&
                field[y][2] == p.getHand() ){
                return true;
            }
        } 
       
        if (field[0][0] == p.getHand() &&
            field[1][1] == p.getHand() &&
            field[2][2] == p.getHand() ) {
            return true;
        }
        
        if (field[0][2] == p.getHand() &&
            field[1][1] == p.getHand() && 
            field[2][0] == p.getHand() ) {
            return true;
        }
        return false; 
    }
    
    public boolean isPutArea(int areaNo) {
        System.out.println("area no: " + areaNo + " put, ok?");
        switch(areaNo) {
            case 1:
                  if (field[0][0] != 0) {
                      return false;
                  }
                  return true;
            case 2:
                  if (field[0][1] != 0) { 
                      return false;
                  }
                  return true;
            case 3:
                  if (field[0][2] != 0) { 
                      return false;
                  }
                  return true;
            case 4:
                  if (field[1][0] != 0) { 
                      return false;
                  }
                  return true;
            case 5:
                  if (field[1][1] != 0) { 
                      return false;
                  }
                  return true;
            case 6:
                  if (field[1][2] != 0) { 
                      return false;
                  }
                  return true;
            case 7:
                  if (field[2][0] != 0) {
                      return false;
                  }
                  return true;
            case 8:
                  if (field[2][1] != 0) {
                      return false;
                  }
                  return true;
            case 9:
                  if (field[2][2] != 0) {
                      return false;
                  }
                  return true;
        }
        return false;
    }
    
    public void putHand(IPlay p, int areaNo) {
        System.out.println("area no[" + areaNo + "] put.");
        switch(areaNo) {
            case 1:
                  field[0][0] = p.getHand();
                  break;
            case 2:
                  field[0][1] = p.getHand();
                  break;
            case 3:
                  field[0][2] = p.getHand();
                  break;
            case 4:
                  field[1][0] = p.getHand();
                  break;
            case 5:
                  field[1][1] = p.getHand();
                  break;
            case 6:
                  field[1][2] = p.getHand();
                  break;
            case 7:
                  field[2][0] = p.getHand();
                  break;
            case 8:
                  field[2][1] = p.getHand();
                  break;
            case 9:
                  field[2][2] = p.getHand();
                  break;
        }
    }
    public boolean hasAlreadyWin(IPlay[] players) {
        for (IPlay p: players) {
            if (p.isWin()) {
                return true;
            }
        }
        return false;
    }
    
    public void displayNowBoard() {
        System.out.println("--- now board ---");
        headLineDraw();
        for (int y = 0; y < 3; ++y) {
            for (int x = 0; x < 3; ++x) {
                print("|");
                print(s(field[y][x]));
            }
            p("|");
 
            if (y < 2) {
                middleLineDraw();
            }
            
        }
        fotterLineDraw();
    }

    private String s(int kindNum) {
        switch(kindNum) {
            case 0:
                return "  ";
            case 1:
                return " ○";
            case 2:
                return " ×";
        }
        return "  ";
    }

    public void displayInputRefference() {
        headLineDraw();
        p("| 1| 2| 3|");
        middleLineDraw();
        p("| 4| 5| 6|");
        middleLineDraw();
        p("| 7| 8| 9|");
        fotterLineDraw();
        
    }
    private void middleLineDraw() {
        p("|--|--|--|");
    }
    private void fotterLineDraw() {
        p("|__|__|__|");
    }
    private void headLineDraw() {
        p("__________");
        p("|  |  |  |");
    }

    public boolean isDraw() {
       for (int y = 0; y < 3; ++y) {
           for (int x = 0; x < 3; ++x) {
               if (field[y][x] == 0) {
                   return false;
               }    
           }
       } 
       return true;
    }
    
    public void startgame() {
        p("game start");
    } 
    public void endgame() {
        p("game end.");
    } 

    private void print(String str) {
        System.out.print(str);
    }

    private void p(String str) {
        System.out.println(str);
    }
}
