namespace Generics
{
    public class CustomTuple<T1, T2>
    {
        public T1 FirstItem { get; set; }
        public T2 SecondItem { get; set; }
        public CustomTuple(T1 firstItem, T2 secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }
    }
}