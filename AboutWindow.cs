using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace StreamHelper
{
    public class AboutWindow : Window
    {
        public AboutWindow(string title, string buildinfo, string content, string created = "Dewrodyn Rafał Kurc", string link = "http://rafalkurc.pl")
        {
            this.Width = 300;
            this.Height = 300;
            this.Title = title;
            Grid grid = new Grid();
            TextBlock textBlock = new TextBlock() { TextWrapping = TextWrapping.WrapWithOverflow, VerticalAlignment = VerticalAlignment.Center, TextAlignment = TextAlignment.Center };
            grid.Children.Add(textBlock);
            this.AddChild(grid);
            if (!string.IsNullOrWhiteSpace(title))
            {
                textBlock.Inlines.Add(new Bold(new Run(title)) { FontSize = 18, });
                textBlock.Inlines.Add(new LineBreak());
            }
            if (!string.IsNullOrWhiteSpace(buildinfo))
            {
                textBlock.Inlines.Add(new Run("Build " + buildinfo));
                textBlock.Inlines.Add(new LineBreak());
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                textBlock.Inlines.Add(new Run(content));
                textBlock.Inlines.Add(new LineBreak());
                textBlock.Inlines.Add(new LineBreak());
            }
            if (!string.IsNullOrWhiteSpace(created))
            {
                textBlock.Inlines.Add(new Italic(new Run("Created by: " + created)));
                textBlock.Inlines.Add(new LineBreak());
            }
            if (!string.IsNullOrWhiteSpace(link))
            {
                textBlock.Inlines.Add(new Hyperlink(new Run(link)));
                textBlock.Inlines.Add(new LineBreak());
            }
            this.Show();
        }
    }
}
