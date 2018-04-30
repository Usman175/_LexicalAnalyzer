using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LexicalAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private static String[] separators = { ";", "{", "}", ">", "<", "+", "-", "|", "&", "`" };
        private static String[] operators = { "()", "[]", "&&", "||", "++", "--", "==", "=<", "=>", "!=", "*", "/", "%", "(", ")", "[", "]", ",", "=" };
        private static String[] keywords = { "abstract", "as", "base", "bool", "break", "by","byte", "case", "catch",
            "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double",
            "descending", "explicit", "event", "extern", "else", "enum","false", "finally", "fixed", "float", "for",
            "foreach", "from","goto", "group", "if", "implicit", "int", "interface","internal", "into", "is",
            "lock", "long", "new", "null", "namespace","object", "operator", "out", "override", "orderby",  "params",
            "private", "protected", "public", "readonly", "ref", "return","switch", "struct", "sbyte", "sealed", "short",
            "sizeof","stackalloc", "static", "string", "select",  "this","throw", "true", "try", "typeof", "uint","ulong",
            "unchecked","unsafe", "ushort", "using", "var", "virtual", "volatile","void", "while", "where", "yield" };
        private static String[] comments = { "//", "/*", "*/" };
        private static String[] constants = { "\"", "\'" };
        private static String[] words;
        private static String data = "";

        private static bool CheckSeparator(String str) => separators.Contains(str);
        private static bool CheckOperators(String str) => operators.Contains(str);
        private static bool CheckKeywords(String str) => keywords.Contains(str);
        private static bool CheckComments(String str) => comments.Contains(str);
        private static bool CheckConstants(String str) => constants.Contains(str);

        public void Program()
        {
            outputBox.Text = "";
            data = textBox.Text + "\n$~";

            for (int j = 0; j < operators.Length; j++)
                data = data.Replace(operators[j], " " + operators[j] + " ");

            for (int i = 0; i < separators.Length; i++)
                data = data.Replace(separators[i], " " + separators[i] + " ");

            var newData = new StringBuilder(data);
            for (int i = 0; i < newData.Length; i++)
            {
                if (newData[i] == '\n')
                    newData[i] = '$';
            }
            char c = '/';
            int firstSign = 0;
            int secondSign = 0;
            try
            {
                for (int i = 0; i < newData.Length; i++)
                {
                    if (newData[i] == c)
                    {
                        if (newData[i] == '$') { c = '/'; secondSign = i; }
                        else { c = '$'; firstSign = i; }
                        do
                        {
                            i++;
                        } while (newData[i] == '$');
                        while (firstSign <= secondSign)
                        {
                            newData[firstSign] = ' ';
                            firstSign++;
                        }
                    }
                }
            }
            catch (Exception) { }

            data = newData.ToString();
            data = data.Replace("\n", String.Empty);
            data = data.Replace("\r", String.Empty);
            data = data.Replace("\t", String.Empty);
            data = data.Replace("$", "");
            data = data.Replace("~", "");
            words = data.Split(' ');

            for (int i = 0; i < words.Length; i++)
                CheckLexicalAnalyzer(words[i]);
        }
        private String Parse(String item)
        {
            StringBuilder str = new StringBuilder();

            if (CheckSeparator(item) == true)
                str.Append(" (separator, <" + item + ">) ");
            else if (CheckOperators(item) == true)
                str.Append(" (operators, <" + item + ">) ");
            else if (CheckKeywords(item) == true)
                str.Append(" (keywords, <" + item + ">) ");
            else if (item.Equals("\r") || item.Equals("\n") || item.Equals("\r\n"))
                str.Append(" (NewLine, <" + item + ">) ");
            else
                str.Append(" (identifier, <" + item + ">) ");
            return str.ToString();
        }
        private void CheckLexicalAnalyzer(String str)
        {
            StringBuilder token = new StringBuilder();
            bool isCheck = false;
            for (int i = 0; i < str.Length; i++)
            {
                try
                {
                    int intValue;
                    if (Int32.TryParse(str, out intValue) && !isCheck)
                    {
                        isCheck = true;
                        outputBox.Text += (" (integerValue, <" + str + ">) ") + "\n";
                    }
                    else if (str.Equals("\r") || str.Equals("\n") || str.Equals("\r\n")) { }

                    else if (CheckSeparator(str[i].ToString()))
                        outputBox.Text += (Parse(str[i].ToString())) + "\n";

                    else if (CheckOperators(str[i].ToString()))
                        outputBox.Text += (Parse(str[i].ToString())) + "\n";

                    else if (str.Contains("\""))
                    {
                        if (str[i + 1].ToString() != "\"") { }
                        do { i++; } while (str == "\"");
                        if (i == 1)
                            outputBox.Text += (" (String, <" + str + ">) ") + "\n";
                    }

                    else if (str.Contains("\'"))
                    {
                        if (str[i + 1].ToString() != "\'") { }
                        do { i++; } while (str == "\'");
                        if (i == 1)
                            outputBox.Text += (" (Char, <" + str + ">) ") + "\n";
                    }

                    else
                    {
                        token.Append(str);
                        try
                        {
                            if (keywords.Contains(token.ToString()))
                                outputBox.Text += (Parse(token.ToString())) + "\n";

                            else
                            {
                                int intValu;

                                if (!separators.Contains(str[i].ToString()))
                                    if (!operators.Contains(str[i].ToString()))
                                        if (!keywords.Contains(str.ToString()))
                                            if (!str.Contains("\"") || !str.Contains("\'"))
                                                if (!Int32.TryParse(str[i].ToString(), out intValu) && !isCheck)
                                                    if (!str.Equals("\r") || !str.Equals("\n") || !str.Equals('\r') || !str.Equals('\n') || !str.Equals("\r\n"))
                                                    {
                                                        
                                                            isCheck = true;
                                                            outputBox.Text += (" (identifier, <" + str + ">) ") + "\n";
                                                        
                                                    }
                            }
                        }
                        catch (Exception) { }
                        token.Remove(i, i);
                    }
                }
                catch (Exception) { }
            }
        }
        private void BrowseFile()
        {
            textBox.Text = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    data = System.IO.File.ReadAllText(file) + "\n$";
                    path.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;

                    textBox.Text = System.IO.File.ReadAllText(file);
                }
                catch (System.IO.IOException) { }
            }
        }
        private void analyzed_Click(object sender, EventArgs e) => Program();
        private void find_Click(object sender, EventArgs e) => BrowseFile();
    }
}