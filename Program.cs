using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magic
{
    internal class Program
    {
        public static void startmagic()
        {
            ArrayList poker = new ArrayList { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };//定义牌
            ArrayList magic = new ArrayList();//最后所取得的4张牌并且分开后的牌放入动态数组
            string[] temp = new string[4];//获取到的牌分开
            ArrayList temp2 = new ArrayList();
            ArrayList Where = new ArrayList();
            Random rnd = new Random();
            for (int i = 1; i <= 4; i++)
            {
                int Index = rnd.Next(poker.Count);
                string selectCard = (string)poker[Index];
                magic.Add(selectCard);
                poker.Remove(selectCard);//防止取到重复的牌，将取到的的牌从poker中删去
            }
            magic.CopyTo(temp, 0);
            for (int j = 0; j < temp.Length; j++)
            {
                magic.Add((string)temp[j]);
            }
            Console.Write("【步骤1：随机拿4张牌，中间对折撕成8张，按顺序叠放。】\n------------------------------------------------------\n当前牌：");
            for (int j = 0; j < magic.Count; j++)
            {
                Console.Write(magic[j] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            int nameLength = rnd.Next(2, 9);//获取名字长度
            for (int length = 1; length <= nameLength; length++)
            {
                magic.Insert(magic.Count, (string)magic[0]);
                magic.RemoveAt(0);
            }
            Console.Write($"【步骤2：随机名字长度：{nameLength}，把这{nameLength}张牌放到末尾。】\n------------------------------------------------------\n当前牌：");
            for (int i = 0; i < magic.Count; i++)
            {
                Console.Write(magic[i] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            int move = rnd.Next(1, 5);
            for (int mve = 0; mve < 3; mve++)
            {
                temp2.Add((string)magic[mve]);
                magic.RemoveAt(0);
            }
            magic.InsertRange(move, temp2);
            Console.Write($"【步骤3：把牌堆顶3张放到中间的随机位置。】\n------------------------------------------------------\n当前牌：");
            for (int i = 0; i < magic.Count; i++)
            {
                Console.Write(magic[i] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            string first = (string)magic[0];
            magic.RemoveAt(0);
            Console.Write($"【步骤4：把最顶上的牌拿走，放在一边。拿走的牌为：'{first}'】\n------------------------------------------------------\n当前牌：");
            for (int i = 0; i < magic.Count; i++)
            {
                Console.Write(magic[i] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            temp2.Clear();
            int where = rnd.Next(1, 4);
            int move2 = rnd.Next(1, 7 - where);
            string origin = where == 1 ? "是南方人" : (where == 2 ? "是北方人" : "不确定自己是哪里人");
            for (int i = 0; i < where; i++)
            {
                temp2.Add(magic[i]);
                magic.RemoveAt(0);
            }
            magic.InsertRange(move2, temp2);
            Console.Write($"【步骤5：我{origin}，把{where}张牌插入到中间的随机位置。】\n------------------------------------------------------\n当前牌：");
            for (int i = 0; i < magic.Count; i++)
            {
                Console.Write(magic[i] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            int sex = rnd.Next(1, 3);
            magic.RemoveRange(0, sex);
            string sexx = sex == 1 ? "男" : "女";
            Console.Write($"【步骤6：我是{sexx}生，移除牌堆顶的{sex}张牌。】\n------------------------------------------------------\n当前牌：");
            for (int i = 0; i < magic.Count; i++)
            {
                Console.Write(magic[i] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            for (int i = 1; i <= 7; i++)
            {
                magic.Insert(magic.Count, (string)magic[0]);
                magic.RemoveAt(0);
            }
            Console.Write($"【步骤7：把顶部的牌移动到末尾，执行7次。】\n------------------------------------------------------\n当前牌：");
            for (int i = 0; i < magic.Count; i++)
            {
                Console.Write(magic[i] + ",");
            }
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine($"【步骤8：把牌堆顶一张牌放到末尾，再移除一张牌，直到只剩下一张牌。】\n------------------------------------------------------");
            while (magic.Count > 1)
            {
                magic.Insert(magic.Count, (string)magic[0]);
                magic.RemoveAt(0);
                Console.Write("好运留下来：\t当前牌：");
                for (int i = 0; i < magic.Count; i++)
                {
                    Console.Write(magic[i] + ",");
                }
                Console.WriteLine();
                magic.RemoveAt(0);
                Console.Write("烦恼丢出去：\t当前牌：");
                for (int i = 0; i < magic.Count; i++)
                {
                    Console.Write(magic[i] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"结果：");
            Console.WriteLine($"名字长度:{nameLength}\t拿走的牌：{first}\t哪里人：{origin}\t性别:{sexx}\t最后剩余牌:{magic[0]}");
            if (first == (string)magic[0])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"藏起的牌为{first}与最后剩余牌{(string)magic[0]}相同");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"藏起的牌为{first}与最后剩余牌{(string)magic[0]}不相同");
                Console.ResetColor();
            }
        }
        public static int magicnolog()
        {
            ArrayList poker = new ArrayList { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };//定义牌
            ArrayList magic = new ArrayList();//最后所取得的4张牌并且分开后的牌放入动态数组
            string[] temp = new string[4];//获取到的牌分开
            ArrayList temp2 = new ArrayList();
            Random rnd = new Random();
            for (int i = 1; i <= 4; i++)
            {
                int Index = rnd.Next(poker.Count);
                string selectCard = (string)poker[Index];
                magic.Add(selectCard);
                poker.Remove(selectCard);//防止取到重复的牌，将取到的的牌从poker中删去
            }
            magic.CopyTo(temp, 0);
            for (int j = 0; j < temp.Length; j++)
            {
                magic.Add((string)temp[j]);
            }
            int nameLength = rnd.Next(2, 9);//获取名字长度
            for (int length = 1; length <= nameLength; length++)
            {
                magic.Insert(magic.Count, (string)magic[0]);
                magic.RemoveAt(0);
            }
            int move = rnd.Next(1, 5);
            for (int mve = 0; mve < 3; mve++)
            {
                temp2.Add((string)magic[mve]);
                magic.RemoveAt(0);
            }
            magic.InsertRange(move, temp2);
            string first = (string)magic[0];
            magic.RemoveAt(0);
            temp2.Clear();
            int where = rnd.Next(1, 4);
            int move2 = rnd.Next(1, 7 - where);

            for (int i = 0; i < where; i++)
            {
                temp2.Add(magic[i]);
                magic.RemoveAt(0);
            }
            magic.InsertRange(move2, temp2);
            int sex = rnd.Next(1, 3);
            magic.RemoveRange(0, sex);

            for (int i = 1; i <= 7; i++)
            {
                magic.Insert(magic.Count, (string)magic[0]);
                magic.RemoveAt(0);
            }
            while (magic.Count > 1)
            {
                magic.Insert(magic.Count, (string)magic[0]);
                magic.RemoveAt(0);
                magic.RemoveAt(0);
            }
            if (first == (String)magic[0])
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        static void Main(string[] args)
        {
            gt:
            Console.WriteLine("1.获取魔术概率\n2.获取获取一次的日志");
            try
            {
                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        { 
                            magicnolog();
                            Console.Write("输入要进行魔术的次数：");
                            int num=int.Parse(Console.ReadLine());
                            int sum = 0;
                            for(int i = 1; i <= num; i++)
                            {
                                if (magicnolog() == 1)
                                {
                                    sum++;
                                }
                            }
                            Console.WriteLine($"共进行了{num}次魔术；其中有{sum}次成功，{num-sum}次失败，成功概率为{sum/num*100}%");
                            Console.WriteLine("继续？y/n");
                            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                            {
                                goto gt;
                            }                                                         
                            break;
                        }
                    case 2:
                        {
                            startmagic();
                            Console.WriteLine("继续？y/n");
                            if (Console.ReadLine() == "y"||Console.ReadLine()=="Y")
                            {
                                goto gt;
                            }
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("数字输入错误！");
                            Console.ResetColor();
                            goto gt;
                            
                        }
                }
            }catch (Exception ex)
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("请输入数字！");
                Console.ResetColor();
                
            }     
        }
    }
}
        
    

