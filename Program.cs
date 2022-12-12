using System;
class Program
{
     static void Main(string[] args)
    {
        bool exit = false,exitname = false,exitbranch = false;
        int level = -1,countbranch = 0,count = 0,group = 0;
        Stack<string> sname = new Stack<string>();
        Stack<int> sbranch = new Stack<int>();
        Stack<string> aname = new Stack<string>();
        Tree<int> slevel = new Tree<int>();
        Tree<string> tree = new Tree<string>();
        while(true)
        {
            string name = Console.ReadLine();
            int branch = int.Parse(Console.ReadLine());
            if(branch > 0)
            {
                tree.AddChild(level,name);
                slevel.AddChild(level,level);
                level++;
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
                    slevel.AddChild(level,level);
                    count++;
                    countbranch--;
                }
                else
                {
                    tree.AddChild(level,name);
                    slevel.AddChild(level,level);
                    sbranch.Pop();
                    count = 0;
                    level--;
                    countbranch--;
                }
            }
            
            if(countbranch == 0)
            {
                break;
            }
        }
        string vacator = Console.ReadLine();
        int compare = 0,tail = 0;
        for(int i=0; i<tree.GetLength(); i++)
        {
            if(vacator == tree.Get(i))
            {
                tail = i; // tail bass = 2
                compare = slevel.Get(i); // 1
            }
        }
        while(compare > -1)
        {
            for(int i=tail; i>=0 && compare > -1; i--)
            {
                if(slevel.Get(i) < compare)
                {
                    sname.Push(tree.Get(i));
                    tail = i;
                    compare--;
                    break;
                }
            }
        }
        for(int i=0; i<sname.GetLength(); i++)
        {
            aname.Push(sname.Get(i));
        }
        for(int i=0; i<sname.GetLength(); i++)
        {
            Console.WriteLine(aname.Get(i));
        }
    }
}