using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Terraria
{
    internal class ProgramServer
    {
        public const string PluginsPath = "ServerPlugins";
        public static readonly Version ApiVersion = new Version(1, 10, 0, 1);
        public static List<PluginContainer> Plugins = new List<PluginContainer>();
        public static Dictionary<string, Assembly> LoadedAssemblies = new Dictionary<string, Assembly>();
        private static Main Game;

        private static void Main(string[] args)
        {
            try
            {
                Game = new Main();
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].ToLower() == "-config")
                    {
                        i++;
                        Game.LoadDedConfig(args[i]);
                    }
                    if (args[i].ToLower() == "-port")
                    {
                        i++;
                        try
                        {
                            int serverPort = Convert.ToInt32(args[i]);
                            Netplay.serverPort = serverPort;
                        }
                        catch
                        {
                        }
                    }
                    if (args[i].ToLower() == "-players" || args[i].ToLower() == "-maxplayers")
                    {
                        i++;
                        try
                        {
                            int netPlayers = Convert.ToInt32(args[i]);
                            Game.SetNetPlayers(netPlayers);
                        }
                        catch
                        {
                        }
                    }
                    if (args[i].ToLower() == "-pass" || args[i].ToLower() == "-password")
                    {
                        i++;
                        Netplay.password = args[i];
                    }
                    if (args[i].ToLower() == "-world")
                    {
                        i++;
                        Game.SetWorld(args[i]);
                    }
                    if (args[i].ToLower() == "-worldname")
                    {
                        i++;
                        Game.SetWorldName(args[i]);
                    }
                    if (args[i].ToLower() == "-motd")
                    {
                        i++;
                        Game.NewMOTD(args[i]);
                    }
                    if (args[i].ToLower() == "-banlist")
                    {
                        i++;
                        Netplay.banFile = args[i];
                    }
                    if (args[i].ToLower() == "-autoshutdown")
                    {
                        Game.autoShut();
                    }
                    if (args[i].ToLower() == "-secure")
                    {
                        Netplay.spamCheck = true;
                    }
                    if (args[i].ToLower() == "-autocreate")
                    {
                        i++;
                        string newOpt = args[i];
                        Game.autoCreate(newOpt);
                    }
                }
                Initialize(Game);
                Game.DedServ();
                DeInitialize();
            }
            catch (Exception value)
            {
                try
                {
                    using (var streamWriter = new StreamWriter("crashlog.txt", true))
                    {
                        streamWriter.WriteLine(DateTime.Now);
                        streamWriter.WriteLine(value);
                        streamWriter.WriteLine("");
                    }
                    Console.WriteLine("Server crash: " + DateTime.Now);
                    Console.WriteLine(value);
                    Console.WriteLine("");
                    Console.WriteLine("Please send crashlog.txt to support@terraria.org");
                }
                catch
                {
                }
            }
        }

        public static void Initialize(Main main)
        {
            if (!Directory.Exists("ServerPlugins"))
            {
                Directory.CreateDirectory("ServerPlugins");
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            FileInfo[] files = new DirectoryInfo("ServerPlugins").GetFiles("*.dll");
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = files[i];
                try
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.Name);
                    Assembly assembly;
                    if (!LoadedAssemblies.TryGetValue(fileNameWithoutExtension, out assembly))
                    {
                        assembly = Assembly.Load(File.ReadAllBytes(fileInfo.FullName));
                        LoadedAssemblies.Add(fileNameWithoutExtension, assembly);
                    }
                    Type[] types = assembly.GetTypes();
                    for (int j = 0; j < types.Length; j++)
                    {
                        Type type = types[j];
                        if (type.BaseType == typeof (TerrariaPlugin)) // Mono has this as a TODO.
                        {
                            if (Compatible(type))
                            {
                                Plugins.Add(new PluginContainer((TerrariaPlugin) Activator.CreateInstance(type, new object[]
                                                                                                                    {
                                                                                                                        main
                                                                                                                    })));
                            }
                            else
                            {
                                Console.WriteLine("Outdated plugin: {0} ({1})", fileInfo.Name, type);
                            }
                        }
                    }
                }
                catch (Exception innerException)
                {
                    if (innerException is TargetInvocationException)
                    {
                        innerException = (innerException).InnerException;
                    }
                    Console.WriteLine("Plugin {0} failed to load", fileInfo.Name);
                }
            }
            IOrderedEnumerable<PluginContainer> orderedEnumerable =
                from x in Plugins
                orderby x.Plugin.Order , x.Plugin.Name
                select x;
            foreach (PluginContainer current in orderedEnumerable)
            {
                current.Initialize();
                Console.WriteLine("{0} v{1} ({2}) initiated.", current.Plugin.Name, current.Plugin.Version, current.Plugin.Author);
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string text = args.Name.Split(new[]
                                              {
                                                  ','
                                              })[0];
            string path = Path.Combine("ServerPlugins", text + ".dll");
            try
            {
                if (File.Exists(path))
                {
                    Assembly assembly;
                    if (!LoadedAssemblies.TryGetValue(text, out assembly))
                    {
                        assembly = Assembly.Load(File.ReadAllBytes(path));
                        LoadedAssemblies.Add(text, assembly);
                    }
                    return assembly;
                }
            }
            catch (Exception value)
            {
                Console.WriteLine(value);
            }
            return null;
        }

        private static bool Compatible(Type type)
        {
            object[] customAttributes = type.GetCustomAttributes(typeof (APIVersionAttribute), false);
            if (customAttributes.Length != 1)
            {
                return false;
            }
            var aPIVersionAttribute = (APIVersionAttribute) customAttributes[0];
            Version apiVersion = aPIVersionAttribute.ApiVersion;
            return apiVersion.Major == ApiVersion.Major && apiVersion.Minor == ApiVersion.Minor;
        }

        public static void DeInitialize()
        {
            foreach (PluginContainer current in Plugins)
            {
                current.DeInitialize();
            }
            foreach (PluginContainer current2 in Plugins)
            {
                current2.Dispose();
            }
        }
    }
}