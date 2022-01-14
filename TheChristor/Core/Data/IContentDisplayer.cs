namespace TheChristor.Core.Content {
    internal interface IContentDisplayer<T> {
        void DisplayContent(T displayingContent);
    }
}