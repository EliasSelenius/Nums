using System;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace NumsCodeGenerator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("CodeGenerator running");



            // float
            new VectorStruct("vec", "float", vectorComps[..2]);
            new VectorStruct("vec", "float", vectorComps[..3]);
            new VectorStruct("vec", "float", vectorComps);

            // int
            new VectorStruct("ivec", "int", vectorComps[..2]);
            new VectorStruct("ivec", "int", vectorComps[..3]);
            new VectorStruct("ivec", "int", vectorComps);

            // double
            new VectorStruct("dvec", "double", vectorComps[..2]);
            new VectorStruct("dvec", "double", vectorComps[..3]);
            new VectorStruct("dvec", "double", vectorComps);


            // bivectors
            //new VectorStruct("bivec", "vec2", comps[..2]);


            // matrices 
            for (int i = 2; i <= 4; i++) {
                for (int j = 2; j <= 4; j++) {
                    new MatrixStruct("mat", "float", i, j);
                    new MatrixStruct("dmat", "double", i, j);
                }
            }

         

            FileGenerator.Generate();

            Console.WriteLine("CodeGenerator done");
        }

        public static string[] vectorComps = new[] {
            "x", "y", "z", "w"
        };

        public static string getVectorType(string type) => type switch
        {
            "float" => "vec",
            "double" => "dvec",
            "int" => "ivec",
            _ => throw new Exception()
        };

        private static readonly string[] indexNames = new[] {
            "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
        };

        public static string Index2String(int index) {
            return index < indexNames.Length ? indexNames[index] : index + "'th";
        }
    }
}
