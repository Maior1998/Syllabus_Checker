﻿using Xceed.Document.NET;
using Xceed.Words.NET;
using MessageBox = System.Windows.MessageBox;

namespace SyllabusChecker
{
    public class Checker
    {
        private DocX Model { get; set; }
        private DocX Syllable { get; set; }

        public Checker(InputData inputData)
        {
            Model = DocX.Load(inputData.ModelPath);
            Syllable = DocX.Load(inputData.SyllablePath);
            CheckTitlePage();
        }

        //Проверка титульника
        public void CheckTitlePage()
        {
            Section title_model = Model.Sections[0];
            Section title_syllable = Syllable.Sections[0];

            for (int i = 0; i < title_model.SectionParagraphs.Count; i++)
            {
                Paragraph par_model = title_model.SectionParagraphs[i];
                Paragraph par_syllable = title_syllable.SectionParagraphs[i];

                ///Здесь нужна помощь
                ///нужно определить, какие свойства у параграфов нужно сравнивать, и как это делать
                ///потому что шрифты например -- это не просто поля почему-то
                
                if ((par_model.Text != par_syllable.Text) ||
                    (par_model.Alignment != par_syllable.Alignment) ||
                    (par_model.IndentationAfter != par_syllable.IndentationAfter) ||
                    (par_model.IndentationBefore != par_syllable.IndentationBefore) ||
                    (par_model.IndentationFirstLine != par_syllable.IndentationFirstLine) ||
                    (par_model.IndentationHanging != par_syllable.IndentationHanging) ||
                    (par_model.IsKeepWithNext != par_syllable.IsKeepWithNext) ||
                    (par_model.LineSpacing != par_syllable.LineSpacing) ||
                    (par_model.LineSpacingAfter != par_syllable.LineSpacingAfter) ||
                    (par_model.LineSpacingBefore != par_syllable.LineSpacingBefore) ||
                    (par_model.StyleName != par_syllable.StyleName))
                {
                    MessageBox.Show("Несоответствие в параграфе №" + i.ToString() + 
                        "\nТекст в макете: " + par_model.Text + 
                        "\nТекст в проверяемой программе: " + par_syllable.Text);
                }
            }
        }
    }
}
