using Kolben;
using Kolben.Types;
using System;

namespace KolbenRun
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new ScriptProcessor();

            while (true)
            {
                Console.Write("< ");
                string input = Console.ReadLine();

                var result = processor.Run(input);
                
                if (result.TypeOf() == SObject.LiteralTypeError)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    SError error = (SError)result;

                    Console.WriteLine("x " + ((SString)error.Members["type"].Data).Value + ": " +
                                      ((SString)error.Members["message"].Data).Value);

                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("> " + result.ToScriptSource());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
