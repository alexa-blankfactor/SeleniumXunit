namespace TestBdd.Pages
{
    public interface IHomePage
    {
        void ClickProduct();
        void ClickCreate();
        void PerformClickOnSpecialValue(string name, string operation);
    }
}