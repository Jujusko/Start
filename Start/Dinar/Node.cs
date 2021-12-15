namespace Start.Dinar
{
    public abstract class Node<T>
    {
        public abstract T Content { get; set; }

        public abstract Node<T> Next { get; set; }
    }
}
