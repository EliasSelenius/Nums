﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NumsCodeGenerator {
    public class VectorStruct : FileGenerator {

        private string name;

        /// <summary>
        /// Array of component names. E.g: ['x', 'y', 'z', 'w']
        /// </summary>
        private string[] compsNames;

        private int compCount => compsNames.Length;

        /// <summary>
        /// the type of this vector. E.g: float, int, double
        /// </summary>
        private string type;

        /// <summary>
        /// vector name plus number of components. E.g: vec3, dvec2, etc..
        /// </summary>
        private string vecName;

        private readonly CodeBuilder mathClass = new CodeBuilder();

        public VectorStruct(string name, string type, params string[] compNames) : base("vectors/" + name + compNames.Length) {
            this.name = name;
            this.compsNames = compNames;
            this.type = type;
            this.vecName = name + compNames.Length;
        }

        private static string unitVectorSymbol(int i) => i switch
        {
            0 => "→",
            1 => "↑",
            2 => "↗",
            _ => ""
        };

        protected override void generate() {

            // genetate math class first
            mathClass.numTabs++;
            mathClass.startBlock("public static partial class math");


            writeline("using System;");
            writeline("using System.Runtime.InteropServices;");
            linebreak();

            startBlock("namespace Nums");
            linebreak();

            summary("A " + compsNames.Length + " component vector of " + type);
            writeline("[StructLayout(LayoutKind.Sequential)]");
            startBlock("public struct " + vecName + " : " + name);

            genConstants();

            linebreak();
            // fields & basic properties:

            for (int i = 0; i < compsNames.Length; i++) {
                summary($"The {compsNames[i]} component is the {Program.Index2String(i)} index of the vector");
                writeline($"public {type} {compsNames[i]};");
            }
            //writeline($"public {type} {compsNames.Aggregate((x, y) => x + ", " + y)};");

            var sum = compsNames.Aggregate((x, y) => x + " + " + y);
            summary("The sum of the vectors components. " + sum);
            writeline($"public readonly {type} sum => {sum};");

            summary("The number of bytes the vector type uses.");
            writeline($"public const int bytesize = sizeof({type}) * {compsNames.Length};");

            summary("The magnitude of the vector");
            writeline($"public readonly {type} length => ({type})Math.Sqrt(dot(this));");
            summary("The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.");
            writeline($"public readonly {type} sqlength => dot(this);");

            summary("The normalized version of this vector.");
            writeline($"public readonly {vecName} normalized() => this / length;");
            summary("Normalizes this vector.");
            writeline("public void normalize() => this /= length;");

            genIndexAccessor();
            genSwizzlingProperties();
            genContructors();
            genArithmeticOperators();
            genMath();
            genCastOperands();

            region("other");
            writeline($"public override string ToString() => $\"({compsNames.Select(x => "{" + x + "}").Aggregate((x, y) => x + ", " + y)})\";");
            endregion();


            endBlock(); // end vector struct block

            mathClass.endBlock(); // end math partial class
            writesection(mathClass);
            
            endBlock(); // end namespace

        }


        private void genConstants() {
            region("constants");

            var constantcomps = new string[compsNames.Length];

            for (int i = 0; i < constantcomps.Length; i++)
                constantcomps[i] = "0";

            summary("The zero vector: A vector where all components are equal to zero.");
            writeline($"public static readonly {vecName} zero = ({constantcomps.Aggregate((x, y) => x + ", " + y)});");

            for (int i = 0; i < compsNames.Length; i++) {
                constantcomps[i] = "1";
                summary("A unit vector pointing in the positive " + compsNames[i] + " direction. " + unitVectorSymbol(i));
                writeline($"public static readonly {vecName} unit{compsNames[i]} = ({constantcomps.Aggregate((x, y) => x + ", " + y)});");
                constantcomps[i] = "0";
            }

            for (int i = 0; i < constantcomps.Length; i++)
                constantcomps[i] = "1";
            summary("A vector where all components are equal to one.");
            writeline($"public static readonly {vecName} one = ({constantcomps.Aggregate((x, y) => x + ", " + y)});");

            endregion();
        }

        private void genIndexAccessor() {
            linebreak();
            startBlock($"public {type} this[int i]");
            var indexerror = $"throw new IndexOutOfRangeException(\"{vecName}[\" + i + \"] is not a valid index\")";
            //get:
            startBlock("readonly get => i switch");
            for (int i = 0; i < compsNames.Length; i++) {
                writeline($"{i} => {compsNames[i]},");
            }
            writeline($"_ => {indexerror}");
            endBlock(";");
            //set:
            startBlock("set"); startBlock("switch (i)");
            for (int i = 0; i < compsNames.Length; i++) {
                writeline($"case {i}: {compsNames[i]} = value; return;");
            }
            writeline($"default: {indexerror};");
            endBlock(); endBlock();

            endBlock();
        }

        private void genSwizzlingProperties() {
            region("swizzling properties");

            void _genswizzles(int size) {
                var swizzleindexes = new int[size];
                var swizzlevecname = name + size;

                for (int si = 0; si < Math.Pow(compsNames.Length, size); si++) {

                    var propName = swizzleindexes.Select(x => compsNames[x]).Aggregate((x, y) => x + y);
                    var getterandsetter = swizzleindexes.Distinct().Count() == swizzleindexes.Length;

                    var r = getterandsetter ? "" : "readonly ";
                    string decl = $"public {r}{swizzlevecname} {propName}",
                           get = $"=> new {swizzlevecname}({swizzleindexes.Select(x => compsNames[x]).Aggregate((x, y) => x + ", " + y)});";
                    summary($"A {swizzlevecname} containing the {propName} components of this vector");
                    if (getterandsetter) {
                        startBlock(decl);
                        writeline($"readonly get {get}");
                        startBlock("set");
                        for (int j = 0; j < swizzleindexes.Length; j++) {
                            writeline(compsNames[swizzleindexes[j]] + " = value." + compsNames[j] + ";");
                        }
                        endBlock();
                        endBlock();
                    } else {
                        writeline(decl + " " + get);
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

            endregion();
        }

        private void genContructors() {
            region("constructors");

            string _paramslist(string[] args) {
                var res = new string[args.Length];
                for (int i = 0; i < res.Length; i++) res[i] = type + " " + args[i];
                return res.Aggregate((x, y) => x + ", " + y);
            }
            void _paramsassigmentcode(string[] args) {
                foreach (var item in args)
                    writeline($"this.{item} = {item};");
            }

            startBlock($"public {vecName}({_paramslist(compsNames)})");
            _paramsassigmentcode(compsNames);
            endBlock();

            /*
                vec4(vec2, vec2)
                vec4(vec2, float, float)
                vec4(float, vec2, float)
                vec4(float, float, vec2)

                vec4(vec3, float)
                vec4(float, vec3)

                vec3(vec2, float)
                vec3(float, vec2)
            */
            if (compCount == 4) {
                _genConstructor(2, 2);
                _genConstructor(2, 1, 1);
                _genConstructor(1, 2, 1);
                _genConstructor(1, 1, 2);
                
                _genConstructor(3, 1);
                _genConstructor(1, 3);
            } else if (compCount == 3) {
                _genConstructor(2, 1);
                _genConstructor(1, 2);

            }
            
            
            

            void _genConstructor(params int[] args) {

                var argList = new string[args.Length];
                var argNames = new string[args.Length];

                int c = 0;
                for (int i = 0; i < args.Length; i++) {
                    argList[i] = (args[i] == 1 ? type : name + args[i]); 
                    argNames[i] = compsNames[c..(c += args[i])].Aggregate((x, y) => x + y);
                }

                startBlock($"public {vecName}({argList.Select((x, i) => x + " " + argNames[i]).Aggregate((x, y) => x + ", " + y)})");
                c = 0;
                for (int i = 0; i < args.Length; i++) {    
                    for (int j = 0; j < args[i]; j++) {
                        writeline("this." + compsNames[c] + " = " + argNames[i] + ((args[i] == 1) ? "" : "." + compsNames[j]) + ";");
                        c++;
                    }
                }
                endBlock();
            }



            endregion();
        }

        private void genArithmeticOperators() {
            region("arithmetic");
            writeline($"public readonly {type} dot({vecName} v) => (this * v).sum;");
            linebreak();

            void _vecoperator(string opr) {
                var res = new string[compsNames.Length];
                for (int i = 0; i < res.Length; i++)
                    res[i] = $"a.{compsNames[i]} {opr} b.{compsNames[i]}";

                writeline($"public static {vecName} operator {opr}({vecName} a, {vecName} b) => new {vecName}({res.Aggregate((x, y) => x + ", " + y)});");
            }

            void _vecscalaroperator(string opr) {
                var res = new string[compsNames.Length];
                for (int i = 0; i < res.Length; i++)
                    res[i] = $"a.{compsNames[i]} {opr} s";

                writeline($"public static {vecName} operator {opr}({vecName} a, {type} s) => new {vecName}({res.Aggregate((v, w) => v + ", " + w)});");
            }

            _vecoperator("*");
            _vecoperator("/");
            _vecoperator("+");
            _vecoperator("-");
            linebreak();
            _vecscalaroperator("*");
            _vecscalaroperator("/");
            //_vecscalaroperator("+");
            //_vecscalaroperator("-");
            linebreak();
            writeline($"public static {vecName} operator -({vecName} v) => new {vecName}({compsNames.Select((x) => "-v." + x).Aggregate((z, x) => z + ", " + x)});");

            endregion();
        }

        private void genMath() {
            region("math");
            writeline($"public readonly {type} distTo({vecName} o) => (o - this).length;");
            writeline($"public readonly {type} angleTo({vecName} o) => ({type})Math.Acos(this.dot(o) / (this.length * o.length));");
            //writeline($"public readonly {vecName} lerp({vecName} o, {type} t) => this + ((o - this) * t);"); i removed this to encurage use of the static version since it is cleaner
            writeline($"public readonly {vecName} reflect({vecName} normal) => this - (normal * 2 * (this.dot(normal) / normal.dot(normal)));");


            if (compsNames.Length == 3) {
                // only write for 3-dimensional vectors
                writeline($"public {vecName} cross({vecName} o) => new {vecName}(y * o.z - z * o.y, z * o.x - x * o.z, x * o.y - y * o.x);");
            }

            var mathFunc_vec_args = compsNames.Select(x => $"_R_(o.{x})").Aggregate((x, y) => x + ", " + y);
            void mathFunc_vec(string name) {
                mathClass.summary($"Takes the {name} of each component in the given {vecName}.");
                mathClass.writeline($"public static {vecName} {name}(in {vecName} o) => new {vecName}({mathFunc_vec_args.Replace("_R_", name)});");
            }
            var mathFunc_vec_vec_args = compsNames.Select(x => $"_R_(a.{x}, b.{x})").Aggregate((x, y) => x + ", " + y);
            void mathFunc_vec_vec(string name) {
                mathClass.summary($"Takes the {name} of each component in the given {vecName}.");
                mathClass.writeline($"public static {vecName} {name}(in {vecName} a, in {vecName} b) => new {vecName}({mathFunc_vec_vec_args.Replace("_R_", name)});");
            }
            var mathFunc_vec_scalar_args = compsNames.Select(x => $"_R_(a.{x}, b)").Aggregate((x, y) => x + ", " + y);
            void mathFunc_vec_scalar(string name) {
                mathClass.summary($"Takes the {name} of each component in the given {vecName}.");
                mathClass.writeline($"public static {vecName} {name}(in {vecName} a, {type} b) => new {vecName}({mathFunc_vec_scalar_args.Replace("_R_", name)});");
            }







            if (!type.Equals("int")) {
                mathFunc_vec("floor");
                mathFunc_vec("fract");
                mathFunc_vec("sqrt");
                mathFunc_vec_scalar("pow");
                mathFunc_vec("sin");
                mathFunc_vec("cos");
                mathFunc_vec("tan");
            }

            mathFunc_vec("abs");

            mathFunc_vec_vec("min");
            mathFunc_vec_vec("max");

            // lerp
            mathClass.summary($"Linear interpolation of two {vecName} by t.");
            mathClass.writeline($"public static {vecName} lerp(in {vecName} x, in {vecName} y, {type} t) => x + (y - x) * t;");

            // bezier
            // lerp(lerp(p0, p1, t), lerp(p1, p2, t), t)
            // p0 + (p1 - p0) * t   ....   p1 + (p2 - p1) * t

            // p0 + p1t - p0t + p1t + p2t^2 - p1t^2 - p0t + p1t^2 - p0t^2
            // p0 + 2p1t - 2p0t + p2t^2 - p0t^2
            // bezier(a, b, c, t) = a + 2bt - 2at + ct^2 - at^2
            // bezier(a, b, c, t) = a + (2(b - a) + t(c - a))t
            // a + (2*(b - a) + t*(c - a))*t

            // lerp(a, b, t) = (1 - t)a + tb
            // lerp(lerp(a, b, t), lerp(b, c, t), t)
            // (1 - t)a + tb  ....  (1 - t)b + tc
            // a - at + bt - at - at^2 + bt^2 + bt - bt^2 + ct^2
            // a - (2(a + b) - t(a + c))t // derived from lerp func (1 - t)a + tb 
            // a + (2(b - a) + t(c - a))t // derived from lerp func a + (b - a) * t


            /* second atempt

                lerp(a, b, t) = a + (b - a) * t

                bezier(a, b, c, t) = lerp(lerp(a, b, t), lerp(b, c, t), t)

                a + (b - a) * t      b + (c - b) * t

                a + bt - at + bt + ct^2 - bt^2 - at + bt^2 - at^2
                
                a + ((b - a)2 + (c - a)t)t



                lerp(lerp(a, b, t), lerp(b, c, t), t) 
                lerp(a + (b - a) * t, b + (c - b) * t, t)


                a + bt - at + bt + ct^2 - bt^2 - at - bt^2 + at^2
                a + 2bt - 2at + ct^2 - 2bt^2 + at^2
                a + ((b - a)2 + (c - 2b + a)t)t
                a + ((b - a)*2 + (c - 2*b + a)*t)*t

            */
            mathClass.summary($"Gets the {vecName} at location t along a curve.");
            mathClass.writeline($"public static {vecName} bezier(in {vecName} a, in {vecName} b, in {vecName} c, {type} t) => a + ((b - a)*2 + (c - 2*b + a)*t)*t;");

            endregion();
        }

        private void genCastOperands() {
            region("conversion/deconstructors");

            // tuple cast
            var tupletype = compsNames.Select(x => type).Aggregate((x, c) => x + ", " + c);
            var tupleparams = new string[compsNames.Length];
            for (int i = 0; i < compsNames.Length; i++)
                tupleparams[i] = "tuple.Item" + (i + 1);
            writeline($"public static implicit operator {vecName}(({tupletype}) tuple) => new {vecName}({tupleparams.Aggregate((x, v) => x + ", " + v)});");


            // casts to other vectortypes
            var conversions = typeCastMap[name];
            foreach (var item in conversions) {
                var otherVecName = item.Key + compsNames.Length;

                var prefix = item.Value.Equals("explicit") ? $"({getPrimitiveType(item.Key)})v." : "v.";
                var constructorargs = compsNames.Select(x => prefix + x).Aggregate((x, y) => x + ", " + y);
                
                writeline($"public static {item.Value} operator {otherVecName}({vecName} v) => new {otherVecName}({constructorargs});");
            }

            // from single number to vector
            writeline($"public static implicit operator {vecName}({type} n) => new {vecName}({compsNames.Select(x => "n").Aggregate((x, y) => x + ", " + y)});");
            

            // deconstruct to tuple
            {
                var pa = compsNames.Select(x => "out " + type + " " + x).Aggregate((x, y) => x + ", " + y);
                var c = compsNames.Aggregate((x, y) => x + ", " + y);
                var tc = compsNames.Select(x => "this." + x).Aggregate((x, y) => x + ", " + y);
                writeline($"public void Deconstruct({pa}) => ({c}) = ({tc});");
            }


            endregion();
        }

        private static string getPrimitiveType(string vectorType)
            => vectorType switch
            {
                "vec" => "float",
                "ivec" => "int",
                "dvec" => "double",
                _ => throw new Exception()
            };

        private static readonly Dictionary<string, Dictionary<string, string>> typeCastMap = new Dictionary<string, Dictionary<string, string>>() {
            { "ivec", 
                new Dictionary<string, string>() {
                    { "vec", "implicit" },
                    { "dvec", "implicit" }
                }
            },
            { "vec",
                new Dictionary<string, string>() {
                    { "ivec", "explicit" },
                    { "dvec", "implicit" }
                }
            },
            { "dvec",
                new Dictionary<string, string>() {
                    { "ivec", "explicit" },
                    { "vec", "explicit" }
                }
            }
        };

    }
}
