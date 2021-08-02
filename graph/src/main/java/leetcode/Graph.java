package leetcode;

import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;

public class Graph {

    public List<List<Integer>> allPathsSourceTarget(int[][] graph) {
        LinkedList<Integer> path = new LinkedList<>();
        traverse(graph, 0, path);
        return res;
    }

    List<List<Integer>> res = new LinkedList<>();

    private void traverse(int[][] graph, int s, LinkedList<Integer> path) {
        path.addLast(s);

        int n = graph.length;
        if (s == n - 1) {
            res.add(new LinkedList<>(path));
            return;
        }

        for (int neighbor : graph[s]) {
            traverse(graph, neighbor, path);
        }

        path.removeLast();
    }

    private final char IDF = '#';

    public char[][] solve(char[][] board) {
        int rowCnt = board.length;
        int colCnt = board[0].length;

        // mark the one can be reach using '#'
        // start from first/last col
        for (int i = 0; i < rowCnt; i++) {
            mark(board, i, 0);
            mark(board, i, colCnt - 1);
        }
        // start from first/last row
        for (int j = 0; j < colCnt; j++) {
            mark(board, 0, j);
            mark(board, rowCnt - 1, j);
        }

        for (int i = 0; i < rowCnt; i++) {
            System.out.printf(Arrays.toString(board[i]));
            System.out.printf("\n");
        }

        // flip remain 'O' to X;
        // and flip '#' to 'O'
        for (int i = 0; i < rowCnt; i++) {
            for (int j = 0; j < colCnt; j++) {
                if (board[i][j] == 'O')
                    board[i][j] = 'X';
                if (board[i][j] == IDF)
                    board[i][j] = 'O';
            }
        }

        return board;
    }

    private void mark(char[][] board, int row, int col) {
        if (row < 0 || row >= board.length || col < 0 || col >= board[0].length || board[row][col] == IDF
                || board[row][col] == 'X') {
            return;
        }

        board[row][col] = IDF;
        mark(board, row - 1, col);
        mark(board, row + 1, col);
        mark(board, row, col - 1);
        mark(board, row, col + 1);
    }
}
