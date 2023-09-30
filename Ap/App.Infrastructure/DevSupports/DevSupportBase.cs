namespace App.Infrastructure.Supports
{
    public abstract class DevSupportBase
    {
        public virtual string Name => this.GetType().Name;
    }
}
