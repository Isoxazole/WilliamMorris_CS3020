using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    class ReadFile
    {
        string[] text;
        public ReadFile()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "examples.txt";
            text = System.IO.File.ReadAllLines(filePath);
            
        }

        public string LoadNumbers (int index)
        {
            return text[index];
        }

    }
}
