namespace ProblemsInLINQINCSharp.AbstarctFactoryPattern
{
    public interface IButton
    {
        void Render();
        void Click();
        string GetStyle();
    }

    public interface ITextBox
    {
        void Render();
        void SetText(string text);
        string GetPlaceholder();
    }

    public interface ICheckBox
    {
        void Render();
        void Check();
        bool IsChecked { get; }
    }

    // Concrete Products - Light Theme
    public class LightButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Theme Button");
            Console.WriteLine("  Background: White");
            Console.WriteLine("  Text Color: Black");
            Console.WriteLine("  Border: Light Gray");
        }

        public void Click()
        {
            Console.WriteLine("Light button clicked!");
        }

        public string GetStyle()
        {
            return "Light Theme Button Style";
        }
    }

    public class LightTextBox : ITextBox
    {
        private string _text = "";

        public void Render()
        {
            Console.WriteLine("Rendering Light Theme TextBox");
            Console.WriteLine("  Background: White");
            Console.WriteLine("  Text Color: Dark Gray");
            Console.WriteLine("  Border: Light Blue");
        }

        public void SetText(string text)
        {
            _text = text;
            Console.WriteLine($"Light textbox text set to: {text}");
        }

        public string GetPlaceholder()
        {
            return "Enter text here...";
        }
    }

    public class LightCheckBox : ICheckBox
    {
        public bool IsChecked { get; private set; }

        public void Render()
        {
            Console.WriteLine("Rendering Light Theme CheckBox");
            Console.WriteLine("  Background: White");
            Console.WriteLine("  Check Color: Blue");
        }

        public void Check()
        {
            IsChecked = !IsChecked;
            Console.WriteLine($"Light checkbox {(IsChecked ? "checked" : "unchecked")}");
        }
    }

}