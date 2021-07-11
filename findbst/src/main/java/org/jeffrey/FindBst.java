package org.jeffrey;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class FindBst {
    public static List<TreeNode> generateTrees(int n) {
        // create a array to track if a value already in the tree
        boolean[] addedInBst = new boolean[n];
        for (int i = 0; i < n; i++) {
            addedInBst[i] = false;
        }

        // build the bst one by one
        List<TreeNode> result = new ArrayList<>();
        for (int i = 0; i < n; i++) {

        }

        return result;
    }
}
