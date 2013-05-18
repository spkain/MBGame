using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace TicTacToe
{
    class PlugManager
    {


        private List<IPlayLogic> _logics = new List<IPlayLogic>();
        private string ipluginName = typeof(IPlayLogic).FullName;

        public PlugManager()
        {
            PlugInitialize();
        }

        private void PlugInitialize()
        {
            string folder = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            folder += "\\plugins";

            string[] list = Directory.GetFiles(folder, "*LPlugin.dll");

            Console.WriteLine("cpu logic plugin load start");
            Console.WriteLine("----------------------------------------");
            foreach (string str in list)
            {
                Assembly asm = Assembly.LoadFrom(str);

                foreach (Type t in asm.GetTypes())
                {
                    if (t.IsClass && t.IsPublic && !t.IsAbstract &&
                        t.GetInterface(ipluginName) !=  null)
                    {
                        IPlayLogic logic = CreateInstance(t);
                        Console.WriteLine("plugin... {0} load ok", logic.GetName());
                        _logics.Add(logic);
                        
                    }
                }
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("plugin load end");
        }

        private IPlayLogic CreateInstance(Type t)
        {
            try
            {
                return Activator.CreateInstance(t) as TicTacToe.IPlayLogic;
            }
            catch
            {
                return null;
            }
        }

        public List<IPlayLogic> getPlugList()
        {
            return _logics;
        }

    }
}
