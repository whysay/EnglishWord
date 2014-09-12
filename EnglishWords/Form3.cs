using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EnglishWords
{
    public partial class Form3 : Form
    {
        WordFileControl WFC;
        public Form3(WordFileControl inWFC)
        {
            InitializeComponent();

            WFC = inWFC;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            TreeNode CurMainNode = this.treeView1.TopNode;
            for (int i = 0; i < WFC.GetItemCount(); ++i)
            {
                string str = (string)WFC.WordsSL.GetByIndex(i);
                if (str.StartsWith("["))
                {
                    CurMainNode = this.treeView1.Nodes.Add(str);
                    continue;
                }

                if (str.StartsWith("*"))
                {
                    str = str.Remove(0, 1);
                    CurMainNode.Nodes.Add(str).Checked = true;
                }
                else
                    CurMainNode.Nodes.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(WFC.filename, FileMode.Create, FileAccess.Write);
            StreamWriter r = new StreamWriter(file, System.Text.Encoding.Default);
            WFC.IndexAL.Clear();
            int nRand = 0, nIndex = 0;
            TreeNode tmpMainNode = this.treeView1.Nodes[0];
            while (tmpMainNode != null)
            {
                r.WriteLine(tmpMainNode.Text);
                if (0 < tmpMainNode.GetNodeCount(true))
                {
                    TreeNode tmpSubNode = tmpMainNode.FirstNode;
                    nIndex++;
                    while (tmpSubNode != null)
                    {
                        if (tmpSubNode.Checked == true)
                        {
                            if (WFC.IndexAL.Count != 0)
                            {
                                nRand = WFC.rand.Next();
                                if (nRand < 0)
                                    nRand *= -1;
                                nRand %= WFC.IndexAL.Count;
                            }

                            WFC.IndexAL.Insert(nRand, nIndex);
                            r.Write('*');
                        }

                        if (tmpSubNode.Text.StartsWith("*"))
                            tmpSubNode.Text = tmpSubNode.Text.Remove(0, 1);
                        r.WriteLine(tmpSubNode.Text);
                        tmpSubNode = tmpSubNode.NextNode;
                        nIndex++;
                    }
                }
                tmpMainNode = tmpMainNode.NextNode;
            }

            r.Flush();
            WFC.nCurIndex = 0;
            this.Hide();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 함수 내의 수정에 의해 일어나는 이벤트는 pass~
            if (e.Action == TreeViewAction.Unknown)
                return;

            // 하위 항목 전체 같도록..
            TreeNode tmpSubNode = e.Node.FirstNode;
            while (tmpSubNode != null)
            {
                if (tmpSubNode.Checked != e.Node.Checked)
                    tmpSubNode.Checked = e.Node.Checked;
                tmpSubNode = tmpSubNode.NextNode;
            }

            // check됐는데 상위 항목이 check안되있으면 체크
            if (e.Node.Checked == true && e.Node.Parent != null)
            {
                if (e.Node.Parent.Checked == false)
                    e.Node.Parent.Checked = true;
            }

            // check 풀렸을때, 상위항목 있으면
            if (e.Node.Checked == false && e.Node.Parent != null)
            {
                if (e.Node.Parent.Checked == true)
                {
                    // 하위 항목이 모두 체크 풀렸으면 상위 항목도 풀어줌.
                    bool bAllNonChecked = true;
                    TreeNode tmpSubNode2 = e.Node.Parent.FirstNode;
                    while (tmpSubNode2 != null)
                    {
                        if (tmpSubNode2.Checked == true)
                        {
                            bAllNonChecked = false;
                            break;
                        }

                        tmpSubNode2 = tmpSubNode2.NextNode;
                    }

                    if (bAllNonChecked)
                        e.Node.Parent.Checked = false;
                }
            }

        }//private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    }
}
