using System;
using System.Linq;
using System.Collections.Generic;
namespace NumsCodeGenerator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("CodeGenerator running");

            
            System.IO.File.WriteAllText("autogen\\vec2.g.cs", genVecStruct("float", "x", "y"));
            System.IO.File.WriteAllText("autogen\\vec3.g.cs", genVecStruct("float", "x", "y", "z"));
            System.IO.File.WriteAllText("autogen\\vec4.g.cs", genVecStruct("float", "x", "y", "z", "w"));

            Console.WriteLine("CodeGenerator done");
        }


        static string genVecStruct(string type, params string[] compsNames) {
            var cb = new CodeBuilder();

            var vecName = "vec" + compsNames.Length;

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

            // constanst:
            _region("constants");
            _endregion();

            cb.linebreak();
            // fields & basic properties:
            cb.writeline($"public {type} {compsNames.Aggregate((x, y) => x + ", " + y)};");
            cb.writeline($"public {type} sum => {compsNames.Aggregate((x, y) => x + " + " + y)};");
            cb.writeline($"public int bytesize => sizeof({type}) * {compsNames.Length};");
            cb.writeline($"public {type} sqlength => dot(this);");
            cb.writeline($"public {type} length => ({type})Math.Sqrt(dot(this));");
            cb.writeline($"public {vecName} normalized => this / length;");

            // swizzling properies:
            _region("swizzling properties");
            _endregion();

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


            // indexing:

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


            _endregion();

            // advanced math functions:
            _region("math");
            _endregion();

            // conversion:
            _region("conversion");
            _endregion();

            cb.endBlock();
            cb.endBlock();

            return cb.result();
        }
    }
}
