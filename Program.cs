using System;
class Program
{
     static void Main(string[] args)
    {
        bool exit = false,exitname = false,exitbranch = false;
        int level = -1,countbranch = 0,count = 0,group = -1;
        Stack<string> sname = new Stack<string>();
        Stack<int> sbranch = new Stack<int>();
        Stack<int> slevel = new Stack<int>();
        Tree<string> tree = new Tree<string>();
        while(true)
        {
            string name = Console.ReadLine();
            int branch = int.Parse(Console.ReadLine());
            if(branch > 0)
            {
                tree.AddChild(level,name);
                slevel.Push(level);
                level++;
                group++;
                countbranch += branch;
                sbranch.Push(branch);
                if(tree.GetLength() > 1)
                {
                    countbranch--;
                }
            }
            else
            {
                if(count+1 < sbranch.Get(sbranch.GetLength()-1))
                {
                    tree.AddChild(level,name);
                    slevel.Push(level);
                    count++;
                    countbranch--;
                }
                else
                {
                    tree.AddChild(level,name);
                    slevel.Push(level);
                    sbranch.Pop();
                    count = 0;
                    level--;
                    countbranch--;
                    group++;
                }
            }
            if(countbranch == 0)
            {
                break;
            }
            int c = 0;
        c++;
        }
        for(int i=0; i<tree.GetLength(); i++)
        {
            sname.Push(tree.Get(i));
            Console.WriteLine(slevel.Get(i));
        }
        string vacator = Console.ReadLine();
        int compare = 0,j = 0;
        for(int i = 0; i<tree.GetLength(); i++)
        {
            if(vacator == tree.Get(j))
            {
                level = slevel.Get(j);
            }
            else
            {
                sname.Pop();
                j++;
            }
        }
        Console.WriteLine(sname.Pop());
    }
}