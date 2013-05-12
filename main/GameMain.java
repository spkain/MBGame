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
        
        out.print("�v���C���[�̖��O�����Ă��������B= ");
        result = scan.next();
            
        if (result.length() != 0) {
            return "�������̂���ׂ���";
        }
        scan = null;
        out.println();

        return result;
    }

    private boolean inputYourSente() {
    
        boolean result = false;
        Scanner scan = new Scanner(System.in);
        out.print("���A�������߂Ă��������B[0:���,���̓G���[�����ɂȂ�܂�]= ");
        try {
            int input = scan.nextInt();

            if (input == 0) {
                result = true;
            } else {
                result = false;
            }

        } catch (Exception e) {
            out.println("���̓G���[�ł��̂ŁA���ɂ��܂��B");
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
        // �v���C���[�ɔ��f������
    }

    private void randomSet(Player cpu) {
        int ran = r.nextInt(10);
        Field.setCellFromNumberInputNum(ran, cpu.getHand());
    }

    private void gameend(Player p) {
        switch(p.getWin()) {
            case 1:
                out.println(p.getName() + "�̏����ł��B");
                break;
            case 2:
                out.println("���������ɂȂ�܂����B");
                break;
        }
        
        out.println("�������Q�[���I�����܂��B�����l�ł����B������");
    }

    public void information() {
        out.println("��������������");
        out.println("���P���Q���R��");
        out.println("��������������");
        out.println("���S���T���U��");
        out.println("��������������");
        out.println("���V���W���X��");
        out.println("��������������");
    }


    public void title() {
        out.println("������tic tac toe game!������");
    }
}
