using System;
using System.Collections.Generic;
using System.Linq;

namespace Properties2XML
{
    public class Arguments
    {
        private static string[] args; // Unmodified args live here
        public static Dictionary<string, string> ArgumentDictionary { get; set; } = new Dictionary<string, string>();
        public static void Init(ref string[] args)
        {
            Arguments.args = args; // save the original args

            args = FixArguments();
        }

        private static string[] FixArguments()
        {
            List<string> fixedArgs = new();

            #region String array to dictionary
            for (int i = 0; i < args.Length; i++)
            {
                string key = "";
                List<string> value = new();
                if (args[0].StartsWith("--"))
                {
                    key = args[i];
                    //i++;
                    while (i + 1 < args.Length && !args[i + 1].StartsWith("--"))
                    {
                        value.Add(args[i + 1]);
                        i++;
                    }
                }
                else throw new ArgumentException($"Invalid argument detected at position {i + 1} with value \"{args[i]}\".");

                ArgumentDictionary.Add(key, string.Join(" ", value));
            }
            #endregion

            #region Dictionary to list
            ArgumentDictionary.ToList().ForEach(x =>
            {
                fixedArgs.Add(x.Key);
                fixedArgs.Add(x.Value);
            });
            #endregion
            return fixedArgs.ToArray();
        }

        public static string GetParameter(string parameterName)
        {
            parameterName = parameterName.StartsWith("--") ? parameterName : $"--{parameterName.Trim('-')}";
            return ArgumentDictionary.Where(x=>x.Key.ToLower() == parameterName.ToLower()).FirstOrDefault().Value;
        }
    }
}
