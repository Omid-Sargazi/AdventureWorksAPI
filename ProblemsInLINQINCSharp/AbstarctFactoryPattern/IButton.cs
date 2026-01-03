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

    public interface IUIThemeFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
        ICheckBox CreateCheckBox();
    }


    public class LightThemeFactory : IUIThemeFactory
    {
        public IButton CreateButton() => new LightButton();
        public ITextBox CreateTextBox() => new LightTextBox();
        public ICheckBox CreateCheckBox() => new LightCheckBox();
    }

    public class DarkThemeFactory : IUIThemeFactory
    {
        public IButton CreateButton() => new DarkButton();
        public ITextBox CreateTextBox() => new DarkTextBox();
        public ICheckBox CreateCheckBox() => new DarkCheckBox();
    }

    // Client Code
    class Application
    {
        private IUIThemeFactory _themeFactory;

        public Application(IUIThemeFactory themeFactory)
        {
            _themeFactory = themeFactory;
        }

        public void RenderUI()
        {
            Console.WriteLine("\n=== Rendering UI Components ===");
            
            var button = _themeFactory.CreateButton();
            var textBox = _themeFactory.CreateTextBox();
            var checkBox = _themeFactory.CreateCheckBox();

            button.Render();
            textBox.Render();
            textBox.SetText("Hello World!");
            checkBox.Render();
            checkBox.Check();
        }
    }

}