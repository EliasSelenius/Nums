using System;
using System.Collections.Generic;
using System.Text;

namespace NumsCodeGenerator {
    public abstract class FileGenerator : CodeBuilder {

        private static List<FileGenerator> files = new List<FileGenerator>();

        public string fileName;

        public FileGenerator(string name) {
            fileName = name;
            files.Add(this);
        }

        public static void Generate() {
            foreach (var item in files) {
                item._gen();
            }
        }

        public void region(string name) {
            linebreak();
            writeline("#region " + name);
        }
        public void endregion() {
            writeline("#endregion");
        }

        /// <summary>
        /// 
        /// </summary>
        public void summary(string text) {
            writeline("/// <summary>");
            writeline("/// " + text);
            writeline("/// </summary>");
        }

        private void _gen() {

            Console.WriteLine($"generating: {fileName}.g.cs");

            generate();

            System.IO.File.WriteAllText($"autogen/{fileName}.g.cs", this.result());
        }

        protected abstract void generate();

    }
}
