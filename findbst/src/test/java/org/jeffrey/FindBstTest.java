package org.jeffrey;

import org.junit.Test;

import java.util.LinkedList;
import java.util.List;

import static org.junit.Assert.*;

public class FindBstTest {

    @Test
    public void generateTrees() {
        List<TreeNode> expected = new LinkedList<>();
        expected.add(new TreeNode(1));
        List<TreeNode> actual = FindBst.generateTrees(1);
        assertEquals(expected, actual);
    }
}