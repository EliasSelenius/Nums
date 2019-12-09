using System;
using System.Linq;
using System.Collections.Generic;
namespace NumsCodeGenerator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("CodeGenerator running");

            
            // float
            System.IO.File.WriteAllText("autogen\\vec2.g.cs", genVecStruct("vec", "float", "x", "y"));
            System.IO.File.WriteAllText("autogen\\vec3.g.cs", genVecStruct("vec", "float", "x", "y", "z"));
            System.IO.File.WriteAllText("autogen\\vec4.g.cs", genVecStruct("vec", "float", "x", "y", "z", "w"));

            // int
            System.IO.File.WriteAllText("autogen\\ivec2.g.cs", genVecStruct("ivec", "int", "x", "y"));
            System.IO.File.WriteAllText("autogen\\ivec3.g.cs", genVecStruct("ivec", "int", "x", "y", "z"));
            System.IO.File.WriteAllText("autogen\\ivec4.g.cs", genVecStruct("ivec", "int", "x", "y", "z", "w"));

            // double
            System.IO.File.WriteAllText("autogen\\dvec2.g.cs", genVecStruct("dvec", "double", "x", "y"));
            System.IO.File.WriteAllText("autogen\\dvec3.g.cs", genVecStruct("dvec", "double", "x", "y", "z"));
            System.IO.File.WriteAllText("autogen\\dvec4.g.cs", genVecStruct("dvec", "double", "x", "y", "z", "w"));

            // decimal
            /*System.IO.File.WriteAllText("autogen\\mvec2.g.cs", genVecStruct("mvec", "decimal", "x", "y"));
            System.IO.File.WriteAllText("autogen\\mvec3.g.cs", genVecStruct("mvec", "decimal", "x", "y", "z"));
            System.IO.File.WriteAllText("autogen\\mvec4.g.cs", genVecStruct("mvec", "decimal", "x", "y", "z", "w"));
            */

            Console.WriteLine("CodeGenerator done");
        }


        static string genVecStruct(string name, string type, params string[] compsNames) {
            var cb = new CodeBuilder();

            var vecName = name + compsNames.Length;

            Console.WriteLine("generating: " + vecName);

            void _region(string name) {
                cb.linebreak();
                cb.writeline("#region " + name);
            }
            void _endregion() {
                cb.writeline("#endregion");
            }

            cb.writeline("using System;");
            cb.linebreak();
            cb.startBlock("namespace Nums");
            cb.linebreak();
            cb.writeline("[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]");
            cb.startBlock("public struct " + vecName);

            #region genConstants
            // constanst:
            _region("constants");


            var constantcomps = new string[compsNames.Length];
            for (int i = 0; i < constantcomps.Length; i++) 
                constantcomps[i] = "0";
            cb.writeline($"public static readonly {vecName} zero = ({constantcomps.Aggregate((x, y) => x + ", " + y)});");
            for (int i = 0; i < compsNames.Length; i++) {
                constantcomps[i] = "1";
                cb.writeline($"public static readonly {vecName} unit{compsNames[i]} = ({constantcomps.Aggregate((x, y) => x + ", " + y)});");
                constantcomps[i] = "0";
            }
            for (int i = 0; i < constantcomps.Length; i++)
                constantcomps[i] = "1";
            cb.writeline($"public static readonly {vecName} one = ({constantcomps.Aggregate((x, y) => x + ", " + y)});");

            _endregion();
            #endregion

            cb.linebreak();
            // fields & basic properties:
            cb.writeline($"public {type} {compsNames.Aggregate((x, y) => x + ", " + y)};");
            cb.writeline($"public {type} sum => {compsNames.Aggregate((x, y) => x + " + " + y)};");
            cb.writeline($"public int bytesize => sizeof({type}) * {compsNames.Length};");
            cb.writeline($"public {type} sqlength => dot(this);");
            cb.writeline($"public {type} length => ({type})Math.Sqrt(dot(this));");
            cb.writeline($"public {vecName} normalized => this / length;");


            #region genIndexAccessor
            // indexing:
            cb.linebreak();
            cb.startBlock($"public {type} this[int i]");
            var indexerror = $"throw new IndexOutOfRangeException(\"{vecName}[\" + i + \"] is not a valid index\")";
            //get:
            cb.startBlock("get => i switch");
            for (int i = 0; i < compsNames.Length; i++) {
                cb.writeline($"{i} => {compsNames[i]},");
            }
            cb.writeline($"_ => {indexerror}");
            cb.endBlock(";");
            //set:
            cb.startBlock("set"); cb.startBlock("switch (i)");
            for (int i = 0; i < compsNames.Length; i++) {
                cb.writeline($"case {i}: {compsNames[i]} = value; return;");
            }
            cb.writeline($"default: {indexerror};");
            cb.endBlock(); cb.endBlock();

            cb.endBlock();
            #endregion

            #region genswizzling properties
            // swizzling properies:
            _region("swizzling properties");

            void _genswizzles(int size) {
                var swizzleindexes = new int[size];
                var swizzlevecname = name + size;

                for (int si = 0; si < Math.Pow(compsNames.Length, size); si++) {


                    string decl = $"public {swizzlevecname} {swizzleindexes.Select(x => compsNames[x]).Aggregate((x, y) => x + y)}",
                           get =  $"=> new {swizzlevecname}({swizzleindexes.Select(x => compsNames[x]).Aggregate((x, y) => x + ", " + y)});";

                    if (swizzleindexes.Distinct().Count() == swizzleindexes.Length) {
                        cb.startBlock(decl);
                        cb.writeline($"get {get}");
                        cb.startBlock("set");
                        for (int j = 0; j < swizzleindexes.Length; j++) {
                            cb.writeline(compsNames[swizzleindexes[j]] + " = value." + compsNames[j] + ";");
                        }
                        cb.endBlock();
                        cb.endBlock();
                    } else {
                        cb.writeline(decl + " " + get);
                    }

                    // increment swizzleIndexes
                    for (int i = 0; i < swizzleindexes.Length; i++) {
                        if (swizzleindexes[i] < compsNames.Length) {
                            if (swizzleindexes[i] == compsNames.Length - 1) {
                                for (int j = i; j >= 0; j--)
                                    swizzleindexes[j] = 0;
                                continue;
                            }
                            swizzleindexes[i]++;
                            break;
                        }
                    }
                }
            }

            for (int i = 2; i <= compsNames.Length; i++) 
                _genswizzles(i);

            _endregion();
            #endregion

            #region gen constructors
            // constructors:
            _region("constructors");

            string _paramslist(string[] args) {
                var res = new string[args.Length];
                for (int i = 0; i < res.Length; i++) res[i] = type + " " + args[i];
                return res.Aggregate((x, y) => x + ", " + y);
            }
            void _paramsassigmentcode(string[] args) {
                foreach (var item in args) 
                    cb.writeline($"this.{item} = {item};");
            }

            cb.startBlock($"public {vecName}({_paramslist(compsNames)})");
            _paramsassigmentcode(compsNames);
            cb.endBlock();

            _endregion();
            #endregion

            #region gen arithmetic operators
            // arithmetic:
            _region("arithmetic");
            cb.writeline($"public {type} dot({vecName} v) => (this * v).sum;");
            cb.linebreak();

            void _vecoperator(string opr) {
                var res = new string[compsNames.Length];
                for (int i = 0; i < res.Length; i++) 
                    res[i] = $"a.{compsNames[i]} {opr} b.{compsNames[i]}";
                
                cb.writeline($"public static {vecName} operator {opr}({vecName} a, {vecName} b) => new {vecName}({res.Aggregate((x, y) => x + ", " + y)});");
            }

            void _vecscalaroperator(string opr) {
                var res = new string[compsNames.Length];
                for (int i = 0; i < res.Length; i++)
                    res[i] = $"a.{compsNames[i]} {opr} s";

                cb.writeline($"public static {vecName} operator {opr}({vecName} a, {type} s) => new {vecName}({res.Aggregate((v,w) => v + ", " + w)});");
            }

            _vecoperator("*");
            _vecoperator("/");
            _vecoperator("+");
            _vecoperator("-");
            cb.linebreak();
            _vecscalaroperator("*");
            _vecscalaroperator("/");
            //_vecscalaroperator("+");
            //_vecscalaroperator("-");
            cb.linebreak();
            cb.writeline($"public static {vecName} operator -({vecName} v) => new {vecName}({compsNames.Select((x) => "-v." + x).Aggregate((z, x) => z + ", " + x)});");

            _endregion();
            #endregion


            #region gen math
            // advanced math functions:
            _region("math");
            cb.writeline($"public {type} distTo({vecName} o) => (o - this).length;");
            cb.writeline($"public {type} angleTo({vecName} o) => ({type})Math.Acos(this.dot(o) / (this.length * o.length));");
            cb.writeline($"public {vecName} lerp({vecName} o, {type} t) => this + ((o - this) * t);");

            _endregion();
            #endregion

            #region gen cast operands
            // conversion:
            _region("conversion");

            var tupletype = compsNames.Select(x => type).Aggregate((x, c) => x + ", " + c);
            var tupleparams = new string[compsNames.Length];
            for (int i = 0; i < compsNames.Length; i++)
                tupleparams[i] = "tuple.Item" + (i + 1);
            cb.writeline($"public static implicit operator {vecName}(({tupletype}) tuple) => new {vecName}({tupleparams.Aggregate((x,v) => x + ", " + v)});");

            _endregion();

            cb.endBlock();
            cb.endBlock();
            #endregion

            return cb.result();
        }
    }
}
