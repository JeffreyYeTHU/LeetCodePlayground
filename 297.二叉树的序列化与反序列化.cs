using System.Linq;
/*
 * @lc app=leetcode.cn id=297 lang=csharp
 *
 * [297] 二叉树的序列化与反序列化
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        SeriHelper(root);
        return res;
    }

    string res = "";
    void SeriHelper(TreeNode root)
    {
        if(root == null){
            res += "#,";
            return;
        }

        res += root.val + ",";
        SeriHelper(root.left);
        SeriHelper(root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] dataArr = data.Split(",");
        var dataList = new List<string>(dataArr);
        return DeseriHelper(dataList);
    }

    TreeNode DeseriHelper(List<string> dataList){
        if(dataList[0] == "#"){
            dataList.RemoveAt(0);
            return null;
        }
        // Console.WriteLine($"dataList[0 = {dataList[0]}");
        var root = new TreeNode(int.Parse(dataList[0]));
        dataList.RemoveAt(0);
        root.left = DeseriHelper(dataList);
        root.right = DeseriHelper(dataList);
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
// @lc code=end

