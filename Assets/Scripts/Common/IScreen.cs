namespace Common
{
    public interface IScreen
    {
        public bool IsActive { get; }
        public void Show();
        public void Hide();
    }
}