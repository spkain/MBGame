import java.util.Scanner;
import java.util.Random;

public class Player implements IPlay {

    public static enum Kind {
        ONE,
        CPU
    }

    private String name;
    private boolean win;
    private int hand;
    
    public Player(Player.Kind kind) {
        switch(kind) {
            case ONE: 
                inputYourName();
                hand = 1;
                break;
            case CPU:
                setName("CPU");
                hand = 2;
                break;
        }
    } 

    private void setName(String name) {
        this.name = name;
    }
    public String getName() {
        return this.name;
    }
    public void setWin(boolean win) {
        this.win = win;
    }
    @Override
    public int getHand() {
        return this.hand;
    }
    
    private void inputYourName() {
        System.out.print("input your name: ");
        Scanner scan = new Scanner(System.in);
        try {
            setName(scan.next());
            
            if (name.length() == 0) {
                System.out.println("not input.");
                System.out.println("and your name is nothing");
                setName("nothing");
            }
        } catch (Exception e) {
            System.out.println("error. your name is nothing");
            setName("nothing");
        }
    }
    private void wait(int timemilliseconds) {
        try {
            Thread.sleep(timemilliseconds);
        } catch (InterruptedException e) {
        }
    }
    private void cpuplay(GameBoard gameboard) {
        wait(1000);
        Random rnd = new Random();
        int putAreaNo = rnd.nextInt(10);
        while (gameboard.isPutArea(putAreaNo) == false) {
           putAreaNo = rnd.nextInt(10); 
        }
        gameboard.putHand(this, putAreaNo);
        System.out.println("result: ");
        gameboard.displayNowBoard();
    }

    private void userplay(GameBoard gameboard) {
        int putAreaNo = 0;
        putAreaNo = inputYourPutAreaNo(gameboard);
        gameboard.putHand(this, putAreaNo);
        System.out.println("result: ");
        gameboard.displayNowBoard();
    }
    
    private int inputYourPutAreaNo(GameBoard gameboard) {
        int putAreaNoResult = 0;
        Scanner scan = new Scanner(System.in);

        while(true) {
           gameboard.displayNowBoard();
           gameboard.displayInputRefference();
           System.out.println();
           System.out.print("Input your put area no.[1-9]: ");
           try {
               putAreaNoResult = scan.nextInt();
               
               if (gameboard.isPutArea(putAreaNoResult)) {
                   System.out.println();
                   return putAreaNoResult;
               } else {
                  System.out.println();
                  System.out.println("already put no is: " + putAreaNoResult);
                  wait(1000);
                  continue;
               }
           }catch(Exception e) {
               System.out.println();
               continue;
           }
        }
    }

    @Override
    public void play(GameBoard gameboard) {
        if ("CPU".equals(name)) {
            System.out.println("cpu play");
            cpuplay(gameboard);
        } else {
            System.out.println("user play");
            userplay(gameboard);
        }
        if (gameboard.isLineOK(this)) {
            this.win = true;
        }
    }

    @Override
    public boolean isWin() {
        return win;
    }

    @Override
    public void info() {
        System.out.println("player name is " + getName());
    }

    @Override
    public void winInfo() {
        System.out.println("winner is " + getName());
    }

}
