package leetcode;

import static org.junit.Assert.*;
import org.junit.Test;

public class GraphTest {

    @Test
    public void insideHasOs() {
        char[][] original = new char[][] { { 'O', 'X', 'X', 'O', 'X' }, { 'X', 'O', 'O', 'X', 'O' },
                { 'X', 'O', 'X', 'O', 'X' }, { 'O', 'X', 'O', 'O', 'O' }, { 'X', 'X', 'O', 'X', 'O' } };
        char[][] expected = new char[][] { { 'O', 'X', 'X', 'O', 'X' }, { 'X', 'X', 'X', 'X', 'O' },
                { 'X', 'X', 'X', 'O', 'X' }, { 'O', 'X', 'O', 'O', 'O' }, { 'X', 'X', 'O', 'X', 'O' } };
        char[][] actual = new Graph().solve(original);
        for (int i = 0; i < original.length; i++) {
            assertArrayEquals(expected[i], actual[i]);
        }
    }
}