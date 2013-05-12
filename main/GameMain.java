package main;

import static java.lang.System.out;
import java.util.Scanner;
import java.util.Random;

public class GameMain {

    private Jadge j;
    private Random r;

    private GameMain() {
        j = new Jadge();
        r = new Random();
    }

    public static void main(String[] args) {
        new GameMain().mainloop();
    }

    private String inputYourName() {
    
        String result = "";
        Scanner scan = new Scanner(System.in);
        
        out.print("プレイヤーの名前を入れてください。= ");
        result = scan.next();
            
        if (result.length() != 0) {
            return "名無しのごんべさん";
        }
        scan = null;
        out.println();

        return result;
    }

    private boolean inputYourSente() {
    
        boolean result = false;
        Scanner scan = new Scanner(System.in);
        out.print("先手、後手を決めてください。[0:先手,入力エラーも先手になります]= ");
        try {
            int input = scan.nextInt();

            if (input == 0) {
                result = true;
            } else {
                result = false;
            }

        } catch (Exception e) {
            out.println("入力エラーですので、先手にします。");
            result = true;
        } finally {
            scan = null;
        }
        out.println();

        return result;
    }


    private void mainloop() {
        title();
        out.println("");
        String username = inputYourName();
        boolean sente = inputYourSente();

        Player[]  players = {new Player(username, sente), new Player("CPU", !sente) };

        information();

        while(true) {

            for(Player p : players) {
                play(p);

                if (j.isGameEnd(p)){
                    gameend(p);
                    break;
                }
            }
        }
        
    }
    private void play(Player p) {
        if (p.getName() == "CPU") {
            randomSet(p);
        } else {
            inputSelectNumber(p);
        }
    }

    private void inputSelectNumber(Player p) {
        // プレイヤーに判断させる
    }

    private void randomSet(Player cpu) {
        int ran = r.nextInt(10);
        Field.setCellFromNumberInputNum(ran, cpu.getHand());
    }

    private void gameend(Player p) {
        switch(p.getWin()) {
            case 1:
                out.println(p.getName() + "の勝利です。");
                break;
            case 2:
                out.println("引き分けになりました。");
                break;
        }
        
        out.println("■■■ゲーム終了します。お疲れ様でした。■■■");
    }

    public void information() {
        out.println("┌─┬─┬─┐");
        out.println("│１│２│３│");
        out.println("├─┼─┼─┤");
        out.println("│４│５│６│");
        out.println("├─┼─┼─┤");
        out.println("│７│８│９│");
        out.println("└─┴─┴─┘");
    }


    public void title() {
        out.println("■■■tic tac toe game!■■■");
    }
}
