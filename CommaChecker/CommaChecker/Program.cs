using System;
using System.Text;

namespace CommaChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //"въпреки че", "макар че", "само че"

            Console.WriteLine("CommaChecker 1.0 by xnikoloff");
            Console.WriteLine("-----------------------------");

            Console.WriteLine();

            string[] conjunctions = { "който", "която", "което", "които", "чиято", "чието", "чиито",
            "защото", "когато", "където", "накъдето", "дето", "както", "че", "ако","но", "а", "ама",
            "за да", "камо ли", "какъвто", "докато", "щом", "без да", "понеже", "колкто", "сякаш"};
            string text = "";

            try
            {
                Console.WriteLine("Въведете текст: ");
                text = Console.ReadLine();
            }

            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Текстът превишава максималния позволен брой символи! Моля, въвдете по-кратък текст.");
            }

            catch (OutOfMemoryException)
            {
                Console.WriteLine("Няма достатъчно памет, за да се обработи текстът. Моля, въвдете по-кратък текст.");
            }
            
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            int index = 0;
            string newText = "";
            
            for(int i = 0; i < conjunctions.Length; i++)
            {
                if (sb.ToString().Contains(conjunctions[i]))
                {
                    index = sb.ToString().IndexOf(conjunctions[i]);
                    while (index != -1)
                    {

                        if (text[index - 1].Equals(' '))
                        {
                            if (text[index - 2] != ',')
                            {
                                text = (text.Insert(index - 1, ","));
                                
                            }

                            if (!(newText.Equals(text)))
                            {
                                newText = text;
                                text = newText;
                                sb.Clear();
                                sb.Append(newText);
                                index = newText.ToString().IndexOf(conjunctions[i], index + conjunctions[i].Length);
                            }

                            else
                            {
                                index = newText.ToString().IndexOf(conjunctions[i], index + conjunctions[i].Length);
                            }

                           
                        }

                        else
                        {
                            if (index + conjunctions[i].Length >= newText.ToString().Length)
                            {
                                index = -1;
                            }

                            else
                            {
                                index = newText.ToString().IndexOf(conjunctions[i], index + conjunctions[i].Length);
                            }
                            
                            
                        }

                        
                    }
                    
                    
                }
            }

            if(newText == "")
            {
                Console.WriteLine("В текста не беше промемено нищо.");
            }

            Console.WriteLine("----------------------------------------");

            Console.WriteLine(newText);
        }
    }
}
