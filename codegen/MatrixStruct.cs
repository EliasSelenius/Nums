﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NumsCodeGenerator {
    class MatrixStruct : FileGenerator {

        int rows, cols;
        string vectorRow;
        string vectorCol;
        string matrixType;
        string structname;
        string type;
        string[] rowNames;
        string[] colNames;
        bool isSquare => rows == cols;
        bool is4x4 => isSquare && rows == 4;

        public MatrixStruct(string name, string type, int rows, int cols) : base("matrices/") {
            this.rows = rows; this.cols = cols;
            this.type = type;
            this.matrixType = name;

            this.vectorRow = Program.getVectorType(type) + cols;
            this.vectorCol = Program.getVectorType(type) + rows;

            structname = name + rows;
            if (!isSquare) structname += "x" + cols;
            fileName += structname;


            rowNames = new string[rows];
            for (int i = 0; i < rowNames.Length; i++) rowNames[i] = "row" + (i + 1);
            colNames = new string[cols];
            for (int i = 0; i < colNames.Length; i++) colNames[i] = "col" + (i + 1);

        }

        protected override void generate() {

            writeline("using System;");
            writeline("using System.Runtime.InteropServices;");
            linebreak();

            startBlock("namespace Nums");
            linebreak();

            summary("A " + rows + " by " + cols + " matrix");
            writeline("[StructLayout(LayoutKind.Sequential)]");
            startBlock("public struct " + structname);

            genConsts();
            genRowsAndCols();
            genProperties();
            genConstructors();
            genOperators();

            endBlock(); // end struct block
            endBlock(); // end namespace block
        }

        private void genConsts() {
            if (isSquare) {
                summary("The identity matrix");
                var args = "";
                for (int r = 0; r < rows; r++) {
                    for (int c = 0; c < cols; c++) {
                        args += (r == c ? "1" : "0") + ", ";
                    }
                }
                args = args.TrimEnd(',', ' ');
                writeline($"public static readonly {structname} identity = new {structname}({args});");
            }
        }

        private void genRowsAndCols() {

            // rows
            region("rows and columns");
            for (int i = 1; i <= rows; i++) {
                summary("The " + Program.Index2String(i - 1) + " row in the matrix.");
                writeline("public " + vectorRow + " row" + i + ";");
            }
            linebreak();

            // cols
            for (int i = 1; i <= cols; i++) {
                var comp = Program.vectorComps[i - 1];
                var args = rowNames.Select(x => x + "." + comp);
                summary("The " + Program.Index2String(i - 1) + " column in the matrix.");
                startBlock("public " + vectorCol + " col" + i);
                
                writeline("readonly get => new " + vectorCol + "(" + args.Aggregate((x, y) => x + ", " + y) + ");");
                
                startBlock("set");
                for (int j = 0; j < args.Count(); j++)
                    writeline(args.ElementAt(j) + " = value." + Program.vectorComps[j] + ";");
                endBlock();

                endBlock();
            }
            endregion();
            linebreak();


            // indexprops
            region("indexed properties");
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    summary("Gets the value at the " + Program.Index2String(i) + " row in the " + Program.Index2String(j) + " column");
                    startBlock("public " + type + " m" + (i + 1) + (j + 1));
                    var id = "row" + (i + 1) + "." + Program.vectorComps[j];
                    writeline("readonly get => " + id + ";");
                    writeline("set => " + id + " = value;");
                    endBlock();
                }
            }
            endregion();
            linebreak();
        }

        private void genProperties() {


            // transpose
            summary("Gets the transpose of this matrix");
            var transposeStruct = matrixType + cols;
            if (!isSquare) transposeStruct += "x" + rows;

            writeline("public readonly " + transposeStruct + " transpose => new " + transposeStruct + "(" + colNames.Aggregate((x, y) => x + ", " + y) + ");");

            // bytetype
            summary("The number of bytes the matrix type uses.");
            writeline($"public const int bytesize = sizeof({type}) * {rows * cols};");

            if (isSquare) {
                // diagonal
                summary("Gets or sets the diagonal of the matrix.");
                startBlock($"public {vectorRow} diagonal");
                var diagonalRows = rowNames.Select((x, i) => x + "." + Program.vectorComps[i]);
                var args = "(" + diagonalRows.Aggregate((x, y) => x + ", " + y) + ")";
                writeline($"readonly get => new {vectorRow}{args};");
                writeline($"set => {args} = ({Program.vectorComps[..rows].Select(x => "value." + x).Aggregate((x, y) => x + ", " + y)});");
                endBlock();

                // trace
                summary("Gets the sum of the diagonal.");
                writeline($"public readonly {type} trace => {diagonalRows.Aggregate((x, y) => x + " + " + y)};");
            }

            // transform matrix
            if (is4x4) {
                var v3 = Program.getVectorType(type) + "3";

                summary("Gets the scale of this transformation matrix.");
                writeline($"public {v3} getScale() => new {v3}(row1.xyz.length, row2.xyz.length, row3.xyz.length);");

                summary("Gets the translation of this transformation matrix.");
                writeline($"public {v3} getTranslation() => row4.xyz;");

                summary("Gets the rotation of this transformation matrix.");
                writeline($"// TODO: implement... ");


                summary("Clears the scale of this transformation matrix.");
                startBlock("public void clearScale()");
                for (int i = 1; i <= 3; i++) writeline($"row{i}.xyz /= row{i}.xyz.length;");
                endBlock();

                summary("Clears the translation of this transformation matrix.");
                writeline($"public void clearTranslation() => row4.xyz = {v3}.zero;");

                summary("Clears the rotation of this transformation matrix.");
                startBlock("public void clearRotation()");
                writeline($"row1.xyz = new {v3}(row1.xyz.length, 0, 0);");
                writeline($"row2.xyz = new {v3}(0, row1.xyz.length, 0);");
                writeline($"row3.xyz = new {v3}(0, 0, row1.xyz.length);");
                endBlock();

            }


            // indexing 
            summary("Gets or sets the element at row r and column c.");
            startBlock($"public {type} this[int r, int c]");
            var indexexception = "throw new IndexOutOfRangeException(r + \" is not a valid row index for " + structname + "\")";
            startBlock("readonly get => r switch");
            for (int i = 0; i < rows; i++) writeline($"{i} => row{i + 1}[c],");
            writeline("_ => " + indexexception);
            endBlock(";"); // end get block
            startBlock("set");
            startBlock("switch(r)");
            for (int i = 0; i < rows; i++) writeline($"case {i}: row{i + 1}[c] = value; return;");
            writeline("default: " + indexexception + ";");
            endBlock();
            endBlock(); // end set block
            endBlock(); // end indexing


            linebreak();
        }

        private void genConstructors() {
            // rows constructor
            startBlock("public " + structname + "(" + rowNames.Select(x => vectorRow + " " + x).Aggregate((x, y) => x + ", " + y) + ")");
            for (int i = 0; i < rowNames.Length; i++) {
                writeline("this." + rowNames[i] + " = " + rowNames[i] + ";");
            }
            endBlock();

            // sepperate values constructor
            var props = new string[rows * cols];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    props[i * cols + j] = "m" + (i + 1) + (j + 1);
                }
            }
            var cargs = props.Select(x => type + " " + x).Aggregate((x, y) => x + ", " + y);
            startBlock("public " + structname + "(" + cargs + ")");

            var comps = Program.vectorComps[..cols];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    writeline(rowNames[i] + "." + Program.vectorComps[j] + " = " + props[i * cols + j] + ";");
                }
            }

            endBlock();

            // cast constructors e.g: mat4(mat3)
            if (isSquare) {
                for (int i = 2; i <= 4; i++) {
                    if (i == rows) continue;
                    var otherMat = matrixType + i;
                    summary($"creates a {structname} from the given {otherMat}");
                    startBlock($"public {structname}({otherMat} m)");
                    for (int r = 0; r < rows; r++) {
                        for (int c = 0; c < cols; c++) {
                            var curField = rowNames[r] + "." + Program.vectorComps[c];
                            var line = curField + " = ";
                            if (i < rows) {
                                if (c < i && r < i) line += "m." + curField;
                                else line += r == c ? "1" : "0";
                            } else {
                                line += "m." + curField;
                            }
                            writeline(line + ";");
                        }
                    }
                    endBlock();
                }
            }

        }

        public void genOperators() {
            region("operators");

            // matrix vector multiplication
            {
                var args = rowNames.Select(x => "m." + x + ".dot(v)").Aggregate((x, y) => x + ", " + y);
                summary($"Multiplies a {structname} with a {vectorRow}.");
                writeline("public static " + vectorCol + " operator *(" + structname + " m, " + vectorRow + " v) => new " + vectorCol + "(" + args + ");");

                args = colNames.Select(x => "m." + x + ".dot(v)").Aggregate((x, y) => x + ", " + y);
                summary($"Multiplies a {vectorCol} with a {structname}.");
                writeline($"public static {vectorRow} operator *({vectorCol} v, {structname} m ) => new {vectorRow}({args});");
            }


            // matrix matrix multiplication
            for (int i = 2; i <= 4; i++) {
                var otherstruct = matrixType + cols;
                if (cols != i) otherstruct += "x" + i;

                var resultstruct = matrixType + rows;
                if (rows != i) resultstruct += "x" + i;

                var args = new string[rows * i];
                for (int r = 1; r <= rows; r++)
                    for (int c = 1; c <= i; c++) 
                        args[(r - 1) * i + c -1] = "m1.row" + r + ".dot(m2.col" + c + ")";
                summary($"Multiplies a {structname} with a {otherstruct}.");
                writeline("public static " + resultstruct + " operator *(" + structname + " m1, " + otherstruct + " m2) => new " + resultstruct + "(" + args.Aggregate((x, y) => x + ", " + y)+");");
            }

            // matrix scalar multiplication
            summary("Multiplies all elements of a matrix with a scalar.");
            writeline($"public static {structname} operator *({structname} m, {type} s) => new {structname}({rowNames.Select(x => "m." + x + " * s").Aggregate((x, y) => x + ", " + y)});");


            endregion();
        }
    }
}
