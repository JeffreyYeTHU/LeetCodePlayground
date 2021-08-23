using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Codec ser = new Codec();
            Codec deser = new Codec();
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            TreeNode ans = deser.deserialize(ser.serialize(root));
            
        }
    }

    public class Codec 
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root) {
            SeriHelper(root);
            Console.WriteLine(res);
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
            var root = new TreeNode(int.Parse(dataList[0]));
            dataList.RemoveAt(0);
            root.left = DeseriHelper(dataList);
            root.right = DeseriHelper(dataList);
            return root;
        }
    }
}
