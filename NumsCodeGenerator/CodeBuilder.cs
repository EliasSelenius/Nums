using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace NumsCodeGenerator {
    public class CodeBuilder {

        private readonly Stack<string> content = new Stack<string>();
        private string tabs = "";

        public int numTabs {
            get => tabs.Length / 4;
            set {
                tabs = "";
                for (int i = 0; i < value; i++) tabs += "    ";
            }
        }

        public string result() {
            var res = "";
            foreach (var item in content) res = item + res;
            return res;
        }

        public void write(string str) => content.Push(str);
        public void writeline(string line) => write(tabs + line + "\n");

        public void undo(int i = 1) {
            for (; i > 0; i--) content.Pop();
        }


        public void startBlock(string prepend) {
            writeline(prepend + " {");
            numTabs++;
        }
        public void endBlock() {
            numTabs--;
            writeline("}");
        }

        public void linebreak(int num = 1) {
            for (; num > 0; num--) write("\n");
        }
    }
}
