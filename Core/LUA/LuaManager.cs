﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

using MoonSharp.Interpreter;

using Navislamia.Utilities;

using Navislamia.LUA.Functions;

using Serilog;

namespace Navislamia.LUA
{
    public class LuaManager
    {
        Script luaVM = new Script();

        public static LuaManager Instance;

        public string ScriptsDirectory = null;

        public LuaManager() => Instance = this;

        public int ScriptCount { get; private set; }

        public bool Initialize(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                Log.Fatal("LuaManager failed to initialize because the provided directory was null!");
                return false;
            }

            if (!Directory.Exists(directory))
            {
                Log.Fatal("LuaManager failed to initialize because the provided directory: {directory} does not exist!", directory);
                return false;
            }

            ScriptsDirectory = directory;

            registerFunctions();

            Log.Debug("Loading scripts from: {0}", ScriptsDirectory);

            loadScripts();

            return true;
        }

        public void RunString(string script)
        {
            if (string.IsNullOrEmpty(script))
            {
                Log.Error("Cannot RunString for a null script!");
                return;
            }

            try {
                luaVM.DoString(script);
            }
            catch (ScriptRuntimeException rtEx) {
                Log.Error("A runtime exception occured while executing the lua string: {0}\n- Message: {1}\n- Stack-Trace: {2}", script, rtEx.Message, rtEx.StackTrace);
                return;
            }
            catch (SyntaxErrorException sEx) {
                Log.Error("A syntax exception occured while executing the lua string: {0}\n- Message: {1}\n- Stack-Trace: {2}", script, sEx.Message, sEx.StackTrace);
                return;
            }
            catch (Exception ex) {
                Log.Error("An exception occured while executing the lua string: {0}\n- Message: {1}\n- Stack-Trace: {2}", script, ex.Message, ex.StackTrace);
                return;
            }
        }

        void registerFunctions()
        {
            registerFunction("call_lc_In", MiscFunc.SetCurrentLocationID);
            registerFunction("get_monster_id", MonsterFunc.get_monster_id);
        }

        void registerFunction(string name, Func<object[], int> function) => luaVM.Globals[name] = function;

        void loadScripts()
        {
            string[] scriptPaths;

            if (string.IsNullOrEmpty(ScriptsDirectory))
            {
                Log.Error("ScriptsDirectory is null!");
                return;
            }

            if (!Directory.Exists(ScriptsDirectory))
            {
                Log.Error("Provided scripts directory: {0} does not exist!", ScriptsDirectory);
                return;
            }

            scriptPaths = Directory.GetFiles(ScriptsDirectory);
            List<Task> scriptTasks = new List<Task>();


            for (int i = 0; i < scriptPaths.Length; i++)
            {
                string path = scriptPaths[i];

                scriptTasks.Add(Task.Run(() =>
                {
                    try
                    {
                        luaVM.DoFile(path);
                    }
                    catch (Exception ex)
                    {

                        string exMsg;

                        if (ex is SyntaxErrorException || ex is ScriptRuntimeException)
                            exMsg = $"{Path.GetFileName(path)} could not be loaded!\n\nMessage: {StringExt.LuaExceptionToString(((InterpreterException)ex).DecoratedMessage)}\n";
                        else
                            exMsg = $"An exception occured while loading {Path.GetFileName(path)}!\n\nMessage: {ex.Message}\nStack-Trace: {ex.StackTrace}\n";

                        throw new Exception(exMsg);
                    }
                }));


                ScriptCount++;
            }

            Task t = Task.WhenAll(scriptTasks).ContinueWith(_ => { Log.Information("{0} LUA Scripts loaded!", ScriptCount); });
            try
            {
                t.Wait();
            }
            catch { }

            foreach (var task in scriptTasks)
                if (task.IsFaulted)
                    Log.Warning(task.Exception.Message);
        }
    }
}
